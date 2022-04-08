using Microsoft.Reporting.WinForms;
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
    public partial class ReportView : Form
    {
        private string reportPath = "";
        ReportParameter[] rparray = null;
        public ReportView(string reportPath, ReportParameter[] rparray)
        {
            InitializeComponent();
            this.reportPath = reportPath;
            this.rparray = rparray;
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            
            reportViewer1.ProcessingMode = ProcessingMode.Remote;
            reportViewer1.Anchor = AnchorStyles.Bottom |
        AnchorStyles.Right |
        AnchorStyles.Top |
        AnchorStyles.Left;

            ServerReport serverReport = reportViewer1.ServerReport;

            System.Net.ICredentials credentials = System.Net.CredentialCache.DefaultCredentials;
            ReportServerCredentials rsCredentials = serverReport.ReportServerCredentials;
            rsCredentials.NetworkCredentials = new System.Net.NetworkCredential("evaerpViewer", "CArTv3hVJ4OS2XBH", "http://192.168.66.8/ReportServer");

            // Set the report server URL and report path
            serverReport.ReportServerUrl = new Uri("http://192.168.66.8/reportserver");
            serverReport.ReportPath = reportPath;

            reportViewer1.ServerReport.SetParameters(rparray);
            reportViewer1.RefreshReport();

        }
    }
}
