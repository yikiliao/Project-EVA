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
    public partial class wCdept : Form
    {
        public string Cdept;
        public string Code_desc;

        public bool[] AB = new bool[100];//存勾選狀態
        public wCdept()
        {
            InitializeComponent();            
        }

        public wCdept(string Comp)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = department.ToDoList(Comp).ToList();
            if (Comp == "EW")
                bindingSource1.DataSource = department.ToDoList(Comp).ToList();
            if (Comp == "KV")
                bindingSource1.DataSource = department.ToDoList(Comp).ToList();
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
            string message = string.Empty;
            var idx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected) //-如果有選取抓選取的值
                {
                    message += "'" + row.Cells[1].Value.ToString() + "',";
                }
                //把勾選狀態存起來
                AB[idx] = isSelected;
                idx = idx + 1;
                //---------------
            }

            if (message.Length > 0) //如果有勾選取字串;沒有就跟放棄動作
            {
                message = message.Substring(0, message.Length - 1);
                Cdept = message;
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
            Cdept = string.Empty;
            btnUnSelectalll_Click(null, null);
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        private void btnSelectalll_Click(object sender, EventArgs e)
        {
            var idx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = true;
                //把勾選狀態存起來
                AB[idx] = true;
                idx = idx + 1;
                //---------------
            }
        }

        private void btnUnSelectalll_Click(object sender, EventArgs e)
        {
            var idx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = false;
                //把勾選狀態存起來
                AB[idx] = false;
                idx = idx + 1;
                //---------------
            }
        }

        private void wCdept_Load(object sender, EventArgs e)
        {
            var idx = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = AB[idx];
                idx = idx + 1;
            }
        }

    }
}
