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
    
    public partial class BM : Form
    {
        PanelControl panelcontrol = new PanelControl();
       
        public BM()
        {
            InitializeComponent();
          //  Config.SetFormSize(this);
            
        }

        private void BM_Load(object sender, EventArgs e)
        {
            
        }

        private void BM_detel_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow(BM1.Name,this);
        }

       
    }
}
