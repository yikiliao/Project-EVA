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
    public partial class PR03101 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR03101()
        {
            InitializeComponent();
        }

        private void pri019_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri019.Name);
        }

        private void pri023_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri023.Name);
        }

        private void pri038_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri038.Name);
        }

       
    }
}
