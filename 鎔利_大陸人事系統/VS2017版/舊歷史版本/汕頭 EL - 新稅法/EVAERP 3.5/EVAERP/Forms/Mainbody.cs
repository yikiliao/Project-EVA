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
    public partial class Mainbody : Form
    {

        PanelControl panelcontrol = new PanelControl();
        
        public Mainbody()
        {
            InitializeComponent();
            
        }  
        public void BM_Click(object sender, EventArgs e)
        {
            
            panelcontrol.panelshow(BM.Name, this);
           
        }

        private void Mainbody_Load(object sender, EventArgs e)
        {            
           
            
        }

        private void PR_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow(PR.Name, this);
        }
    }
}
