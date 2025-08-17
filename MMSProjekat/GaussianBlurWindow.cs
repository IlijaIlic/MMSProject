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
        public GaussianBlurWindow()
        {
            InitializeComponent();
        }

        private void GaussianBlurWindow_Deactivate(object sender, EventArgs e)
        {
            Close();
        }
    }
}
