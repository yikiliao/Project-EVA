using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using EDHR.Models;

namespace EDHR.Forms
{
    public partial class pri011 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt011> LS1 = new List<prt011>();        
        string Dept = Login.DEPT;

        public pri011()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            SetColumnToRight();
            set_dept();
            D_Type_f();//下拉選單
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
        }
        private void SetColumnToRight()
        {
            f_a1.TextAlign = HorizontalAlignment.Right;
            f_a2.TextAlign = HorizontalAlignment.Right;
            f_a3.TextAlign = HorizontalAlignment.Right;
            f_a4.TextAlign = HorizontalAlignment.Right;
            f_a5.TextAlign = HorizontalAlignment.Right;
            f_a6.TextAlign = HorizontalAlignment.Right;
            f_a7.TextAlign = HorizontalAlignment.Right;
            f_a8.TextAlign = HorizontalAlignment.Right;
            f_a9.TextAlign = HorizontalAlignment.Right;
            f_a10.TextAlign = HorizontalAlignment.Right;
            f_a11.TextAlign = HorizontalAlignment.Right;
            f_a12.TextAlign = HorizontalAlignment.Right;
            f_a13.TextAlign = HorizontalAlignment.Right;
            f_a14.TextAlign = HorizontalAlignment.Right;
            f_a15.TextAlign = HorizontalAlignment.Right;
            f_a16.TextAlign = HorizontalAlignment.Right;
            f_a17.TextAlign = HorizontalAlignment.Right;
            f_a18.TextAlign = HorizontalAlignment.Right;
            f_a19.TextAlign = HorizontalAlignment.Right;
            f_a20.TextAlign = HorizontalAlignment.Right;
            f_a21.TextAlign = HorizontalAlignment.Right;
            f_a22.TextAlign = HorizontalAlignment.Right;
            f_a23.TextAlign = HorizontalAlignment.Right;
            f_a24.TextAlign = HorizontalAlignment.Right;
            f_a25.TextAlign = HorizontalAlignment.Right;
            f_a26.TextAlign = HorizontalAlignment.Right;
            f_a27.TextAlign = HorizontalAlignment.Right;
            f_a28.TextAlign = HorizontalAlignment.Right;
            f_a29.TextAlign = HorizontalAlignment.Right;
            f_a30.TextAlign = HorizontalAlignment.Right;
        }

        private void D_Type_f()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("是", "Y"));
            data.Add(new DictionaryEntry("否", "N"));
            f_vaild.DisplayMember = "Key";
            f_vaild.ValueMember = "Value";
            f_vaild.DataSource = data;
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);
            add_zero(this);
            Col_Disable();
            f_wk_code.Text = prt011.Get_Wk_code_No(f_pr_dept.SelectedValue.ToString());
            //FontBlod(this, false);
        }

        private void fo_1(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                fo_1(c);
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Value = 1;
                    (c as NumericUpDown).Value = 0;
                }
            }
        }


        private void Col_Disable()
        {
            f_pr_company.Enabled = false;
            f_pr_dept.Enabled = false;
            f_wk_code.Enabled = false; 
        }

        private void add_zero(Control ctl_false)
        {            
            foreach (Control c in ctl_false.Controls)
            {
                add_zero(c);
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Value = 1;
                    (c as NumericUpDown).Value = 0;
                }
            }
            f_vaild.SelectedIndex = 1;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
            f_vaild.SelectedIndex = 0;
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
                    (a as TextBox).ReadOnly = false;
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
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is NumericUpDown)
                {   
                    (a as NumericUpDown).Enabled = true;
                    (a as NumericUpDown).ReadOnly = false;
                }
            }
            f_add_date.Enabled = false;
            f_add_user.Enabled = false;
            f_mod_date.Enabled = false;
            f_mod_user.Enabled = false;
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
                    (c as TextBox).ReadOnly = true;
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Checked = false;
                    (c as RadioButton).Enabled = false;
                }
                if (c is  ComboBox)
                {   
                    (c as ComboBox).Enabled = false;
                }
                if (c is  Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is NumericUpDown)
                {                    
                    (c as NumericUpDown).Enabled = false;
                    (c as NumericUpDown).ReadOnly = true;
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
                    (c as TextBox).ReadOnly = true;
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Enabled = false;
                    (c as NumericUpDown).ReadOnly = true;                    
                }
            }
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
                    (a as TextBox).ReadOnly = false;
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Enabled = true;
                    (a as NumericUpDown).ReadOnly = false;                    
                }
            }
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
                InitMotherboard(this);
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
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
                InitMotherboard(this);
            }

            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Delete());
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                InitMotherboard(this);
            }
        }


        private bool f_Check()
        {
            if (f_wk_code.Text  == System.String.Empty)
            {
                Config.Show("代碼型態不可空白");
                //f_type_f.Focus();
                return false;
            }
            return true;
        }


        private string f_Insert()
        {
            var p_prt011 = new prt011();
            p_prt011.Pr_company = Dept;
            p_prt011.Wk_code = f_wk_code.Text;
            p_prt011.Pr_dept = Dept;
            p_prt011.A1 = f_a1.Value;
            p_prt011.A2 = f_a2.Value;
            p_prt011.A3 = f_a3.Value;
            p_prt011.A4 = f_a4.Value;
            p_prt011.A5 = f_a5.Value;
            p_prt011.A6 = f_a6.Value;
            p_prt011.A7 = f_a7.Value;
            p_prt011.A8 = f_a8.Value;
            p_prt011.A9 = f_a9.Value;
            p_prt011.A10 = f_a10.Value;
            p_prt011.A11 = f_a11.Value;
            p_prt011.A12 = f_a12.Value;
            p_prt011.A13 = f_a13.Value;
            p_prt011.A14 = f_a14.Value;
            p_prt011.A15 = f_a15.Value;
            p_prt011.A16 = f_a16.Value;
            p_prt011.A17 = f_a17.Value;
            p_prt011.A18 = f_a18.Value;
            p_prt011.A19 = f_a19.Value;
            p_prt011.A20 = f_a20.Value;
            p_prt011.A21 = f_a21.Value;
            p_prt011.A22 = f_a22.Value;
            p_prt011.A23 = f_a23.Value;
            p_prt011.A24 = f_a24.Value;
            p_prt011.A25 = f_a25.Value;
            p_prt011.A26 = f_a26.Value;
            p_prt011.A27 = f_a27.Value;
            p_prt011.A28 = f_a28.Value;
            p_prt011.A29 = f_a29.Value;
            p_prt011.A30 = f_a30.Value;
            p_prt011.Vaild = f_vaild.SelectedValue.ToString();
            return p_prt011.Insert();
        }

        
        private string f_Update()
        {
            var p_prt011 = new prt011();            
            p_prt011.Pr_company = f_pr_dept.SelectedValue.ToString();
            p_prt011.Wk_code = f_wk_code.Text;
            p_prt011.Pr_dept = f_pr_dept.SelectedValue.ToString();
            p_prt011.A1 = f_a1.Value;
            p_prt011.A2 = f_a2.Value;
            p_prt011.A3 = f_a3.Value;
            p_prt011.A4 = f_a4.Value;
            p_prt011.A5 = f_a5.Value;
            p_prt011.A6 = f_a6.Value;
            p_prt011.A7 = f_a7.Value;
            p_prt011.A8 = f_a8.Value;
            p_prt011.A9 = f_a9.Value;
            p_prt011.A10 = f_a10.Value;
            p_prt011.A11 = f_a11.Value;
            p_prt011.A12 = f_a12.Value;
            p_prt011.A13 = f_a13.Value;
            p_prt011.A14 = f_a14.Value;
            p_prt011.A15 = f_a15.Value;
            p_prt011.A16 = f_a16.Value;
            p_prt011.A17 = f_a17.Value;
            p_prt011.A18 = f_a18.Value;
            p_prt011.A19 = f_a19.Value;
            p_prt011.A20 = f_a20.Value;
            p_prt011.A21 = f_a21.Value;
            p_prt011.A22 = f_a22.Value;
            p_prt011.A23 = f_a23.Value;
            p_prt011.A24 = f_a24.Value;
            p_prt011.A25 = f_a25.Value;
            p_prt011.A26 = f_a26.Value;
            p_prt011.A27 = f_a27.Value;
            p_prt011.A28 = f_a28.Value;
            p_prt011.A29 = f_a29.Value;
            p_prt011.A30 = f_a30.Value;
            p_prt011.Vaild = f_vaild.SelectedValue.ToString();            
            return p_prt011.Update(p_prt011.Wk_code, p_prt011.Pr_dept);
        }

        private string f_Delete()
        {
            var p_prt011 = new prt011();
            p_prt011.Pr_company = f_pr_company.Text;
            p_prt011.Wk_code = f_wk_code.Text;
            p_prt011.Pr_dept = f_pr_dept.SelectedValue.ToString();
            return p_prt011.Delete(p_prt011.Wk_code, p_prt011.Pr_dept);
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            f_vaild.SelectedIndex = 0;
            add_zero(this);
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt011.ToDoList(f_wk_code.Text,f_pr_dept.SelectedValue.ToString()).ToList();
            if (LS1.Count() == 0)
            {
                Config.Show("無符合資料");
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
                Config.Show("已無資料");
            }
            else
            {
                f_pr_company.Text = LS1[idx].Pr_company;
                f_wk_code.Text = LS1[idx].Wk_code;
                f_pr_dept.SelectedValue = LS1[idx].Pr_dept;;
                f_a1.Value = (decimal)LS1[idx].A1;
                f_a2.Value = (decimal)LS1[idx].A2;
                f_a3.Value = (decimal)LS1[idx].A3;
                f_a4.Value = (decimal)LS1[idx].A4;
                f_a5.Value = (decimal)LS1[idx].A5;
                f_a6.Value = (decimal)LS1[idx].A6;
                f_a7.Value = (decimal)LS1[idx].A7;
                f_a8.Value = (decimal)LS1[idx].A8;
                f_a9.Value = (decimal)LS1[idx].A9;
                f_a10.Value = (decimal)LS1[idx].A10;
                f_a11.Value = (decimal)LS1[idx].A11;
                f_a12.Value = (decimal)LS1[idx].A12;
                f_a13.Value = (decimal)LS1[idx].A13;
                f_a14.Value = (decimal)LS1[idx].A14;
                f_a15.Value = (decimal)LS1[idx].A15;
                f_a16.Value = (decimal)LS1[idx].A16;
                f_a17.Value = (decimal)LS1[idx].A17;
                f_a18.Value = (decimal)LS1[idx].A18;
                f_a19.Value = (decimal)LS1[idx].A19;
                f_a20.Value = (decimal)LS1[idx].A20;
                f_a21.Value = (decimal)LS1[idx].A21;
                f_a22.Value = (decimal)LS1[idx].A22;
                f_a23.Value = (decimal)LS1[idx].A23;
                f_a24.Value = (decimal)LS1[idx].A24;
                f_a25.Value = (decimal)LS1[idx].A25;
                f_a26.Value = (decimal)LS1[idx].A26;
                f_a27.Value = (decimal)LS1[idx].A27;
                f_a28.Value = (decimal)LS1[idx].A28;
                f_a29.Value = (decimal)LS1[idx].A29;
                f_a30.Value = (decimal)LS1[idx].A30;
                f_add_date.Text = LS1[idx].Add_date.ToString();
                f_add_user.Text = LS1[idx].Add_user.Trim();
                f_mod_date.Text = LS1[idx].Mod_date.ToString();
                f_mod_user.Text = LS1[idx].Mod_user.Trim();
                f_vaild.SelectedValue = LS1[idx].Vaild;
            }
        }

        private void menu_first_Click(object sender, EventArgs e)
        {
            i = 0;
            f_show(i);
        }

        private void menu_previous_Click(object sender, EventArgs e)
        {
            i = i - 1;
            f_show(i);
            if (i < 0) i = 0;
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            i = i + 1;
            f_show(i);
            if (i > LS1.Count - 1) i = LS1.Count - 1;
        }

        private void menu_last_Click(object sender, EventArgs e)
        {
            i = LS1.Count() - 1;
            f_show(i);
        }


        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_pr_company.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                Col_Disable();
                f_a1.Focus();
                //FontBlod(this, false);
            }
            else
            {
                Config.Show("請先查詢");
            }
        }

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_company.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Del";
                InitMotherboard(this);
                confirm_Click(sender, e);
            }
            else
            {
                Config.Show("請先查詢");
            }
        }

        private void f_wk_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 48 || (byte)e.KeyChar > 57)//若小於0或大於9 
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true; //不可輸;鎖起來
                }
            }

        }

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            
        }

        private void f_vaild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel=="Upd")
            {
                if (f_vaild.SelectedIndex == 0)
                    f_vaild.SelectedIndex = 1;
            }
        }

        private void f_a1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a2.Focus();
        }

        private void f_a2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a3.Focus();
        }

        private void f_a3_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a4.Focus();
        }

        private void f_a4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a5.Focus();
        }

        private void f_a5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a6.Focus();
        }

        private void f_a6_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a7.Focus();
        }

        private void f_a7_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a8.Focus();
        }

        private void f_a8_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a9.Focus();
        }

        private void f_a9_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a10.Focus();
        }

        private void f_a10_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a11.Focus();
        }

        
        private void f_a11_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a12.Focus();
        }

        private void f_a12_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a13.Focus();
        }

        private void f_a13_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a14.Focus();
        }

        private void f_a14_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a15.Focus();
        }

        private void f_a15_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a16.Focus();
        }

        private void f_a16_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a17.Focus();
        }

        private void f_a17_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a18.Focus();
        }

        private void f_a18_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a19.Focus();
        }

        private void f_a19_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a20.Focus();
        }

        private void f_a20_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a21.Focus();
        }

        private void f_a21_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a22.Focus();
        }

        private void f_a22_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a23.Focus();
        }

        private void f_a23_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a24.Focus();
        }

        private void f_a24_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a25.Focus();
        }

        private void f_a25_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a26.Focus();
        }

        private void f_a26_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a27.Focus();
        }

        private void f_a27_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a28.Focus();
        }

        private void f_a28_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a29.Focus();
        }

        private void f_a29_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a30.Focus();
        }

        private void f_a30_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_a1.Focus();
        }

        private void pri011_KeyDown(object sender, KeyEventArgs e)
        {
            //新增(Control+A)
            if (e.Control && e.KeyCode == Keys.A)
            {
                menu_add_Click(sender, e);
            }
            //查詢(Control+Q)
            if (e.Control && e.KeyCode == Keys.Q)
            {
                menu_query_Click(sender, e);
            }
            //修改(Control+E)
            if (e.Control && e.KeyCode == Keys.E)
            {
                menu_edit_Click(sender, e);
            }
            //刪除(Control+D)
            if (e.Control && e.KeyCode == Keys.D)
            {
                menu_del_Click(sender, e);
            }

            //第一筆(Control+F)
            if (e.Control && e.KeyCode == Keys.F)
            {
                menu_first_Click(sender, e);
            }

            //上一筆(Control+P)
            if (e.Control && e.KeyCode == Keys.P)
            {
                menu_previous_Click(sender, e);
            }

            //下一筆(Control+N)
            if (e.Control && e.KeyCode == Keys.N)
            {
                menu_next_Click(sender, e);
            }

            //最後一筆(Control+L)
            if (e.Control && e.KeyCode == Keys.L)
            {
                menu_last_Click(sender, e);
            }

            //確認(Escape)
            if (e.KeyCode == Keys.Escape)
            {
                confirm_Click(sender, e);
            }
            //取消(Delete)
            if (e.KeyCode == Keys.Delete)
            {
                cancel_Click(sender, e);
            }

            //離開(Control+Del)
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                mnu_exit_Click(sender, e);
            }
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


        private void NumAllControl_Enter(object sender, EventArgs e)
        {
            ((NumericUpDown)sender).Select(0, 8);
            ((NumericUpDown)sender).Focus();
            //((NumericUpDown)sender).BackColor = Color.Beige;
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
