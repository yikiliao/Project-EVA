using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using EVAERP.Models;

namespace EVAERP.Forms
{
    public partial class pri046 : Form
    {
        int i = 0;
        static List<prt053> LS1 = new List<prt053>();
        
        string Menu_Sel;
        string Dept = Login.DEPT;

        public pri046()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }


        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {   
                        Config.Show(String.Format("{0}", f_Update()));
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                else
                {
                    return;
                }
                InitMotherboard(this);
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);
            }

        }



        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt053.ToDoListByGroup(f_dept.SelectedValue.ToString()).ToList();
            if (LS1.Count() == 0)
            {
                MessageBox.Show("無符合資料");
                return;
            }
            else
            {
                i = 0;
                f_show(i);
            }
        }

        private void f_show(int idx)
        {
            if (idx < 0 || idx > LS1.Count - 1)
            {
                MessageBox.Show("已無資料");
                if (idx < 0)
                    menu_first_Click(null, null);
                else
                    menu_last_Click(null, null);
            }
            else
            {
                //Master 資料
                f_dept.SelectedValue = LS1[idx].Dept;
                f_tax_date.Text = LS1[idx].Tax_date;
                //抓名細資料
                bindingSource1.Clear();//清資料
                foreach (var i in prt053.ToDoList(f_dept.SelectedValue.ToString(),f_tax_date.Text).ToList())
                {
                    prt053 p_prt053 = new prt053();
                    p_prt053.Seq_no = i.Seq_no;
                    p_prt053.Amt1 = i.Amt1;
                    p_prt053.Amt2 = i.Amt2;
                    p_prt053.Tax_rate = i.Tax_rate;
                    p_prt053.Amt_sub = i.Amt_sub;
                    bindingSource1.Add(p_prt053);
                }
            }
        }

        
        private string f_Update()
        {
            var p_prt053 = new prt053();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                p_prt053.Dept = f_dept.SelectedValue.ToString();
                p_prt053.Tax_date = f_tax_date.Text;
                p_prt053.Seq_no = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[0].Value);
                p_prt053.Amt1 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[1].Value);
                p_prt053.Amt2 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[2].Value);
                p_prt053.Tax_rate = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[3].Value);
                p_prt053.Amt_sub = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[4].Value);
                p_prt053.Delete(p_prt053.Dept, p_prt053.Tax_date, p_prt053.Seq_no);
                p_prt053.Insert();
            }
            return "修改成功";
        }

        private void Col_Disable()
        {   
            f_dept.Enabled = false;
            f_tax_date.Enabled = false;
        }


        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("請先查詢");
                return;
            }
            else
            {
                if (f_tax_date.Text != string.Empty)
                {
                    Menu_Sel = "Upd";
                    SetMotherboard(this);
                    Col_Disable();
                    f_tax_date_s.Enabled = false;
                    dataGridView1.ReadOnly = false;
                    bindingNavigator1.Enabled = false;
                }
                else
                {
                    MessageBox.Show("請先查詢");
                    return;
                }
            }
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            dataGridView1.Rows.Clear();
            dataGridView1.DataBindings.Clear();
            dataGridView1.ReadOnly = true;
            confirm_Click(sender, e);
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            if (f_tax_date.Text != string.Empty)
            {
                i = i + 1;
                f_show(i);
                if (i > LS1.Count - 1) i = LS1.Count - 1;
            }
            else
            {
                MessageBox.Show("請先查詢");
                return;
            }
        }
                

        private void menu_previous_Click(object sender, EventArgs e)
        {  
            if (f_tax_date.Text != string.Empty)
            {
                i = i - 1;
                f_show(i);
                if (i < 0) i = 0;
            }
            else
            {
                MessageBox.Show("請先查詢");
                return;
            }
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {            
            if (Config.Message("是否離開?")=="Y")
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
                this.Close();
        }

        //private void cancel_Click(object sender, EventArgs e)
        //{
        //    i = 0;
        //    Menu_Sel = "";
        //    LS1.Clear();
        //    InitColumn(this);
        //    bindingSource1.Clear();//清資料
        //}

        private void menu_last_Click(object sender, EventArgs e)
        {
            if (f_tax_date.Text != string.Empty)
            {
                i = LS1.Count() - 1;
                f_show(i);
            }
            else
            {
                MessageBox.Show("請先查詢");
                return;
            }
        }

        private void menu_first_Click(object sender, EventArgs e)
        {
            if (f_tax_date.Text != string.Empty)
            {
                i = 0;
                f_show(i);
            }
            else
            {
                MessageBox.Show("請先查詢");
                return;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            base.OnKeyPress(e);
        }

        //所有欄位限制並清空
        private void InitColumn(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                InitColumn(c);
                if (c is TextBox)
                {
                    (c as TextBox).Text = "";
                    (c as TextBox).Enabled = false;
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Checked = false;
                    (c as RadioButton).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
            }
        }

        //主板欄位限制
        private void InitMotherboard(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                InitMotherboard(c);
                if (c is TextBox)
                {
                    (c as TextBox).Enabled = false;
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
            }

            bindingNavigator1.Enabled = true;
        }

        //所有欄位解除並清空
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                SetColumn(a);
                if (a is TextBox)
                {
                    (a as TextBox).Text = "";
                    (a as TextBox).Enabled = true;
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Checked = false;
                    (a as RadioButton).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
            }
            f_add_date.Enabled = false;
            f_add_user.Enabled = false;
            f_mod_date.Enabled = false;
            f_mod_user.Enabled = false;
        }

        //主板欄位解除限制
        private void SetMotherboard(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                SetMotherboard(a);
                if (a is TextBox)
                {
                    (a as TextBox).Enabled = true;
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
            }
        }


        


        private void button1_Click(object sender, EventArgs e)
        {
            f_Query();
            Col_Disable();
        }

        private void f_tax_date_s_ValueChanged(object sender, EventArgs e)
        {
            f_tax_date.Text = f_tax_date_s.Value.ToString("yyyy/MM/dd");
        }

        //產生提示訊息
        private void confirm_MouseHover(object sender, EventArgs e)
        {
            ToolTip ttTip = new ToolTip();
            ttTip.SetToolTip(confirm, "Escape");
        }

        private void cancel_MouseHover(object sender, EventArgs e)
        {
            ToolTip ttTip = new ToolTip();
            ttTip.SetToolTip(cancel, "Delete");
        }

        private void pri012_KeyDown(object sender, KeyEventArgs e)
        {
            
            //查詢(F3)            
            if (e.KeyCode == Keys.F3)
            {
                menu_query_Click(sender, e);
            }
            //修改(F4)
            if (e.KeyCode == Keys.F4)
            {
                menu_edit_Click(sender, e);
            }


            //第一筆(F5)

            if (e.KeyCode == Keys.F5)
            {
                menu_first_Click(sender, e);
            }

            //上一筆(F6)
            if (e.KeyCode == Keys.F6)
            {
                menu_previous_Click(sender, e);
            }

            //下一筆(F7)
            if (e.KeyCode == Keys.F7)
            {
                menu_next_Click(sender, e);
            }

            //最後一筆(F8)
            if (e.KeyCode == Keys.F8)
            {
                menu_last_Click(sender, e);
            }

            //取消(F9)
            if (e.KeyCode == Keys.F9)
            {
                cancel_Click(sender, e);
            }

            //離開(F10)
            if (e.KeyCode == Keys.F10)
            {
                mnu_exit_Click(sender, e);
            }

            //確認(ESC)
            if (e.KeyCode == Keys.Escape)
            {
                confirm_Click(sender, e);
            }
        }

        private void pri012_Load(object sender, EventArgs e)
        {
            //數字靠右
            DataGrid_Right();
        }


        private void DataGrid_Right()
        {
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        
    }
}
