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
    public partial class pri013 : Form
    {
        int i = 0;
        static List<prt013> LS1 = new List<prt013>();
        string Menu_Sel;
        string Dept = Login.DEPT;

        public pri013()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            f_tax_amt.TextAlign = HorizontalAlignment.Right;
            set_dept();
            D_Nation();//國別
            D_Vaild();//是否
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void D_Nation()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("0-本國籍", "0"));
            data.Add(new DictionaryEntry("1-外國籍", "1"));
            f_nation.DisplayMember = "Key";
            f_nation.ValueMember = "Value";
            f_nation.DataSource = data;
        }

        private void D_Vaild()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("Y-是", "Y"));
            data.Add(new DictionaryEntry("N-否", "N"));
            f_vaild.DisplayMember = "Key";
            f_vaild.ValueMember = "Value";
            f_vaild.DataSource = data;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {  
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_Check() == false)
                        return;
                    try
                    {
                        Config.Show(String.Format("{0}", f_Insert()));
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
                InitColumn(this);//初始
                InitMotherboard(this);
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    { 
                        Config.Show(f_Update());
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

            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Delete());
                        LS1.RemoveAt(i);//刪除List那一筆
                        i = i - 1;//紀錄List的idx

                        if (LS1.Count > 0)
                        {
                            menu_next_Click(sender, e); //自動找下一筆
                        }
                        else
                        {
                            Config.Show("已無資料");
                            InitColumn(this);
                        }
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
        }
        private string f_Delete()
        {
            return string.Format("prt0013{0}\n",
                new prt013().Delete(Dept, f_nation.SelectedValue.ToString(), f_tax_date.Text));
        }
        private bool f_Check()
        {            
            if (f_tax_date.Text == System.String.Empty)
            {
                Config.Show("日期不可空白");
                f_tax_date.Focus();
                return false;
            }
            return true;
        }


        private void f_Query()
        {
            var t_dept = f_dept.SelectedValue.ToString();
            var t_nation = f_nation.SelectedValue.ToString();
            var t_tax_date = f_tax_date.Text;
            LS1.Clear();
            LS1 = prt013.ToDoList(t_dept, t_nation, t_tax_date).ToList();
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
                if (idx < 0)
                    menu_first_Click(null, null);
                else
                    menu_last_Click(null, null);
            }
            else
            {
                var q_prt013 = prt013.Get(LS1[idx].Dept, LS1[idx].Nation, Convert.ToDateTime(LS1[idx].Tax_date).ToString("yyyy/MM/dd"));

                f_dept.SelectedValue = q_prt013.Dept;
                f_nation.SelectedValue = q_prt013.Nation;
                f_tax_date.Text = Convert.ToDateTime(q_prt013.Tax_date).ToString("yyyy/MM/dd");
                f_tax_date_s.Value = Convert.ToDateTime(q_prt013.Tax_date);
                f_tax_amt.Text = q_prt013.Tax_amt.ToString();
                f_vaild.SelectedValue = q_prt013.Vaild;
            }
        }


        //private void f_show(int idx)
        //{
        //    if (idx < 0 || idx > LS1.Count - 1)
        //    {
        //        MessageBox.Show("已無資料");
        //    }
        //    else
        //    {
        //        f_dept.SelectedValue = LS1[idx].Dept;
        //        f_nation.SelectedValue = LS1[idx].Nation;
        //        f_tax_date.Text = Convert.ToDateTime(LS1[idx].Tax_date).ToString("yyyy/MM/dd");
        //        f_tax_date_s.Value =Convert.ToDateTime(LS1[idx].Tax_date);
        //        f_tax_amt.Text = LS1[idx].Tax_amt.ToString();
        //        f_vaild.SelectedValue = LS1[idx].Vaild;
        //    }
        //}

        private string f_Update()
        {
            var p_prt013 = new prt013();
            decimal amt = System.Convert.ToDecimal(f_tax_amt.Text);
            p_prt013.Dept = f_dept.SelectedValue.ToString();
            p_prt013.Nation = f_nation.SelectedValue.ToString();
            p_prt013.Tax_date = f_tax_date_s.Value.ToShortDateString();
            p_prt013.Tax_amt = amt;
            p_prt013.Vaild = f_vaild.SelectedValue.ToString();
            return p_prt013.Update(p_prt013.Dept, p_prt013.Nation, p_prt013.Tax_date);
        }

        private string f_Insert()
        {   
            var p_prt013 = new prt013();
            decimal amt = System.Convert.ToDecimal(f_tax_amt.Text);
            p_prt013.Dept = Dept;
            p_prt013.Nation = f_nation.SelectedValue.ToString();
            p_prt013.Tax_date = f_tax_date.Text;
            p_prt013.Tax_amt = amt;
            p_prt013.Vaild = f_vaild.SelectedValue.ToString();
            return p_prt013.Insert();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);//給初值
            Col_Disable();
            f_tax_amt.Text = "0";
            f_nation.SelectedIndex = 1;
            f_vaild.SelectedIndex = 1;
            bindingNavigator1.Enabled = false;
        }

        private void Col_Disable()
        {
            f_dept.Enabled = false;
            f_tax_date.Enabled = false;
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_tax_amt.Text != string.Empty)
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                Col_Disable();
                f_nation.Enabled = false;
                f_tax_date.Enabled = false;
                f_tax_date_s.Enabled = false;
                f_tax_amt.Focus();
                bindingNavigator1.Enabled = false;
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        //private void menu_edit_Click(object sender, EventArgs e)
        //{
        //    if (f_dept.SelectedValue.ToString() != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        Col_Disable();
        //        f_nation.Enabled = false;                
        //        f_tax_amt.Focus();
        //    }
        //    else
        //    {
        //        MessageBox.Show("請先查詢");
        //    }
        //}

        private void menu_query_Click(object sender, EventArgs e)
        {   
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            f_tax_amt.Text = "";
            f_nation.SelectedIndex = 0;
            f_vaild.SelectedIndex = 0;
            confirm_Click(sender, e);

        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            if (f_tax_amt.Text != string.Empty)
            {
                i = i + 1;
                f_show(i);
                if (i > LS1.Count - 1) i = LS1.Count - 1;
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }
                

        private void menu_previous_Click(object sender, EventArgs e)
        {
            if (f_tax_amt.Text != string.Empty)
            {
                i = i - 1;
                f_show(i);
                if (i < 0) i = 0;
            }
            else
            {
                Config.Show("請先查詢");
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
            {
                if (Menu_Sel == "Add")
                {
                    i = 0;
                    Menu_Sel = "";
                    LS1.Clear();
                    InitColumn(this);
                    f_tax_amt.Text = "";
                    f_nation.SelectedIndex = 0;
                    f_vaild.SelectedIndex = 0;
                }
                if (Menu_Sel == "Upd")
                {
                    InitMotherboard(this);
                }
                bindingNavigator1.Enabled = true;
            }
            else
            {
                return;
            }
                
        }

        //private void cancel_Click(object sender, EventArgs e)
        //{
        //    i = 0;
        //    Menu_Sel = "";
        //    LS1.Clear();
        //    InitColumn(this);
        //    f_tax_amt.Text = "";
        //    f_nation.SelectedIndex = 0;
        //    f_vaild.SelectedIndex = 0;
        //}

        private void menu_last_Click(object sender, EventArgs e)
        {
            if (f_tax_amt.Text != string.Empty)
            {
                i = LS1.Count() - 1;
                f_show(i);
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        private void menu_first_Click(object sender, EventArgs e)
        {
            if (f_tax_amt.Text != string.Empty)
            {
                i = 0;
                f_show(i);
            }
            else
            {
                Config.Show("請先查詢");
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
                if (c is ComboBox)
                {                    
                    (c as ComboBox).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
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
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
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
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
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
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
            }
        }
                

        private void f_nation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_nation.SelectedIndex == 0)
                    f_nation.SelectedIndex = 1;
            }
        }

        private void f_vaild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_vaild.SelectedIndex == 0)
                    f_vaild.SelectedIndex = 1;
            }
        }

        private void f_tax_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 48 || (byte)e.KeyChar > 57)//若小於0或大於9 
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true; //不可輸;鎖起來
                }
            }

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

        private void pri013_KeyDown(object sender, KeyEventArgs e)
        {
            //新增(F1)            
            if (e.KeyCode == Keys.F1)
            {
                menu_add_Click(sender, e);
            }

            //刪除(F2)            
            if (e.KeyCode == Keys.F2)
            {
                menu_del_Click(sender, e);
            }
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

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_tax_amt.Text != string.Empty)
            {
                Menu_Sel = "Del";
                InitMotherboard(this);
                confirm_Click(sender, e);
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        //private void menu_del_Click(object sender, EventArgs e)
        //{
        //    if (f_tax_amt.Text != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Del";
        //        InitMotherboard(this);
        //        confirm_Click(sender, e);
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}

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
