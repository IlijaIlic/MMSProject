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
    public partial class BlackLightWindow : Form
    {
        public int value { get; set; }

        public BlackLightWindow()
        {
            InitializeComponent();
        }

        private void btnBlackLightApply_Click(object sender, EventArgs e)
        {
            value = (int) nmrcBlacklight.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
