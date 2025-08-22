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
    public partial class MeanRemovalWindow : Form
    {

        public int value {  get; set; }
        public MeanRemovalWindow()
        {
            InitializeComponent();
        }

        private void btnMeanApply_Click(object sender, EventArgs e)
        {
            value = (int) nmrcMean.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
