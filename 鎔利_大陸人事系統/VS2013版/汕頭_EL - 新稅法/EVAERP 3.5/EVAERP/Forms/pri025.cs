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
    public partial class pri025 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt031L> LS1 = new List<prt031L>();
        prt016 p_prt016 = new prt016();
        string Dept = Login.DEPT;

        public decimal rYy;
        public decimal rMm;
        public string rCdept;//部門
        public string rPrno;//工號 
        public bool rOK = false;//按下確認鍵  

        public pri025()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_YY();//下拉選單-年
            D_MM();//下拉選單-月
            D_Cdpet();//部門
            Choice_Sel();
            intCol_Right();//數字欄位靠右
            f_pr_cdept.SelectedIndex = 0;
            menu_add.Enabled = false;
        }

        private void D_Cdpet()
        {
            List<prt001> LI = prt001.ToDoList(Dept).ToList();
            LI.Insert(0, new prt001());
            f_pr_cdept.DataSource = LI;
            f_pr_cdept.DisplayMember = "Department_name_new";
            f_pr_cdept.ValueMember = "Department_code";
        }

        //private void D_Cdpet()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("", ""));
        //    foreach (var i in prt001.ToDoList(Dept).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Department_name_new, i.Department_code));
        //    }
        //    f_pr_cdept.DisplayMember = "Key";
        //    f_pr_cdept.ValueMember = "Value";
        //    f_pr_cdept.DataSource = data;
        //}
        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList().ToList();
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
        }
        private void D_YY()
        {
            int NYY = DateTime.Now.Year;
            int PYY = NYY - 1;
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(NYY.ToString(), NYY));
            data.Add(new DictionaryEntry(PYY.ToString(), PYY));
            f_yy.DisplayMember = "Key";
            f_yy.ValueMember = "Value";
            f_yy.DataSource = data;
        }

        private void D_MM()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("一月", 1));
            data.Add(new DictionaryEntry("二月", 2));
            data.Add(new DictionaryEntry("三月", 3));
            data.Add(new DictionaryEntry("四月", 4));
            data.Add(new DictionaryEntry("五月", 5));
            data.Add(new DictionaryEntry("六月", 6));
            data.Add(new DictionaryEntry("七月", 7));
            data.Add(new DictionaryEntry("八月", 8));
            data.Add(new DictionaryEntry("九月", 9));
            data.Add(new DictionaryEntry("十月", 10));
            data.Add(new DictionaryEntry("十一月", 11));
            data.Add(new DictionaryEntry("十二月", 12));
            f_mm.DisplayMember = "Key";
            f_mm.ValueMember = "Value";
            f_mm.DataSource = data;
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
            Choice_Sel();
            Config.FontBlod(this, false);//字體不加粗
            code_dearch_bt_Click(sender, e);
            bindingNavigator1.Enabled = false;
        }

        private void Choice_Sel()
        {
            int smm = DateTime.Now.AddMonths(-1).Month;//上一月
            if (smm == 12)
            {
                //去年
                f_yy.SelectedIndex = 1;
            }
            else
            {
                //當年
                f_yy.SelectedIndex = 0;
            }
            f_mm.SelectedIndex = smm - 1;
        }
        

        private void Col_Disable()
        {
            f_pr_sqe.Enabled = false;
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
            f_pr_dept.Enabled = false;
            f_pr_cdept.Enabled = false;
            f_pr_in_date.Enabled = false;
            f_pr_leave_date.Enabled = false;
            
            f_tot_atime.Enabled = false;
            f_amt_16.Enabled = false;
            f_amt_25.Enabled = false;
            if (Menu_Sel != "Add")
            {
                f_yy.Enabled = false;
                f_mm.Enabled = false;
            }
        }

        protected void intCol_Right()
        {
            var _rihgt = f_amt_1.TextAlign;
            f_tot_wtime.TextAlign = _rihgt;
            f_tot_vtime1.TextAlign = _rihgt;
            f_tot_vtime2.TextAlign = _rihgt;
            f_tot_ntime.TextAlign = _rihgt;
            f_tot_atime1.TextAlign = _rihgt;
            f_tot_atime2.TextAlign = _rihgt;
            f_tot_atime.TextAlign = _rihgt;

            f_amt_1.TextAlign = _rihgt;
            f_amt_2.TextAlign = _rihgt;
            f_amt_3.TextAlign = _rihgt;
            f_amt_4.TextAlign = _rihgt;
            f_amt_5.TextAlign = _rihgt;
            f_amt_6.TextAlign = _rihgt;
            f_amt_7.TextAlign = _rihgt;
            f_amt_8.TextAlign = _rihgt;
            f_amt_9.TextAlign = _rihgt;
            f_amt_10.TextAlign = _rihgt;
            f_amt_11.TextAlign = _rihgt;
            f_amt_12.TextAlign = _rihgt;
            f_amt_13.TextAlign = _rihgt;
            //f_amt_14.TextAlign = _rihgt;
            f_amt_15.TextAlign = _rihgt;
            f_amt_16.TextAlign = _rihgt;
            f_amt_17.TextAlign = _rihgt;
            //f_amt_18.TextAlign = _rihgt;
            f_amt_19.TextAlign = _rihgt;
            f_amt_20.TextAlign = _rihgt;
            f_amt_28.TextAlign = _rihgt;
            f_amt_29.TextAlign = _rihgt;
            f_amt_25.TextAlign = _rihgt;
            f_amt_26.TextAlign = _rihgt;
            f_amt_27.TextAlign = _rihgt;
            f_amt_30.TextAlign = _rihgt;
            f_amt_31.TextAlign = _rihgt;
            f_amt_32.TextAlign = _rihgt;

            f_tax_1.TextAlign = _rihgt;
            f_tax_2.TextAlign = _rihgt;
            f_tax_3.TextAlign = _rihgt;
            f_tax_4.TextAlign = _rihgt;
            f_tax_5.TextAlign = _rihgt;
            f_tax_6.TextAlign = _rihgt;
        }

        
        private void Col_Vol()
        {
            if (Menu_Sel == "Add")
            {
                const decimal zro = 0;
                const decimal _pr_sqe = 1;

                f_pr_sqe.Text = _pr_sqe.ToString();

                f_tot_wtime.Text = zro.ToString();
                f_tot_vtime1.Text = zro.ToString();
                f_tot_vtime2.Text = zro.ToString();
                f_tot_ntime.Text = zro.ToString();
                f_tot_atime1.Text = zro.ToString();
                f_tot_atime2.Text = zro.ToString();
                f_tot_atime.Text = zro.ToString();

                
                f_amt_1.Text = zro.ToString();
                f_amt_2.Text = zro.ToString();
                f_amt_3.Text = zro.ToString();
                f_amt_4.Text = zro.ToString();
                f_amt_5.Text = zro.ToString();
                f_amt_6.Text = zro.ToString();
                f_amt_7.Text = zro.ToString();
                f_amt_8.Text = zro.ToString();
                f_amt_9.Text = zro.ToString();
                f_amt_10.Text = zro.ToString();
                f_amt_11.Text = zro.ToString();
                f_amt_12.Text = zro.ToString();
                f_amt_13.Text = zro.ToString();
                //f_amt_14.Text = zro.ToString();
                f_amt_15.Text = zro.ToString();
                f_amt_16.Text = zro.ToString();
                f_amt_17.Text = zro.ToString();
                //f_amt_18.Text = zro.ToString();
                f_amt_19.Text = zro.ToString();
                f_amt_20.Text = zro.ToString();
                f_amt_28.Text = zro.ToString();
                f_amt_29.Text = zro.ToString();
                f_amt_25.Text = zro.ToString();
                f_amt_26.Text = zro.ToString();
                f_amt_27.Text = zro.ToString();
                f_amt_28.Text = zro.ToString();
                f_amt_30.Text = zro.ToString();
                f_amt_31.Text = zro.ToString();
                f_amt_32.Text = zro.ToString();

                f_tax_1.Text = zro.ToString();
                f_tax_2.Text = zro.ToString();
                f_tax_3.Text = zro.ToString();
                f_tax_4.Text = zro.ToString();
                f_tax_5.Text = zro.ToString();
                f_tax_6.Text = zro.ToString();
            }
            
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
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Enabled = true;
                }
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            decimal C_Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            decimal C_Mm = System.Convert.ToDecimal(f_mm.SelectedValue); ;
            string C_Dept = f_pr_dept.SelectedValue.ToString();
            
            
            if (Menu_Sel == "Add")
            {
                if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
                {
                    Config.Show("此薪資料已關帳，無法異動。");
                    return;
                }   
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
                if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
                {
                    Config.Show("此薪資料已關帳，無法異動。");
                    return;
                } 
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
                if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
                {
                    Config.Show("此薪資料已關帳，無法異動。");
                    return;
                } 
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

            if (f_pr_no.Text == System.String.Empty)
            {
                Config.Show("員工編號不可空白");
                f_pr_no.Focus();
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
            var p_prt031L = new prt031L();
            p_prt031L.Pr_no = f_pr_no.Text;
            p_prt031L.Yy = Convert.ToDecimal(f_yy.SelectedValue);
            p_prt031L.Mm = Convert.ToDecimal(f_mm.SelectedValue);
            p_prt031L.Pr_sqe = Convert.ToDecimal(f_pr_sqe.Text);
            p_prt031L.Tot_wtime = string.IsNullOrEmpty(f_tot_wtime.Text) ? 0 : System.Convert.ToDecimal(f_tot_wtime.Text);
            p_prt031L.Tot_vtime1 = string.IsNullOrEmpty(f_tot_vtime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime1.Text);
            p_prt031L.Tot_vtime2 = string.IsNullOrEmpty(f_tot_vtime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime2.Text);
            p_prt031L.Tot_ntime = string.IsNullOrEmpty(f_tot_ntime.Text) ? 0 : System.Convert.ToDecimal(f_tot_ntime.Text);
            p_prt031L.Tot_atime1 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime1.Text);
            p_prt031L.Tot_atime2 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime2.Text);
            p_prt031L.Tot_atime = string.IsNullOrEmpty(f_tot_atime.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime.Text);
            p_prt031L.Amt_1 = string.IsNullOrEmpty(f_amt_1.Text) ? 0 : System.Convert.ToDecimal(f_amt_1.Text);
            p_prt031L.Amt_2 = string.IsNullOrEmpty(f_amt_2.Text) ? 0 : System.Convert.ToDecimal(f_amt_2.Text);
            p_prt031L.Amt_3 = string.IsNullOrEmpty(f_amt_3.Text) ? 0 : System.Convert.ToDecimal(f_amt_3.Text);
            p_prt031L.Amt_4 = string.IsNullOrEmpty(f_amt_4.Text) ? 0 : System.Convert.ToDecimal(f_amt_4.Text);
            p_prt031L.Amt_5 = string.IsNullOrEmpty(f_amt_5.Text) ? 0 : System.Convert.ToDecimal(f_amt_5.Text);
            p_prt031L.Amt_6 = string.IsNullOrEmpty(f_amt_6.Text) ? 0 : System.Convert.ToDecimal(f_amt_6.Text);
            p_prt031L.Amt_7 = string.IsNullOrEmpty(f_amt_7.Text) ? 0 : System.Convert.ToDecimal(f_amt_7.Text);
            p_prt031L.Amt_8 = string.IsNullOrEmpty(f_amt_8.Text) ? 0 : System.Convert.ToDecimal(f_amt_8.Text);
            p_prt031L.Amt_9 = string.IsNullOrEmpty(f_amt_9.Text) ? 0 : System.Convert.ToDecimal(f_amt_9.Text);
            p_prt031L.Amt_10 = string.IsNullOrEmpty(f_amt_10.Text) ? 0 : System.Convert.ToDecimal(f_amt_10.Text);
            p_prt031L.Amt_11 = string.IsNullOrEmpty(f_amt_11.Text) ? 0 : System.Convert.ToDecimal(f_amt_11.Text);
            p_prt031L.Amt_12 = string.IsNullOrEmpty(f_amt_12.Text) ? 0 : System.Convert.ToDecimal(f_amt_12.Text);
            p_prt031L.Amt_13 = string.IsNullOrEmpty(f_amt_13.Text) ? 0 : System.Convert.ToDecimal(f_amt_13.Text);
            //p_prt031L.Amt_14 = string.IsNullOrEmpty(f_amt_14.Text) ? 0 : System.Convert.ToDecimal(f_amt_14.Text);
            p_prt031L.Amt_15 = string.IsNullOrEmpty(f_amt_15.Text) ? 0 : System.Convert.ToDecimal(f_amt_15.Text);
            p_prt031L.Amt_16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : System.Convert.ToDecimal(f_amt_16.Text);
            p_prt031L.Amt_17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : System.Convert.ToDecimal(f_amt_17.Text);
            //p_prt031L.Amt_18 = string.IsNullOrEmpty(f_amt_18.Text) ? 0 : System.Convert.ToDecimal(f_amt_18.Text);
            p_prt031L.Amt_19 = string.IsNullOrEmpty(f_amt_19.Text) ? 0 : System.Convert.ToDecimal(f_amt_19.Text);
            p_prt031L.Amt_20 = string.IsNullOrEmpty(f_amt_20.Text) ? 0 : System.Convert.ToDecimal(f_amt_20.Text);
            p_prt031L.Amt_28 = string.IsNullOrEmpty(f_amt_28.Text) ? 0 : System.Convert.ToDecimal(f_amt_28.Text);
            p_prt031L.Amt_29 = string.IsNullOrEmpty(f_amt_29.Text) ? 0 : System.Convert.ToDecimal(f_amt_29.Text);
            p_prt031L.Amt_25 = string.IsNullOrEmpty(f_amt_25.Text) ? 0 : System.Convert.ToDecimal(f_amt_25.Text);
            p_prt031L.Amt_26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : System.Convert.ToDecimal(f_amt_26.Text);
            p_prt031L.Amt_27 = string.IsNullOrEmpty(f_amt_27.Text) ? 0 : System.Convert.ToDecimal(f_amt_27.Text);
            p_prt031L.Amt_30 = string.IsNullOrEmpty(f_amt_30.Text) ? 0 : System.Convert.ToDecimal(f_amt_30.Text);
            p_prt031L.Amt_31 = string.IsNullOrEmpty(f_amt_31.Text) ? 0 : System.Convert.ToDecimal(f_amt_31.Text);
            p_prt031L.Amt_32 = string.IsNullOrEmpty(f_amt_32.Text) ? 0 : System.Convert.ToDecimal(f_amt_32.Text);
            p_prt031L.Amt_21 = p_prt031L.Amt_29 + p_prt031L.Amt_30;
            p_prt031L.Add_user = Home.Id;
            p_prt016 = prt016.Get(p_prt031L.Pr_no);
            p_prt031L.Pr_direct_type = p_prt016.Pr_direct_type;
            p_prt031L.Direct_type1 = p_prt016.Direct_type1;
            p_prt031L.Direct_type2 = p_prt016.Direct_type2;
            p_prt031L.Cdept_no = f_pr_cdept.SelectedValue.ToString();

            p_prt031L.Tax_1 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : System.Convert.ToDecimal(f_tax_1.Text);
            p_prt031L.Tax_2 = string.IsNullOrEmpty(f_tax_2.Text) ? 0 : System.Convert.ToDecimal(f_tax_2.Text);
            p_prt031L.Tax_3 = string.IsNullOrEmpty(f_tax_3.Text) ? 0 : System.Convert.ToDecimal(f_tax_3.Text);
            p_prt031L.Tax_4 = string.IsNullOrEmpty(f_tax_4.Text) ? 0 : System.Convert.ToDecimal(f_tax_4.Text);
            p_prt031L.Tax_5 = string.IsNullOrEmpty(f_tax_5.Text) ? 0 : System.Convert.ToDecimal(f_tax_5.Text);
            p_prt031L.Tax_6 = string.IsNullOrEmpty(f_tax_6.Text) ? 0 : System.Convert.ToDecimal(f_tax_6.Text);
            return p_prt031L.Insert();
        }


        private string f_Update_1()
        {   
            var p_prt031L = new prt031L();
            p_prt031L.Pr_no = f_pr_no.Text;
            p_prt031L.Yy = Convert.ToDecimal(f_yy.SelectedValue);
            p_prt031L.Mm = Convert.ToDecimal(f_mm.SelectedValue);
            p_prt031L.Pr_sqe = Convert.ToDecimal(f_pr_sqe.Text);
            p_prt031L.Tot_wtime = string.IsNullOrEmpty(f_tot_wtime.Text) ? 0 : System.Convert.ToDecimal(f_tot_wtime.Text);
            p_prt031L.Tot_vtime1 = string.IsNullOrEmpty(f_tot_vtime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime1.Text);
            p_prt031L.Tot_vtime2 = string.IsNullOrEmpty(f_tot_vtime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime2.Text);
            p_prt031L.Tot_ntime = string.IsNullOrEmpty(f_tot_ntime.Text) ? 0 : System.Convert.ToDecimal(f_tot_ntime.Text);
            p_prt031L.Tot_atime1 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime1.Text);
            p_prt031L.Tot_atime2 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime2.Text);
            p_prt031L.Tot_atime = string.IsNullOrEmpty(f_tot_atime.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime.Text);
            p_prt031L.Amt_1 = string.IsNullOrEmpty(f_amt_1.Text) ? 0 : System.Convert.ToDecimal(f_amt_1.Text);
            p_prt031L.Amt_2 = string.IsNullOrEmpty(f_amt_2.Text) ? 0 : System.Convert.ToDecimal(f_amt_2.Text);
            p_prt031L.Amt_3 = string.IsNullOrEmpty(f_amt_3.Text) ? 0 : System.Convert.ToDecimal(f_amt_3.Text);
            p_prt031L.Amt_4 = string.IsNullOrEmpty(f_amt_4.Text) ? 0 : System.Convert.ToDecimal(f_amt_4.Text);
            p_prt031L.Amt_5 = string.IsNullOrEmpty(f_amt_5.Text) ? 0 : System.Convert.ToDecimal(f_amt_5.Text);
            p_prt031L.Amt_6 = string.IsNullOrEmpty(f_amt_6.Text) ? 0 : System.Convert.ToDecimal(f_amt_6.Text);
            p_prt031L.Amt_7 = string.IsNullOrEmpty(f_amt_7.Text) ? 0 : System.Convert.ToDecimal(f_amt_7.Text);
            p_prt031L.Amt_8 = string.IsNullOrEmpty(f_amt_8.Text) ? 0 : System.Convert.ToDecimal(f_amt_8.Text);
            p_prt031L.Amt_9 = string.IsNullOrEmpty(f_amt_9.Text) ? 0 : System.Convert.ToDecimal(f_amt_9.Text);
            p_prt031L.Amt_10 = string.IsNullOrEmpty(f_amt_10.Text) ? 0 : System.Convert.ToDecimal(f_amt_10.Text);
            p_prt031L.Amt_11 = string.IsNullOrEmpty(f_amt_11.Text) ? 0 : System.Convert.ToDecimal(f_amt_11.Text);
            p_prt031L.Amt_12 = string.IsNullOrEmpty(f_amt_12.Text) ? 0 : System.Convert.ToDecimal(f_amt_12.Text);
            p_prt031L.Amt_13 = string.IsNullOrEmpty(f_amt_13.Text) ? 0 : System.Convert.ToDecimal(f_amt_13.Text);
            //p_prt031L.Amt_14 = string.IsNullOrEmpty(f_amt_14.Text) ? 0 : System.Convert.ToDecimal(f_amt_14.Text);
            p_prt031L.Amt_15 = string.IsNullOrEmpty(f_amt_15.Text) ? 0 : System.Convert.ToDecimal(f_amt_15.Text);
            p_prt031L.Amt_16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : System.Convert.ToDecimal(f_amt_16.Text);
            p_prt031L.Amt_17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : System.Convert.ToDecimal(f_amt_17.Text);
            //p_prt031L.Amt_18 = string.IsNullOrEmpty(f_amt_18.Text) ? 0 : System.Convert.ToDecimal(f_amt_18.Text);
            p_prt031L.Amt_19 = string.IsNullOrEmpty(f_amt_19.Text) ? 0 : System.Convert.ToDecimal(f_amt_19.Text);
            p_prt031L.Amt_20 = string.IsNullOrEmpty(f_amt_20.Text) ? 0 : System.Convert.ToDecimal(f_amt_20.Text);
            p_prt031L.Amt_28 = string.IsNullOrEmpty(f_amt_28.Text) ? 0 : System.Convert.ToDecimal(f_amt_28.Text);
            p_prt031L.Amt_29 = string.IsNullOrEmpty(f_amt_29.Text) ? 0 : System.Convert.ToDecimal(f_amt_29.Text);
            p_prt031L.Amt_25 = string.IsNullOrEmpty(f_amt_25.Text) ? 0 : System.Convert.ToDecimal(f_amt_25.Text);
            p_prt031L.Amt_26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : System.Convert.ToDecimal(f_amt_26.Text);
            p_prt031L.Amt_27 = string.IsNullOrEmpty(f_amt_27.Text) ? 0 : System.Convert.ToDecimal(f_amt_27.Text);
            p_prt031L.Amt_30 = string.IsNullOrEmpty(f_amt_30.Text) ? 0 : System.Convert.ToDecimal(f_amt_30.Text);
            p_prt031L.Amt_31 = string.IsNullOrEmpty(f_amt_31.Text) ? 0 : System.Convert.ToDecimal(f_amt_31.Text);
            p_prt031L.Amt_32 = string.IsNullOrEmpty(f_amt_32.Text) ? 0 : System.Convert.ToDecimal(f_amt_32.Text);
            p_prt031L.Amt_21 = p_prt031L.Amt_29 + p_prt031L.Amt_30;
            p_prt031L.Mod_user = Home.Id;
            p_prt016 = prt016.Get(p_prt031L.Pr_no);
            p_prt031L.Pr_direct_type = p_prt016.Pr_direct_type;
            p_prt031L.Direct_type1 = p_prt016.Direct_type1;
            p_prt031L.Direct_type2 = p_prt016.Direct_type2;
            p_prt031L.Cdept_no = f_pr_cdept.SelectedValue.ToString();

            p_prt031L.Tax_1 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : System.Convert.ToDecimal(f_tax_1.Text);
            p_prt031L.Tax_2 = string.IsNullOrEmpty(f_tax_2.Text) ? 0 : System.Convert.ToDecimal(f_tax_2.Text);
            p_prt031L.Tax_3 = string.IsNullOrEmpty(f_tax_3.Text) ? 0 : System.Convert.ToDecimal(f_tax_3.Text);
            p_prt031L.Tax_4 = string.IsNullOrEmpty(f_tax_4.Text) ? 0 : System.Convert.ToDecimal(f_tax_4.Text);
            p_prt031L.Tax_5 = string.IsNullOrEmpty(f_tax_5.Text) ? 0 : System.Convert.ToDecimal(f_tax_5.Text);
            p_prt031L.Tax_6 = string.IsNullOrEmpty(f_tax_6.Text) ? 0 : System.Convert.ToDecimal(f_tax_6.Text);
            return p_prt031L.Update(p_prt031L.Yy, p_prt031L.Mm,p_prt031L.Pr_no,p_prt031L.Pr_sqe);
        }
                

        private string f_Delete_1()
        {
            var p_prt031L = new prt031L();
            decimal _yy = Convert.ToDecimal(f_yy.SelectedValue);
            decimal _mm = Convert.ToDecimal(f_mm.SelectedValue);
            return p_prt031L.Delete(_yy, _mm, f_pr_no.Text, Convert.ToDecimal(f_pr_sqe.Text));
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
            Config.FontBlod(this, true);//字體加粗
        }

        private void FormQuery()
        {
            pri025Q fm = new pri025Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rYy = fm.rYy;
                rMm = fm.rMm;
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
            LS1 = prt031L.ToDoList(rYy, rMm, rCdept, rPrno, 1).ToList();
           
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
                if (idx < 0)
                    menu_first_Click(null, null);
                else
                    menu_last_Click(null, null);
            }
            else
            {
                var q_prt031L = prt031L.Get(LS1[idx].Yy, LS1[idx].Mm, LS1[idx].Pr_no, LS1[idx].Pr_sqe);

                Find_p(q_prt031L.Pr_no, q_prt031L.Cdept_no);

                f_yy.Text = q_prt031L.Yy.ToString();                
                f_mm.SelectedValue = (int)q_prt031L.Mm;

                if (Menu_Sel != "Add")
                {
                    f_pr_sqe.Text = q_prt031L.Pr_sqe.ToString();
                    f_tot_wtime.Text = q_prt031L.Tot_wtime.ToString();
                    f_tot_vtime1.Text = q_prt031L.Tot_vtime1.ToString();
                    f_tot_vtime2.Text = q_prt031L.Tot_vtime2.ToString();
                    f_tot_ntime.Text = q_prt031L.Tot_ntime.ToString();
                    f_tot_atime1.Text = q_prt031L.Tot_atime1.ToString();
                    f_tot_atime2.Text = q_prt031L.Tot_atime2.ToString();
                    f_tot_atime.Text = q_prt031L.Tot_atime.ToString();
                }

                f_amt_1.Text = q_prt031L.Amt_1.ToString();
                f_amt_2.Text = q_prt031L.Amt_2.ToString();
                f_amt_3.Text = q_prt031L.Amt_3.ToString();
                f_amt_4.Text = q_prt031L.Amt_4.ToString();
                f_amt_5.Text = q_prt031L.Amt_5.ToString();
                f_amt_6.Text = q_prt031L.Amt_6.ToString();
                f_amt_7.Text = q_prt031L.Amt_7.ToString();
                f_amt_8.Text = q_prt031L.Amt_8.ToString();
                f_amt_9.Text = q_prt031L.Amt_9.ToString();
                f_amt_10.Text = q_prt031L.Amt_10.ToString();
                f_amt_11.Text = q_prt031L.Amt_11.ToString();
                f_amt_12.Text = q_prt031L.Amt_12.ToString();
                f_amt_13.Text = q_prt031L.Amt_13.ToString();
                f_amt_15.Text = q_prt031L.Amt_15.ToString();
                f_amt_16.Text = q_prt031L.Amt_16.ToString();
                f_amt_17.Text = q_prt031L.Amt_17.ToString();
                f_amt_19.Text = q_prt031L.Amt_19.ToString();
                f_amt_20.Text = q_prt031L.Amt_20.ToString();
                f_amt_25.Text = q_prt031L.Amt_25.ToString();
                f_amt_26.Text = q_prt031L.Amt_26.ToString();
                f_amt_27.Text = q_prt031L.Amt_27.ToString();
                f_amt_28.Text = q_prt031L.Amt_28.ToString();
                f_amt_29.Text = q_prt031L.Amt_29.ToString();
                f_amt_30.Text = q_prt031L.Amt_30.ToString();
                f_amt_31.Text = q_prt031L.Amt_31.ToString();

                f_amt_32.Text = q_prt031L.Amt_32.ToString();

                f_add_date.Text = string.IsNullOrEmpty(q_prt031L.Add_date) ? "" : Convert.ToDateTime(q_prt031L.Add_date).ToString("yyyy/MM/dd");
                f_add_user.Text = q_prt031L.Add_user.Trim();
                f_mod_date.Text = string.IsNullOrEmpty(q_prt031L.Mod_date) ? "" : Convert.ToDateTime(q_prt031L.Mod_date).ToString("yyyy/MM/dd");
                f_mod_user.Text = q_prt031L.Mod_user.Trim();

                f_tax_1.Text = q_prt031L.Tax_1.ToString();
                f_tax_2.Text = q_prt031L.Tax_2.ToString();
                f_tax_3.Text = q_prt031L.Tax_3.ToString();
                f_tax_4.Text = q_prt031L.Tax_4.ToString();
                f_tax_5.Text = q_prt031L.Tax_5.ToString();
                f_tax_6.Text = q_prt031L.Tax_6.ToString();                
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
        //        Find_p(LS1[idx].Pr_no,LS1[idx].Cdept_no);

        //        f_yy.Text = LS1[idx].Yy.ToString();
        //        f_mm.Text = LS1[idx].Mm.ToString();

        //        if (Menu_Sel != "Add")
        //        {
        //            f_pr_sqe.Text = LS1[idx].Pr_sqe.ToString();
        //            f_tot_wtime.Text = LS1[idx].Tot_wtime.ToString();
        //            f_tot_vtime1.Text = LS1[idx].Tot_vtime1.ToString();
        //            f_tot_vtime2.Text = LS1[idx].Tot_vtime2.ToString();
        //            f_tot_ntime.Text = LS1[idx].Tot_ntime.ToString();
        //            f_tot_atime1.Text = LS1[idx].Tot_atime1.ToString();
        //            f_tot_atime2.Text = LS1[idx].Tot_atime2.ToString();
        //            f_tot_atime.Text = LS1[idx].Tot_atime.ToString();
        //        }

        //        f_amt_1.Text = LS1[idx].Amt_1.ToString();
        //        f_amt_2.Text = LS1[idx].Amt_2.ToString();
        //        f_amt_3.Text = LS1[idx].Amt_3.ToString();
        //        f_amt_4.Text = LS1[idx].Amt_4.ToString();
        //        f_amt_5.Text = LS1[idx].Amt_5.ToString();
        //        f_amt_6.Text = LS1[idx].Amt_6.ToString();
        //        f_amt_7.Text = LS1[idx].Amt_7.ToString();
        //        f_amt_8.Text = LS1[idx].Amt_8.ToString();
        //        f_amt_9.Text = LS1[idx].Amt_9.ToString();
        //        f_amt_10.Text = LS1[idx].Amt_10.ToString();
        //        f_amt_11.Text = LS1[idx].Amt_11.ToString();
        //        f_amt_12.Text = LS1[idx].Amt_12.ToString();
        //        f_amt_13.Text = LS1[idx].Amt_13.ToString();                
        //        f_amt_15.Text = LS1[idx].Amt_15.ToString();
        //        f_amt_16.Text = LS1[idx].Amt_16.ToString();
        //        f_amt_17.Text = LS1[idx].Amt_17.ToString();                
        //        f_amt_19.Text = LS1[idx].Amt_19.ToString();
        //        f_amt_20.Text = LS1[idx].Amt_20.ToString();                
        //        f_amt_25.Text = LS1[idx].Amt_25.ToString();
        //        f_amt_26.Text = LS1[idx].Amt_26.ToString();
        //        f_amt_27.Text = LS1[idx].Amt_27.ToString();
        //        f_amt_28.Text = LS1[idx].Amt_28.ToString();
        //        f_amt_29.Text = LS1[idx].Amt_29.ToString();
        //        f_amt_30.Text = LS1[idx].Amt_30.ToString();
        //        f_amt_31.Text = LS1[idx].Amt_31.ToString();

        //        f_amt_32.Text = LS1[idx].Amt_32.ToString();

        //        f_add_date.Text = string.IsNullOrEmpty(LS1[idx].Add_date) ? "" : Convert.ToDateTime(LS1[idx].Add_date).ToString("yyyy/MM/dd");
        //        f_add_user.Text = LS1[idx].Add_user.Trim();
        //        f_mod_date.Text = string.IsNullOrEmpty(LS1[idx].Mod_date) ? "" : Convert.ToDateTime(LS1[idx].Mod_date).ToString("yyyy/MM/dd");
        //        f_mod_user.Text = LS1[idx].Mod_user.Trim();
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
                //if (f_pr_leave_date.Text.Trim().ToString() != string.Empty)
                //{
                //    Config.Show("已離職無法異動");
                //    return;
                //}
                Menu_Sel = "Upd";
                SetMotherboard(this);
                code_dearch_bt.Enabled = false;
                Col_Disable();
                Config.FontBlod(this, false);//字體不加粗
                f_tot_wtime.Focus();
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
        //    if (f_pr_no.Text != "" && (Menu_Sel == "Qry" || Menu_Sel == "Upd"))
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        code_dearch_bt.Enabled = false;
        //        Col_Disable();
        //        Config.FontBlod(this, false);//字體不加粗
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //    f_tot_wtime.Focus();
        //}


        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            pri019w fm = new pri019w(Dept, (Int32)f_yy.SelectedValue, (Int32)f_mm.SelectedValue, "", "");//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                Find_p(f_pr_no.Text, "");
            }
            if (Menu_Sel == "Add")
            {
                Int32 Yy = Convert.ToInt32(f_yy.SelectedValue);
                Int32 Mm = Convert.ToInt32(f_mm.SelectedValue);
                string Pr_no = f_pr_no.Text.Trim();
                decimal seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7 = 0;
                seq_no = string.IsNullOrEmpty(f_pr_sqe.Text) ? 0 : Convert.ToDecimal(f_pr_sqe.Text);
                amt1 = string.IsNullOrEmpty(f_tot_wtime.Text) ? 0 : Convert.ToDecimal(f_tot_wtime.Text);
                amt2 = string.IsNullOrEmpty(f_tot_vtime1.Text) ? 0 : Convert.ToDecimal(f_tot_vtime1.Text);
                amt3 = string.IsNullOrEmpty(f_tot_vtime2.Text) ? 0 : Convert.ToDecimal(f_tot_vtime2.Text);
                amt4 = string.IsNullOrEmpty(f_tot_ntime.Text) ? 0 : Convert.ToDecimal(f_tot_ntime.Text);
                amt5 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : Convert.ToDecimal(f_tot_atime1.Text);
                amt6 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : Convert.ToDecimal(f_tot_atime2.Text);
                amt7 = string.IsNullOrEmpty(f_tot_atime.Text) ? 0 : Convert.ToDecimal(f_tot_atime.Text);

                if (prt031L.ToDoList(Yy, Mm, f_pr_no.Text, Convert.ToDecimal(f_pr_sqe.Text)).Count() > 0)
                {
                    Config.Show("以有此筆資料,請查詢後處理");
                    return;
                }
                if (prt016.Get(f_pr_no.Text) == null) //人事主檔
                {
                    Config.Show("人事主檔沒資料");
                    return;
                }
                int Last_seq = prt021.Get_Last_Seq_no(f_pr_no.Text);
                if (prt021.Get(f_pr_no.Text, Last_seq) == null)
                {
                    Config.Show("找不到薪資設定資料");
                    return;
                }

                p_prt016 = prt016.Get(Pr_no);
                //有出勤資料
                if (prt030L.ToDoListByGroup(f_pr_dept.SelectedValue.ToString(), Yy, Mm, f_pr_no.Text).Count() > 0)
                {
                    //出勤時數(平日)
                    amt1 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "1").Sum(m => m.Pr_wtime);

                    //請假時數(扣薪)va_time1
                    amt2 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Va_time1);

                    //請假時數(不扣薪)va_time2
                    amt3 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Va_time2);

                    //曠職時數.pr_ntime
                    amt4 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Pr_ntime);

                    //tot_atime1平日加班
                    amt5 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "1").Sum(m => m.Pr_atime);

                    //tot_atime2假日加班
                    amt6 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "2").Sum(m => m.Pr_wtime) +
                                        prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "2").Sum(m => m.Pr_atime);

                    //總加班時數
                    amt7 = amt5 + amt6;

                    f_tot_wtime.Text = amt1.ToString();
                    f_tot_vtime1.Text = amt2.ToString();
                    f_tot_vtime2.Text = amt3.ToString();
                    f_tot_ntime.Text = amt4.ToString();
                    f_tot_atime1.Text = amt5.ToString();
                    f_tot_atime2.Text = amt6.ToString();
                    f_tot_atime.Text = amt7.ToString();
                    P_Sing(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7);
                }
                else
                {
                    //沒出勤資料,的新增
                    P_Sing(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7);
                }
                f_tot_wtime.Focus();
            }
        }

        

        private void P_Sing(string Dept,Int32 Yy,Int32 Mm,string Pr_no,decimal seq_no, decimal amt1,decimal amt2,decimal amt3, decimal amt4,decimal amt5,decimal amt6,decimal amt7)
        {
            if (prt031L.Pay_TrnSingle(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7) == null)
            {
                return;
            }
            var p_prt031L = prt031L.Pay_TrnSingle(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7);
            f_amt_1.Text = p_prt031L.Amt_1.ToString();
            f_amt_2.Text = p_prt031L.Amt_2.ToString();
            f_amt_3.Text = p_prt031L.Amt_3.ToString();
            f_amt_4.Text = p_prt031L.Amt_4.ToString();
            f_amt_5.Text = p_prt031L.Amt_5.ToString();
            f_amt_6.Text = p_prt031L.Amt_6.ToString();
            f_amt_7.Text = p_prt031L.Amt_7.ToString();
            f_amt_8.Text = p_prt031L.Amt_8.ToString();
            f_amt_9.Text = p_prt031L.Amt_9.ToString();
            f_amt_10.Text = p_prt031L.Amt_10.ToString();
            f_amt_11.Text = p_prt031L.Amt_11.ToString();
            f_amt_12.Text = p_prt031L.Amt_12.ToString();
            f_amt_13.Text = p_prt031L.Amt_13.ToString();
            //f_amt_14.Text = p_prt031L.Amt_14.ToString();
            f_amt_15.Text = p_prt031L.Amt_15.ToString();
            f_amt_16.Text = p_prt031L.Amt_16.ToString();
            f_amt_17.Text = p_prt031L.Amt_17.ToString();
            //f_amt_18.Text = p_prt031L.Amt_18.ToString();
            f_amt_19.Text = p_prt031L.Amt_19.ToString();
            f_amt_20.Text = p_prt031L.Amt_20.ToString();
            f_amt_28.Text = p_prt031L.Amt_28.ToString();
            f_amt_29.Text = p_prt031L.Amt_29.ToString();
            f_amt_25.Text = p_prt031L.Amt_25.ToString();
            f_amt_26.Text = p_prt031L.Amt_26.ToString();
            f_amt_27.Text = p_prt031L.Amt_27.ToString();
            f_amt_30.Text = p_prt031L.Amt_30.ToString();
            f_amt_31.Text = p_prt031L.Amt_31.ToString();
            f_amt_32.Text = p_prt031L.Amt_32.ToString();
        }


        private void Find_p(string Pr_no,string Cdept_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_pr_dept.SelectedValue = p_prt016.Pr_dept;
            f_pr_cdept.SelectedValue = !string.IsNullOrEmpty(Cdept_no) ? Cdept_no : p_prt016.Pr_cdept;            

            f_pr_in_date.Text = string.IsNullOrEmpty(p_prt016.Pr_in_date) ? "" : Convert.ToDateTime(p_prt016.Pr_in_date).ToString("yyyy/MM/dd");
            f_pr_leave_date.Text = string.IsNullOrEmpty(p_prt016.Pr_leave_date) ? "" : Convert.ToDateTime(p_prt016.Pr_leave_date).ToString("yyyy/MM/dd");
        }

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
            {
                //if (f_pr_leave_date.Text.Trim().ToString() != string.Empty)
                //{
                //    Config.Show("已離職無法異動");
                //    return;
                //}
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
        //    if (f_pr_no.Text != "" && (Menu_Sel == "Qry" || Menu_Sel == "Del"))
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

        

        private void isDecimal(object sender, KeyPressEventArgs e)
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

        

        private void Sum_attime(object sender, EventArgs e)
        {
            decimal at1, at2,att = 0;
            at1 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : Convert.ToDecimal(f_tot_atime1.Text);
            at2 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : Convert.ToDecimal(f_tot_atime2.Text);
            att = at1 + at2;
            f_tot_atime.Text = att.ToString();

            if (Menu_Sel == "Add")
            {
                //算個人並顯示
                Pay_S(sender, e);
            }
        }

        

        

         
        private void Pay_S(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                decimal seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7 = 0;
                Int32 Yy = Convert.ToInt32(f_yy.SelectedValue);
                Int32 Mm = Convert.ToInt32(f_mm.SelectedValue);
                string Pr_no = f_pr_no.Text.Trim();
                seq_no = string.IsNullOrEmpty(f_pr_sqe.Text) ? 0 : Convert.ToDecimal(f_pr_sqe.Text);
                amt1 = string.IsNullOrEmpty(f_tot_wtime.Text) ? 0 : Convert.ToDecimal(f_tot_wtime.Text);
                amt2 = string.IsNullOrEmpty(f_tot_vtime1.Text) ? 0 : Convert.ToDecimal(f_tot_vtime1.Text);
                amt3 = string.IsNullOrEmpty(f_tot_vtime2.Text) ? 0 : Convert.ToDecimal(f_tot_vtime2.Text);
                amt4 = string.IsNullOrEmpty(f_tot_ntime.Text) ? 0 : Convert.ToDecimal(f_tot_ntime.Text);
                amt5 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : Convert.ToDecimal(f_tot_atime1.Text);
                amt6 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : Convert.ToDecimal(f_tot_atime2.Text);
                amt7 = string.IsNullOrEmpty(f_tot_atime.Text) ? 0 : Convert.ToDecimal(f_tot_atime.Text);
                P_Sing(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7);
            }
        }

        private void Sum_Pay1(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt2 = 0, amt3 = 0, amt4 = 0, amt5 = 0, amt6 = 0, amt7 = 0,
                amt8 = 0, amt9 = 0, amt10 = 0, amt11 = 0, amt12 = 0, amt13 = 0, amt15 = 0,
                amt16 = 0, amt17 = 0, amt19 = 0, amt20 = 0, amt29 = 0, amt25 = 0, amt26 = 0, amt27 = 0, amt28 = 0, amt30 = 0, amt31 = 0, amt32 = 0;
            decimal tax_1 = 0, tax_2 = 0, tax_3 = 0, tax_4 = 0, tax_5 = 0, tax_6 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt1 = string.IsNullOrEmpty(f_amt_1.Text) ? 0 : Convert.ToDecimal(f_amt_1.Text);
                amt2 = string.IsNullOrEmpty(f_amt_2.Text) ? 0 : Convert.ToDecimal(f_amt_2.Text);
                amt3 = string.IsNullOrEmpty(f_amt_3.Text) ? 0 : Convert.ToDecimal(f_amt_3.Text);
                amt4 = string.IsNullOrEmpty(f_amt_4.Text) ? 0 : Convert.ToDecimal(f_amt_4.Text);
                amt5 = string.IsNullOrEmpty(f_amt_5.Text) ? 0 : Convert.ToDecimal(f_amt_5.Text);
                amt6 = string.IsNullOrEmpty(f_amt_6.Text) ? 0 : Convert.ToDecimal(f_amt_6.Text);
                amt7 = string.IsNullOrEmpty(f_amt_7.Text) ? 0 : Convert.ToDecimal(f_amt_7.Text);
                amt8 = string.IsNullOrEmpty(f_amt_8.Text) ? 0 : Convert.ToDecimal(f_amt_8.Text);
                amt9 = string.IsNullOrEmpty(f_amt_9.Text) ? 0 : Convert.ToDecimal(f_amt_9.Text);
                amt10 = string.IsNullOrEmpty(f_amt_10.Text) ? 0 : Convert.ToDecimal(f_amt_10.Text);
                amt11 = string.IsNullOrEmpty(f_amt_11.Text) ? 0 : Convert.ToDecimal(f_amt_11.Text);
                amt12 = string.IsNullOrEmpty(f_amt_12.Text) ? 0 : Convert.ToDecimal(f_amt_12.Text);
                amt13 = string.IsNullOrEmpty(f_amt_13.Text) ? 0 : Convert.ToDecimal(f_amt_13.Text);
                amt15 = string.IsNullOrEmpty(f_amt_15.Text) ? 0 : Convert.ToDecimal(f_amt_15.Text);
                amt16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : Convert.ToDecimal(f_amt_16.Text);
                amt17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : Convert.ToDecimal(f_amt_17.Text);
                amt19 = string.IsNullOrEmpty(f_amt_19.Text) ? 0 : Convert.ToDecimal(f_amt_19.Text);
                amt20 = string.IsNullOrEmpty(f_amt_20.Text) ? 0 : Convert.ToDecimal(f_amt_20.Text);
                amt29 = string.IsNullOrEmpty(f_amt_29.Text) ? 0 : Convert.ToDecimal(f_amt_29.Text);
                amt25 = string.IsNullOrEmpty(f_amt_25.Text) ? 0 : Convert.ToDecimal(f_amt_25.Text);
                amt26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : Convert.ToDecimal(f_amt_26.Text);
                amt27 = string.IsNullOrEmpty(f_amt_27.Text) ? 0 : Convert.ToDecimal(f_amt_27.Text);
                amt28 = string.IsNullOrEmpty(f_amt_28.Text) ? 0 : Convert.ToDecimal(f_amt_28.Text);
                amt30 = string.IsNullOrEmpty(f_amt_30.Text) ? 0 : Convert.ToDecimal(f_amt_30.Text);
                amt31 = string.IsNullOrEmpty(f_amt_31.Text) ? 0 : Convert.ToDecimal(f_amt_31.Text);
                amt32 = string.IsNullOrEmpty(f_amt_32.Text) ? 0 : Convert.ToDecimal(f_amt_32.Text);

                tax_1 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);
                tax_2 = string.IsNullOrEmpty(f_tax_2.Text) ? 0 : Convert.ToDecimal(f_tax_2.Text);
                tax_3 = string.IsNullOrEmpty(f_tax_3.Text) ? 0 : Convert.ToDecimal(f_tax_3.Text);
                tax_4 = string.IsNullOrEmpty(f_tax_4.Text) ? 0 : Convert.ToDecimal(f_tax_4.Text);
                tax_5 = string.IsNullOrEmpty(f_tax_5.Text) ? 0 : Convert.ToDecimal(f_tax_5.Text);
                tax_6 = string.IsNullOrEmpty(f_tax_6.Text) ? 0 : Convert.ToDecimal(f_tax_6.Text);

                //應發金額(amt16)
                amt16 = amt1 + amt2 + amt3 +
                     amt5 + amt6 + amt7 + amt8 + amt9 +
                     amt10 + amt32 + amt13 + amt27 - amt11 - amt12 - amt15;
                f_amt_16.Text = amt16.ToString();
            }
        }

        

        private void NullToZero()
        {
            if (string.IsNullOrEmpty(f_amt_1.Text)) f_amt_1.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_2.Text)) f_amt_2.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_3.Text)) f_amt_3.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_4.Text)) f_amt_4.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_5.Text)) f_amt_5.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_6.Text)) f_amt_6.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_7.Text)) f_amt_7.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_8.Text)) f_amt_8.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_9.Text)) f_amt_9.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_10.Text)) f_amt_10.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_11.Text)) f_amt_11.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_12.Text)) f_amt_12.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_13.Text)) f_amt_13.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_15.Text)) f_amt_15.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_16.Text)) f_amt_16.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_17.Text)) f_amt_17.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_19.Text)) f_amt_19.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_20.Text)) f_amt_20.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_29.Text)) f_amt_29.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_25.Text)) f_amt_25.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_26.Text)) f_amt_26.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_27.Text)) f_amt_27.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_28.Text)) f_amt_28.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_30.Text)) f_amt_30.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_31.Text)) f_amt_31.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_32.Text)) f_amt_32.Text = "0.00";
        }

        private void Sum_Pay2(object sender, EventArgs e)
        {
            decimal Yy = Convert.ToDecimal(f_yy.SelectedValue);
            decimal Mm = Convert.ToDecimal(f_mm.SelectedValue);
            string Pr_no = f_pr_no.Text;

            decimal amt16 = 0, amt17 = 0, amt19 = 0, amt20 = 0, amt29 = 0, amt25 = 0, amt26 = 0, amt30 = 0, amt31 = 0, amt28 = 0;
            decimal tax_1 = 0, tax_2 = 0, tax_3 = 0, tax_4 = 0, tax_5 = 0, tax_6 = 0;            
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : Convert.ToDecimal(f_amt_16.Text);
                amt17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : Convert.ToDecimal(f_amt_17.Text);
                amt19 = string.IsNullOrEmpty(f_amt_19.Text) ? 0 : Convert.ToDecimal(f_amt_19.Text);
                amt20 = string.IsNullOrEmpty(f_amt_20.Text) ? 0 : Convert.ToDecimal(f_amt_20.Text);
                amt28 = string.IsNullOrEmpty(f_amt_28.Text) ? 0 : Convert.ToDecimal(f_amt_28.Text);
                amt29 = string.IsNullOrEmpty(f_amt_29.Text) ? 0 : Convert.ToDecimal(f_amt_29.Text);
                amt26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : Convert.ToDecimal(f_amt_26.Text);
                amt30 = string.IsNullOrEmpty(f_amt_30.Text) ? 0 : Convert.ToDecimal(f_amt_30.Text);
                amt31 = string.IsNullOrEmpty(f_amt_31.Text) ? 0 : Convert.ToDecimal(f_amt_31.Text);

                tax_1 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);
                tax_2 = string.IsNullOrEmpty(f_tax_2.Text) ? 0 : Convert.ToDecimal(f_tax_2.Text);
                tax_3 = string.IsNullOrEmpty(f_tax_3.Text) ? 0 : Convert.ToDecimal(f_tax_3.Text);
                tax_4 = string.IsNullOrEmpty(f_tax_4.Text) ? 0 : Convert.ToDecimal(f_tax_4.Text);
                tax_5 = string.IsNullOrEmpty(f_tax_5.Text) ? 0 : Convert.ToDecimal(f_tax_5.Text);
                tax_6 = string.IsNullOrEmpty(f_tax_6.Text) ? 0 : Convert.ToDecimal(f_tax_6.Text);                                

                //所得稅                
                amt19 = CalcuteTax.Get(Yy, Mm, Pr_no, amt16, amt28, amt29, amt30, amt31).Amt_20;
                if (amt19 < 0) amt19 = 0;
                f_amt_19.Text = amt19.ToString();

                
                //實發金額                
                amt25 = amt16 - amt17 - amt19 - amt20 - (amt28 + amt29 + amt30 + amt31);
                if (amt25 < 0) amt25 = 0;
                amt25 = Math.Round(amt25, 2, MidpointRounding.AwayFromZero);
                f_amt_25.Text = amt25.ToString();
            }
        }

        

        

        private void button1_Click(object sender, EventArgs e)
        {
            ReportParameter rp1 = new ReportParameter("pr_no");
            rp1.Values.Add(f_pr_no.Text);
            ReportParameter rp2 = new ReportParameter("year");
            rp2.Values.Add(f_yy.Text);
            ReportParameter rp3 = new ReportParameter("month");
            rp3.Values.Add(f_mm.Text);

            ReportParameter[] rparray = new ReportParameter[] { rp1,rp2,rp3 };

            ReportView fm = new ReportView("/ERP/prr030-L", rparray);

            if (fm.ShowDialog() == DialogResult.OK)
            {
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

        private void pri025_KeyDown(object sender, KeyEventArgs e)
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

        private void menu_Print_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(f_pr_no.Text))
            {
                Config.Show("請先查詢");
                return;
            }
            crr030 IForm = new crr030();

            IForm.rDept = f_pr_dept.SelectedValue.ToString();
            IForm.rYy = System.Convert.ToInt16(f_yy.Text);
            IForm.rMm = System.Convert.ToInt16((f_mm.SelectedIndex) + 1);
            IForm.rPrno = f_pr_no.Text;
            IForm.rIsCall = "Y";
            IForm.SetValue();
            IForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu_Print_Click(null, null);
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
