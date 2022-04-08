using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using EDHR.Models;
using System.Windows.Forms;

namespace EDHR.Forms
{
    public partial class ssi001w : Form
    {
        //string _code;
        //string _code_desc;
        public string Code { get; set; }
        public string Code_desc { get; set; }

        public ssi001w()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
        }
              

        private void bmi001w_Load(object sender, EventArgs e)
        {            
            bindingSource1.DataSource = sst001.ToDoListCode().ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            //_code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //_code_desc = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Code_desc = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }
    }
}
