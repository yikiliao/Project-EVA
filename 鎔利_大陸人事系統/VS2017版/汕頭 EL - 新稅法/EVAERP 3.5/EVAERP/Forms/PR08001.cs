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
    public partial class PR08001 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR08001()
        {
            InitializeComponent();
        }

        private void pri019_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri019.Name);
        }

        private void pri029_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri029.Name);
        }

        private void pri030_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri030.Name);
        }

        private void pri038_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri038.Name);
        }
    }
}
