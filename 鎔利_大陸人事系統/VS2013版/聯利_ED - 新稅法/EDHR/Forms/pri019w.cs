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
    public partial class pri019w : Form
    {
        public string Code;
        public string Code_desc;
             

        
        public pri019w(string type,string dept)
        {
            InitializeComponent();
            Config.SetWindowSize(this);            
            bindingSource1.DataSource = prt016.ToDoListPrno(type, dept).ToList();            
        }

        public pri019w(string Dept,string Cdept, string pr_date)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno2(Dept, Cdept, pr_date).ToList();
        }

        
        



        public pri019w(string Dept, Int32 Yy, Int32 Mm, string Pr_no, string Cdpet)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            if (Dept == "L")
            {
                bindingSource1.DataSource = prt030L.ToDoListByGroup2(Dept, Yy, Mm, Pr_no, Cdpet).ToList();
            }
            if (Dept == "S")
            {
                bindingSource1.DataSource = prt030S.ToDoListByGroup2(Dept, Yy, Mm, Pr_no, Cdpet).ToList();
            }
            if (Dept == "D")
            {
                bindingSource1.DataSource = prt030D.ToDoListByGroup2(Dept, Yy, Mm, Pr_no, Cdpet).ToList();
            }
        }

        

        private void bmi003w_Load(object sender, EventArgs e)
        {
            //bindingSource1.DataSource = prt016.ToDoListPrno().ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            Code = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Code_desc = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["pr_name"].Value.ToString() == f_search.Text)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[row.Index].Cells["pr_name"];
                    break;
                }
            }            
        }

        private void f_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            //bt1_Click(sender, e);
        }
    }
}
