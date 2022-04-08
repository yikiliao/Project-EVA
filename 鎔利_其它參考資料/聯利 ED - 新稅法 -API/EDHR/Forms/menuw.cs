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
    public partial class menuw : Form
    {
        public menuw()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
        }
        public string Id { get; set; }
        public string IdName { get; set; }

        private void menuw_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = umenuS.Select().ToList();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            IdName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }
    }
}
