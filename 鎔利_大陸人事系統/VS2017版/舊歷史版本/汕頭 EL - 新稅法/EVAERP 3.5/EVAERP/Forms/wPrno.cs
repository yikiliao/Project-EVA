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
    public partial class wPrno : Form
    {
        public string Code;
        public string Code_desc;
        
        public List<bool> LS = new List<bool>();//存勾選狀態

/// <summary>
/// </summary>
/// <param name="Dept">廠部</param>
/// <param name="Cdpet">部門</param>
/// <param name="Type">離L 在I 職</param>
/// <param name="DataRang">資料範圍</param>
        public wPrno(string Dept, string Cdpet, string Type)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            bindingSource1.DataSource = prt016.ToDoListPrno(Dept, Cdpet, Type, "").ToList();
            Add_CheckBox();
        }

        public wPrno(decimal Yy, string Dept, string Cdpet, string SType)
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            if (SType == "prt035L")
                bindingSource1.DataSource = prt035L.ToDoList_Prno(Yy, Dept, Cdpet).ToList();
            if (SType == "prt036L")
                bindingSource1.DataSource = prt036L.ToDoList_Prno(Yy, Dept, Cdpet).ToList();
            if (SType == "prt037L")
                bindingSource1.DataSource = prt037L.ToDoList_Prno(Yy, Dept, Cdpet).ToList();
            Add_CheckBox();
        }



        //public wPrno(string Dept, string Cdpet, string Type, string DataRang)
        //{
        //    InitializeComponent();
        //    Config.SetWindowSize(this);
        //    //L_PRNO = prt016.ToDoListPrno(Dept, Cdpet, Type, DataRang).ToList();
        //    //bindingSource1.DataSource = L_PRNO;
        //    bindingSource1.DataSource = prt016.ToDoListPrno(Dept, Cdpet, Type, DataRang).ToList();
        //    Add_CheckBox();
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
       
        //確定的按鈕
        private void bt1_Click(object sender, EventArgs e)
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
                LS.Add(isSelected);
            }

            if (message.Length > 0) //如果有勾選取字串;沒有就跟放棄動作
            {
                message = message.Substring(0, message.Length - 1);//取字串把最後一個逗號去掉
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
                LS.Add(false);
            }
        }


        private void wPrno_Load(object sender, EventArgs e)
        {
            if (LS.Count > 0)
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
