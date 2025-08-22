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
    struct UndoStackItem{
        Bitmap bm;
        string name;
    }

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
        private Queue<UndoStackItem> undoStack;

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
                imgBitmap = Filters.BlackFilter(blckWindow.value, imgBitmap);
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
                Filters.MeanRemove(meanWindow.value, imgBitmap);

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
                        imgBitmap = ReadWriteFunc.Read(dialog);
                        imgBitmapOriginal = (Bitmap)imgBitmap.Clone();
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

                            ReadWriteFunc.Write(imgBitmap, dialog);
                            break;
                    }

                }
            }

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
