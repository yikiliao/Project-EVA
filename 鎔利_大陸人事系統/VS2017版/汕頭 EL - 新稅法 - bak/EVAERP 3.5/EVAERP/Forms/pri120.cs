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
using Microsoft.Reporting.WinForms;

namespace EVAERP.Forms
{
    public partial class pri120 : Form
    {
        
        int i = 0;
        string Menu_Sel;
        static List<prt036L> LS1 = new List<prt036L>();
        prt016 p_prt016 = new prt016();
        string Dept = "L";
        string SType = "prt036L";
        
        List<bool> LCdept = new List<bool>();//存 部門勾選 
        List<bool> LPrno = new List<bool>();//存 工號勾選

        public decimal rYy;        
        public string rCdept;//部門
        public string rPrno;//工號 
        public bool rOK = false;//按下確認鍵

        public pri120()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            InitForm();
        }

        private void InitForm()
        {
            set_dept();
            D_YY();//下拉選單-年
            D_Cdpet();//部門
        }
        

        private void set_dept()
        {
            //--廠部下拉選單
            var p_dept = sst011.ToDoList().ToList();
            p_dept.Insert(0, new sst011());//加一空白在第一列
            f_pr_dept.DataSource = p_dept;
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
        }

        private void D_YY()
        {
            var p_yy = prt036L.ToDoList_YY().ToList();
            p_yy.Insert(0, new prt036L());//加一空白在第一列        
            f_yy.DataSource = p_yy;
            f_yy.DisplayMember = "yy";
            f_yy.ValueMember = "yy";
        }

