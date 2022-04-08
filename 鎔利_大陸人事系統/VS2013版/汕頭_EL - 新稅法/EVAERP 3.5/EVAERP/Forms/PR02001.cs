using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EVAERP.Forms
{
    public partial class PR02001 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR02001()
        {
            InitializeComponent();
        }

        private void pri029_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri029.Name);
        }

        private void pri030_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri030.Name);
        }
    }
}
