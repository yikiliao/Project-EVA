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
    public partial class wCode : Form
    {
        public string Code;
        public string Code_desc;
        public List<bool> LS = new List<bool>();//存勾選狀態
        public wCode(string Dept)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt006.GroupCode(Dept).ToList();            
            Add_CheckBox();//加入checkbox的欄位在
        }

        //public wCode(decimal Yy, string Dept, string SType)
        //{
        //    InitializeComponent();
        //    Config.SetWindowSize(this);
        //    if (SType == "prt035L")
        //        bindingSource1.DataSource = prt035L.ToDoList_Cdept(Yy, Dept).ToList();
        //    if (SType == "prt036L")
        //        bindingSource1.DataSource = prt036L.ToDoList_Cdept(Yy, Dept).ToList();
        //    if (SType == "prt037L")
        //        bindingSource1.DataSource = prt037L.ToDoList_Cdept(Yy, Dept).ToList();
        //    Add_CheckBox();//加入checkbox的欄位在
        //}
                
        

        public void Add_CheckBox()
        {
            //Add a CheckBox Column to the DataGridView at the first position.
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "選取";
            checkBoxColumn.Width = 30;
            checkBoxColumn.Name = "checkBoxColumn";
            dataGridView1.Columns.Insert(0, checkBoxColumn);
        }
        
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   
            //Code = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            //Code_desc = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            //DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            //Close();
        }

        //確定的按鈕
        private void btnGet_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            string message_desc = string.Empty;
            LS.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    message += "'" + row.Cells[1].Value.ToString() + "',";
                    message_desc += "'" + row.Cells[2].Value.ToString() + "',";
                }
                //把勾選狀態存起來
                LS.Add(isSelected);
            }
            
            if (message.Length > 0) //如果有勾選取字串;沒有就跟放棄動作
            {                
                message = message.Substring(0, message.Length - 1); //從前面取到最後一個字之前就等於; 把最後的逗號","去掉
                message_desc = message_desc.Substring(0, message_desc.Length - 1);
                Code = message;             //回傳點選的值
                Code_desc = message_desc;   //回傳點選的值
                DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
                Close();
            }
            else
            {
                btnAbort_Click(null, null);
            }
        }

        //放棄的按鈕
        private void btnAbort_Click(object sender, EventArgs e)
        {
            Code = string.Empty;
            btnUnSelectalll_Click(null, null);
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            Close();
        }

        //全選的按鈕
        private void btnSelectalll_Click(object sender, EventArgs e)
        {
            LS.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = true;
                //把勾選狀態存起來
                LS.Add(true);
            }
        }

        //全不選的按鈕
        private void btnUnSelectalll_Click(object sender, EventArgs e)
        {
            LS.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["checkBoxColumn"].Value = false;
                //把勾選狀態存起來
                LS.Add(false);
            }
        }

        //畫面Load進來;如果有點選的(打勾)就把打勾放進來
        private void wCdept_Load(object sender, EventArgs e)
        {
            if (LS.Count>0)
            {
                var idx = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {                    
                    row.Cells["checkBoxColumn"].Value = LS[idx];
                    idx = idx + 1;
                }
            }
        }

    }
}
