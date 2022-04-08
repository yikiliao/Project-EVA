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
    public partial class PR04401 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR04401()
        {
            InitializeComponent();
        }

        private void pri020_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri020.Name);
        }

        private void pri021_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri021.Name);
        }
    }
}
