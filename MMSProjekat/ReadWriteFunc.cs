using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace MMSProjekat
{
    internal static class ReadWriteFunc
    {
        public static Bitmap Read(OpenFileDialog dialog)
        {
            using (var fs = File.Open(dialog.FileName, FileMode.Open))
            {
                using (var br = new BinaryReader(fs))
                {
                    /* FILE START */
                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0x33)
                        throw new Exception("Nepoznat tip fajla!");

                    /* HEADER START */
                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0xE0)
                        throw new Exception("Problem sa headerom!");
                    /* HEADER */
                    string ident = Encoding.ASCII.GetString(br.ReadBytes(5));
                    int width = br.ReadUInt16();
                    int height = br.ReadUInt16();
                    byte downFactor = br.ReadByte();

                    /* BITMAP START */
                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0xC0)
                        throw new Exception("Missing SOF");

                    /* BITMAPA */
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

                    /* FILE END */
                    if (br.ReadByte() != 0xFF || br.ReadByte() != 0xEF)
                        throw new Exception("Missing EOI");

                    Bitmap bmp = new Bitmap(width, height);
                    Rectangle velicina = new Rectangle(0, 0, width, height);
                    BitmapData bmpData = bmp.LockBits(velicina, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                    int stride = bmpData.Stride;

                    unsafe
                    {
                        byte* ptr = (byte*)bmpData.Scan0.ToPointer();

                        for (int x = 0; x < width; x++)
                        {
                            for (int y = 0; y < height; y++)
                            {
                                int cx = Math.Min(x / 2, cbW - 1);
                                int cy = Math.Min(y / 2, cbH - 1);

                                byte CbVal = CbSmall[cx, cy];
                                byte CrVal = CrSmall[cx, cy];
                                byte YVal = Y[x, y];

                                int r = (int)(YVal + 1.402 * (CrVal - 128));
                                int g = (int)(YVal - 0.344136 * (CbVal - 128) - 0.714136 * (CrVal - 128));
                                int b = (int)(YVal + 1.772 * (CbVal - 128));

                                byte* pixelPtr = ptr + y * stride + x * 3;

                                pixelPtr[2] = GetNormalValue(r);
                                pixelPtr[1] = GetNormalValue(g);
                                pixelPtr[0] = GetNormalValue(b);

                            }
                        }
                    }
                    bmp.UnlockBits(bmpData);
                    return bmp;
                }

            }
        }

        public static void Write(Bitmap bitmap, SaveFileDialog dialog)
        {
            int downFactor = 2;

            int w = bitmap.Width;
            int h = bitmap.Height;

            Rectangle velicina = new Rectangle(0, 0, w, h);
            BitmapData bitData = bitmap.LockBits(velicina, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int stride = bitData.Stride;

            byte[,] Y = new byte[w, h];
            byte[,] Cr = new byte[w, h];
            byte[,] Cb = new byte[w, h];

            unsafe
            {

                byte* ogPtr = (byte*)bitData.Scan0.ToPointer();


                for (int x = 0; x < w; x++)
                {
                    for (int y = 0; y < h; y++)
                    {

                        byte* pixelPtr = ogPtr + y * stride + x * 3;

                        int r = pixelPtr[2];
                        int g = pixelPtr[1];
                        int b = pixelPtr[0];

                        double yy = 0.299 * r + 0.587 * g + 0.114 * b;
                        double cb = 128 - 0.168736 * r - 0.331264 * g + 0.5 * b;
                        double cr = 128 + 0.5 * r - 0.418688 * g - 0.081312 * b;

                        Y[x, y] = ReadWriteFunc.GetNormalValue(yy);
                        Cb[x, y] = ReadWriteFunc.GetNormalValue(cb);
                        Cr[x, y] = ReadWriteFunc.GetNormalValue(cr);
                    }
                }
            }
            bitmap.UnlockBits(bitData);

            int cbW = w / 2;
            int cbH = h / 2;

            byte[,] CbSmall = new byte[cbW, cbH];
            byte[,] CrSmall = new byte[cbW, cbH];

            for (int x = 0; x < cbW; x++)
            {
                for (int y = 0; y < cbH; y++)
                {

                    int srcX = x * 2;
                    int srcY = y * 2;

                    double newCb = (Cb[srcX, srcY] + Cb[srcX, srcY + 1]) / 2;
                    double newCr = (Cr[srcX, srcY] + Cr[srcX, srcY + 1]) / 2;

                    CbSmall[x, y] = (byte)newCb;
                    CrSmall[x, y] = (byte)newCr;
                }
            }

            using (var fs = File.Open(dialog.FileName, FileMode.Create))
            {

                using (var bWriter = new BinaryWriter(fs))
                {
                    /* FILE START */
                    bWriter.Write((byte)0xFF);
                    bWriter.Write((byte)0x33);

                    /* HEADER */
                    bWriter.Write((byte)0xFF);                          // 1
                    bWriter.Write((byte)0xE0);                          // 1
                                                                        //bWriter.Write((short)15);                         // 2 NIJE BITNO
                    bWriter.Write(Encoding.ASCII.GetBytes("ILIJ\0"));   // 5

                    bWriter.Write((ushort)w);                           // 2
                    bWriter.Write((ushort)h);                           // 2
                                                                        //bWriter.Write((byte)3); // komponente             // 1 NIJE BITNO
                    bWriter.Write((byte)downFactor);                    // 1
                                                                        // 15
                    /* BITMAP START */                                                    // START OF FRAME
                    bWriter.Write((byte)0xFF);
                    bWriter.Write((byte)0xC0);

                    /* BITMAPA */
                    for (int x = 0; x < w; x++)
                        for (int y = 0; y < h; y++)
                            bWriter.Write(Y[x, y]);

                    for (int x = 0; x < cbW; x++)
                        for (int y = 0; y < cbH; y++)
                            bWriter.Write(CbSmall[x, y]);

                    for (int x = 0; x < cbW; x++)
                        for (int y = 0; y < cbH; y++)
                            bWriter.Write(CrSmall[x, y]);

                    /* FILE END */
                    bWriter.Write((byte)0xFF);
                    bWriter.Write((byte)0xEF);

                }

            }
        }


        public static byte GetNormalValue(double v)
        {
            if (v < 0) return 0;
            if (v > 255) return 255;
            return (byte)v;
        }
    }
}
