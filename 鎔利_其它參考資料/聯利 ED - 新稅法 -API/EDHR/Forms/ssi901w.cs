using EDHR.Models;
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
    public partial class ssi901w : Form
    {
        public ssi901w()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = sst901.gridviewErpid("Y").ToList();
        }
        public ssi901w(string UserId)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = sst901.gridviewErpid("Y", UserId).ToList();       
        }
        public string Erp_id { get; set; }
        public string Pr_name { get; set; }
        public string Mail { get; set; }

        private void ssi901w_Load(object sender, EventArgs e)
        {
            //bindingSource1.DataSource = sst901.gridviewErpid("Y").ToList();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Erp_id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Pr_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Mail = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }
    }
}
