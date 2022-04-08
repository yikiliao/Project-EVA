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
    public partial class pri029 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt021> LS1 = new List<prt021>();
        int Seq_no = 0;
        int Priv_Seq_no = 0;
        string old_date = "";
        string Dept = Login.DEPT;

        public string rPrno;//工號
        public bool rOK = false;//按下確認鍵
        prt016 p_prt016 = new prt016();

        public pri029()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_work("");//下拉選單-職等
            D_type();//下拉選單-職級
            D_Cdpet();//部門
        }

        private void D_Cdpet()
        {
            ArrayList data = new ArrayList();
            foreach (var i in prt001.ToDoList(Dept).ToList())
            {
                data.Add(new DictionaryEntry(i.Department_name_new, i.Department_code));
            }
            f_cdept.DisplayMember = "Key";
            f_cdept.ValueMember = "Value";
            f_cdept.DataSource = data;
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void D_work(string rDept)
        {
            f_code.Text = "";
            f_code.DataSource = prt016.ToDoList_wk_code(rDept).ToList();
            f_code.DisplayMember = "wk_code";
            f_code.ValueMember = "wk_code";
        }

        private void D_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry(" 1", "1"));
            data.Add(new DictionaryEntry(" 2", "2"));
            data.Add(new DictionaryEntry(" 3", "3"));
            data.Add(new DictionaryEntry(" 4", "4"));
            data.Add(new DictionaryEntry(" 5", "5"));
            data.Add(new DictionaryEntry(" 6", "6"));
            data.Add(new DictionaryEntry(" 7", "7"));
            data.Add(new DictionaryEntry(" 8", "8"));
            data.Add(new DictionaryEntry(" 9", "9"));
            data.Add(new DictionaryEntry("10", "10"));
            data.Add(new DictionaryEntry("11", "11"));
            data.Add(new DictionaryEntry("12", "1"));
            data.Add(new DictionaryEntry("13", "13"));
            data.Add(new DictionaryEntry("14", "14"));
            data.Add(new DictionaryEntry("15", "15"));
            data.Add(new DictionaryEntry("16", "16"));
            data.Add(new DictionaryEntry("17", "17"));
            data.Add(new DictionaryEntry("18", "18"));
            data.Add(new DictionaryEntry("19", "19"));
            data.Add(new DictionaryEntry("20", "20"));
            data.Add(new DictionaryEntry("21", "21"));
            data.Add(new DictionaryEntry("22", "22"));
            data.Add(new DictionaryEntry("23", "23"));
            data.Add(new DictionaryEntry("24", "24"));
            data.Add(new DictionaryEntry("25", "25"));
            data.Add(new DictionaryEntry("26", "26"));
            data.Add(new DictionaryEntry("27", "27"));
            data.Add(new DictionaryEntry("28", "28"));
            data.Add(new DictionaryEntry("29", "29"));
            data.Add(new DictionaryEntry("30", "30"));
            f_code1.DisplayMember = "Key";
            f_code1.ValueMember = "Value";
            f_code1.DataSource = data;
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
            Disb_p();//欄位disable
            f_code.Enabled = false;
            f_prno_bt_Click(sender, e);
            bindingNavigator1.Enabled = false;
        }

        private void add_zero()
        {   
            f_pay_3.Text = "0";
            f_pay_4.Text = "0";
            f_pay_5.Text = "0";
            f_pay_6.Text = "0";
            f_pay_7.Text = "0";
            f_pay_8.Text = "0";
            f_pay_9.Text = "0";
            f_pay_10.Text = "0";
            f_pay_tot.Text = "0";
            f_pay_tot.Enabled = false;
            f_sdate.Enabled = false;f_sdate_s.Value = DateTime.Now;
            f_edate.Enabled = false;
            f_code1.SelectedIndex = 0;
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
                    D_work("");//下拉選單-職等
                    f_code1.SelectedIndex = 0;//職級
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
        //    D_work("");//下拉選單-職等
        //    f_code1.SelectedIndex = 0;//職級
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
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
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
                InitMotherboard(this);
            }
        }


        private bool f_Check()
        {
            if (f_pr_no.Text == String.Empty)
            {
                Config.Show("工號不可空白");
                f_pr_no.Focus();
                return false;
            }

            if (f_code.Text == String.Empty)
            {
                Config.Show("職等不可空白");
                f_code.Focus();
                return false;
            }
                        
            if (f_code1.SelectedIndex == 0)
            {
                Config.Show("職級不可空白");
                f_code1.Focus();
                return false;
            }
            return true;
        }

        private string f_Insert()
        {
            return String.Format("{0}\n{1}\n{2}", f_Insert_prt021(), f_Update_priv_prt021(), f_Update_prt028());
        }

        private string f_Insert_prt021()
        {
            var p_prt021 = new prt021();
            p_prt021.Pr_company = Dept;//公司
            p_prt021.Pr_dept = f_dept.SelectedValue.ToString();//廠部
            p_prt021.Pr_no = f_pr_no.Text;
            p_prt021.Seq_no = Seq_no;
            //p_prt021.Seq_no = prt021.Get_Seq_no(f_pr_no.Text);//找最大值
            //Priv_Seq_no = prt021.Get_Seq_no(f_pr_no.Text)-1;//上一筆序號
            p_prt021.Sdate = f_sdate.Text;
            p_prt021.Edate = f_edate.Text;
            p_prt021.Wk_code = f_code.SelectedValue.ToString();            
            p_prt021.Code1 = Convert.ToInt32(f_code1.SelectedValue.ToString());
            p_prt021.Pay_3 = Convert.ToDecimal(f_pay_3.Text);
            p_prt021.Pay_4 = Convert.ToDecimal(f_pay_4.Text);
            p_prt021.Pay_5 = Convert.ToDecimal(f_pay_5.Text);
            p_prt021.Pay_6 = Convert.ToDecimal(f_pay_6.Text);
            p_prt021.Pay_7 = Convert.ToDecimal(f_pay_7.Text);
            p_prt021.Pay_8 = Convert.ToDecimal(f_pay_8.Text);
            p_prt021.Pay_9 = Convert.ToDecimal(f_pay_9.Text);
            p_prt021.Pay_10 = Convert.ToDecimal(f_pay_10.Text);
            return p_prt021.Insert();
        }

        private string f_Update_priv_prt021()
        {
            if (Priv_Seq_no > 0)
            {
                //修改上一筆資料edate
                var p_prt021 = new prt021();
                p_prt021 = prt021.Get(f_pr_no.Text, Priv_Seq_no);
                p_prt021.Edate = f_sdate_s.Value.AddDays(-1).ToString("yyyy/MM/dd");
                return p_prt021.Update(f_pr_no.Text, Priv_Seq_no);
            }
            else
            { 
                return "";
            }
        }

        private string f_Update_prt028()
        {
            var p_prt028 = new prt028();
            p_prt028 = prt028.Get(f_pr_no.Text);
            if (p_prt028 != null)
            {
                p_prt028.Wk_code = f_code.SelectedValue.ToString();                
                return p_prt028.Update(f_pr_no.Text);
            }
            else
            {
                return "";
            }
        }


        private string f_Update()
        {            
            return String.Format("{0}\n{1}\n{2}", f_Update_prt021(), f_Update_priv_prt021(), f_Update_prt028());
        }

        private string f_Update_prt021()
        {
            var p_prt021 = new prt021();
            p_prt021.Sdate = f_sdate.Text;
            p_prt021.Edate = f_edate.Text;            
            p_prt021.Wk_code = f_code.SelectedValue.ToString();
            p_prt021.Code1 = Convert.ToInt32(f_code1.SelectedValue.ToString());
            p_prt021.Pay_3 = Convert.ToDecimal(f_pay_3.Text);
            p_prt021.Pay_4 = Convert.ToDecimal(f_pay_4.Text);
            p_prt021.Pay_5 = Convert.ToDecimal(f_pay_5.Text);
            p_prt021.Pay_6 = Convert.ToDecimal(f_pay_6.Text);
            p_prt021.Pay_7 = Convert.ToDecimal(f_pay_7.Text);
            p_prt021.Pay_8 = Convert.ToDecimal(f_pay_8.Text);
            p_prt021.Pay_9 = Convert.ToDecimal(f_pay_9.Text);
            p_prt021.Pay_10 = Convert.ToDecimal(f_pay_10.Text);
            return p_prt021.Update(f_pr_no.Text, Seq_no);
        }


        private string f_Delete()
        {
            return String.Format("{0}\n{1}", f_Delete_prt021(), f_Delete_priv_prt021());
        }

        private string f_Delete_prt021()
        {
            var p_prt021 = new prt021();
            return p_prt021.Delete(f_pr_no.Text,Seq_no);
        }

        private string f_Delete_priv_prt021()
        {
            if (Priv_Seq_no > 0)
            {
                //修改上一筆資料edate
                var p_prt021 = new prt021();
                p_prt021 = prt021.Get(f_pr_no.Text, Priv_Seq_no);
                p_prt021.Edate = null;
                return p_prt021.Update(f_pr_no.Text, Priv_Seq_no);
            }
            else
            {
                return "";
            }
        }


        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            FormQuery();//查詢畫面
            if (rOK == true)
                confirm_Click(sender, e);//確認按鍵
            else
                InitColumn(this);//初始
        }

        private void FormQuery()
        {
            pri029Q fm = new pri029Q();
            if (fm.ShowDialog() == DialogResult.OK)
            { 
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
            LS1 = prt021.ToDoList(Dept,rPrno, null).ToList();
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
                var q_prt021 = prt021.Get(LS1[idx].Pr_no, LS1[idx].Seq_no);

                f_pr_no.Text = q_prt021.Pr_no;
                f_dept.SelectedValue = q_prt021.Pr_dept;
                Find_p(f_pr_no.Text);
                D_work(Dept);//下拉選單-職等
                f_code.SelectedValue = q_prt021.Wk_code.ToString();//職等
                f_code1.SelectedValue = q_prt021.Code1.ToString();//職級
                f_edate.Text = string.IsNullOrEmpty(q_prt021.Edate) ? "" : Convert.ToDateTime(q_prt021.Edate).ToString("yyyy/MM/dd");

                f_pay_3.Text = q_prt021.Pay_3.ToString();
                f_pay_4.Text = q_prt021.Pay_4.ToString();
                f_pay_5.Text = q_prt021.Pay_5.ToString();
                f_pay_6.Text = q_prt021.Pay_6.ToString();
                f_pay_7.Text = q_prt021.Pay_7.ToString();
                f_pay_8.Text = q_prt021.Pay_8.ToString();
                f_pay_9.Text = q_prt021.Pay_9.ToString();
                f_pay_10.Text = q_prt021.Pay_10.ToString();
                f_add_date.Text = q_prt021.Add_date.ToString();
                f_add_user.Text = q_prt021.Add_user.Trim();
                f_mod_date.Text = q_prt021.Mod_date.ToString();
                f_mod_user.Text = q_prt021.Mod_user.Trim();
                f_sdate_s.Value = DateTime.Parse(string.Format("{0}", "1900/01/01"));
                f_sdate_s.Value = Convert.ToDateTime(q_prt021.Sdate);
                Seq_no = Convert.ToInt32(q_prt021.Seq_no);
                Priv_Seq_no = Seq_no - 1;
                old_date = q_prt021.Sdate;
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
        //        f_pr_no.Text = LS1[idx].Pr_no;
        //        f_dept.SelectedValue = LS1[idx].Pr_dept;
        //        Find_p(f_pr_no.Text);                
        //        D_work(Dept);//下拉選單-職等
        //        f_code.SelectedValue = LS1[idx].Wk_code.ToString();//職等
        //        f_code1.SelectedValue = LS1[idx].Code1.ToString();//職級




        //        //f_sdate.Text = LS1[idx].Sdate;
        //        f_edate.Text = string.IsNullOrEmpty(LS1[idx].Edate) ? "" : Convert.ToDateTime(LS1[idx].Edate).ToString("yyyy/MM/dd");

        //        f_pay_3.Text = LS1[idx].Pay_3.ToString();
        //        f_pay_4.Text = LS1[idx].Pay_4.ToString();
        //        f_pay_5.Text = LS1[idx].Pay_5.ToString();
        //        f_pay_6.Text = LS1[idx].Pay_6.ToString();
        //        f_pay_7.Text = LS1[idx].Pay_7.ToString();
        //        f_pay_8.Text = LS1[idx].Pay_8.ToString();
        //        f_pay_9.Text = LS1[idx].Pay_9.ToString();
        //        f_pay_10.Text = LS1[idx].Pay_10.ToString();
        //        f_add_date.Text = LS1[idx].Add_date.ToString();
        //        f_add_user.Text = LS1[idx].Add_user.Trim();
        //        f_mod_date.Text = LS1[idx].Mod_date.ToString();
        //        f_mod_user.Text = LS1[idx].Mod_user.Trim();
        //        f_sdate_s.Value =DateTime.Parse(string.Format("{0}","1900/01/01"));
        //        f_sdate_s.Value = Convert.ToDateTime(LS1[idx].Sdate);
        //        Seq_no = Convert.ToInt32(LS1[idx].Seq_no);
        //        Priv_Seq_no = Seq_no - 1;
        //        old_date = LS1[idx].Sdate;
        //    }
        //}

        private void menu_first_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
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
            if (f_pr_no.Text != string.Empty)
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
            if (f_pr_no.Text != string.Empty)
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
            if (f_pr_no.Text != string.Empty)
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
            if (f_pr_no.Text != string.Empty)
            {
                if (!string.IsNullOrEmpty(f_edate.Text))
                {
                    Config.Show("此筆資料不是最新之薪資  不可修改");
                    return;
                }
                if (p_prt016.Pr_leave_date != string.Empty)
                {
                    Config.Show("已離職無法異動");
                    return;
                }
                Menu_Sel = "Upd";
                SetMotherboard(this);
                Disb_p();
                f_pay_3.Select();
                f_pay_3.Focus();
                f_prno_bt.Enabled = false;
                f_pay_tot.ReadOnly = true;
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
        //    if (f_pr_no.Text != "" && Menu_Sel == "Qry")
        //    {
        //        if (!string.IsNullOrEmpty(f_edate.Text))
        //        {
        //            Config.Show("此筆資料不是最新之薪資  不可修改");
        //            return;
        //        }
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        Disb_p();
        //        f_pay_3.Select();
        //        f_pay_3.Focus();
        //        f_prno_bt.Enabled = false;
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
            {
                if (!string.IsNullOrEmpty(f_edate.Text))
                {
                    Config.Show("此筆資料不是最新之薪資  不可修改");
                    return;
                }
                if (p_prt016.Pr_leave_date != string.Empty)
                {
                    Config.Show("已離職無法異動");
                    return;
                }
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
        //    if (f_pr_no.Text != "" && Menu_Sel == "Qry")
        //    {
        //        if (!string.IsNullOrEmpty(f_edate.Text))
        //        {
        //            Config.Show("此筆資料不是最新之薪資  不可修改");
        //            return;
        //        }
        //        Menu_Sel = "Del"; 
        //        InitMotherboard(this);
        //        confirm_Click(sender, e);
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}

        

        private void f_prno_bt_Click(object sender, EventArgs e)
        {
            string _type = "";
            if (Menu_Sel == "Add")
                _type = "I";//在職
            if (Menu_Sel == "Qry")
                _type = "";//離職

            pri019w fm = new pri019w(_type,f_dept.SelectedValue.ToString());//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                Find_p_Add(f_pr_no.Text);
                if (Menu_Sel == "Add") 
                { 
                    add_zero();
                    Seq_no = prt021.Get_Seq_no(f_pr_no.Text);//找最大值
                    Priv_Seq_no = Seq_no - 1;//上一筆序號
                }
                    
            }
        }

        private void Disb_p()
        {            
            f_pr_no.Enabled=false;
            f_pr_name.Enabled = false;
            f_idno.Enabled = false;
            f_dept.Enabled = false;
            f_cdept.Enabled = false;
            f_sdate.Enabled = false;
            f_edate.Enabled = false;
        }
                

        private void Find_p(string Pr_no)
        {            
            p_prt016 = prt016.Get(Pr_no);
            if (p_prt016 == null)
            {
                Config.Show(string.Format("工號:{0}\n人事資料無此資料", Pr_no));
            }
            f_pr_name.Text = (p_prt016 == null ? "" : p_prt016.Pr_name);
            f_idno.Text = (p_prt016 == null ? "" : p_prt016.Pr_idno);
            f_cdept.SelectedValue = (p_prt016 == null ? "" : p_prt016.Pr_cdept);
        }

        private void Find_p_Add(string Pr_no)
        {
            var p_prt016 = new prt016();
            p_prt016 = prt016.Get(Pr_no);
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_idno.Text = p_prt016.Pr_idno;
            f_dept.SelectedValue = p_prt016.Pr_dept;
            f_cdept.SelectedValue = p_prt016.Pr_cdept;
            D_work(Dept);//下拉選單-職等
            f_code.SelectedValue = p_prt016.Wk_code;//職等 設定進去           
        }

        private void f_sdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_sdate.Text = f_sdate_s.Value.ToString("yyyy/MM/dd");
            if (Menu_Sel == "Add")
            {
                if (f_sdate.Text == DateTime.Now.ToString("yyyy/MM/dd"))
                {
                    return;
                }
                else
                {
                    if (f_sdate_s.Value < DateTime.Now)
                        Config.Show("生效日 < 系統日期");
                }
            }            
        }

        private void f_code1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Qry"||Menu_Sel=="Del")
                return;
            var p_prt011 = new prt011();            
            p_prt011 = prt011.Get(f_dept.SelectedValue.ToString(), f_code.Text);
            if (f_code1.SelectedIndex == 1) f_pay_3.Text = p_prt011.A1.ToString();
            if (f_code1.SelectedIndex == 2) f_pay_3.Text = p_prt011.A2.ToString();
            if (f_code1.SelectedIndex == 3) f_pay_3.Text = p_prt011.A3.ToString();
            if (f_code1.SelectedIndex == 4) f_pay_3.Text = p_prt011.A4.ToString();
            if (f_code1.SelectedIndex == 5) f_pay_3.Text = p_prt011.A5.ToString();
            if (f_code1.SelectedIndex == 6) f_pay_3.Text = p_prt011.A6.ToString();
            if (f_code1.SelectedIndex == 7) f_pay_3.Text = p_prt011.A7.ToString();
            if (f_code1.SelectedIndex == 8) f_pay_3.Text = p_prt011.A8.ToString();
            if (f_code1.SelectedIndex == 9) f_pay_3.Text = p_prt011.A9.ToString();
            if (f_code1.SelectedIndex == 10) f_pay_3.Text = p_prt011.A10.ToString();
            if (f_code1.SelectedIndex == 11) f_pay_3.Text = p_prt011.A11.ToString();
            if (f_code1.SelectedIndex == 12) f_pay_3.Text = p_prt011.A12.ToString();
            if (f_code1.SelectedIndex == 13) f_pay_3.Text = p_prt011.A13.ToString();
            if (f_code1.SelectedIndex == 14) f_pay_3.Text = p_prt011.A14.ToString();
            if (f_code1.SelectedIndex == 15) f_pay_3.Text = p_prt011.A15.ToString();
            if (f_code1.SelectedIndex == 16) f_pay_3.Text = p_prt011.A16.ToString();
            if (f_code1.SelectedIndex == 17) f_pay_3.Text = p_prt011.A17.ToString();
            if (f_code1.SelectedIndex == 18) f_pay_3.Text = p_prt011.A18.ToString();
            if (f_code1.SelectedIndex == 19) f_pay_3.Text = p_prt011.A19.ToString();
            if (f_code1.SelectedIndex == 20) f_pay_3.Text = p_prt011.A20.ToString();
            if (f_code1.SelectedIndex == 21) f_pay_3.Text = p_prt011.A21.ToString();
            if (f_code1.SelectedIndex == 22) f_pay_3.Text = p_prt011.A22.ToString();
            if (f_code1.SelectedIndex == 23) f_pay_3.Text = p_prt011.A23.ToString();
            if (f_code1.SelectedIndex == 24) f_pay_3.Text = p_prt011.A24.ToString();
            if (f_code1.SelectedIndex == 25) f_pay_3.Text = p_prt011.A25.ToString();
            if (f_code1.SelectedIndex == 26) f_pay_3.Text = p_prt011.A26.ToString();
            if (f_code1.SelectedIndex == 27) f_pay_3.Text = p_prt011.A27.ToString();
            if (f_code1.SelectedIndex == 28) f_pay_3.Text = p_prt011.A28.ToString();
            if (f_code1.SelectedIndex == 29) f_pay_3.Text = p_prt011.A29.ToString();
            if (f_code1.SelectedIndex == 30) f_pay_3.Text = p_prt011.A30.ToString();
            Sum_Pay();
            f_pay_3.Focus();
        }

        private void Sum_Pay()
        {
            Int32 p3, p4, p5, p6, p7, p8, p9, p10, aa = 0;
            p3 = string.IsNullOrEmpty(f_pay_3.Text) ? 0 : Convert.ToInt32(f_pay_3.Text);
            p4 = string.IsNullOrEmpty(f_pay_4.Text) ? 0 : Convert.ToInt32(f_pay_4.Text);
            p5 = string.IsNullOrEmpty(f_pay_5.Text) ? 0 : Convert.ToInt32(f_pay_5.Text);
            p6 = string.IsNullOrEmpty(f_pay_6.Text) ? 0 : Convert.ToInt32(f_pay_6.Text);
            p7 = string.IsNullOrEmpty(f_pay_7.Text) ? 0 : Convert.ToInt32(f_pay_7.Text);
            p8 = string.IsNullOrEmpty(f_pay_8.Text) ? 0 : Convert.ToInt32(f_pay_8.Text);
            p9 = string.IsNullOrEmpty(f_pay_9.Text) ? 0 : Convert.ToInt32(f_pay_9.Text);
            p10 = string.IsNullOrEmpty(f_pay_10.Text) ? 0 : Convert.ToInt32(f_pay_10.Text);
            aa = p3 + p4 + p5 + p6 + p7 + p8 + p9 + p10;
            f_pay_tot.Text = aa.ToString();

            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (string.IsNullOrEmpty(f_pay_3.Text)) f_pay_3.Text = "0";
                if (string.IsNullOrEmpty(f_pay_4.Text)) f_pay_4.Text = "0";
                if (string.IsNullOrEmpty(f_pay_5.Text)) f_pay_5.Text = "0";
                if (string.IsNullOrEmpty(f_pay_6.Text)) f_pay_6.Text = "0";
                if (string.IsNullOrEmpty(f_pay_7.Text)) f_pay_7.Text = "0";
                if (string.IsNullOrEmpty(f_pay_8.Text)) f_pay_8.Text = "0";
                if (string.IsNullOrEmpty(f_pay_9.Text)) f_pay_9.Text = "0";
                if (string.IsNullOrEmpty(f_pay_10.Text)) f_pay_10.Text = "0";
            }

        }

        private void isInt(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 48 || (byte)e.KeyChar > 57)//若小於0或大於9 
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true; //不可輸;鎖起來
                }
            }
        }

        private void f_pay_3_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_4.Focus();
        }

        private void f_pay_4_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_5.Focus();
        }

        private void f_pay_5_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_6.Focus();
        }

        private void f_pay_6_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_7.Focus();
        }

        private void f_pay_7_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_8.Focus();
        }

        private void f_pay_8_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_9.Focus();
        }

        private void f_pay_9_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_10.Focus();
        }

                
        

        private void f_pay_3_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_5_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_4_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_6_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_7_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_8_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_9_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }


        private void f_pay_11_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_12_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_10_TextChanged(object sender, EventArgs e)
        {
            Sum_Pay();
        }

        private void f_pay_10_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_pay_3.Focus();
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

        private void pri029_KeyDown(object sender, KeyEventArgs e)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pri029_Load(object sender, EventArgs e)
        {
            SetColumnToRight();            
        }
        
        private void SetColumnToRight()
        {
            f_pay_3.TextAlign = HorizontalAlignment.Right;
            f_pay_4.TextAlign = HorizontalAlignment.Right;
            f_pay_5.TextAlign = HorizontalAlignment.Right;
            f_pay_6.TextAlign = HorizontalAlignment.Right;
            f_pay_7.TextAlign = HorizontalAlignment.Right;
            f_pay_8.TextAlign = HorizontalAlignment.Right;
            f_pay_9.TextAlign = HorizontalAlignment.Right;
            f_pay_10.TextAlign = HorizontalAlignment.Right;
        }

    }
}
