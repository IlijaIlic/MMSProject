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
using System.Reflection;
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
            undoStack = new UndoStack();
        }

        private Bitmap imgBitmap;
        private Bitmap imgBitmapOriginal;
        private float zoomScale = 1f;
        private float baseScale;
        private UndoStack undoStack;

        private void btnGaussianBlur_Click(object sender, EventArgs e)
        {
            GaussianBlurWindow gaussianBlurWindow = new GaussianBlurWindow()
            {
                Owner = this,
                StartPosition = FormStartPosition.CenterParent
            };

            gaussianBlurWindow.ShowDialog(this);

            if (gaussianBlurWindow.DialogResult == DialogResult.OK)
            {
                Bitmap gaussianBitmap = (Bitmap)imgBitmap.Clone();
                imgBitmap = Filters.GaussianBlur(gaussianBitmap, gaussianBlurWindow.kSizeValue, gaussianBlurWindow.sigmaValue);
                pctrBox.Invalidate();

                UndoStackItem uSI = new UndoStackItem((Bitmap)imgBitmap.Clone(), "Gaussian Blur");
                ManageUndoStack(uSI);
            }
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
                Bitmap blackBitmap = (Bitmap)imgBitmap.Clone();
                imgBitmap = Filters.BlackFilter(blckWindow.value, blackBitmap);
                pctrBox.Invalidate();
                UndoStackItem uSI = new UndoStackItem((Bitmap)imgBitmap.Clone(), "Black Light");
                ManageUndoStack(uSI);
            }
        }

        private void btnHistogramEqual_Click(object sender, EventArgs e)
        {
            if (imgBitmap == null)
            {
                return;
            }

            Bitmap histoBitmap = (Bitmap)imgBitmap.Clone();

            imgBitmap = Filters.HistogramEqualization(histoBitmap);
            pctrBox.Invalidate();

            UndoStackItem uSI = new UndoStackItem((Bitmap)imgBitmap.Clone(), "Histogram Equalization");
            ManageUndoStack(uSI);
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
                Bitmap meanBitmap = (Bitmap)imgBitmap.Clone();
                imgBitmap = Filters.MeanRemove(meanWindow.value, meanBitmap);

                pctrBox.Invalidate();
                UndoStackItem uSI = new UndoStackItem((Bitmap)imgBitmap.Clone(), "Histogram Equalization");
                ManageUndoStack(uSI);
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

                        undoStack.Clear();
                        imgBitmapOriginal = (Bitmap)imgBitmap.Clone();
                        UndoStackItem usi = new UndoStackItem((Bitmap)imgBitmapOriginal.Clone(), "Original Image");
                        undoStack.PushToStack(usi);
                    }
                    else
                    {
                        imgBitmap = ReadWriteFunc.Read(dialog);

                        undoStack.Clear();
                        imgBitmapOriginal = (Bitmap)imgBitmap.Clone();
                        UndoStackItem usi = new UndoStackItem((Bitmap)imgBitmapOriginal.Clone(), "Original Image");
                        undoStack.PushToStack(usi);
                    }
                    float scaleX = (float)pctrBox.Width / imgBitmap.Width;
                    float scaleY = (float)pctrBox.Height / imgBitmap.Height;
                    baseScale = Math.Min(scaleX, scaleY);

                    ManageUndoList();


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
                            imgBitmap.Save(dialog.FileName, ImageFormat.Jpeg);
                            break;

                        case 2: // .png
                            imgBitmap.Save(dialog.FileName, ImageFormat.Png);
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
            if (imgBitmap != null)
            {
                if (undoStack.GetIndex() > 0)
                {
                    undoStack.SetIndex(undoStack.GetIndex() - 1);
                    ManageUndoList();

                    imgBitmap = undoStack.GetFromIndexPos().GetBitmap();
                    pctrBox.Invalidate();
                }
            }
        }

        private void ManageUndoList()
        {

            undoListToolStripMenuItem.DropDownItems.Clear(); // clear old items

            for (int i = 0; i < undoStack.GetList().Count; i++)
            {
                int index = i;
                var item = undoStack.GetList()[i];


                ToolStripMenuItem menuItem = new ToolStripMenuItem($"Step {i}: {item.GetFilterName()}");


                menuItem.ForeColor = Color.White;
                menuItem.BackColor = Color.FromArgb(255, 22, 22, 22);

                menuItem.Tag = item;

                menuItem.Click += (sender, e) =>
                {
                    ToolStripMenuItem clickedItem = sender as ToolStripMenuItem;
                    UndoStackItem undoItem = clickedItem.Tag as UndoStackItem;

                    UndoTo(undoItem, index);
                };


                undoListToolStripMenuItem.DropDownItems.Add(menuItem);
            }
        }
        private void ManageUndoStack(UndoStackItem uSI)
        {

            if (undoStack.GetIndex() + 1 != undoStack.GetList().Count)
            {
                undoStack.AddNewFilterToStack(uSI);
            }
            else
            {
                undoStack.PushToStack(uSI);
            }
            ManageUndoList();
        }

        private void UndoTo(UndoStackItem uSI, int i)
        {
            undoStack.SetIndex(i);
            imgBitmap = (Bitmap)uSI.GetBitmap().Clone();

            pctrBox.Invalidate();
        }

    }
}
