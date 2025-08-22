using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace MMSProjekat
{
    public partial class MMSProjekat : Form
    {

        public MMSProjekat()
        {
            InitializeComponent();
        }

        private Bitmap imgBitmap;
        private Bitmap imgBitmapOriginal;
        private float zoomScale = 1f;
        private float baseScale;

        private void btnGaussianBlur_Click(object sender, EventArgs e)
        {
            GaussianBlurWindow gaussianBlurWindow = new GaussianBlurWindow()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            gaussianBlurWindow.ShowDialog(this);

        }

        private void btnBlackLight_Click(object sender, EventArgs e)
        {

            if (imgBitmap == null)
            {
                return;
            }

            BlackLightWindow blckWindow = new BlackLightWindow()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            blckWindow.ShowDialog(this);

            if (blckWindow.DialogResult == DialogResult.OK)
            {
                int blckVal = blckWindow.value;

                for (int i = 0; i < imgBitmap.Height; i++)
                {
                    for (int j = 0; j < imgBitmap.Width; j++)
                    {
                        int r = imgBitmap.GetPixel(j, i).R;
                        int g = imgBitmap.GetPixel(j, i).G;
                        int b = imgBitmap.GetPixel(j, i).B;

                        int L = (222 * r + 707 * g + 71 * b) / 1000;
                        //int L = (r + b + g) / 3;

                        r = Math.Abs(r - L) * blckVal; // 2 je broj koji se uzima iz windowa od 1 -> 7
                        g = Math.Abs(g - L) * blckVal; // 2 je broj koji se uzima iz windowa od 1 -> 7
                        b = Math.Abs(b - L) * blckVal; // 2 je broj koji se uzima iz windowa od 1 -> 7

                        if (r > 255) { r = 255; }
                        if (g > 255) { g = 255; }
                        if (b > 255) { b = 255; }

                        Color boja = new Color();
                        boja = Color.FromArgb(255, r, g, b);

                        imgBitmap.SetPixel(j, i, boja);
                    }
                }

                pctrBox.Invalidate();
            }
        }

        private void btnHistogramEqual_Click(object sender, EventArgs e)
        {
            HistogramEqualizationWindow hstWindow = new HistogramEqualizationWindow()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            hstWindow.ShowDialog(this);
        }

        private void btnMeanRemoval_Click(object sender, EventArgs e)
        {
            if (imgBitmap == null)
            {
                return;
            }

            MeanRemovalWindow meanWindow = new MeanRemovalWindow()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            meanWindow.ShowDialog(this);

            if (meanWindow.DialogResult == DialogResult.OK)
            {
                int kernelSize = meanWindow.value;

                if (kernelSize % 2 == 0)
                {
                    kernelSize--;
                }

                int minmax = kernelSize / 2;

                Bitmap srcBitmap = (Bitmap)imgBitmap.Clone();
                Rectangle rect = new Rectangle(0, 0, imgBitmap.Width, imgBitmap.Height);
                BitmapData srcData = srcBitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = imgBitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                int width = imgBitmap.Width;
                int height = imgBitmap.Height;
                int strideSrc = srcData.Stride;
                int strideDst = dstData.Stride;

                unsafe
                {
                    byte* srcPtr = (byte*)srcData.Scan0.ToPointer();
                    byte* dstPtr = (byte*)dstData.Scan0.ToPointer();

                    for (int i = 0; i < height; i++)
                    {
                        for (int j = 0; j < width; j++)
                        {
                            int nmbrEl = 0;
                            int rSum = 0;
                            int gSum = 0;
                            int bSum = 0;

                            for (int x = -minmax; x <= minmax; x++)
                            {
                                for (int y = -minmax; y <= minmax; y++)
                                {
                                    if (i + x < 0 || i + x >= height)
                                        continue;

                                    if (j + y < 0 || j + y >= width)
                                        continue;

                                    byte* pPixel = srcPtr + (i + x) * strideSrc + (j + y) * 3;
                                    bSum += pPixel[0]; // blue
                                    gSum += pPixel[1]; // green
                                    rSum += pPixel[2]; // red

                                    nmbrEl++;
                                }
                            }

                            byte* pDst = dstPtr + i * strideDst + j * 3;
                            pDst[0] = (byte)Math.Min(255, bSum / nmbrEl); // blue
                            pDst[1] = (byte)Math.Min(255, gSum / nmbrEl); // green
                            pDst[2] = (byte)Math.Min(255, rSum / nmbrEl); // red

                        }
                    }

                }
                srcBitmap.UnlockBits(srcData);
                imgBitmap.UnlockBits(dstData);

                pctrBox.Invalidate();
            }

        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files (*.png *.jpg *.bmp *.ilij) |*.png; *.jpg; *.bmp; *.ilij";
                dialog.Title = "Ucitaj fajl za prikaz!";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(dialog.FileName) != ".ilij")
                    {
                        Image img = Image.FromFile(dialog.FileName);
                        imgBitmap = (Bitmap)img;
                        imgBitmapOriginal = (Bitmap)imgBitmap.Clone();

                    }
                    else
                    {
                        using (var fs = File.Open(dialog.FileName, FileMode.Open))
                        {
                            using (var deflate = new DeflateStream(fs, CompressionMode.Decompress))
                            {
                                using (var br = new BinaryReader(deflate))
                                {
                                    // SOI
                                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0x33)
                                        throw new Exception("Not MYJPEG file");

                                    // Header
                                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0xE0)
                                        throw new Exception("Missing header");

                                    // ushort headerLen = ReadUInt16(br);
                                    string ident = Encoding.ASCII.GetString(br.ReadBytes(5));
                                    int width = br.ReadUInt16();
                                    int height = br.ReadUInt16();
                                    // byte comps = br.ReadByte();
                                    byte downFactor = br.ReadByte();

                                    // Start of Frame
                                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0xC0)
                                        throw new Exception("Missing SOF");

                                    // Učitavanje podataka
                                    byte[,] Y = new byte[width, height];
                                    for (int x = 0; x < width; x++)
                                        for (int y = 0; y < height; y++)
                                            Y[x, y] = br.ReadByte();

                                    int cbW = width / downFactor;
                                    int cbH = height / downFactor;
                                    byte[,] CbSmall = new byte[cbW, cbH];
                                    byte[,] CrSmall = new byte[cbW, cbH];

                                    for (int x = 0; x < cbW; x++)
                                        for (int y = 0; y < cbH; y++)
                                            CbSmall[x, y] = br.ReadByte();

                                    for (int x = 0; x < cbW; x++)
                                        for (int y = 0; y < cbH; y++)
                                            CrSmall[x, y] = br.ReadByte();

                                    // EOI
                                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0xEF)
                                        throw new Exception("Missing EOI");

                                    // Rekonstrukcija u RGB
                                    Bitmap bmp = new Bitmap(width, height);
                                    for (int x = 0; x < width; x++)
                                    {
                                        for (int y = 0; y < height; y++)
                                        {
                                            byte Yv = Y[x, y];
                                            byte Cbv = CbSmall[x / downFactor, y / downFactor];
                                            byte Crv = CrSmall[x / downFactor, y / downFactor];

                                            int r = (int)(Yv + 1.402 * (Crv - 128));
                                            int g = (int)(Yv - 0.344136 * (Cbv - 128) - 0.714136 * (Crv - 128));
                                            int b = (int)(Yv + 1.772 * (Cbv - 128));

                                            bmp.SetPixel(x, y, Color.FromArgb(ClampByte(r), ClampByte(g), ClampByte(b)));
                                        }
                                    }

                                    imgBitmap = bmp;
                                    imgBitmapOriginal = (Bitmap)imgBitmap.Clone();

                                }
                            }
                        }
                    }
                    float scaleX = (float)pctrBox.Width / imgBitmap.Width;
                    float scaleY = (float)pctrBox.Height / imgBitmap.Height;
                    baseScale = Math.Min(scaleX, scaleY);

                }
                zoomScale = 1f; // zoom reset
                trckBarZoom.Value = 10;
                pctrBox.Invalidate();
            }
        }

        private void trckBarZoom_Scroll(object sender, EventArgs e)
        {
            zoomScale = trckBarZoom.Value / 10f;
            pctrBox.Invalidate();
        }

        private void pctrBox_Paint(object sender, PaintEventArgs e)
        {
            if (imgBitmap == null) return;

            float scale = baseScale * zoomScale;
            int newW = (int)(imgBitmap.Width * scale);
            int newH = (int)(imgBitmap.Height * scale);

            int x = (pctrBox.Width - newW) / 2;
            int y = (pctrBox.Height - newH) / 2;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(imgBitmap, new Rectangle(x, y, newW, newH));

        }

        /* Menja baseScale u zavisnosti od velicine prozora */
        private void UpdateBaseScale()
        {
            if (imgBitmap == null) return;
            float scaleX = (float)pctrBox.Width / imgBitmap.Width;
            float scaleY = (float)pctrBox.Height / imgBitmap.Height;
            baseScale = Math.Min(scaleX, scaleY);
        }

        /* Svaki put kada se window resizuje radi se update slike */
        private void pctrBox_Resize(object sender, EventArgs e)
        {
            UpdateBaseScale();
            pctrBox.Invalidate();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int downFactor = 2;

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Odaberite lokaciju!";
                dialog.Filter = "JPG Image | *.jpg| Png Image | *.png| Ilija Image | *.ilij";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    switch (dialog.FilterIndex)
                    {

                        case 1: // .jpeg
                            break;

                        case 2: // .png
                            break;

                        case 3: // .ilij

                            int w = imgBitmap.Width;
                            int h = imgBitmap.Height;

                            byte[,] Y = new byte[w, h];
                            byte[,] Cr = new byte[w, h];
                            byte[,] Cb = new byte[w, h];

                            // RGB konverzija u YCbCr
                            for (int x = 0; x < w; x++)
                            {
                                for (int y = 0; y < h; y++)
                                {
                                    Color clr = imgBitmap.GetPixel(x, y);
                                    double r = clr.R;
                                    double g = clr.G;
                                    double b = clr.B;

                                    double yy = 0.299 * r + 0.587 * g + 0.114 * b;
                                    double cb = 128 - 0.168736 * r - 0.331264 * g + 0.5 * b;
                                    double cr = 128 + 0.5 * r - 0.418688 * g - 0.081312 * b;

                                    Y[x, y] = ClampByte(yy);
                                    Cb[x, y] = ClampByte(cb);
                                    Cr[x, y] = ClampByte(cr);
                                }
                            }

                            // Downsampling
                            int cbW = w / downFactor;
                            int cbH = h / downFactor;

                            byte[,] CbSmall = new byte[cbW, cbH];
                            byte[,] CrSmall = new byte[cbW, cbH];

                            for (int x = 0; x < cbW; x++)
                            {
                                for (int y = 0; y < cbH; y++)
                                {
                                    CbSmall[x, y] = Cb[x * downFactor, y * downFactor];
                                    CrSmall[x, y] = Cr[x * downFactor, y * downFactor];
                                }
                            }

                            using (var fs = File.Open(dialog.FileName, FileMode.Create))
                            {
                                using (var deflate = new DeflateStream(fs, CompressionMode.Compress))
                                {
                                    using (var bWriter = new BinaryWriter(deflate))
                                    {
                                        // START OF FILE
                                        bWriter.Write((byte)0xFF);
                                        bWriter.Write((byte)0x33);

                                        // HEADER
                                        bWriter.Write((byte)0xFF);                          // 1
                                        bWriter.Write((byte)0xE0);                          // 1
                                        //bWriter.Write((short)15);                         // 2 NIJE BITNO
                                        bWriter.Write(Encoding.ASCII.GetBytes("ILIJ\0"));   // 5

                                        bWriter.Write((ushort)w);                           // 2
                                        bWriter.Write((ushort)h);                           // 2
                                        //bWriter.Write((byte)3); // komponente             // 1 NIJE BITNO
                                        bWriter.Write((byte)downFactor);                    // 1
                                                                                            // 15
                                                                                            // START OF FRAME
                                        bWriter.Write((byte)0xFF);
                                        bWriter.Write((byte)0xC0);

                                        // BITMAPA
                                        for (int x = 0; x < w; x++)
                                            for (int y = 0; y < h; y++)
                                                bWriter.Write(Y[x, y]);

                                        for (int x = 0; x < cbW; x++)
                                            for (int y = 0; y < cbH; y++)
                                                bWriter.Write(CbSmall[x, y]);

                                        for (int x = 0; x < cbW; x++)
                                            for (int y = 0; y < cbH; y++)
                                                bWriter.Write(CrSmall[x, y]);

                                        // END OF FILE
                                        bWriter.Write((byte)0xFF);
                                        bWriter.Write((byte)0xEF);

                                    }
                                }
                            }
                            break;
                    }

                }
            }

        }

        private static byte ClampByte(double v)
        {
            if (v < 0) return 0;
            if (v > 255) return 255;
            return (byte)v;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (imgBitmapOriginal != null)
            {
                imgBitmap = (Bitmap)imgBitmapOriginal.Clone();
                pctrBox.Invalidate();
            }
        }
    }
}
