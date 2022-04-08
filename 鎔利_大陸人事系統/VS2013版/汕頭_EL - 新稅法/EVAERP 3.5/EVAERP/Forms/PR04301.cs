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
    public partial class PR04301 : Form
    {
        PanelControl panelcontrol = new PanelControl();
        public PR04301()
        {
            InitializeComponent();
        }

        private void pri020_Click(object sender, EventArgs e)
        {
            panelcontrol.formshow(pri020.Name);
        }
    }
}
