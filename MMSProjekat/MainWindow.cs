using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMSProjekat
{
    public partial class MMSProjekat : Form
    {



        public MMSProjekat()
        {
            InitializeComponent();
        }

        private Image img;
        private Bitmap imgBitmap;
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
            BlackLightWindow blckWindow = new BlackLightWindow()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            blckWindow.ShowDialog(this);
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
            MeanRemovalWindow meanWindow = new MeanRemovalWindow()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };
            meanWindow.ShowDialog(this);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Image Files (*.png *.jpg *.bmp *.jpeg) |*.png; *.jpg; *.bmp; *.jpeg";
                dialog.Title = "Ucitaj fajl za prikaz!";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    img = Image.FromFile(dialog.FileName);
                    imgBitmap = (Bitmap)img;

                    float scaleX = (float)pctrBox.Width / img.Width;
                    float scaleY = (float)pctrBox.Height / img.Height;
                    baseScale = Math.Min(scaleX, scaleY);
                }
                zoomScale = 1f; // reset zoom
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
            if (img == null) return;

            float scale = baseScale * zoomScale;
            int newW = (int)(img.Width * scale);
            int newH = (int)(img.Height * scale);

            int x = (pctrBox.Width - newW) / 2;
            int y = (pctrBox.Height - newH) / 2;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(img, new Rectangle(x, y, newW, newH));
        }

        private void UpdateBaseScale()
        {
            if (img == null) return;
            float scaleX = (float)pctrBox.Width / img.Width;
            float scaleY = (float)pctrBox.Height / img.Height;
            baseScale = Math.Min(scaleX, scaleY);
        }

        // Handle PictureBox resize
        private void pctrBox_Resize(object sender, EventArgs e)
        {
            UpdateBaseScale();
            pctrBox.Invalidate();
        }
    }
}
