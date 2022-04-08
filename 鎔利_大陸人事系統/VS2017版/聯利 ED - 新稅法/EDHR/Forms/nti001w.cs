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
    public partial class nti001w : Form
    {
        public string Code;
        public string Code_desc;
        public nti001w(string Country_code)
        {
            InitializeComponent();
            Config.SetWindowSize(this);            
            bindingSource1.DataSource = ntt001.ToDoListCode(Country_code).ToList();
        }
                

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Code_desc = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }
    }
}
