using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
