using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using EVAERP.Models;
using System.Windows.Forms;

namespace EVAERP.Forms
{
    public partial class pri019w : Form
    {
        public string Code;
        public string Code_desc;
              

        public pri019w()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno().ToList();
        }
        public pri019w(string type)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno(type).ToList();
        }

        public pri019w(string type,string dept)
        {
            InitializeComponent();
            Config.SetWindowSize(this);            
            bindingSource1.DataSource = prt016.ToDoListPrno(type, dept).ToList();            
        }

        public pri019w(string pr_date, string Dept,string nothing )
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno2(Dept, null, pr_date).ToList();
        }



        public pri019w(string Dept, string Cdpet, string Pr_date, string DataRang)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            if (!string.IsNullOrEmpty(Cdpet))
            {
                bindingSource1.DataSource = prt016.ToDoListPrno2(Dept, Cdpet, Pr_date, DataRang).ToList();
            }
            else
            {
                bindingSource1.DataSource = prt016.ToDoListPrno2(null, null, Pr_date, DataRang).ToList();
            }
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