        private void D_Cdpet()
        {
            var p_cdept = prt001.ToDoList(Dept).ToList();
            p_cdept.Insert(0, new prt001());//加一空白在第一列
            f_pr_cdept.DataSource = p_cdept;
            f_pr_cdept.DisplayMember = "Department_name_new";
            f_pr_cdept.ValueMember = "Department_code";
        }

        

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            
        }

        


        private void Col_Disable()
        {
            f_pr_dept.Enabled = false;
            
            f_pr_cdept.Enabled = false;
            
            f_work_name.Enabled = false;
            f_yy.Enabled = false;
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;

            f_pr_in_date.Enabled = false;
            f_pay_3.Enabled = false;
            f_pay_4.Enabled = false;
            f_pay_5.Enabled = false;
            f_pay_8.Enabled = false;
            f_pay_9.Enabled = false;
            f_pay.Enabled = false;

            f_check_base.Enabled = false;
            f_check_comp.Enabled = false;
            f_check_point.Enabled = false;
            f_hoday.Enabled = false;
            f_bonus_ho.Enabled = false;

            f_s_hoday.Enabled = true;   //扣減請假
            f_t_bonus.Enabled = false;  //應付年終獎金
            f_s_extra.Enabled = false;  //主管調整增加數
            f_x_bonus.Enabled = false;  //年度總獎金
            f_s_tax.Enabled = false;    //應扣稅額
            f_s_bonus.Enabled = false;    //預付獎金
            f_bonus.Enabled = false;    //時領獎金
            f_hoday.Enabled = true;    //請假時數
            f_un_sp_hoday.Enabled = false;  //特休未請時數
            f_y_bonus.Enabled = false;  //基準年終獎金            
            f_memo.Enabled = true;      //備註

            f_s_hoday_Enter(null, null); //讓扣減請假欄位反白            
            button1.Enabled = false;//工號按鈕
            
        }

        
        
        

        
        private void cancel_Click(object sender, EventArgs e)
        {
            InitMotherboard(this);
            return;
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
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Enabled = true;                    
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
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Enabled = false;
                    (c as NumericUpDown).TextAlign = HorizontalAlignment.Right;
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
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Enabled = false;
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

                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Enabled = true;
                }
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            decimal C_Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            decimal C_Mm = 88;
            string C_Dept = f_pr_dept.Text;

            if (Menu_Sel == "Qry")
            {
                f_Query();                
                InitMotherboard(this);                
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
                {
                    Config.Show("此年度資料已關帳，無法異動。");
                    return;
                }
                if (Config.Message("確定修改?") == "Y")
                {
                    if (f_Check() == false)
                        return;
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
                if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
                {
                    Config.Show("此年度資料已關帳，無法異動。");
                    return;
                }
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Delete());
                        LS1.RemoveAt(i);//刪除List那一筆
                        i = i - 1;//紀錄List的idx
                        menu_next_Click(sender, e); //自動找下一筆
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
            if (f_bonus.Value < 0)
            {
                Config.Show("實領獎金小於 ０");
                f_s_tax_Enter(null, null);
                return false;
            }
            return true;
        }



        private string f_Update()
        {
            return String.Format("{0}", f_Update_1());
        }

        private string f_Delete()
        {
            return String.Format("{0}", f_Delete_1());
        }
                

        private string f_Update_1()
        {
            var p_prt036L = new prt036L();
            p_prt036L.Yy = System.Convert.ToDecimal(f_yy.SelectedValue.ToString());
            p_prt036L.Dept = f_pr_dept.SelectedValue.ToString();
            p_prt036L.Cdept = f_pr_cdept.SelectedValue.ToString();
            p_prt036L.Pr_no = f_pr_no.Text;
            p_prt036L.Pay_3 = f_pay_3.Value;
            p_prt036L.Pay_4 = f_pay_4.Value;
            p_prt036L.Pay_5 = f_pay_5.Value;
            p_prt036L.Pay_8 = f_pay_8.Value;
            p_prt036L.Pay_9 = f_pay_9.Value;
            p_prt036L.Pay = f_pay.Value;
            p_prt036L.Check_base = f_check_base.Value;
            p_prt036L.Check_point = f_check_point.Value;
            p_prt036L.Check_comp = f_check_comp.Value;
            p_prt036L.Y_bonus = f_y_bonus.Value;
            p_prt036L.Bonus_ho = f_bonus_ho.Value;
            p_prt036L.S_hoday = f_s_hoday.Value;
            p_prt036L.T_bonus = f_t_bonus.Value;
            p_prt036L.S_extra = f_s_extra.Value;
            p_prt036L.X_bonus = f_x_bonus.Value;
            p_prt036L.S_tax = f_s_tax.Value;
            p_prt036L.S_bonus = f_s_bonus.Value;
            p_prt036L.Bonus = f_bonus.Value;
            p_prt036L.Hoday = f_hoday.Value;
            p_prt036L.Un_sp_hoday = f_un_sp_hoday.Value;
            p_prt036L.Memo = f_memo.Text;
            return p_prt036L.Update(p_prt036L.Yy, p_prt036L.Dept, p_prt036L.Cdept, p_prt036L.Pr_no);              
        }

        private string f_Delete_1()
        {
            var p_prt036L = new prt036L();
            decimal Yy = Convert.ToDecimal(f_yy.SelectedValue);
            string Dept = f_pr_dept.SelectedValue.ToString();
            string Cdept = f_pr_cdept.SelectedValue.ToString();
            string Pr_no = f_pr_no.Text;
            return p_prt036L.Delete(Yy, Dept, Cdept, Pr_no);
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            InitForm();
            FormQuery();//查詢畫面            
            if (rOK == true)
                confirm_Click(sender, e);//確認按鍵
            else
                InitColumn(this);//初始
            Config.FontBlod(this, true);//字體加粗
        }

        private void FormQuery()
        {
            pri120Q fm = new pri120Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rYy = fm.rYy;
                rCdept = fm.rCdept;//部門
                rPrno = fm.rPrno;//工號
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();
        }


        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt036L.ToDoList(rYy, Dept, rCdept, rPrno).ToList();
            if (LS1.Count() == 0)
            {
                Config.Show("無符合資料");
                return;
            }
            else
            {                
                Config.FontBlod(this, true);//字體加粗
                i = 0;
                f_show(i);
            }
        }

        private void f_show(int idx)
        {
            if (idx < 0 || idx > LS1.Count - 1)
            {
                Config.Show("已無資料");
                if (idx < 0)
                    menu_first_Click(null, null);
                else
                    menu_last_Click(null, null); ;
            }
            else
            {
                //數字給零
                GNumberZero(this);
                //----------
                var q_prt036L = prt036L.Get(LS1[idx].Yy, LS1[idx].Dept, LS1[idx].Cdept, LS1[idx].Pr_no);

                f_yy.SelectedValue = q_prt036L.Yy;
                f_pr_dept.SelectedValue = q_prt036L.Dept;
                f_pr_cdept.SelectedValue = q_prt036L.Cdept;
                f_pr_no.Text = q_prt036L.Pr_no;
                p_prt016 = prt016.Get(q_prt036L.Pr_no);
                f_pr_name.Text = p_prt016.Pr_name;

                f_pr_in_date.Text = string.IsNullOrEmpty(p_prt016.Pr_in_date) ? "" : Convert.ToDateTime(p_prt016.Pr_in_date).ToString("yyyy/MM/dd");
                f_work_name.Text = string.Format("{0}-{1}", prt006.Get(q_prt036L.Dept, "WK", p_prt016.Pr_work) == null ? "" : prt006.Get(q_prt036L.Dept, "WK", p_prt016.Pr_work).Code_desc, prt006.Get(q_prt036L.Dept, "WT", p_prt016.Position) == null ? "" : prt006.Get(q_prt036L.Dept, "WT", p_prt016.Position).Code_desc);

                f_pay_3.Value = q_prt036L.Pay_3;
                f_pay_4.Value = q_prt036L.Pay_4;
                f_pay_5.Value = q_prt036L.Pay_5;
                f_pay_8.Value = q_prt036L.Pay_8;
                f_pay_9.Value = q_prt036L.Pay_9;
                f_pay.Value = q_prt036L.Pay;

                f_check_base.Value = q_prt036L.Check_base;
                f_check_comp.Value = q_prt036L.Check_comp;
                f_check_point.Value = q_prt036L.Check_point;

                f_y_bonus.Value = q_prt036L.Y_bonus;
                f_bonus_ho.Value = q_prt036L.Bonus_ho;
                f_s_hoday.Value = q_prt036L.S_hoday;
                f_t_bonus.Value = q_prt036L.T_bonus;

                f_s_extra.Value = q_prt036L.S_extra;
                f_x_bonus.Value = q_prt036L.X_bonus;
                f_s_tax.Value = q_prt036L.S_tax;
                f_s_bonus.Value = q_prt036L.S_bonus;
                f_bonus.Value = q_prt036L.Bonus;
                f_hoday.Value = q_prt036L.Hoday;
                f_un_sp_hoday.Value = q_prt036L.Un_sp_hoday;
                if (q_prt036L.Yy < 2020)
                    f_memo.Text = q_prt036L.Memo;
                else
                    f_memo.Text = q_prt036L.Memo.Trim() + " " + "汕頭廠自2020年起年假未請補助不列入年終獎金計算";
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
        //        //數字給零
        //        GNumberZero(this);
        //        //----------

        //        f_yy.SelectedValue = LS1[idx].Yy;
        //        f_pr_dept.SelectedValue = LS1[idx].Dept;
        //        f_pr_cdept.SelectedValue = LS1[idx].Cdept;
        //        f_pr_no.Text = LS1[idx].Pr_no;
        //        p_prt016 = prt016.Get(LS1[idx].Pr_no);
        //        f_pr_name.Text = p_prt016.Pr_name;

        //        f_pr_in_date.Text = string.IsNullOrEmpty(p_prt016.Pr_in_date) ? "" : Convert.ToDateTime(p_prt016.Pr_in_date).ToString("yyyy/MM/dd");
        //        f_work_name.Text = string.Format("{0}-{1}", prt006.Get(LS1[idx].Dept, "WK", p_prt016.Pr_work) == null ? "" : prt006.Get(LS1[idx].Dept, "WK", p_prt016.Pr_work).Code_desc, prt006.Get(LS1[idx].Dept, "WT", p_prt016.Position) == null ? "" : prt006.Get(LS1[idx].Dept, "WT", p_prt016.Position).Code_desc);

        //        f_pay_3.Value = LS1[idx].Pay_3;                
        //        f_pay_4.Value = LS1[idx].Pay_4;
        //        f_pay_5.Value = LS1[idx].Pay_5;
        //        f_pay_8.Value = LS1[idx].Pay_8;
        //        f_pay_9.Value = LS1[idx].Pay_9;
        //        f_pay.Value = LS1[idx].Pay;

        //        f_check_base.Value = LS1[idx].Check_base;
        //        f_check_comp.Value = LS1[idx].Check_comp;
        //        f_check_point.Value = LS1[idx].Check_point;

        //        f_y_bonus.Value = LS1[idx].Y_bonus;
        //        f_bonus_ho.Value = LS1[idx].Bonus_ho;
        //        f_s_hoday.Value = LS1[idx].S_hoday;
        //        f_t_bonus.Value = LS1[idx].T_bonus;

        //        f_s_extra.Value = LS1[idx].S_extra;
        //        f_x_bonus.Value = LS1[idx].X_bonus;
        //        f_s_tax.Value = LS1[idx].S_tax;
        //        f_s_bonus.Value = LS1[idx].S_bonus;
        //        f_bonus.Value = LS1[idx].Bonus;
        //        f_hoday.Value = LS1[idx].Hoday;
        //        f_un_sp_hoday.Value = LS1[idx].Un_sp_hoday;
        //        f_memo.Text = LS1[idx].Memo;
        //    }
        //}

        private void GNumberZero(Control ctl_false)
        {
            //數字部分先給值再清為0,直接給0會空白...不知道甚麼原因            
            foreach (Control c in ctl_false.Controls)
            {
                GNumberZero(c);
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Value = 1;
                    (c as NumericUpDown).Value = 0;
                }
            }
        }

        private void GNumberEnable(Control ctl_false)
        {                        
            foreach (Control c in ctl_false.Controls)
            {
                GNumberEnable(c);
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Enabled = false;
                }
            }
        }


        private void menu_first_Click(object sender, EventArgs e)
        {
            Menu_Sel = "First";
            i = 0;
            f_show(i);
        }

        private void menu_previous_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Priv";
            i = i - 1;
            f_show(i);
            if (i < 0) i = 0;
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Next";
            i = i + 1;
            f_show(i);
            if (i > LS1.Count - 1) i = LS1.Count - 1;
        }

        private void menu_last_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Last";
            i = LS1.Count() - 1;
            f_show(i);
        }


        private void menu_edit_Click(object sender, EventArgs e)
        {
            decimal C_Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            decimal C_Mm = 88;
            string C_Dept = f_pr_dept.Text;

            if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
            {
                Config.Show("此年度資料已關帳，無法異動。");
                return;
            }
            if (f_pr_no.Text != string.Empty)
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                //code_dearch_bt.Enabled = false;
                Col_Disable();
                Config.FontBlod(this, true);//字體加粗
            }
            else
            {
                Config.Show("請先查詢");
            }
        }





        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
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


        private void Sum_Pay1(object sender, EventArgs e)
        {
            if (Menu_Sel == "Upd")
            {
                f_bonus.Value = f_x_bonus.Value - f_s_tax.Value - f_s_bonus.Value;
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

        

        private void menu_Print_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(f_pr_no.Text))
            {
                Config.Show("請先查詢");
                return;
            }
            qrr205 IForm = new qrr205();

            IForm.rDept = f_pr_dept.Text;
            IForm.rYy = System.Convert.ToInt16(f_yy.Text);
            //IForm.rMm = System.Convert.ToInt16((f_mm.SelectedIndex) + 1);
            IForm.rPrno = f_pr_no.Text;
            IForm.rIsCall = "Y";
            IForm.SetValue();
            IForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu_Print_Click(null, null);
        }

        

        private void f_s_extra_ValueChanged(object sender, EventArgs e)
        {
            f_x_bonus.Value = f_t_bonus.Value + f_s_extra.Value;            
        }

        private void f_s_extra_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_s_tax.Focus();
        }

        private void f_s_tax_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_s_bonus.Focus();
        }

        private void f_s_bonus_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_memo.Focus();
        }

        private void f_memo_KeyUp(object sender, KeyEventArgs e)
        {            
            if (e.KeyData == Keys.Enter)
                f_s_hoday.Focus();
        }

        
        private void f_memo_Enter(object sender, EventArgs e)
        {
            f_memo.Focus();
            f_memo.Select(0,f_memo.Text.Length);
        }

        private void f_s_extra_Enter(object sender, EventArgs e)
        {  
            f_s_extra.Focus();
            f_s_extra.Select(0, 8);
        }

        private void f_s_tax_Enter(object sender, EventArgs e)
        {
            
            f_s_tax.Focus();
            f_s_tax.Select(0, 8);
        }

        private void f_s_bonus_Enter(object sender, EventArgs e)
        {
            f_s_bonus.Focus();
            f_s_bonus.Select(0, 8);
        }

        private void pri050_KeyDown(object sender, KeyEventArgs e)
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

        

        private void button1_Click(object sender, EventArgs e)
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            var Dept = f_pr_dept.Text;
            var Cdept = f_pr_cdept.Text;
                        
            wPrno fm = new wPrno(Yy, Dept, Cdept, SType);
            fm.LS = LPrno;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                LPrno = fm.LS;
            }
        }

        


        private void f_s_hoday_ValueChanged(object sender, EventArgs e)
        {
            //應付年終獎金(基準年終獎金+特休未請補助-扣減請假)
            f_t_bonus.Value = f_y_bonus.Value + f_bonus_ho.Value - f_s_hoday.Value;

            //年度總獎金(應付年終獎金+主管調整增加數)
            f_x_bonus.Value = f_t_bonus.Value + f_s_extra.Value;

            //實領獎金(年度總獎金-應付稅額-預付獎金)
            f_bonus.Value = f_x_bonus.Value - f_s_tax.Value - f_s_bonus.Value;
        }

        private void f_s_hoday_Click(object sender, EventArgs e)
        {
            f_s_hoday.Focus();
            f_s_hoday.Select(0, 8);
        }

        private void f_s_hoday_Enter(object sender, EventArgs e)
        {
            f_s_hoday.Focus();
            f_s_hoday.Select(0, 8);
        }

        private void f_s_hoday_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_hoday.Focus();
        }

        private void f_hoday_Enter(object sender, EventArgs e)
        {
            f_hoday.Focus();
            f_hoday.Select(0, 8);
        }

        private void f_hoday_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_memo.Focus();
        }

        
    }
}
