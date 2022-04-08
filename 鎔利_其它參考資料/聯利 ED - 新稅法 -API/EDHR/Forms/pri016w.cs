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
    public partial class pri016w : Form
    {
        public string Code;
        public string Code_desc;

        string _Type;
        string _DataRang;
       
        public pri016w()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno().ToList();
        }
        public pri016w(string type)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno(type).ToList();
        }

        public pri016w(string type,string dept)
        {
            InitializeComponent();
            Config.SetWindowSize(this);            
            bindingSource1.DataSource = prt016.ToDoListPrno(type, dept).ToList();

             _Type = type;
             _DataRang = dept;             
        }

        public pri016w(string type, string dept,string find)
        {   
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno(type, dept, find).ToList();
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
            bindingSource1.Clear();
            if (f_search.Text != "")
            {   
                var _p = prt016.ToDoListPrno(_Type, _DataRang, f_search.Text).ToList();
                foreach (var i in _p)
                {
                    prt016 p_prt016 = new prt016();
                    p_prt016.Pr_no = i.Pr_no;
                    p_prt016.Pr_name = i.Pr_name;
                    bindingSource1.Add(p_prt016);
                }
            }
            else
            {
                var _p = prt016.ToDoListPrno(_Type, _DataRang,"").ToList();
                foreach (var i in _p)
                {
                    prt016 p_prt016 = new prt016();
                    p_prt016.Pr_no = i.Pr_no;
                    p_prt016.Pr_name = i.Pr_name;
                    bindingSource1.Add(p_prt016);
                }
            }
        }
    }
}
