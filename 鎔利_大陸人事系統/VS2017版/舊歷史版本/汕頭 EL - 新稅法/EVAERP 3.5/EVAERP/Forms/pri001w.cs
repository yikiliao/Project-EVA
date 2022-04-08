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
    public partial class pri001w : Form
    {
        public string Code;
        public string Code_desc;

        public pri001w(string Dept)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt001.ToDoList(Dept).ToList();
        }

        public pri001w(string Dept,Int32 Yy,Int32 Mm)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            if (Dept == "L")
            {
                bindingSource1.DataSource = prt030L.GroupCdept(Dept, Yy, Mm).ToList();
            }
            if (Dept == "S")
            {
                bindingSource1.DataSource = prt030S.GroupCdept(Dept, Yy, Mm).ToList();
            }            
        }


        private void bmi003w_Load(object sender, EventArgs e)
        {            
            //bindingSource1.DataSource = prt003.ToDoListCode("Y").ToList();
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
