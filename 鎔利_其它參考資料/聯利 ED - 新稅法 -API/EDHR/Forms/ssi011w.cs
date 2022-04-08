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
    public partial class ssi011w : Form
    {
        public string Company;
        public string Company_name;
        public string Company_shname;

        public ssi011w()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = sst011.ToDoList(Login.DEPT).ToList();
        }

        public ssi011w(string Comp)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = sst011.ToDoList(Login.DEPT).ToList();
        }


        //public string Company
        //{
        //    get
        //    {
        //        return _company;
        //    }
        //    set
        //    {
        //        _company = value;
        //    }
        //}

        //public string Company_name
        //{
        //    get
        //    {
        //        return _company_name;
        //    }
        //    set
        //    {
        //        _company_name = value;
        //    }
        //}

        //public string Company_shname
        //{
        //    get
        //    {
        //        return _company_shname;
        //    }
        //    set
        //    {
        //        _company_shname = value;
        //    }
        //}

        private void bmi001w_Load(object sender, EventArgs e)
        {
            //bindingSource1.DataSource = sst011.ToDoListDept("Y").ToList();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Company = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Company_shname = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Company_name = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }
    }
}
