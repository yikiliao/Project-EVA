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
    public partial class pri011 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt011> LS1 = new List<prt011>();
        //string DataRang;//處理廠部範圍
        string Dept = Login.DEPT;

        public pri011()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            SetColumnToRight();
            D_Type_f();//下拉選單
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList().ToList();
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
            add_zero();
            Col_Disable();
            f_wk_code.Text = prt011.Get_Wk_code_No(f_pr_dept.SelectedValue.ToString());
            bindingNavigator1.Enabled = false;
        }

        private void Col_Disable()
        {            
            f_pr_dept.Enabled = false;
            f_wk_code.Enabled = false; 
        }

        private void add_zero()
        {
            f_a1.Text = "0";
            f_a2.Text = "0";
            f_a3.Text = "0";
            f_a4.Text = "0";
            f_a5.Text = "0";
            f_a6.Text = "0";
            f_a7.Text = "0";
            f_a8.Text = "0";
            f_a9.Text = "0";
            f_a10.Text = "0";
            f_a11.Text = "0";
            f_a12.Text = "0";
            f_a13.Text = "0";
            f_a14.Text = "0";
            f_a15.Text = "0";
            f_a16.Text = "0";
            f_a17.Text = "0";
            f_a18.Text = "0";
            f_a19.Text = "0";
            f_a20.Text = "0";
            f_a21.Text = "0";
            f_a22.Text = "0";
            f_a23.Text = "0";
            f_a24.Text = "0";
            f_a25.Text = "0";
            f_a26.Text = "0";
            f_a27.Text = "0";
            f_a28.Text = "0";
            f_a29.Text = "0";
            f_a30.Text = "0";
            f_vaild.SelectedIndex = 1;
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
        //    f_vaild.SelectedIndex = 0;
        //}
                

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
            }

            bindingNavigator1.Enabled = true;
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
                else
                {
                    return;
                }
                InitColumn(this);//初始
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
                else
                {
                    return;
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


        private bool f_Check()
        {
            if (f_wk_code.Text  == System.String.Empty)
            {
                Config.Show("代碼型態不可空白");                
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
            p_prt011.A1 = System.Convert.ToDecimal(f_a1.Text);
            p_prt011.A2 = System.Convert.ToDecimal(f_a2.Text);
            p_prt011.A3 = System.Convert.ToDecimal(f_a3.Text);
            p_prt011.A4 = System.Convert.ToDecimal(f_a4.Text);
            p_prt011.A5 = System.Convert.ToDecimal(f_a5.Text);
            p_prt011.A6 = System.Convert.ToDecimal(f_a6.Text);
            p_prt011.A7 = System.Convert.ToDecimal(f_a7.Text);
            p_prt011.A8 = System.Convert.ToDecimal(f_a8.Text);
            p_prt011.A9 = System.Convert.ToDecimal(f_a9.Text);
            p_prt011.A10 = System.Convert.ToDecimal(f_a10.Text);
            p_prt011.A11 = System.Convert.ToDecimal(f_a11.Text);
            p_prt011.A12 = System.Convert.ToDecimal(f_a12.Text);
            p_prt011.A13 = System.Convert.ToDecimal(f_a13.Text);
            p_prt011.A14 = System.Convert.ToDecimal(f_a14.Text);
            p_prt011.A15 = System.Convert.ToDecimal(f_a15.Text);
            p_prt011.A16 = System.Convert.ToDecimal(f_a16.Text);
            p_prt011.A17 = System.Convert.ToDecimal(f_a17.Text);
            p_prt011.A18 = System.Convert.ToDecimal(f_a18.Text);
            p_prt011.A19 = System.Convert.ToDecimal(f_a19.Text);
            p_prt011.A20 = System.Convert.ToDecimal(f_a20.Text);
            p_prt011.A21 = System.Convert.ToDecimal(f_a21.Text);
            p_prt011.A22 = System.Convert.ToDecimal(f_a22.Text);
            p_prt011.A23 = System.Convert.ToDecimal(f_a23.Text);
            p_prt011.A24 = System.Convert.ToDecimal(f_a24.Text);
            p_prt011.A25 = System.Convert.ToDecimal(f_a25.Text);
            p_prt011.A26 = System.Convert.ToDecimal(f_a26.Text);
            p_prt011.A27 = System.Convert.ToDecimal(f_a27.Text);
            p_prt011.A28 = System.Convert.ToDecimal(f_a28.Text);
            p_prt011.A29 = System.Convert.ToDecimal(f_a29.Text);
            p_prt011.A30 = System.Convert.ToDecimal(f_a30.Text);
            p_prt011.Vaild = f_vaild.SelectedValue.ToString();
            return p_prt011.Insert();
        }

        private string f_Update()
        {
            var p_prt011 = new prt011();
            p_prt011.Wk_code = f_wk_code.Text;
            p_prt011.Pr_dept = f_pr_dept.SelectedValue.ToString();
            p_prt011.A1 = System.Convert.ToDecimal(f_a1.Text);
            p_prt011.A2 = System.Convert.ToDecimal(f_a2.Text);
            p_prt011.A3 = System.Convert.ToDecimal(f_a3.Text);
            p_prt011.A4 = System.Convert.ToDecimal(f_a4.Text);
            p_prt011.A5 = System.Convert.ToDecimal(f_a5.Text);
            p_prt011.A6 = System.Convert.ToDecimal(f_a6.Text);
            p_prt011.A7 = System.Convert.ToDecimal(f_a7.Text);
            p_prt011.A8 = System.Convert.ToDecimal(f_a8.Text);
            p_prt011.A9 = System.Convert.ToDecimal(f_a9.Text);
            p_prt011.A10 = System.Convert.ToDecimal(f_a10.Text);
            p_prt011.A11 = System.Convert.ToDecimal(f_a11.Text);
            p_prt011.A12 = System.Convert.ToDecimal(f_a12.Text);
            p_prt011.A13 = System.Convert.ToDecimal(f_a13.Text);
            p_prt011.A14 = System.Convert.ToDecimal(f_a14.Text);
            p_prt011.A15 = System.Convert.ToDecimal(f_a15.Text);
            p_prt011.A16 = System.Convert.ToDecimal(f_a16.Text);
            p_prt011.A17 = System.Convert.ToDecimal(f_a17.Text);
            p_prt011.A18 = System.Convert.ToDecimal(f_a18.Text);
            p_prt011.A19 = System.Convert.ToDecimal(f_a19.Text);
            p_prt011.A20 = System.Convert.ToDecimal(f_a20.Text);
            p_prt011.A21 = System.Convert.ToDecimal(f_a21.Text);
            p_prt011.A22 = System.Convert.ToDecimal(f_a22.Text);
            p_prt011.A23 = System.Convert.ToDecimal(f_a23.Text);
            p_prt011.A24 = System.Convert.ToDecimal(f_a24.Text);
            p_prt011.A25 = System.Convert.ToDecimal(f_a25.Text);
            p_prt011.A26 = System.Convert.ToDecimal(f_a26.Text);
            p_prt011.A27 = System.Convert.ToDecimal(f_a27.Text);
            p_prt011.A28 = System.Convert.ToDecimal(f_a28.Text);
            p_prt011.A29 = System.Convert.ToDecimal(f_a29.Text);
            p_prt011.A30 = System.Convert.ToDecimal(f_a30.Text);
            p_prt011.Vaild = f_vaild.SelectedValue.ToString();
            return p_prt011.Update(p_prt011.Wk_code, p_prt011.Pr_dept);
        }

        private string f_Delete()
        {
            var p_prt011 = new prt011();
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
            confirm_Click(sender, e);
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
                if (idx < 0)
                    menu_first_Click(null, null);
                else
                    menu_last_Click(null, null);
            }
            else
            {
                var q_prt011 = prt011.Get(LS1[idx].Pr_dept, LS1[idx].Wk_code);

                f_wk_code.Text = q_prt011.Wk_code;
                f_pr_dept.SelectedValue = q_prt011.Pr_dept;
                f_a1.Text = q_prt011.A1.ToString();
                f_a2.Text = q_prt011.A2.ToString();
                f_a3.Text = q_prt011.A3.ToString();
                f_a4.Text = q_prt011.A4.ToString();
                f_a5.Text = q_prt011.A5.ToString();
                f_a6.Text = q_prt011.A6.ToString();
                f_a7.Text = q_prt011.A7.ToString();
                f_a8.Text = q_prt011.A8.ToString();
                f_a9.Text = q_prt011.A9.ToString();
                f_a10.Text = q_prt011.A10.ToString();
                f_a11.Text = q_prt011.A11.ToString();
                f_a12.Text = q_prt011.A12.ToString();
                f_a13.Text = q_prt011.A13.ToString();
                f_a14.Text = q_prt011.A14.ToString();
                f_a15.Text = q_prt011.A15.ToString();
                f_a16.Text = q_prt011.A16.ToString();
                f_a17.Text = q_prt011.A17.ToString();
                f_a18.Text = q_prt011.A18.ToString();
                f_a19.Text = q_prt011.A19.ToString();
                f_a20.Text = q_prt011.A20.ToString();
                f_a21.Text = q_prt011.A21.ToString();
                f_a22.Text = q_prt011.A22.ToString();
                f_a23.Text = q_prt011.A23.ToString();
                f_a24.Text = q_prt011.A24.ToString();
                f_a25.Text = q_prt011.A25.ToString();
                f_a26.Text = q_prt011.A26.ToString();
                f_a27.Text = q_prt011.A27.ToString();
                f_a28.Text = q_prt011.A28.ToString();
                f_a29.Text = q_prt011.A29.ToString();
                f_a30.Text = q_prt011.A30.ToString();
                f_add_date.Text = q_prt011.Add_date.ToString();
                f_add_user.Text = q_prt011.Add_user.Trim();
                f_mod_date.Text = q_prt011.Mod_date.ToString();
                f_mod_user.Text = q_prt011.Mod_user.Trim();
                f_vaild.SelectedValue = q_prt011.Vaild;
            }
        }

        //private void f_show(int idx)
        //{
        //    if (idx < 0 || idx > LS1.Count - 1)
        //    {
        //        Config.Show("已無資料");
        //    }
        //    else
        //    {                
        //        f_wk_code.Text = LS1[idx].Wk_code;
        //        f_pr_dept.SelectedValue = LS1[idx].Pr_dept;
        //        f_a1.Text = LS1[idx].A1.ToString();
        //        f_a2.Text = LS1[idx].A2.ToString();
        //        f_a3.Text = LS1[idx].A3.ToString();
        //        f_a4.Text = LS1[idx].A4.ToString();
        //        f_a5.Text = LS1[idx].A5.ToString();
        //        f_a6.Text = LS1[idx].A6.ToString();
        //        f_a7.Text = LS1[idx].A7.ToString();
        //        f_a8.Text = LS1[idx].A8.ToString();
        //        f_a9.Text = LS1[idx].A9.ToString();
        //        f_a10.Text = LS1[idx].A10.ToString();
        //        f_a11.Text = LS1[idx].A11.ToString();
        //        f_a12.Text = LS1[idx].A12.ToString();
        //        f_a13.Text = LS1[idx].A13.ToString();
        //        f_a14.Text = LS1[idx].A14.ToString();
        //        f_a15.Text = LS1[idx].A15.ToString();
        //        f_a16.Text = LS1[idx].A16.ToString();
        //        f_a17.Text = LS1[idx].A17.ToString();
        //        f_a18.Text = LS1[idx].A18.ToString();
        //        f_a19.Text = LS1[idx].A19.ToString();
        //        f_a20.Text = LS1[idx].A20.ToString();
        //        f_a21.Text = LS1[idx].A21.ToString();
        //        f_a22.Text = LS1[idx].A22.ToString();
        //        f_a23.Text = LS1[idx].A23.ToString();
        //        f_a24.Text = LS1[idx].A24.ToString();
        //        f_a25.Text = LS1[idx].A25.ToString();
        //        f_a26.Text = LS1[idx].A26.ToString();
        //        f_a27.Text = LS1[idx].A27.ToString();
        //        f_a28.Text = LS1[idx].A28.ToString();
        //        f_a29.Text = LS1[idx].A29.ToString();
        //        f_a30.Text = LS1[idx].A30.ToString();
        //        f_add_date.Text = LS1[idx].Add_date.ToString();
        //        f_add_user.Text = LS1[idx].Add_user.Trim();
        //        f_mod_date.Text = LS1[idx].Mod_date.ToString();
        //        f_mod_user.Text = LS1[idx].Mod_user.Trim();
        //        f_vaild.SelectedValue = LS1[idx].Vaild;
        //    }
        //}

        private void menu_first_Click(object sender, EventArgs e)
        {   
            if (f_wk_code.Text != string.Empty)
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

        private void menu_previous_Click(object sender, EventArgs e)
        {
            if (f_wk_code.Text != string.Empty)
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

        private void menu_next_Click(object sender, EventArgs e)
        {            
            if (f_wk_code.Text != string.Empty)
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

        private void menu_last_Click(object sender, EventArgs e)
        {            
            if (f_wk_code.Text != string.Empty)
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

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_wk_code.Text != string.Empty)
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                Col_Disable();
                f_a1.Focus();
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
        //    if (f_pr_dept.SelectedValue.ToString() != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        Col_Disable();
        //        f_a1.Focus();
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_wk_code.Text != string.Empty)
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
        //    if (f_pr_dept.SelectedValue.ToString() != "" && Menu_Sel == "Qry")
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
                

        private void f_vaild_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel=="Upd")
            {
                if (f_vaild.SelectedIndex == 0)
                    f_vaild.SelectedIndex = 1;
            }
        }

        

        private void pri011_KeyDown(object sender, KeyEventArgs e)
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
