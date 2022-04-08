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
    public partial class prr001 : Form
    {
        public prr001()
        {
            InitializeComponent();
            Config.SetFormSize(this);
        }
        public string Pr_dept { get; set; }
        public string Department_name_new { get; set; } 
        private void prr001_Load(object sender, EventArgs e)
        {
            //this.webBrowser1.Url = new Uri("http://192.168.66.251/ReportServer/Pages/ReportViewer.aspx?%2fdesign%2fEVA-ERP%2fprr021&rs:Command=Render" + "&rem_no=" + Rem_no);
        }
    }
}
