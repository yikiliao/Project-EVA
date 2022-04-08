using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDHR.Forms
{
    public partial class PR05101 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR05101()
        {
            InitializeComponent();
        }

       

        private void HR03001_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow(HR03001.Name, this);
        }

        private void HR03101_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow(HR03101.Name, this);
        }

        private void pri038_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri038.Name);
        }

        private void HR07201_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow(HR07201.Name, this);
        }

        private void HR10001_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow(HR10001.Name, this);
        }

        private void HR10101_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow(HR10101.Name, this);
        }

        private void pri038_1_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri038.Name);
        }

        
    }
}
