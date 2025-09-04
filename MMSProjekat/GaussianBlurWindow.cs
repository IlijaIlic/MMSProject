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
    public partial class GaussianBlurWindow : Form
    {
        public double sigmaValue { get; set; }
        public int kSizeValue { get; set; }

        public GaussianBlurWindow()
        {
            InitializeComponent();
        }


        private void btnGaussApply_Click(object sender, EventArgs e)
        {
            sigmaValue = (double)nmrcSigma.Value;
            kSizeValue = (int)nmrcGauss.Value;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
