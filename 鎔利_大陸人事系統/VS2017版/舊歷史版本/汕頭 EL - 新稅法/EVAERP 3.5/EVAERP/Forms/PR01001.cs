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
    public partial class PR01001 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR01001()
        {
            InitializeComponent();
        }

        private void pri001_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri001.Name);
        }

        private void pri002_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri002.Name);
        }

        private void pri003_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri003.Name);
        }

        private void pri004_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri004.Name);
        }

        private void pri005_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri005.Name);
        }

       


        
    }
}
