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
    public partial class PR10001 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR10001()
        {
            InitializeComponent();
        }

        private void pri022_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri022.Name);
        }

        private void pri038_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri038.Name);
        }
    }
}
