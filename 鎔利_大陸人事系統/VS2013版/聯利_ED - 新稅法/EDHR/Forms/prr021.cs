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
    public partial class prr021 : Form
    {
        public prr021()
        {
            InitializeComponent();
            Config.SetFormSize(this);
        }
        public string Rem_no { get; set; } 
        private void prr021_Load(object sender, EventArgs e)
        {
            this.webBrowser1.Url = new Uri("http://192.168.66.251/ReportServer/Pages/ReportViewer.aspx?%2fdesign%2fEVA-ERP%2fprr021&rs:Command=Render" + "&rem_no=" + Rem_no);
        }

        
    }
}
