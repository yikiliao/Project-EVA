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
    public partial class pri034 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt030L> LS1 = new List<prt030L>();
        prt016 p_prt016 = new prt016();
        string DataRang;//處理廠部範圍 

        public pri034()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            DataRang = Login.DEPT;
            D1();//下拉選單-班別
            D2();//下拉選單-遲到
            D3();//下拉選單-早退
            D4();//下拉選單-輪班津貼
            D5();//下拉選單-夜餐補助
        }

        private void D1()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry(" 1.平日", "1"));
            data.Add(new DictionaryEntry(" 2.假日", "2"));
            f_va_code3.DisplayMember = "Key";
            f_va_code3.ValueMember = "Value";
            f_va_code3.DataSource = data;
        }

        private void D2()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("N:準時", "N"));
            data.Add(new DictionaryEntry("A: 4-5 分鐘", "A"));
            data.Add(new DictionaryEntry("B:6-15 分鐘", "B"));
            data.Add(new DictionaryEntry("C:15分鐘以上", "C"));
            data.Add(new DictionaryEntry("D:一小時以上", "D"));
            f_va_code1.DisplayMember = "Key";
            f_va_code1.ValueMember = "Value";
            f_va_code1.DataSource = data;
        }

        private void D3()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("N:準時", "N"));
            data.Add(new DictionaryEntry("A:早退", "A"));
            f_va_code2.DisplayMember = "Key";
            f_va_code2.ValueMember = "Value";
            f_va_code2.DataSource = data;
        }

        private void D4()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("0", "0"));
            data.Add(new DictionaryEntry("10", "10"));
            f_pr_add1.DisplayMember = "Key";
            f_pr_add1.ValueMember = "Value";
            f_pr_add1.DataSource = data;
        }

        private void D5()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("0", "0"));
            data.Add(new DictionaryEntry("3", "3"));
            f_pr_add2.DisplayMember = "Key";
            f_pr_add2.ValueMember = "Value";
            f_pr_add2.DataSource = data;
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
            Col_Disable();
            Col_Vol();
            QueryDate(false);
        }

        private void Col_Disable()
        {
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
            f_pr_company.Enabled = false;
            f_pr_company_name.Enabled = false;
            f_pr_dept.Enabled = false;
            f_pr_dept_name.Enabled = false;
            f_pr_cdept.Enabled = false;
            f_pr_cdept_name.Enabled = false;
            f_pr_date.Enabled = false;
        }

        private void Col_Vol()
        {
            if (Menu_Sel == "Add")
            {
                f_pr_date_s.Value = DateTime.Now.AddDays(-1);                
                f_pr_wtime.Text = "8.0";
                f_pr_atime.Text = "0.0";
                f_va_time1.Text = "0.0";
                f_va_time2.Text = "0.0";
                f_pr_ntime.Text = "0.0";
                f_pr_add1.SelectedIndex = 1;
                f_pr_add2.SelectedIndex = 1;
                f_va_code1.SelectedIndex = 1;
                f_va_code2.SelectedIndex = 1;

                //班別
                if ((int)DateTime.Now.DayOfWeek == 0 || (int)DateTime.Now.DayOfWeek == 6)
                    f_va_code3.SelectedIndex = 2;
                else
                    f_va_code3.SelectedIndex = 1;

            }
            if (Menu_Sel == "Qry")
            {
                f_pr_date.Text = null;
                f_pr_add1.SelectedIndex = 0;
                f_pr_add2.SelectedIndex = 0;
                f_va_code3.SelectedIndex = 0;
                f_va_code1.SelectedIndex = 0;
                f_va_code2.SelectedIndex = 0;
            }
        }

        
        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
            QueryDate(false);
        }
                

        //所有欄位解除並清空
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                //if (a is Panel) SetColumn(a);
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
                //if (c is Panel) InitColumn(c);
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
                }
            }
        }

        //主板欄位限制
        private void InitMotherboard(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                //if (c is Panel) InitMotherboard(c);
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
                //if (a is Panel) SetMotherboard(a);
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
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_Check() == false)
                        return;
                    try
                    {
                        Config.Show(f_Insert());
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(Motherboard);
                QueryDate(false);
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
                InitMotherboard(Motherboard);
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
                InitMotherboard(Motherboard);
            }


        }

        private bool f_Check()
        {
            if (string.IsNullOrEmpty(f_pr_no.Text))
            {
                Config.Show("員工編號不可空白");
                f_pr_no.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(f_va_code3.Text))
            {
                Config.Show("假別不可空白");
                f_pr_no.Focus();
                f_va_code3.SelectedIndex = 1;
                return false;
            }
            if (prt030L.Get(f_pr_date.Text, f_pr_no.Text) != null)
            {
                Config.Show("已有此筆資料");
                f_pr_date_s.Focus();
                return false;
            }
            return true;
        }


        private string f_Insert()
        {
            return String.Format("{0}", f_Insert_1());
        }

        private string f_Update()
        {
            return String.Format("{0}", f_Update_1());
        }

        private string f_Delete()
        {
            return String.Format("{0}", f_Delete_1());
        }

        private string f_Insert_1()
        {   
            var p_prt030L = new prt030L();
            p_prt030L.Pr_company = f_pr_company.Text;//公司
            p_prt030L.Pr_dept = f_pr_dept.Text;//廠部
            p_prt030L.Pr_cdept = f_pr_cdept.Text;//部門代碼
            p_prt030L.Pr_date = f_pr_date_s.Value.ToString("yyyy/MM/dd");//日期
            p_prt030L.Pr_no = f_pr_no.Text;//工號
            p_prt030L.Pr_wtime = string.IsNullOrEmpty(f_pr_wtime.Text) ? 0 : System.Convert.ToDecimal(f_pr_wtime.Text);//上班時數
            p_prt030L.Pr_atime = string.IsNullOrEmpty(f_pr_atime.Text) ? 0 : System.Convert.ToDecimal(f_pr_atime.Text);//加班時數
            p_prt030L.Pr_add1 = System.Convert.ToInt32(f_pr_add1.SelectedValue);//輪班津貼
            p_prt030L.Pr_add2 = System.Convert.ToInt32(f_pr_add2.SelectedValue);//夜餐補助
            p_prt030L.Va_time1 = string.IsNullOrEmpty(f_va_time1.Text) ? 0 : System.Convert.ToDecimal(f_va_time1.Text);//請假扣錢時數
            p_prt030L.Va_time2 = string.IsNullOrEmpty(f_va_time2.Text) ? 0 : System.Convert.ToDecimal(f_va_time2.Text);//請假不扣錢時數
            p_prt030L.Pr_ntime = string.IsNullOrEmpty(f_pr_ntime.Text) ? 0 : System.Convert.ToDecimal(f_pr_ntime.Text);//曠職時數
            p_prt030L.Va_code1 = f_va_code1.SelectedValue.ToString();//遲到
            p_prt030L.Va_code2 = f_va_code2.SelectedValue.ToString();//早退
            p_prt030L.Va_code3 = f_va_code3.SelectedValue.ToString();//班別
            p_prt030L.Status_code = "N";//狀態
            return p_prt030L.Insert();
        }


        private string f_Update_1()
        {   
            var p_prt030L = new prt030L();
            p_prt030L.Pr_company = f_pr_company.Text;//公司
            p_prt030L.Pr_dept = f_pr_dept.Text;//廠部
            p_prt030L.Pr_cdept = f_pr_cdept.Text;//部門代碼
            p_prt030L.Pr_date = f_pr_date_s.Value.ToString("yyyy/MM/dd");//日期
            p_prt030L.Pr_no = f_pr_no.Text;//工號
            p_prt030L.Pr_wtime = string.IsNullOrEmpty(f_pr_wtime.Text) ? 0 : System.Convert.ToDecimal(f_pr_wtime.Text);//上班時數
            p_prt030L.Pr_atime = string.IsNullOrEmpty(f_pr_atime.Text) ? 0 : System.Convert.ToDecimal(f_pr_atime.Text);//加班時數
            p_prt030L.Pr_add1 = System.Convert.ToInt32(f_pr_add1.SelectedValue);//輪班津貼
            p_prt030L.Pr_add2 = System.Convert.ToInt32(f_pr_add2.SelectedValue);//夜餐補助
            p_prt030L.Va_time1 = string.IsNullOrEmpty(f_va_time1.Text) ? 0 : System.Convert.ToDecimal(f_va_time1.Text);//請假扣錢時數
            p_prt030L.Va_time2 = string.IsNullOrEmpty(f_va_time2.Text) ? 0 : System.Convert.ToDecimal(f_va_time2.Text);//請假不扣錢時數
            p_prt030L.Pr_ntime = string.IsNullOrEmpty(f_pr_ntime.Text) ? 0 : System.Convert.ToDecimal(f_pr_ntime.Text);//曠職時數
            p_prt030L.Va_code1 = f_va_code1.SelectedValue.ToString();//遲到
            p_prt030L.Va_code2 = f_va_code2.SelectedValue.ToString();//早退
            p_prt030L.Va_code3 = f_va_code3.SelectedValue.ToString();//班別
            p_prt030L.Status_code = "N";//狀態
            return p_prt030L.Update(p_prt030L.Pr_date, p_prt030L.Pr_no);
        }

        private string f_Delete_1()
        {
            var p_prt030L = new prt030L();
            return p_prt030L.Delete(f_pr_date.Text, f_pr_no.Text);
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            Col_Vol();
            QueryDate(true);
        }
                

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt030L.ToDoListEndDate("L", f_pr_date.Text, f_pr_date_end.Text, f_pr_no.Text).ToList();
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
                Find_p(LS1[idx].Pr_no);
                f_pr_date.Text =  DateTime.Parse(LS1[idx].Pr_date).ToString("yyyy/MM/dd");
                f_pr_date_s.Value = DateTime.Parse(LS1[idx].Pr_date);//日期
                f_pr_wtime.Text = LS1[idx].Pr_wtime.ToString();//上班時數
                f_pr_atime.Text = LS1[idx].Pr_atime.ToString();//加班時數
                f_pr_add1.SelectedValue = LS1[idx].Pr_add1.ToString();//輪班津貼
                f_pr_add2.SelectedValue = LS1[idx].Pr_add2.ToString();//夜餐補助
                f_va_time1.Text = LS1[idx].Va_time1.ToString();//請假扣錢時數
                f_va_time2.Text = LS1[idx].Va_time2.ToString();//請假不扣錢時數
                f_pr_ntime.Text = LS1[idx].Pr_ntime.ToString();//曠職時數
                f_va_code1.SelectedValue = LS1[idx].Va_code1;//遲到
                f_va_code2.SelectedValue = LS1[idx].Va_code2;//早退
                f_va_code3.SelectedValue = LS1[idx].Va_code3;//班別
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
            if (f_pr_no.Text != "" && (Menu_Sel == "Qry"||Menu_Sel=="Upd"))
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
                code_dearch_bt.Enabled = false;
                Col_Disable();
                f_va_code3.Focus();
            }
            else
            {
                Config.Show("請先查詢");
            }
        }
        
        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            pri019w fm = new pri019w(DataRang, null, f_pr_date.Text);//開視窗資料            
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                Find_p(f_pr_no.Text);
            }
            if (Menu_Sel == "Add")
                f_pr_wtime.Focus();
        }

        private void Find_p(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_pr_company.Text = p_prt016.Pr_company;
            f_pr_company_name.Text = sst011.Get(Login.DEPT) == null ? "" : sst011.Get(Login.DEPT).Company_shname;
            f_pr_dept.Text = p_prt016.Pr_dept;
            f_pr_dept_name.Text = sst011.Get(Login.DEPT) == null ? "" : sst011.Get(Login.DEPT).Company_shname;
            f_pr_cdept.Text = p_prt016.Pr_cdept;
            f_pr_cdept_name.Text = prt001.Get(f_pr_cdept.Text) == null ? "" : prt001.Get(f_pr_cdept.Text).Department_name_new;

            Get_va_code3_def(); //班別內定值
        }

        private void Get_va_code3_def()
        {
            //找那天是否假日, 非假日:1 假日:2 
            f_va_code3.SelectedIndex = 1;

            var _ho = prt008.ToDoList(f_pr_dept.Text, Convert.ToDateTime(f_pr_date.Text).Year, f_pr_cdept.Text, f_pr_date.Text);
            if (_ho.Count() > 0)
            {
                f_va_code3.SelectedIndex = 2;   //假日
            }
            else
            {
                if ((int)DateTime.Now.DayOfWeek == 0 || (int)DateTime.Now.DayOfWeek == 6)
                {
                    f_va_code3.SelectedIndex = 2;   //假日
                }
                else
                {
                    f_va_code3.SelectedIndex = 1;   //非假日
                }
            }
        }
        private void switchVa_Code3()
        {
            //找那天是否假日,假日記錄2,平常記錄1
            var _ho = prt008.ToDoList(f_pr_dept.Text, Convert.ToDateTime(f_pr_date.Text).Year, f_pr_cdept.Text, f_pr_date.Text);
            if (_ho.Count() > 0)
            {
                f_va_code3.SelectedIndex = 2;
            }
            else
            {
                f_va_code3.SelectedIndex = 1;
            }
        }


        private void f_pr_date_ValueChanged(object sender, EventArgs e)
        {
            if (f_pr_date_s.Value >= DateTime.Now)
            {
                Config.Show("日期不可大於今天");
                f_pr_date_s.Value = DateTime.Now.AddDays(-1);
            }
            f_pr_date.Text = f_pr_date_s.Value.ToString("yyyy/MM/dd");
            //找那天是否假日,假日記錄2,平常記錄1
            switchVa_Code3();
        }

        

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != "" && Menu_Sel == "Qry")
            {   
                Menu_Sel = "Del";
                InitMotherboard(Motherboard);
                confirm_Click(sender, e);
            }
            else
            {
                Config.Show("請先查詢");
            }
        }

        private void f_va_code3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_va_code3.SelectedIndex == 0)
                    f_va_code3.SelectedIndex = 1;
            }

        }

        private void f_pr_add1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_pr_add1.SelectedIndex == 0)
                    f_pr_add1.SelectedIndex = 1;
            }
            string tmp = f_pr_add1.SelectedValue.ToString();
            if (tmp == "10")
            {
                f_pr_add2.SelectedValue = "3";
            }
            if (tmp == "0")
            {
                f_pr_add2.SelectedValue = "0";
            }
        }

        private void f_pr_add2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_pr_add2.SelectedIndex == 0)
                    f_pr_add2.SelectedIndex = 1;
            }
        }

        private void f_va_code1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_va_code1.SelectedIndex == 0)
                    f_va_code1.SelectedIndex = 1;
            }
        }

        private void f_va_code2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_va_code2.SelectedIndex == 0)
                    f_va_code2.SelectedIndex = 1;
            }
        }

        private void f_pr_wtime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar != 46 &&
                (byte)e.KeyChar != 49 &&
                (byte)e.KeyChar != 50 &&
                (byte)e.KeyChar != 51 &&
                (byte)e.KeyChar != 52 &&
                (byte)e.KeyChar != 53 &&
                (byte)e.KeyChar != 54 &&
                (byte)e.KeyChar != 55 &&
                (byte)e.KeyChar != 56 &&
                (byte)e.KeyChar != 57 &&
                (byte)e.KeyChar != 48 &&
                (byte)e.KeyChar != 8)
            {
                e.Handled = true;
            }

        }

        private void f_pr_wtime_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_pr_atime.Focus();
        }

        private void f_pr_atime_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_va_time1.Focus();
        }

        private void f_va_time1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_va_time2.Focus();
        }

        private void f_va_time2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_pr_ntime.Focus();
        }

        private void f_pr_ntime_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_pr_wtime.Focus();
        }

        private void QueryDate(bool ss)
        {            
            f_pr_date_end.Visible = ss;
            f_pr_date_s_end.Visible = ss;
        }

        private void f_pr_date_s_end_ValueChanged(object sender, EventArgs e)
        {
            f_pr_date_end.Text = f_pr_date_s_end.Value.ToString("yyyy/MM/dd");
        }

        private void f_pr_date_s_CloseUp(object sender, EventArgs e)
        {
            f_pr_date.Text = f_pr_date_s.Value.ToString("yyyy/MM/dd");
        }

        private void f_pr_date_s_end_CloseUp(object sender, EventArgs e)
        {
            f_pr_date_end.Text = f_pr_date_s_end.Value.ToString("yyyy/MM/dd");
        }

        private void pri034_KeyDown(object sender, KeyEventArgs e)
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

        

    }
}
