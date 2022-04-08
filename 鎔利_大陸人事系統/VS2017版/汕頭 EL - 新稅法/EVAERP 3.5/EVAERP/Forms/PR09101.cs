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
    public partial class PR09101 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR09101()
        {
            InitializeComponent();
        }

        private void pri025_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri025.Name);
        }

        private void pri027_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri027.Name);
        }

        private void pri026_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri026.Name);
        }

        private void pri028_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri028.Name);
        }

        
    }
}
