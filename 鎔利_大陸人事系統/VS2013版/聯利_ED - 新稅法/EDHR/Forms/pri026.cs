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
    public partial class pri026 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt031D> LS1 = new List<prt031D>();
        prt016 p_prt016 = new prt016();
        string Dept = Login.DEPT;                   
        string Cdept_Del = "N";

        public pri026()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            this.Font = new Font("新細明體", 10);
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = System.Convert.ToInt32(DeskWidth * 0.95);
            this.Height = System.Convert.ToInt32(DeskHeight * 0.95);
            InitColumn(this);
            set_dept();
            D_YY();//下拉選單-年
            D_MM();//下拉選單-月
            D_Cdpet();
            Choice_Sel();
            intCol_Right();//數字欄位靠右
            menu_add.Enabled = false;
        }

        private void D_Cdpet()
        {
            List<prt001> IL = new List<prt001>();
            IL = prt001.ToDoList(Dept).ToList();
            IL.Add(new prt001
            {
                Dept = Dept,
                Department_code=string.Empty,
                Department_name_new = "--全選--"
            });
            f_pr_cdept.DataSource = IL;
            //f_pr_cdept.DataSource = prt001.ToDoList(Dept).ToList();
            f_pr_cdept.DisplayMember = "Department_name_new";
            f_pr_cdept.ValueMember = "Department_code";
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
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
            cancel_Click(sender, e);
            Menu_Sel = "Add";
            SetColumn(this);
            Col_Disable();
            Col_Vol();
            Choice_Sel();

            //Config.FontBlod(this, false);
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

            //f_amt_31.Enabled = false;
            //f_amt_32.Enabled = false;
            //f_amt_33.Enabled = false;
            //f_amt_34.Enabled = false;
            //f_amt_35.Enabled = false;
            //f_amt_36.Enabled = false;


            f_add_user.Enabled = false;
            f_add_date.Enabled = false;
            f_mod_user.Enabled = false;
            f_mod_date.Enabled = false;

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
            f_amt_14.TextAlign = _rihgt;
            //f_amt_15.TextAlign = _rihgt;
            f_amt_16.TextAlign = _rihgt;
            f_amt_17.TextAlign = _rihgt;
            f_amt_18.TextAlign = _rihgt;
            f_amt_19.TextAlign = _rihgt;
            f_amt_20.TextAlign = _rihgt;
            f_amt_21.TextAlign = _rihgt;            
            f_amt_22.TextAlign = _rihgt;
            f_amt_23.TextAlign = _rihgt;
            f_amt_25.TextAlign = _rihgt;
            f_amt_26.TextAlign = _rihgt;
            f_amt_27.TextAlign = _rihgt;

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
                f_amt_14.Text = zro.ToString();
                //f_amt_15.Text = zro.ToString();
                f_amt_16.Text = zro.ToString();
                f_amt_17.Text = zro.ToString();
                f_amt_18.Text = zro.ToString();
                f_amt_19.Text = zro.ToString();
                f_amt_20.Text = zro.ToString();
                f_amt_21.Text = zro.ToString();
                f_amt_22.Text = zro.ToString();
                f_amt_23.Text = zro.ToString();
                f_amt_25.Text = zro.ToString();
                f_amt_26.Text = zro.ToString();
                f_amt_27.Text = zro.ToString();

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
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
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
            decimal C_Mm = System.Convert.ToDecimal(f_mm.SelectedValue);            
            
            if (Menu_Sel == "Add")
            {
                if (Config.ClosePay(C_Yy, C_Mm, Dept) == true)
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
                InitMotherboard(this);
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.ClosePay(C_Yy, C_Mm, Dept) == true)
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
                InitMotherboard(this);
            }

            if (Menu_Sel == "Del")
            {
                if (Config.ClosePay(C_Yy, C_Mm, Dept) == true)
                {
                    Config.Show("此薪資料已關帳，無法異動。");
                    return;
                } 
                Cdept_Del = "N";                
                if (Config.Message("是否刪除此部門全部資料?") == "Y")
                {                    
                    Cdept_Del = "Y";//--刪除部門
                }                
                if (Config.Message(Cdept_Del == "Y" ? "確定刪除此部門全部資料?" : "確定刪除個人資料?") == "Y")
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
            var p_prt031D = new prt031D();
            p_prt031D.Pr_no = f_pr_no.Text;
            p_prt031D.Yy = Convert.ToDecimal(f_yy.SelectedValue);
            p_prt031D.Mm = Convert.ToDecimal(f_mm.SelectedValue);
            p_prt031D.Pr_sqe = Convert.ToDecimal(f_pr_sqe.Text);
            p_prt031D.Tot_wtime = string.IsNullOrEmpty(f_tot_wtime.Text) ? 0 : System.Convert.ToDecimal(f_tot_wtime.Text);
            p_prt031D.Tot_vtime1 = string.IsNullOrEmpty(f_tot_vtime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime1.Text);
            p_prt031D.Tot_vtime2 = string.IsNullOrEmpty(f_tot_vtime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime2.Text);
            p_prt031D.Tot_ntime = string.IsNullOrEmpty(f_tot_ntime.Text) ? 0 : System.Convert.ToDecimal(f_tot_ntime.Text);
            p_prt031D.Tot_atime1 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime1.Text);
            p_prt031D.Tot_atime2 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime2.Text);
            p_prt031D.Tot_atime = string.IsNullOrEmpty(f_tot_atime.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime.Text);
            p_prt031D.Amt_1 = string.IsNullOrEmpty(f_amt_1.Text) ? 0 : System.Convert.ToDecimal(f_amt_1.Text);
            p_prt031D.Amt_2 = string.IsNullOrEmpty(f_amt_2.Text) ? 0 : System.Convert.ToDecimal(f_amt_2.Text);
            p_prt031D.Amt_3 = string.IsNullOrEmpty(f_amt_3.Text) ? 0 : System.Convert.ToDecimal(f_amt_3.Text);
            p_prt031D.Amt_4 = string.IsNullOrEmpty(f_amt_4.Text) ? 0 : System.Convert.ToDecimal(f_amt_4.Text);
            p_prt031D.Amt_5 = string.IsNullOrEmpty(f_amt_5.Text) ? 0 : System.Convert.ToDecimal(f_amt_5.Text);
            p_prt031D.Amt_6 = string.IsNullOrEmpty(f_amt_6.Text) ? 0 : System.Convert.ToDecimal(f_amt_6.Text);
            p_prt031D.Amt_7 = string.IsNullOrEmpty(f_amt_7.Text) ? 0 : System.Convert.ToDecimal(f_amt_7.Text);
            p_prt031D.Amt_8 = string.IsNullOrEmpty(f_amt_8.Text) ? 0 : System.Convert.ToDecimal(f_amt_8.Text);
            p_prt031D.Amt_9 = string.IsNullOrEmpty(f_amt_9.Text) ? 0 : System.Convert.ToDecimal(f_amt_9.Text);
            p_prt031D.Amt_10 = string.IsNullOrEmpty(f_amt_10.Text) ? 0 : System.Convert.ToDecimal(f_amt_10.Text);
            p_prt031D.Amt_11 = string.IsNullOrEmpty(f_amt_11.Text) ? 0 : System.Convert.ToDecimal(f_amt_11.Text);
            p_prt031D.Amt_12 = string.IsNullOrEmpty(f_amt_12.Text) ? 0 : System.Convert.ToDecimal(f_amt_12.Text);
            p_prt031D.Amt_13 = string.IsNullOrEmpty(f_amt_13.Text) ? 0 : System.Convert.ToDecimal(f_amt_13.Text);
            p_prt031D.Amt_14 = string.IsNullOrEmpty(f_amt_14.Text) ? 0 : System.Convert.ToDecimal(f_amt_14.Text);;
            p_prt031D.Amt_16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : System.Convert.ToDecimal(f_amt_16.Text);
            p_prt031D.Amt_17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : System.Convert.ToDecimal(f_amt_17.Text);
            p_prt031D.Amt_18 = string.IsNullOrEmpty(f_amt_18.Text) ? 0 : System.Convert.ToDecimal(f_amt_18.Text);
            p_prt031D.Amt_19 = string.IsNullOrEmpty(f_amt_19.Text) ? 0 : System.Convert.ToDecimal(f_amt_19.Text);
            p_prt031D.Amt_20 = string.IsNullOrEmpty(f_amt_20.Text) ? 0 : System.Convert.ToDecimal(f_amt_20.Text);
            p_prt031D.Amt_21 = string.IsNullOrEmpty(f_amt_21.Text) ? 0 : System.Convert.ToDecimal(f_amt_21.Text);
            p_prt031D.Amt_22 = string.IsNullOrEmpty(f_amt_22.Text) ? 0 : System.Convert.ToDecimal(f_amt_22.Text);
            p_prt031D.Amt_23 = string.IsNullOrEmpty(f_amt_23.Text) ? 0 : System.Convert.ToDecimal(f_amt_23.Text);
            p_prt031D.Amt_25 = string.IsNullOrEmpty(f_amt_25.Text) ? 0 : System.Convert.ToDecimal(f_amt_25.Text);
            p_prt031D.Amt_26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : System.Convert.ToDecimal(f_amt_26.Text);
            p_prt031D.Amt_27 = string.IsNullOrEmpty(f_amt_27.Text) ? 0 : System.Convert.ToDecimal(f_amt_27.Text);
            p_prt031D.Add_user = Home.Id;
            p_prt016 = prt016.Get(p_prt031D.Pr_no);
            p_prt031D.Pr_direct_type = p_prt016.Pr_direct_type;
            p_prt031D.Direct_type1 = p_prt016.Direct_type1;
            p_prt031D.Direct_type2 = p_prt016.Direct_type2;
            p_prt031D.Cdept_no = f_pr_cdept.SelectedValue.ToString();

            p_prt031D.Tax_1 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : System.Convert.ToDecimal(f_tax_1.Text);
            p_prt031D.Tax_2 = string.IsNullOrEmpty(f_tax_2.Text) ? 0 : System.Convert.ToDecimal(f_tax_2.Text);
            p_prt031D.Tax_3 = string.IsNullOrEmpty(f_tax_3.Text) ? 0 : System.Convert.ToDecimal(f_tax_3.Text);
            p_prt031D.Tax_4 = string.IsNullOrEmpty(f_tax_4.Text) ? 0 : System.Convert.ToDecimal(f_tax_4.Text);
            p_prt031D.Tax_5 = string.IsNullOrEmpty(f_tax_5.Text) ? 0 : System.Convert.ToDecimal(f_tax_5.Text);
            p_prt031D.Tax_6 = string.IsNullOrEmpty(f_tax_6.Text) ? 0 : System.Convert.ToDecimal(f_tax_6.Text);            
            return p_prt031D.Insert();
        }


        private string f_Update_1()
        {   
            var p_prt031D = new prt031D();
            p_prt031D.Pr_no = f_pr_no.Text;
            p_prt031D.Yy = Convert.ToDecimal(f_yy.Text);
            p_prt031D.Mm = Convert.ToDecimal(f_mm.Text);
            p_prt031D.Pr_sqe = Convert.ToDecimal(f_pr_sqe.Text);
            p_prt031D.Tot_wtime = string.IsNullOrEmpty(f_tot_wtime.Text) ? 0 : System.Convert.ToDecimal(f_tot_wtime.Text);
            p_prt031D.Tot_vtime1 = string.IsNullOrEmpty(f_tot_vtime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime1.Text);
            p_prt031D.Tot_vtime2 = string.IsNullOrEmpty(f_tot_vtime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_vtime2.Text);
            p_prt031D.Tot_ntime = string.IsNullOrEmpty(f_tot_ntime.Text) ? 0 : System.Convert.ToDecimal(f_tot_ntime.Text);
            p_prt031D.Tot_atime1 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime1.Text);
            p_prt031D.Tot_atime2 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime2.Text);
            p_prt031D.Tot_atime = string.IsNullOrEmpty(f_tot_atime.Text) ? 0 : System.Convert.ToDecimal(f_tot_atime.Text);
            p_prt031D.Amt_1 = string.IsNullOrEmpty(f_amt_1.Text) ? 0 : System.Convert.ToDecimal(f_amt_1.Text);
            p_prt031D.Amt_2 = string.IsNullOrEmpty(f_amt_2.Text) ? 0 : System.Convert.ToDecimal(f_amt_2.Text);
            p_prt031D.Amt_3 = string.IsNullOrEmpty(f_amt_3.Text) ? 0 : System.Convert.ToDecimal(f_amt_3.Text);
            p_prt031D.Amt_4 = string.IsNullOrEmpty(f_amt_4.Text) ? 0 : System.Convert.ToDecimal(f_amt_4.Text);
            p_prt031D.Amt_5 = string.IsNullOrEmpty(f_amt_5.Text) ? 0 : System.Convert.ToDecimal(f_amt_5.Text);
            p_prt031D.Amt_6 = string.IsNullOrEmpty(f_amt_6.Text) ? 0 : System.Convert.ToDecimal(f_amt_6.Text);
            p_prt031D.Amt_7 = string.IsNullOrEmpty(f_amt_7.Text) ? 0 : System.Convert.ToDecimal(f_amt_7.Text);
            p_prt031D.Amt_8 = string.IsNullOrEmpty(f_amt_8.Text) ? 0 : System.Convert.ToDecimal(f_amt_8.Text);
            p_prt031D.Amt_9 = string.IsNullOrEmpty(f_amt_9.Text) ? 0 : System.Convert.ToDecimal(f_amt_9.Text);
            p_prt031D.Amt_10 = string.IsNullOrEmpty(f_amt_10.Text) ? 0 : System.Convert.ToDecimal(f_amt_10.Text);
            p_prt031D.Amt_11 = string.IsNullOrEmpty(f_amt_11.Text) ? 0 : System.Convert.ToDecimal(f_amt_11.Text);
            p_prt031D.Amt_12 = string.IsNullOrEmpty(f_amt_12.Text) ? 0 : System.Convert.ToDecimal(f_amt_12.Text);
            p_prt031D.Amt_13 = string.IsNullOrEmpty(f_amt_13.Text) ? 0 : System.Convert.ToDecimal(f_amt_13.Text);
            p_prt031D.Amt_14 = string.IsNullOrEmpty(f_amt_14.Text) ? 0 : System.Convert.ToDecimal(f_amt_14.Text);
            
            p_prt031D.Amt_16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : System.Convert.ToDecimal(f_amt_16.Text);
            p_prt031D.Amt_17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : System.Convert.ToDecimal(f_amt_17.Text);
            p_prt031D.Amt_18 = string.IsNullOrEmpty(f_amt_18.Text) ? 0 : System.Convert.ToDecimal(f_amt_18.Text);
            p_prt031D.Amt_19 = string.IsNullOrEmpty(f_amt_19.Text) ? 0 : System.Convert.ToDecimal(f_amt_19.Text);
            p_prt031D.Amt_20 = string.IsNullOrEmpty(f_amt_20.Text) ? 0 : System.Convert.ToDecimal(f_amt_20.Text);
            p_prt031D.Amt_21 = string.IsNullOrEmpty(f_amt_21.Text) ? 0 : System.Convert.ToDecimal(f_amt_21.Text);
            p_prt031D.Amt_22 = string.IsNullOrEmpty(f_amt_22.Text) ? 0 : System.Convert.ToDecimal(f_amt_22.Text);
            p_prt031D.Amt_23 = string.IsNullOrEmpty(f_amt_23.Text) ? 0 : System.Convert.ToDecimal(f_amt_23.Text);
            p_prt031D.Amt_25 = string.IsNullOrEmpty(f_amt_25.Text) ? 0 : System.Convert.ToDecimal(f_amt_25.Text);
            p_prt031D.Amt_26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : System.Convert.ToDecimal(f_amt_26.Text);
            p_prt031D.Amt_27 = string.IsNullOrEmpty(f_amt_27.Text) ? 0 : System.Convert.ToDecimal(f_amt_27.Text);
            p_prt031D.Mod_user = Home.Id;
            p_prt016 = prt016.Get(p_prt031D.Pr_no);
            p_prt031D.Pr_direct_type = p_prt016.Pr_direct_type;
            p_prt031D.Direct_type1 = p_prt016.Direct_type1;
            p_prt031D.Direct_type2 = p_prt016.Direct_type2;
            p_prt031D.Cdept_no = f_pr_cdept.SelectedValue.ToString();

            p_prt031D.Tax_1 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : System.Convert.ToDecimal(f_tax_1.Text);
            p_prt031D.Tax_2 = string.IsNullOrEmpty(f_tax_2.Text) ? 0 : System.Convert.ToDecimal(f_tax_2.Text);
            p_prt031D.Tax_3 = string.IsNullOrEmpty(f_tax_3.Text) ? 0 : System.Convert.ToDecimal(f_tax_3.Text);
            p_prt031D.Tax_4 = string.IsNullOrEmpty(f_tax_4.Text) ? 0 : System.Convert.ToDecimal(f_tax_4.Text);
            p_prt031D.Tax_5 = string.IsNullOrEmpty(f_tax_5.Text) ? 0 : System.Convert.ToDecimal(f_tax_5.Text);
            p_prt031D.Tax_6 = string.IsNullOrEmpty(f_tax_6.Text) ? 0 : System.Convert.ToDecimal(f_tax_6.Text);
            
            return p_prt031D.Update(p_prt031D.Yy, p_prt031D.Mm,p_prt031D.Pr_no,p_prt031D.Pr_sqe);
        }

        private string f_Delete_1()
        {
            var p_prt031D = new prt031D();
            decimal _yy = Convert.ToDecimal(f_yy.Text);
            decimal _mm = Convert.ToDecimal(f_mm.Text);
            if (Cdept_Del == "Y")
            {
                return p_prt031D.Delete(_yy, _mm, f_pr_cdept.SelectedValue.ToString());
            }
            else
            {
                return p_prt031D.Delete(_yy, _mm, f_pr_no.Text, Convert.ToDecimal(f_pr_sqe.Text));
            }
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            Col_Vol();
            Dept = Login.DEPT;
            f_pr_cdept.SelectedIndex = f_pr_cdept.Items.Count - 1;
            //Config.FontBlod(this, true);//字體加粗
        }

        private void f_Query()
        {
            decimal? _yy = Convert.ToDecimal(f_yy.SelectedValue);
            decimal? _mm = Convert.ToDecimal(f_mm.SelectedValue);
            LS1.Clear();            
            LS1 = prt031D.ToDoList(_yy, _mm, f_pr_no.Text, 1, f_pr_cdept.SelectedValue.ToString()).ToList();
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
                Find_p(LS1[idx].Pr_no,LS1[idx].Cdept_no);

                f_yy.Text = LS1[idx].Yy.ToString();
                f_mm.Text = LS1[idx].Mm.ToString();

                if (Menu_Sel != "Add")
                {
                    f_pr_sqe.Text = LS1[idx].Pr_sqe.ToString();
                    f_tot_wtime.Text = LS1[idx].Tot_wtime.ToString();
                    f_tot_vtime1.Text = LS1[idx].Tot_vtime1.ToString();
                    f_tot_vtime2.Text = LS1[idx].Tot_vtime2.ToString();
                    f_tot_ntime.Text = LS1[idx].Tot_ntime.ToString();
                    f_tot_atime1.Text = LS1[idx].Tot_atime1.ToString();
                    f_tot_atime2.Text = LS1[idx].Tot_atime2.ToString();
                    f_tot_atime.Text = LS1[idx].Tot_atime.ToString();
                }

                f_amt_1.Text = LS1[idx].Amt_1.ToString();
                f_amt_2.Text = LS1[idx].Amt_2.ToString();
                f_amt_3.Text = LS1[idx].Amt_3.ToString();
                f_amt_4.Text = LS1[idx].Amt_4.ToString();
                f_amt_5.Text = LS1[idx].Amt_5.ToString();
                f_amt_6.Text = LS1[idx].Amt_6.ToString();
                f_amt_7.Text = LS1[idx].Amt_7.ToString();
                f_amt_8.Text = LS1[idx].Amt_8.ToString();
                f_amt_9.Text = LS1[idx].Amt_9.ToString();
                f_amt_10.Text = LS1[idx].Amt_10.ToString();
                f_amt_11.Text = LS1[idx].Amt_11.ToString();
                f_amt_12.Text = LS1[idx].Amt_12.ToString();
                f_amt_13.Text = LS1[idx].Amt_13.ToString();
                f_amt_14.Text = LS1[idx].Amt_14.ToString();
               // f_amt_15.Text = LS1[idx].Amt_15.ToString();
                f_amt_16.Text = LS1[idx].Amt_16.ToString();
                f_amt_17.Text = LS1[idx].Amt_17.ToString();
                f_amt_18.Text = LS1[idx].Amt_18.ToString();
                f_amt_19.Text = LS1[idx].Amt_19.ToString();
                f_amt_20.Text = LS1[idx].Amt_20.ToString();
                f_amt_21.Text = LS1[idx].Amt_21.ToString();
                f_amt_22.Text = LS1[idx].Amt_22.ToString();
                f_amt_23.Text = LS1[idx].Amt_23.ToString();
                f_amt_25.Text = LS1[idx].Amt_25.ToString();
                f_amt_26.Text = LS1[idx].Amt_26.ToString();
                f_amt_27.Text = LS1[idx].Amt_27.ToString();

                f_add_date.Text = string.IsNullOrEmpty(LS1[idx].Add_date) ? "" : Convert.ToDateTime(LS1[idx].Add_date).ToString("yyyy/MM/dd");
                f_add_user.Text = LS1[idx].Add_user.Trim();
                f_mod_date.Text = string.IsNullOrEmpty(LS1[idx].Mod_date) ? "" : Convert.ToDateTime(LS1[idx].Mod_date).ToString("yyyy/MM/dd");
                f_mod_user.Text = LS1[idx].Mod_user.Trim();

                f_tax_1.Text = LS1[idx].Tax_1.ToString();
                f_tax_2.Text = LS1[idx].Tax_2.ToString();
                f_tax_3.Text = LS1[idx].Tax_3.ToString();
                f_tax_4.Text = LS1[idx].Tax_4.ToString();
                f_tax_5.Text = LS1[idx].Tax_5.ToString();
                f_tax_6.Text = LS1[idx].Tax_6.ToString();                
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
            if (f_pr_no.Text != "" && (Menu_Sel == "Qry" || Menu_Sel == "Upd"))
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                code_dearch_bt.Enabled = false;
                Col_Disable();
                f_tot_wtime.Focus();

                f_tax_1.ReadOnly = true;
                f_tax_2.ReadOnly = true;
                f_tax_3.ReadOnly = true;
                f_tax_4.ReadOnly = true;
                f_tax_5.ReadOnly = true;
                f_tax_6.ReadOnly = true;

                //Config.FontBlod(this, false);//字體不加粗
            }
            else
            {
                Config.Show("請先查詢");
            }
        }
        
        
        private void code_dearch_bt_Click(object sender, EventArgs e)
        {            
            pri019w fm = new pri019w(Dept, (Int32)f_yy.SelectedValue, (Int32)f_mm.SelectedValue, "", "");//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                Find_p(f_pr_no.Text,"");
            }            
            if (Menu_Sel == "Add" && f_pr_no.Text.Length>0)
            {
                Find_2();//找出缺勤相關資料
            }
        }


        private void Find_2()
        {   
            Int32 Yy = Convert.ToInt32(f_yy.SelectedValue);
            Int32 Mm = Convert.ToInt32(f_mm.SelectedValue);
            string Pr_no = f_pr_no.Text.Trim();
            decimal seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7 = 0;
            seq_no = string.IsNullOrEmpty(f_pr_sqe.Text) ? 0 : Convert.ToDecimal(f_pr_sqe.Text);
            amt1 =  string.IsNullOrEmpty(f_tot_wtime.Text) ? 0 : Convert.ToDecimal(f_tot_wtime.Text);
            amt2 = string.IsNullOrEmpty(f_tot_vtime1.Text) ? 0 : Convert.ToDecimal(f_tot_vtime1.Text);
            amt3 = string.IsNullOrEmpty(f_tot_vtime2.Text) ? 0 : Convert.ToDecimal(f_tot_vtime2.Text);
            amt4 = string.IsNullOrEmpty(f_tot_ntime.Text) ? 0 : Convert.ToDecimal(f_tot_ntime.Text);
            amt5 = string.IsNullOrEmpty(f_tot_atime1.Text) ? 0 : Convert.ToDecimal(f_tot_atime1.Text);
            amt6 = string.IsNullOrEmpty(f_tot_atime2.Text) ? 0 : Convert.ToDecimal(f_tot_atime2.Text);
            amt7 = string.IsNullOrEmpty(f_tot_atime.Text) ? 0 : Convert.ToDecimal(f_tot_atime.Text);

            if (f_pr_no.Text.Length == 0) return;

            if (prt031D.ToDoList(Yy, Mm, f_pr_no.Text, Convert.ToDecimal(f_pr_sqe.Text)).Count() > 0)
            {
                Config.Show("以有此筆資料,請查詢後處理");
                return;
            }
            if (!string.IsNullOrEmpty(f_pr_no.Text) && prt016.Get(f_pr_no.Text) == null) //人事主檔
            {
                Config.Show("人事主檔沒資料");
                return;
            }
            int Last_seq = prt021.Get_Last_Seq_no(f_pr_no.Text);
            if (!string.IsNullOrEmpty(f_pr_no.Text) && prt021.Get(f_pr_no.Text, Last_seq) == null)
            {
                Config.Show("找不到薪資設定資料");
                return;
            }

            p_prt016 = prt016.Get(Pr_no);
            //有出勤資料
            if (prt030D.ToDoListByGroup(Dept, Yy, Mm, f_pr_no.Text).Count() > 0)
            {
                //出勤時數 wtime
                amt1 = prt030D.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Pr_wtime);

                //請假時數va_time1
                amt2 = prt030D.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Va_time1);

                //曠職時數 va_time2
                amt3 = prt030D.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Va_time2);

                //夜班 
                amt4 = prt030D.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code1 == "Y").Count();

                //平日加班
                amt5 = prt030D.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => Convert.ToDateTime(m.Pr_date).DayOfWeek.ToString("d") != "0" && Convert.ToDateTime(m.Pr_date).DayOfWeek.ToString("d") != "6").Sum(m => m.Pr_atime);

                //假日加班
                amt6 = prt030D.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => Convert.ToDateTime(m.Pr_date).DayOfWeek.ToString("d") == "0" || Convert.ToDateTime(m.Pr_date).DayOfWeek.ToString("d") == "6").Sum(m => m.Pr_atime);

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
           
        }


        private void P_Sing(string Dept,Int32 Yy,Int32 Mm,string Pr_no,decimal seq_no, decimal amt1,decimal amt2,decimal amt3, decimal amt4,decimal amt5,decimal amt6,decimal amt7)
        {
            if (prt031D.Pay_TrnSingle(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7) == null)
            {
                return;
            }
            var p_prt031D = prt031D.Pay_TrnSingle(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7);
            f_amt_1.Text = p_prt031D.Amt_1.ToString();
            f_amt_2.Text = p_prt031D.Amt_2.ToString();
            f_amt_3.Text = p_prt031D.Amt_3.ToString();
            f_amt_4.Text = p_prt031D.Amt_4.ToString();
            f_amt_5.Text = p_prt031D.Amt_5.ToString();
            f_amt_6.Text = p_prt031D.Amt_6.ToString();
            f_amt_7.Text = p_prt031D.Amt_7.ToString();
            f_amt_8.Text = p_prt031D.Amt_8.ToString();
            f_amt_9.Text = p_prt031D.Amt_9.ToString();
            f_amt_10.Text = p_prt031D.Amt_10.ToString();
            f_amt_11.Text = p_prt031D.Amt_11.ToString();
            f_amt_12.Text = p_prt031D.Amt_12.ToString();
            f_amt_13.Text = p_prt031D.Amt_13.ToString();
            f_amt_14.Text = p_prt031D.Amt_14.ToString();;
            f_amt_16.Text = p_prt031D.Amt_16.ToString();
            f_amt_17.Text = p_prt031D.Amt_17.ToString();
            f_amt_18.Text = p_prt031D.Amt_18.ToString();
            f_amt_19.Text = p_prt031D.Amt_19.ToString();
            f_amt_20.Text = p_prt031D.Amt_20.ToString();
            f_amt_21.Text = p_prt031D.Amt_21.ToString();
            f_amt_22.Text = p_prt031D.Amt_22.ToString();
            f_amt_23.Text = p_prt031D.Amt_23.ToString();
            f_amt_25.Text = p_prt031D.Amt_25.ToString();
            f_amt_26.Text = p_prt031D.Amt_26.ToString();
            f_amt_27.Text = p_prt031D.Amt_27.ToString();
        }


        private void Find_p(string Pr_no,string Cdept_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            if (p_prt016 == null) return;

            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_pr_dept.SelectedValue = p_prt016.Pr_dept;
            if (!string.IsNullOrEmpty(Cdept_no))
            {
                f_pr_cdept.SelectedValue = Cdept_no;                
            }
            else{
                f_pr_cdept.SelectedValue = p_prt016.Pr_cdept;
            }
            f_pr_in_date.Text = string.IsNullOrEmpty(p_prt016.Pr_in_date) ? "" : Convert.ToDateTime(p_prt016.Pr_in_date).ToString("yyyy/MM/dd");
            f_pr_leave_date.Text = string.IsNullOrEmpty(p_prt016.Pr_leave_date) ? "" : Convert.ToDateTime(p_prt016.Pr_leave_date).ToString("yyyy/MM/dd");
        }


        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != "" && Menu_Sel == "Qry")
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


        private void Sum_Pay1(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt2 = 0, amt3 = 0, amt4 = 0, amt5 = 0, amt6 = 0, amt7 = 0, 
                amt8 = 0, amt9 = 0, amt10 = 0, amt11 = 0, amt12 = 0, amt13 = 0, amt14 = 0, 
                amt16 = 0, amt17 = 0,amt19 = 0, amt21 = 0, amt22 = 0, amt23 = 0, amt26 = 0, amt27 = 0;
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
                amt14 = string.IsNullOrEmpty(f_amt_14.Text) ? 0 : Convert.ToDecimal(f_amt_14.Text);
                amt16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : Convert.ToDecimal(f_amt_16.Text);
                amt17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : Convert.ToDecimal(f_amt_17.Text);
                amt21 = string.IsNullOrEmpty(f_amt_21.Text) ? 0 : Convert.ToDecimal(f_amt_21.Text);
                amt22 = string.IsNullOrEmpty(f_amt_22.Text) ? 0 : Convert.ToDecimal(f_amt_22.Text);
                amt23 = string.IsNullOrEmpty(f_amt_23.Text) ? 0 : Convert.ToDecimal(f_amt_23.Text);
                amt26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : Convert.ToDecimal(f_amt_26.Text);
                amt27 = string.IsNullOrEmpty(f_amt_27.Text) ? 0 : Convert.ToDecimal(f_amt_27.Text);

                //應發金額
                amt16 = amt1 + amt2 + amt3 +
                    amt4 + amt5 + amt6 +
                    amt7 + amt8 + amt9 +
                    amt10 - amt11 - amt12 +
                    amt13 + amt14  + amt27;
                f_amt_16.Text = amt16.ToString();

                //******找稅率*******
                DateTime wk_date1, wk_date2 = new DateTime();
                string _dd = String.Format("{0}/{1}/1", f_yy.SelectedValue, f_mm.SelectedValue);
                wk_date1 = DateTime.Parse(_dd);//當月第一天
                wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天

                if (p_prt016 == null) return;

                if (p_prt016.Nation == null)
                {
                    p_prt016.Nation = "0";
                }
                decimal tmp_16 = 0M;
                ////應發新資-免稅額                
                if (p_prt016.Nation == "0")//本國
                {
                    //do
                    tmp_16 = amt16 - amt17 - amt21 - amt22 - amt23 - amt26 - prt013.GetWith(Dept, p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt;
                    if (tmp_16 > 0)
                    {
                        //找級距
                        var p_prt012 = new prt012();
                        p_prt012 = prt012.Get(Dept, tmp_16);
                        amt19 = tmp_16 * (p_prt012.Tax_rate * 0.01M) - p_prt012.Amt_sub;
                    }
                }
                else
                {   
                    tmp_16 = amt16 - prt013.GetWith(Dept, p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt;
                    if (tmp_16 > 0)
                    {
                        //找級距
                        var p_prt012 = new prt012();
                        p_prt012 = prt012.Get(Dept, tmp_16);
                        amt19 = tmp_16 * (p_prt012.Tax_rate * 0.01M) - p_prt012.Amt_sub;
                    }
                }
                amt19 = Math.Round(amt19, 2, MidpointRounding.AwayFromZero);
                f_amt_19.Text = amt19.ToString();
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

        private void Sum_Pay2(object sender, EventArgs e)
        {
            decimal amt16 = 0, amt17 = 0, amt18 = 0, amt19 = 0, amt20 = 0, amt21 = 0, amt22 = 0, amt23 = 0, amt25 = 0, amt26 = 0;
            decimal tax1 = 0, tax2 = 0, tax3 = 0, tax4 = 0, tax5 = 0, tax6 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt16 = string.IsNullOrEmpty(f_amt_16.Text) ? 0 : Convert.ToDecimal(f_amt_16.Text);
                amt17 = string.IsNullOrEmpty(f_amt_17.Text) ? 0 : Convert.ToDecimal(f_amt_17.Text);
                amt18 = string.IsNullOrEmpty(f_amt_18.Text) ? 0 : Convert.ToDecimal(f_amt_18.Text);
                amt19 = string.IsNullOrEmpty(f_amt_19.Text) ? 0 : Convert.ToDecimal(f_amt_19.Text);
                amt20 = string.IsNullOrEmpty(f_amt_20.Text) ? 0 : Convert.ToDecimal(f_amt_20.Text);
                amt21 = string.IsNullOrEmpty(f_amt_21.Text) ? 0 : Convert.ToDecimal(f_amt_21.Text);
                amt22 = string.IsNullOrEmpty(f_amt_22.Text) ? 0 : Convert.ToDecimal(f_amt_22.Text);
                amt23 = string.IsNullOrEmpty(f_amt_23.Text) ? 0 : Convert.ToDecimal(f_amt_23.Text);
                amt25 = string.IsNullOrEmpty(f_amt_25.Text) ? 0 : Convert.ToDecimal(f_amt_25.Text);
                amt26 = string.IsNullOrEmpty(f_amt_26.Text) ? 0 : Convert.ToDecimal(f_amt_26.Text);

                tax1 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);
                tax2 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);
                tax3 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);
                tax4 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);
                tax5 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);
                tax6 = string.IsNullOrEmpty(f_tax_1.Text) ? 0 : Convert.ToDecimal(f_tax_1.Text);

                if (f_pr_no.Text.Length == 0) return;

                //所得稅
                amt19 = CalcuteTax.Get((int)f_yy.SelectedValue, (int)f_mm.SelectedValue, f_pr_no.Text, amt16, amt17, amt21, amt22, amt23, amt26).Amt_20;               
                if (p_prt016.Nation == "0")//本國
                {
                    amt25 = amt16 - amt17 - amt20 - amt21 - amt23 - amt26 - amt19;
                    amt25 = Math.Round(amt25, 2, MidpointRounding.AwayFromZero);
                    f_amt_25.Text = amt25.ToString();
                }
                else //外國
                {
                    amt25 = amt16 - amt19;
                    amt25 = Math.Round(amt25, 2, MidpointRounding.AwayFromZero);
                    f_amt_25.Text = amt25.ToString();
                }
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
            if (string.IsNullOrEmpty(f_amt_14.Text)) f_amt_14.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_16.Text)) f_amt_16.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_17.Text)) f_amt_17.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_18.Text)) f_amt_18.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_19.Text)) f_amt_19.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_20.Text)) f_amt_20.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_21.Text)) f_amt_21.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_22.Text)) f_amt_22.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_23.Text)) f_amt_23.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_25.Text)) f_amt_25.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_26.Text)) f_amt_26.Text = "0.00";
            if (string.IsNullOrEmpty(f_amt_27.Text)) f_amt_27.Text = "0.00";
        }

        private void f_mm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                SetColumn(this);
                Col_Disable();
                Col_Vol();
                Find_2();
            }
        }

        private void f_yy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                SetColumn(this);
                Col_Disable();
                Col_Vol();
                Find_2();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportParameter rp1 = new ReportParameter("pr_no");
            rp1.Values.Add(f_pr_no.Text);
            ReportParameter rp2 = new ReportParameter("year");
            rp2.Values.Add(f_yy.Text);
            ReportParameter rp3 = new ReportParameter("month");
            rp2.Values.Add(f_mm.Text);

            ReportParameter[] rparray = new ReportParameter[] { rp1, rp2, rp3 };

            ReportView fm = new ReportView("/ERP/prr030-S", rparray);

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

        private void pri026_KeyDown(object sender, KeyEventArgs e)
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

        private void menu_print_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(f_pr_no.Text))
            {
                Config.Show("請先查詢");
                return;
            }
            crr030 IForm = new crr030();
            IForm.rDept = Dept;
            IForm.rYy = System.Convert.ToInt16(f_yy.Text);
            IForm.rMm = System.Convert.ToInt16((f_mm.SelectedIndex) + 1);
            IForm.rPrno = f_pr_no.Text;
            IForm.rIsCall = "Y";
            IForm.SetValue();
            IForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu_print_Click(null, null);
        }

        private void pri026_Load(object sender, EventArgs e)
        {
            Config.FontBlod(this, true);//字體加粗
        }
        

        
        
    }
}
