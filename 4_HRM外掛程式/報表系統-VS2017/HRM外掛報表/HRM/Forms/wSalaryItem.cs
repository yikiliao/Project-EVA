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
    public partial class wSalaryItem : Form
    {
        public string Code;
        public string Code_desc;
        List<mhrm190> L_ITEM = new List<mhrm190>();
        public bool[] Arry = new bool[100];// 存 勾選項目
        public wSalaryItem()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
            L_ITEM = mhrm190.ItemToDoList().ToList();
            L_ITEM.Insert(0, new mhrm190
            {
                ItemId = 0,
                ItemName = "00 所得稅",
                SalaryItemId = "Z00"
            });
            L_ITEM.Insert(1, new mhrm190
            {
                ItemId = 1,
                ItemName = "11 勞保費",
                SalaryItemId = "Z11"
            });
            L_ITEM.Insert(2, new mhrm190
            {
                ItemId = 2,
                ItemName = "22 健保費",
                SalaryItemId = "Z22"
            });
            L_ITEM.Insert(3, new mhrm190
            {
                ItemId = 3,
                ItemName = "33 勞退自提",
                SalaryItemId = "Z33"
            });
            bindingSource1.DataSource = L_ITEM;
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
            string tmp_code = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["checkBoxColumn"].Value);
                if (isSelected)
                {
                    tmp_code += "'" + row.Cells[2].Value.ToString() + "',";
                    message += "'" + row.Cells[3].Value.ToString() + "',";
                }
                //把勾選狀態存起來
                Arry[idx] = isSelected;
                idx = idx + 1;
                //---------------
            }

            if (message.Length > 0) //如果有勾選取字串;沒有就跟放棄動作
            {
                message = message.Substring(0, message.Length - 1);
                Code = message; //
                Code_desc = tmp_code;
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

        private void wSalaryItem_Load(object sender, EventArgs e)
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
