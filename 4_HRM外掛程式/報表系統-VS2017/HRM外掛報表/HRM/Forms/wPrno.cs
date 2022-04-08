using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HRM.Models;

namespace HRM.Forms
{
    public partial class wPrno : Form
    {
        public string Code;
        public string Code_desc;
        List<employee> L_PRNO = new List<employee>();
        public bool[] Arry = new bool[1500];// 存 勾選項目
        public wPrno(string Comp, string Cdpet, Int16 Forg, Int16 Incomp)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            L_PRNO = employee.ToDoList(Comp, Cdpet, Forg, Incomp).ToList();
            bindingSource1.DataSource = L_PRNO;
            Add_CheckBox();//加入checkbox的欄位在
        }

        public wPrno(string Comp, string Cdpet, int Forg, int Incomp, string Direct)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            L_PRNO = employee.ToDoListDirect(Comp, Cdpet, Forg, Incomp).ToList();
            bindingSource1.DataSource = L_PRNO;
            Add_CheckBox();//加入checkbox的欄位在
        }

        public void Add_CheckBox()
        {
            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "選取";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridView1.Columns.Insert(0, checkBoxColumn);
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            var idx = 0;
            string message = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    message += "'" + row.Cells[1].Value.ToString() + "',";
                }
                //把勾選狀態存起來
                Arry[idx] = isSelected;
                idx = idx + 1;
                //---------------
            }

            if (message.Length > 0) //如果有勾選取字串;沒有就跟放棄動作
            {
                message = message.Substring(0, message.Length - 1);
                Code = message;
                DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
                Close();
            }
            else
            {
                btnAbort_Click(null, null);
            }
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            Code = string.Empty;
            btnUnSelectalll_Click(null, null);
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void btnUnSelectalll_Click(object sender, EventArgs e)
        {
            var idx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = false;
                //把勾選狀態存起來
                Arry[idx] = false;
                idx = idx + 1;
                //---------------
            }
        }

        private void btnSelectalll_Click(object sender, EventArgs e)
        {
            var idx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = true;
                //把勾選狀態存起來
                Arry[idx] = true;
                idx = idx + 1;
                //---------------
            }
        }

        private void wPrno_Load(object sender, EventArgs e)
        {
            var idx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = Arry[idx];
                idx = idx + 1;
            }
        }


    }
}
