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
    public partial class wSItem : Form
    {
        public string Code;
        public string Code_desc;
        public List<mItem> LS = new List<mItem>();// 存 勾選項目
        public wSItem()
        {
            InitializeComponent();
            Config.SetWindowSize(this); 
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
           var idx = 0;
            string message = string.Empty;
            string tmp_code = string.Empty;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {                
                bool isSelected = Convert.ToBoolean(row.Cells[0].Value);
                if (isSelected)
                {
                    tmp_code += "'" + row.Cells[2].Value.ToString() + "',";
                }
                //存勾選值
                LS[idx].isSelected = isSelected;
                idx = idx + 1;
            }

            if (tmp_code.Length > 0) //如果有勾選取字串;沒有就跟放棄動作
            {
                tmp_code = tmp_code.Substring(0, tmp_code.Length - 1);
                Code = tmp_code; //
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = false;
            }
            wSItem_Load(null, null);
        }

        private void btnSelectalll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = true;
            }
            wSItem_Load(null, null);
        }

        private void wSItem_Load(object sender, EventArgs e)
        {
            if (LS.LongCount() == 0)
            {
                LS.Insert(0, new mItem
                {
                    isSelected = false,
                    ItemId = "A",
                    ItemName = "應稅加項(A)"
                });
                LS.Insert(1, new mItem
                {
                    isSelected = false,
                    ItemId = "B",
                    ItemName = "免稅加項(B)"
                });
                LS.Insert(2, new mItem
                {
                    isSelected = false,
                    ItemId = "C",
                    ItemName = "應稅扣項(C)"
                });
                LS.Insert(3, new mItem
                {
                    isSelected = false,
                    ItemId = "D",
                    ItemName = "免稅扣項(D)"
                });
                LS.Insert(4, new mItem
                {
                    isSelected = false,
                    ItemId = "E",
                    ItemName = "所得稅(E)"
                });

                bindingSource1.DataSource = LS;
            }
            else
            {
                bindingSource1.DataSource = LS;
            }
        }




    }   
}
