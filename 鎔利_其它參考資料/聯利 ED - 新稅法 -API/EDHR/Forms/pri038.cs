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
using Microsoft.Reporting.WinForms;

namespace EDHR.Forms
{
    public partial class pri038 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt023> LS1 = new List<prt023>();
        prt016 p_prt016 = new prt016();

        public pri038()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);            
            Cont_type();//合同類別
            Rem_code();//解除原因
            set_dept();
            groupBox1.Enabled = false;
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void Cont_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("1:固定期限", "1"));
            data.Add(new DictionaryEntry("2:無固定期", "2"));
            f_cont_type.DisplayMember = "Key";
            f_cont_type.ValueMember = "Value";
            f_cont_type.DataSource = data;
        }

        private void Rem_code()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("01-用人單位停業", "01"));
            data.Add(new DictionaryEntry("02-勞動者死亡或失蹤", "02"));
            data.Add(new DictionaryEntry("03-勞動者開始享受養老保險待遇", "03"));
            data.Add(new DictionaryEntry("04-用人單位裁員", "04"));
            data.Add(new DictionaryEntry("05-勞動者按勞動合同法38條規定解除", "05"));
            data.Add(new DictionaryEntry("06-勞動者單方解除", "06"));
            data.Add(new DictionaryEntry("07-用人單位破產", "07"));
            data.Add(new DictionaryEntry("08-用人單位按勞動合同法40條規定解除", "08"));
            data.Add(new DictionaryEntry("09-用人單位按勞動合同法39條規定解除", "09"));
            data.Add(new DictionaryEntry("10-勞動者試用期內解除", "10"));
            data.Add(new DictionaryEntry("11-協商一致解除--個人原因", "11"));
            data.Add(new DictionaryEntry("12-協商一致解除--單位原因", "12"));
            data.Add(new DictionaryEntry("13-勞動合同期滿", "13"));
            data.Add(new DictionaryEntry("14-行政法規規定的其他情形", "14"));
            f_rem_code.DisplayMember = "Key";
            f_rem_code.ValueMember = "Value";
            f_rem_code.DataSource = data;
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
            //f_trno.Text = "--系統給號--";
            get_enable();

            f_beg_date_s.Enabled = true;
            f_end_date_s.Enabled = true;

            f_cont_type.SelectedIndex = 1;
            //設起始日           
            f_beg_date_s.Value = DateTime.Now;
            f_beg_date.Text = f_beg_date_s.Value.ToShortDateString();
            //設中止日
            Set_EndDate();

            //算合同期現合計--幾年幾月
            Get_yymm();

            //處理group1
            Clear_Group1();
            code_dearch_bt_Click(sender, e);
        }

        private void Clear_Group1()
        {
            f_rem_date.Text = "";
            f_rem_no.Text = "";
            f_memo.Text = "";
            f_rem_code.SelectedIndex = 0;
            groupBox1.Enabled = false;
        }

        private void Set_EndDate()
        {
            f_end_date_s.Enabled = true;
            int yy = System.DateTime.Now.Year;
            yy = yy + 2;
            string p_date = string.Format("{0}/{1}/{2}", yy.ToString(), "12", "31");
            DateTime dt = System.Convert.ToDateTime(p_date);
            f_end_date_s.Value = dt;
            f_end_date.Text = f_end_date_s.Value.ToShortDateString();
        }

        private void Get_yymm()
        {
            Int32 sum_y, sum_m,yy1,yy2,mm1,mm2,dd1,dd2 = 0;
            yy1 = f_beg_date_s.Value.Year;
            mm1 = f_beg_date_s.Value.Month;
            dd1 = f_beg_date_s.Value.Day;

            yy2 = f_end_date_s.Value.Year;
            mm2 = f_end_date_s.Value.Month;
            dd2 = f_end_date_s.Value.Day;

            if (dd2 < dd1)
            {
                dd2 = dd2 + 30;
                mm2 = mm2 - 1;
            }

            if (mm2 < mm1)
            {
                mm2 = mm2 + 12;
                yy2 = yy2 - 1;
            }

            yy1 = yy2 - yy1;
            mm1 = mm2 - mm1;
            dd1 = dd2 - dd1;
            sum_y = yy1;
            sum_m = (dd1 / 30);
            sum_m = sum_m + mm1;
            yy1 = sum_m / 12;
            sum_y = sum_y + yy1;
            sum_m = sum_m - (yy1 * 12);

            if (sum_m < 0)
            {
                sum_m = sum_m + 12;
                sum_y = sum_y - 1;
            }

            f_cont_year.Text = sum_y.ToString();
            f_cont_month.Text = sum_m.ToString();
        }

        private void get_enable()
        {   
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
            f_comp.Enabled = false;
            f_comp_name.Enabled = false;
            f_dept.Enabled = false;
            f_pr_work.Enabled = false;
            f_pr_work_name.Enabled = false;
            f_position.Enabled = false;
            f_position_name.Enabled = false;
            f_cont_seq.Enabled = false;
            f_cont_not.Enabled = false;
            f_cont_year.Enabled = false;
            f_cont_month.Enabled = false;
            f_idno.Enabled = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
            f_cont_type.SelectedIndex = 0;
            f_rem_code.SelectedIndex = 0;
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
            }
            f_add_date.Enabled = false;
            f_add_user.Enabled = false;
            f_mod_date.Enabled = false;
            f_mod_user.Enabled = false;
            f_idno.Enabled = false;
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
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
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
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Insert(), f_pr_no.Text, f_pr_name.Text));
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
                f_beg_date_s.Enabled = false;
                f_end_date_s.Enabled = false;
                f_rem_date_s.Enabled = false;
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

            //解除勞動合同
            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定解除?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Delete());
                        if (Config.Message("是否列印解除終止勞動合同證明書") == "Y")
                        {
                            print();
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

            if (f_pr_no.Text == System.String.Empty)
            {
                Config.Show("員工編號不可空白");
                f_pr_no.Focus();
                return false;
            }
            if (f_cont_no.Text == System.String.Empty)
            {
                Config.Show("不可空白");
                f_cont_no.Focus();
                return false;
            }

            foreach (var it in prt023.ToDoList("",f_dept.SelectedValue.ToString()))
            {
                if (it.Pr_no != f_pr_no.Text && it.Cont_no == f_cont_no.Text)
                {
                    Config.Show("與他人證號相同");
                    f_cont_no.Focus();
                    return false;
                }
            }

            return true;
        }



        

        private string f_Insert()
        {
            return String.Format("{0}", f_Insert_prt023());
        }

        private string f_Update()
        {
            return String.Format("{0}", f_Update_prt023());
        }

        private string f_Delete()
        {
            return String.Format("{0}", f_Delete_prt023());
        }
        

        private string f_Insert_prt023()
        {   
            var p_prt023 = new prt023();
            p_prt023.Dept = f_dept.SelectedValue.ToString();
            p_prt023.Pr_no = f_pr_no.Text;
            p_prt023.Cont_seq = System.Convert.ToInt32(f_cont_seq.Text);
            p_prt023.Cont_no = f_cont_no.Text;
            p_prt023.Cont_type = f_cont_type.SelectedValue.ToString();
            p_prt023.Beg_date = f_beg_date.Text;
            p_prt023.End_date = f_end_date.Text;
            p_prt023.Cont_year =  System.Convert.ToInt32(f_cont_year.Text);
            p_prt023.Cont_month = System.Convert.ToInt32(f_cont_month.Text);
            p_prt023.Cont_not = System.Convert.ToInt32(f_cont_not.Text);
            p_prt023.Rem_date = null;
            p_prt023.Rem_no = null;
            p_prt023.Rem_code = null;
            p_prt023.Memo = null;
            return p_prt023.Insert();
        }

        

        private string f_Update_prt023()
        {   
            var p_prt023 = new prt023();
            p_prt023.Dept = f_dept.SelectedValue.ToString();
            p_prt023.Pr_no = f_pr_no.Text;
            p_prt023.Cont_seq = System.Convert.ToInt32(f_cont_seq.Text);
            p_prt023.Cont_no = f_cont_no.Text;
            p_prt023.Cont_type = f_cont_type.SelectedValue.ToString();
            p_prt023.Beg_date = f_beg_date.Text;
            p_prt023.End_date = f_end_date.Text;
            p_prt023.Cont_year = System.Convert.ToInt32(f_cont_year.Text);
            p_prt023.Cont_month = System.Convert.ToInt32(f_cont_month.Text);
            p_prt023.Cont_not = System.Convert.ToInt32(f_cont_not.Text);
            return p_prt023.Update(p_prt023.Pr_no, p_prt023.Cont_seq);
        }


        private string f_Delete_prt023()
        {
            var p_prt023 = new prt023();
            p_prt023.Dept = f_dept.SelectedValue.ToString();
            p_prt023.Pr_no = f_pr_no.Text;
            p_prt023.Cont_seq = System.Convert.ToInt32(f_cont_seq.Text);
            p_prt023.Cont_no = f_cont_no.Text;
            p_prt023.Cont_type = f_cont_type.SelectedValue.ToString();
            p_prt023.Beg_date = f_beg_date.Text;
            p_prt023.End_date = f_end_date.Text;
            p_prt023.Cont_year = System.Convert.ToInt32(f_cont_year.Text);
            p_prt023.Cont_month = System.Convert.ToInt32(f_cont_month.Text);
            p_prt023.Cont_not = System.Convert.ToInt32(f_cont_not.Text);
            p_prt023.Rem_code = f_rem_code.SelectedValue.ToString();
            p_prt023.Rem_date = f_rem_date.Text;
            p_prt023.Rem_no = f_rem_no.Text;
            p_prt023.Memo = f_memo.Text;
            return p_prt023.Update(p_prt023.Pr_no, p_prt023.Cont_seq);
        }



        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            Clear_Group1();
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt023.ToDoList(f_pr_no.Text,f_dept.SelectedValue.ToString()).ToList();
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
                f_dept.SelectedValue = LS1[idx].Dept;
                f_pr_no.Text = LS1[idx].Pr_no;
                Find_p(f_pr_no.Text);
                f_cont_seq.Text = LS1[idx].Cont_seq.ToString();
                f_cont_no.Text = LS1[idx].Cont_no;
                f_cont_type.SelectedValue = LS1[idx].Cont_type.ToString();
                f_beg_date.Text = LS1[idx].Beg_date;
                f_end_date.Text = LS1[idx].End_date;
                f_cont_year.Text = LS1[idx].Cont_year.ToString();
                f_cont_month.Text = LS1[idx].Cont_month.ToString();
                f_cont_not.Text = LS1[idx].Cont_not.ToString();
                f_rem_no.Text = LS1[idx].Rem_no;
                f_rem_code.SelectedValue = LS1[idx].Rem_code.ToString();
                f_memo.Text = LS1[idx].Memo;
                f_rem_date.Text = LS1[idx].Rem_date;
                f_add_date.Text = LS1[idx].Add_date.ToString();
                f_add_user.Text = LS1[idx].Add_user.Trim();
                f_mod_date.Text = LS1[idx].Mod_date.ToString();
                f_mod_user.Text = LS1[idx].Mod_user.Trim();
                if (f_rem_no.Text != string.Empty)
                {
                    mnu_print.Enabled = true;
                }
                else {
                    mnu_print.Enabled = false;
                }
            }
        }

        private void menu_first_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            i = 0;
            f_show(i);
        }

        private void menu_previous_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            i = i - 1;
            f_show(i);
            if (i < 0) i = 0;
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            i = i + 1;
            f_show(i);
            if (i > LS1.Count - 1) i = LS1.Count - 1;
        }

        private void menu_last_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            i = LS1.Count() - 1;
            f_show(i);
        }


        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
                get_enable();
                code_dearch_bt.Enabled = false;

                f_end_date_s.Enabled = true;
                f_beg_date_s.Enabled = true;

                if (f_rem_no.Text != System.String.Empty)
                {
                    Config.Show("此筆資料已解除");
                    groupBox1.Enabled = false;
                }
                f_cont_no.Focus();
            }
            else
            {
                Config.Show("請先查詢");
            }
        }
        
        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            string _type = "";
            if (Menu_Sel == "Add")
                _type = "I";//在職
            if (Menu_Sel == "Qry")
                _type = null;//全部

            
            pri019w fm = new pri019w(_type,f_dept.SelectedValue.ToString());//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                Find_p(f_pr_no.Text);
            }
            if (Menu_Sel == "Add")
            {
                //找工作證號
                f_cont_no.Text = null;
                foreach (var a in prt023.ToDoList("",f_pr_no.Text))
                {
                    f_cont_no.Text = a.Cont_no;
                }
                f_cont_seq.Text = prt023.GetCont_seq(f_pr_no.Text).ToString();//序號
                f_cont_not.Text = prt023.GetCont_not(f_pr_no.Text).ToString();//簽約次數
            }

        }


       

        private void Find_p(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_comp.Text = p_prt016.Pr_company;
            f_comp_name.Text = sst011.Get(Login.DEPT) == null ? "" : sst011.Get(Login.DEPT).Company_shname;
            f_dept.SelectedValue = p_prt016.Pr_dept;
            f_pr_work.Text = p_prt016.Pr_work;
            f_pr_work_name.Text = prt003.Get(f_pr_work.Text) == null ? "" : prt003.Get(f_pr_work.Text).Code_desc;
            f_position.Text = p_prt016.Position;
            f_position_name.Text = prt002.Get(f_position.Text) == null ? "" : prt002.Get(f_position.Text).Code_desc;
            
        }

        private void f_beg_date_ValueChanged(object sender, EventArgs e)
        {
            f_beg_date.Text = f_beg_date_s.Value.ToString("yyyy/MM/dd");
            Get_yymm();
        }

        private void f_end_date_ValueChanged(object sender, EventArgs e)
        {
            f_end_date.Text = f_end_date_s.Value.ToString("yyyy/MM/dd");
            Get_yymm();
        }

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Del";
                SetMotherboard(Motherboard);
                get_enable();

                f_cont_no.Enabled = false;
                f_cont_type.Enabled = false;
                f_beg_date.Enabled = false;
                f_beg_date_s.Enabled = false;
                f_end_date.Enabled = false;
                f_end_date_s.Enabled = false;
                
                groupBox1.Enabled = true;
                if (f_rem_no.Text != System.String.Empty)
                {
                    Config.Show("此筆資料已解除");
                    groupBox1.Enabled = false;
                }
                else
                {
                    //給解除證書號
                    f_rem_date_s.Enabled = true;
                    f_rem_date_s.Value = System.DateTime.Now;
                    //f_rem_no.Text = Get_Rem_no();
                    f_rem_no.Enabled = false;
                    f_rem_code.SelectedIndex = 13;
                }
            }
            else
            {
                Config.Show("請先查詢");
            }
        }


        private string Get_Rem_no()
        {
            string tmp_no,tmp_ss = "";
            string tmp_yy, tmp_mm, tmp_dd = "";
            double yy = f_rem_date_s.Value.Year;
            double mm = f_rem_date_s.Value.Month;
            double dd = f_rem_date_s.Value.Day;
            yy = yy - 2000;
            tmp_yy = yy.ToString("00");
            tmp_mm = mm.ToString("00");
            tmp_dd = dd.ToString("00");
            tmp_ss = prt023.GetRem_no(f_dept.SelectedValue.ToString(),f_rem_date_s.Value.ToString("yyyy/MM/dd"));
            tmp_no = f_dept.SelectedValue.ToString() + tmp_yy + tmp_mm + tmp_dd + tmp_ss;
            return tmp_no;
        }

        private void f_rem_date_ValueChanged(object sender, EventArgs e)
        {
            //解除合同
            if (Menu_Sel == "Del")
            {
                f_rem_no.Text = Get_Rem_no();
            }
            f_rem_date.Text = f_rem_date_s.Value.ToString("yyyy/MM/dd");
        }

        private void f_cont_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == ""||Menu_Sel==null) return;
            if (Menu_Sel=="Add"||Menu_Sel=="Upd"){
                if (f_cont_type.SelectedIndex == 0)
                    f_cont_type.SelectedIndex = 1;
            }
            if (f_cont_type.SelectedValue.ToString() == "2")
            {
                f_end_date.Text = null;
                f_end_date_s.Enabled = false;
                f_cont_year.Text = "0";
                f_cont_month.Text = "0";
            }
            else
            {                
                Set_EndDate();
                f_end_date_s.Enabled = true;
                //算合同期現合計--幾年幾月
                Get_yymm();
            }
        }

        private void f_rem_code_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Del")
            {
                if (f_rem_code.SelectedIndex == 0)
                    f_rem_code.SelectedIndex = 1;
            }
        }

        private void mnu_print_Click(object sender, EventArgs e)
        {
            //print();//跑RS報表
            print_cr();//跑CR報表
        }

        private void print_cr()
        {
            crr044 p_crr044 = new crr044();
            p_crr044.r_Dept = f_dept.SelectedValue.ToString();
            p_crr044.r_Prno = f_pr_no.Text;
            p_crr044.r_Cont_seq = System.Convert.ToInt32(f_cont_seq.Text);

            p_crr044.SetValue();
            p_crr044.Show();
        }


        private  void print()
        {
            //prr021 r_prr021 = new prr021();
            //r_prr021.Rem_no = f_rem_no.Text;
            //r_prr021.ShowDialog();

            ReportParameter rp1 = new ReportParameter("rem_no");
            rp1.Values.Add(f_rem_no.Text);

            ReportParameter[] rparray = new ReportParameter[] { rp1 };

            ReportView fm = new ReportView("/ERP/prr021", rparray);

            if (fm.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void f_pr_no_TextChanged(object sender, EventArgs e)
        {
            f_idno.Text = prt016.Get(f_pr_no.Text) == null ? "" : prt016.Get(f_pr_no.Text).Pr_idno;
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

        private void pri038_KeyDown(object sender, KeyEventArgs e)
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

    }
}
