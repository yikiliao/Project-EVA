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
    public partial class PR09001 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR09001()
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

        private void pri024_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri024.Name);
        }

        private void pri010_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri010.Name);
        }

        private void pri011_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri011.Name);
        }

        private void pri012_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri012.Name);
        }

        private void pri013_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri013.Name);
        }

        private void pri026_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri026.Name);
        }

        private void pri028_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri028.Name);
        }

        private void pri025_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri025.Name);
        }

        private void pri027_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri027.Name);
        }
    }
}
