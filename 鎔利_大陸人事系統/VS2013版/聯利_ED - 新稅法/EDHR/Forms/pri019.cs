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

using System.Threading;
using EDHR.Forms;

namespace EDHR.Forms
{
    public partial class pri019 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt016> LS1 = new List<prt016>();
        prt028 p_prt0028 = new prt028();
        string Dept = Login.DEPT;
        

        public pri019()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            this.Font = new Font("新細明體", 10);
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = System.Convert.ToInt32(DeskWidth * 0.95);
            this.Height = System.Convert.ToInt32(DeskHeight * 0.95);
            InitColumn(this);//初始

            set_dept();
            D_Sex();//性別下拉選單
            D_Blood();//血型下拉選單
            D_Meery();//婚姻下拉選單
            D_Pr_direct_type();//支薪代碼
            D_Pr_slry_type();//薪資種類
            D_Direct_type1();//成本直間接
            D_Direct_type2();//會計直間接
            D_Nation();//國籍別
            D_Safe_old(Dept);//養老保險等級
            D_Safe_medic(Dept);//醫療保險等級
            D_Safe_job(Dept);//失業保險等級
            D_Safe_house(Dept);//住房公積等級

            D_Cdpet();//部門
            D_WkCdpet();//工作部門
            D_Work();//職稱
            D_Schl();//學歷
            D_Long();//專長
            D_Position();//職位
            D_Class();//班別
            D_WkCode();//職等
        }

        public pri019(string rSel, string PrNo)
        {
            InitializeComponent();
            Config.SetFormSize(this);
            this.Font = new Font("新細明體", 10);
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = System.Convert.ToInt32(DeskWidth * 0.95);
            this.Height = System.Convert.ToInt32(DeskHeight * 0.95);
            InitColumn(this);//初始

            set_dept();
            D_Sex();//性別下拉選單
            D_Blood();//血型下拉選單
            D_Meery();//婚姻下拉選單
            D_Pr_direct_type();//支薪代碼
            D_Pr_slry_type();//薪資種類
            D_Direct_type1();//成本直間接
            D_Direct_type2();//會計直間接
            D_Nation();//國籍別
            D_Safe_old(Dept);//養老保險等級
            D_Safe_medic(Dept);//醫療保險等級
            D_Safe_job(Dept);//失業保險等級
            D_Safe_house(Dept);//住房公積等級

            D_Cdpet();//部門
            D_WkCdpet();//工作部門
            D_Work();//職稱
            D_Schl();//學歷
            D_Long();//專長
            D_Position();//職位
            D_Class();//班別
            D_WkCode();//職等

            Menu_Sel = rSel;
            bindingNavigator1.Visible = false;
            if (rSel == "Add")
            {                
                menu_add_Click(this, null);
            }
            
            if (rSel == "Qry" || rSel == "Upd" || rSel == "Del")
            {
                //--找資料                
                menu_query_Click(null, null); f_pr_no.Text = PrNo;
                f_Query();
            }
        }


        private void Init_S()
        {
            set_dept();
            D_Sex();//性別下拉選單
            D_Blood();//血型下拉選單
            D_Meery();//婚姻下拉選單
            D_Pr_direct_type();//支薪代碼
            D_Pr_slry_type();//薪資種類
            D_Direct_type1();//成本直間接
            D_Direct_type2();//會計直間接
            D_Nation();//國籍別
            D_Safe_old(Dept);//養老保險等級
            D_Safe_medic(Dept);//醫療保險等級
            D_Safe_job(Dept);//失業保險等級
            D_Safe_house(Dept);//住房公積等級

            D_Cdpet();//部門
            D_WkCdpet();//工作部門
            D_Work();//職稱
            D_Schl();//學歷
            D_Long();//專長
            D_Position();//職位
            D_Class();//班別
            D_WkCode();//職等

            f_pr_sex.SelectedIndex = 1;
            f_pr_merry.SelectedIndex = 1;
            f_pr_blood.SelectedIndex = 1;
            f_pr_slry_type.SelectedIndex = 1;
            f_pr_work.SelectedIndex = 1;
            f_pr_direct_type.SelectedIndex = 1;
            f_pr_cdept.SelectedIndex = 1;
            f_pr_schl.SelectedIndex = 1;
            f_pr_long.SelectedIndex = 1;
            f_pr_wk_cdept.SelectedIndex = 1;
            f_position.SelectedIndex = 1;
            f_pr_clas_code.SelectedIndex = 1;
            f_old_safe_no.SelectedIndex = 1;
            f_medic_safe_no.SelectedIndex = 1;
            f_job_safe_no.SelectedIndex = 1;
            f_house_safe_no.SelectedIndex = 1;
            f_nation.SelectedIndex = 1;
        }

        private void D_Class()
        {
            List<prt006> IL = new List<prt006>();
            IL = prt006.ToDoListCode(Dept, "CL", "Y").OrderBy(a => a.Code_desc).ToList();
            IL.Insert(0, new prt006
            {
                Code = string.Empty,
                Code_desc = "請選擇"
            });
            f_pr_clas_code.DataSource = IL;
            f_pr_clas_code.DisplayMember = "Code_desc";
            f_pr_clas_code.ValueMember = "Code";
        }
        private void D_Position()
        {   
            List<prt006> IL = new List<prt006>();
            IL = prt006.ToDoListCode(Dept, "WT", "Y").OrderBy(a => a.Code_desc).ToList();
            IL.Insert(0, new prt006
            {
                Code = string.Empty,
                Code_desc = "請選擇"
            });
            f_position.DataSource = IL;
            f_position.DisplayMember = "Code_desc";
            f_position.ValueMember = "Code";
        }
        private void D_Long()
        {
            //f_pr_long.DataSource = prt006.ToDoListCode(Dept, "LG", "Y").ToList().OrderBy(a=>a.Code_desc);
            //f_pr_long.DataSource = prt006.ToDoListCode(Dept, "LG", "Y").OrderBy(a => a.Code_desc).ToList();
            List<prt006> IL = new List<prt006>();
            IL = prt006.ToDoListCode(Dept, "LG", "Y").OrderBy(a => a.Code_desc).ToList();
            IL.Insert(0, new prt006
            {
                Code = string.Empty,
                Code_desc = "請選擇"
            });
            f_pr_long.DataSource = IL;
            f_pr_long.DisplayMember = "Code_desc";
            f_pr_long.ValueMember = "Code";
        }
        private void D_Schl()
        {
            //f_pr_schl.DataSource = prt006.ToDoListCode(Dept, "SC", "Y").OrderByDescending(m => m.Code).ToList();
            List<prt006> IL = new List<prt006>();
            IL = prt006.ToDoListCode(Dept, "SC", "Y").OrderBy(a => a.Code_desc).ToList();
            IL.Insert(0, new prt006
            {
                Code = string.Empty,
                Code_desc = "請選擇"
            });
            f_pr_schl.DataSource = IL;
            f_pr_schl.DisplayMember = "Code_desc";
            f_pr_schl.ValueMember = "Code";
        }

        private void D_Work()
        {   
            //f_pr_work.DataSource = prt006.ToDoListCode(Dept, "WK", "Y").ToList();
            List<prt006> IL = new List<prt006>();
            IL = prt006.ToDoListCode(Dept, "WK", "Y").OrderBy(a => a.Code_desc).ToList();
            IL.Insert(0, new prt006
            {
                Code = string.Empty,
                Code_desc = "請選擇"
            });
            f_pr_work.DataSource = IL;
            f_pr_work.DisplayMember = "Code_desc";
            f_pr_work.ValueMember = "Code";
        }
        private void D_WkCdpet()
        {
            //f_pr_wk_cdept.DataSource = prt001.ToDoList(Dept).ToList();
            List<prt001> IL = new List<prt001>();
            IL = prt001.ToDoList(Dept).OrderBy(a => a.Department_name_new).ToList();
            IL.Insert(0, new prt001
            {
                Department_code = string.Empty,
                Department_name_new = "請選擇"
            });
            f_pr_wk_cdept.DataSource = IL;
            f_pr_wk_cdept.DisplayMember = "Department_name_new";
            f_pr_wk_cdept.ValueMember = "Department_code";
        }
        private void D_Cdpet()
        {
            //f_pr_cdept.DataSource = prt001.ToDoList(Dept).ToList();
            List<prt001> IL = new List<prt001>();
            IL = prt001.ToDoList(Dept).OrderBy(a => a.Department_name_new).ToList();
            IL.Insert(0, new prt001
            {
                Department_code = string.Empty,
                Department_name_new = "請選擇"
            });
            f_pr_cdept.DataSource = IL;
            f_pr_cdept.DisplayMember = "Department_name_new";
            f_pr_cdept.ValueMember = "Department_code";
        }


        private void D_WkCode()
        {
            //f_wk_code.DataSource = prt011.ToDoList("", Dept).ToList();
            f_wk_code.DataSource = prt011.ToDoList("", Dept).OrderBy(a=>a.Wk_code).ToList();
            f_wk_code.DisplayMember = "Wk_code";
            f_wk_code.ValueMember = "Wk_code";
        }

        
        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
        }
        private void D_Sex()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("男", "M"));
            data.Add(new DictionaryEntry("女", "F"));
            f_pr_sex.DisplayMember = "Key";
            f_pr_sex.ValueMember = "Value";
            f_pr_sex.DataSource = data;
        }
        private void D_Blood()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("A型", "A"));
            data.Add(new DictionaryEntry("B型", "B"));
            data.Add(new DictionaryEntry("O型", "O"));
            data.Add(new DictionaryEntry("AB型", "AB"));
            //data.Add(new DictionaryEntry("RH+型", "RH+"));
            //data.Add(new DictionaryEntry("RH-型", "RH-"));
            f_pr_blood.DisplayMember = "Key";
            f_pr_blood.ValueMember = "Value";
            f_pr_blood.DataSource = data;
        }
        private void D_Meery()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("未婚", "N"));
            data.Add(new DictionaryEntry("已婚", "M"));
            f_pr_merry.DisplayMember = "Key";
            f_pr_merry.ValueMember = "Value";
            f_pr_merry.DataSource = data;
        }

        private void D_Pr_direct_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("間接(月)", "I"));
            data.Add(new DictionaryEntry("直接(日)", "E"));
            f_pr_direct_type.DisplayMember = "Key";
            f_pr_direct_type.ValueMember = "Value";
            f_pr_direct_type.DataSource = data;
        }

        private void D_Pr_slry_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("月薪", "M"));
            data.Add(new DictionaryEntry("日薪", "D"));
            data.Add(new DictionaryEntry("計件", "P"));
            f_pr_slry_type.DisplayMember = "Key";
            f_pr_slry_type.ValueMember = "Value";
            f_pr_slry_type.DataSource = data;
        }

        private void D_Direct_type1()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("直接 ", "1"));
            data.Add(new DictionaryEntry("間接", "2"));
            data.Add(new DictionaryEntry("管理", "21"));
            data.Add(new DictionaryEntry("製造", "22"));
            data.Add(new DictionaryEntry("銷售", "23"));
            f_direct_type1.DisplayMember = "Key";
            f_direct_type1.ValueMember = "Value";
            f_direct_type1.DataSource = data;
        }

        private void D_Direct_type2()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("直接 ", "1"));
            data.Add(new DictionaryEntry("間接", "2"));
            f_direct_type2.DisplayMember = "Key";
            f_direct_type2.ValueMember = "Value";
            f_direct_type2.DataSource = data;
        }


        private void D_Nation()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("0:本國籍", "0"));
            data.Add(new DictionaryEntry("1:外國籍", "1"));
            f_nation.DisplayMember = "Key";
            f_nation.ValueMember = "Value";
            f_nation.DataSource = data;
        }
                
        private void D_Safe_old(string Dept)
        {
            f_old_safe_no.Text = "";
            f_old_safe_no.DataSource = prt033.ToDoList_Safe_no(Dept).ToList();
            f_old_safe_no.DisplayMember = "safe_no";
            f_old_safe_no.ValueMember = "safe_no";
        }
        private void D_Safe_medic(string Dept)
        {
            f_medic_safe_no.Text = "";
            f_medic_safe_no.DataSource = prt033.ToDoList_Safe_no(Dept).ToList();
            f_medic_safe_no.DisplayMember = "safe_no";
            f_medic_safe_no.ValueMember = "safe_no";
        }
        private void D_Safe_job(string Dept)
        {
            f_job_safe_no.Text = "";
            f_job_safe_no.DataSource = prt033.ToDoList_Safe_no(Dept).ToList();
            f_job_safe_no.DisplayMember = "safe_no";
            f_job_safe_no.ValueMember = "safe_no";
        }
        private void D_Safe_house(string Dept)
        {
            f_house_safe_no.Text = "";
            f_house_safe_no.DataSource = prt033.ToDoList_Safe_no(Dept).ToList();
            f_house_safe_no.DisplayMember = "safe_no";
            f_house_safe_no.ValueMember = "safe_no";
        }


        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設                
                this.Close();
            }
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            //Menu_Sel = "Add";
            SetColumn(this);
            Col_Disable();
            Init_S();
            //---
            const decimal zero = 0;
            f_tax_1.Text = zero.ToString();
            f_tax_2.Text = zero.ToString();
            f_tax_3.Text = zero.ToString();
            f_tax_4.Text = zero.ToString();
            f_tax_5.Text = zero.ToString();
            f_tax_6.Text = zero.ToString();
            f_tax_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tax_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tax_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tax_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tax_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tax_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_pr_live_pr.Value = 1;
            f_pr_live_pr.Value = 0;

            f_pr_insr_date_st.Text = DateTime.Now.ToString("yyyy/MM/dd");            
            f_pr_in_date_st.Text = DateTime.Now.ToString("yyyy/MM/dd");
            f_pr_birth_date_st.Text = string.Empty;

        }

        private void Col_Disable()
        {           
            f_pr_dept.Enabled = false;
            f_bank_code_name.Enabled = false;
            f_pr_spec_yearpay.Text = "0";
            f_pr_spec_monthpay.Text = "0";                      
            f_pr_leave_date.Enabled = false;
            f_pr_back_insr_date.Enabled = false;

            f_pr_no.Text = "--系統給號--";
            f_pr_no.Enabled = false;
            f_dsc_login.Text = "--系統給號--";
            f_dsc_login.Enabled = false;
            //Config.Set_DateTo(f_pr_birth_date, "1900/01/01");
            //Config.Set_DateTo(f_pr_birth_date, string.Format("{0}/{1}/{2}", (DateTime.Now.Year - 18).ToString(), "01", "01"));
            //Config.Set_DateTo(f_pr_in_date, DateTime.Now.ToString("yyyy/MM/dd"));
            //Config.Set_DateTo(f_pr_insr_date, DateTime.Now.ToString("yyyy/MM/dd"));
            Config.Set_DateTo(f_pr_leave_date, " ");
            Config.Set_DateTo(f_pr_back_insr_date, " ");
            //下拉選單
            f_pr_sex.SelectedIndex = 1;
            f_pr_blood.SelectedIndex = 1;
            f_pr_merry.SelectedIndex = 1;
            f_pr_direct_type.SelectedIndex = 1;
            f_pr_direct_type.SelectedIndex = 1;
            f_pr_slry_type.SelectedIndex = 1;
            f_direct_type1.SelectedIndex = 1;
            f_direct_type2.SelectedIndex = 1;
            f_nation.SelectedIndex = 1;
        }
        
                

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
            return;
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
            D_Safe_old(Dept);//養老保險等級
            D_Safe_medic(Dept);//醫療保險等級
            D_Safe_job(Dept);//失業保險等級
            D_Safe_house(Dept);//住房公積等級            
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
            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定修改?") == "Y")
                {
                    if (f_Check_Upd() == false)
                        return;
                    try
                    {
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Update(), f_pr_no.Text, f_pr_name.Text));
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
                //DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
                //this.Close();
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
                else
                {
                    return;
                }
                //DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
                //this.Close();
            }

            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_Check() == false)
                        return;
                    try
                    {
                        var p_prt016 = prt016.Duplicate(f_pr_idno.Text);
                        if (p_prt016 != null)
                        {
                            Config.Show("有相同身分證號員工\n" + "工號：" + p_prt016.Pr_no + " 姓名：" + p_prt016.Pr_name);
                            return;
                        }

                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2} TT帳號:{3}", f_Insert(), f_pr_no.Text, f_pr_name.Text, f_dsc_login.Text));
                        //系統通知改由隔天系統自動寄送
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
                //DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
                //this.Close();
            }

            if (Menu_Sel == "Qry")
            {
                //DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
                //this.Close();
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
            this.Close();
        }

        //private void confirm_Click(object sender, EventArgs e)
        //{
        //    if (Menu_Sel == "Add")
        //    {
        //        if (Config.Message("確定新增?") == "Y")
        //        {   
        //            if (f_Check() == false)
        //                return;
        //            try
        //            {
        //                var p_prt016 = prt016.Duplicate(f_pr_idno.Text);
        //                if (p_prt016 != null)
        //                {
        //                    Config.Show("有相同身分證號員工\n" + "工號：" + p_prt016.Pr_no + " 姓名：" + p_prt016.Pr_name);
        //                    return;
        //                }

        //                Config.Show(String.Format("{0}\n工號:{1} 姓名:{2} TT帳號:{3}", f_Insert(), f_pr_no.Text, f_pr_name.Text,f_dsc_login.Text));
        //                //系統通知改由隔天系統自動寄送
        //            }
        //            catch (Exception ex)
        //            {
        //                Config.Show(ex.Message);
        //            }
        //        }
        //        InitMotherboard(this);
        //    }

        //    if (Menu_Sel == "Qry")
        //    {
        //        f_Query();
        //        InitMotherboard(this);                
        //    }

        //    if (Menu_Sel == "Upd")
        //    {
        //        if (Config.Message("確定修改?") == "Y")
        //        {
        //            if (f_Check_Upd() == false)
        //                return;
        //            try
        //            {                        
        //                Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Update(), f_pr_no.Text, f_pr_name.Text));
        //            }
        //            catch (Exception ex)
        //            {
        //                Config.Show(ex.Message);
        //            }
        //        }
        //        InitMotherboard(this);
        //        DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
        //        this.Close();
        //    }

        //    if (Menu_Sel == "Del")
        //    {
        //        if (Config.Message("確定刪除?") == "Y")
        //        {
        //            try
        //            {
        //                Config.Show(f_Delete());
        //            }
        //            catch (Exception ex)
        //            {
        //                Config.Show(ex.Message);
        //            }
        //        }
        //        InitMotherboard(this);
        //        DialogResult = System.Windows.Forms.DialogResult.OK;//這一定要設
        //        this.Close();
        //    }

        //}
        private string f_Delete()
        {
            return string.Format("prt0016{0}\n prt0027{1}\n prt0028{2}\n prvacam{3}", 
                new prt016().Delete(f_pr_no.Text),
                new prt027().Delete(f_pr_no.Text), 
                new prt028().Delete(f_pr_no.Text),
                new prvacam().Delete(f_pr_no.Text));
        }

        private bool f_Check()
        {            
            if (f_pr_no.Text == string.Empty)
            {
                Config.Show("員工編號不可空白");
                f_pr_no.Focus();
                return false;
            }
            if (f_pr_name.Text == string.Empty)
            {
                Config.Show("姓名不可空白");
                f_pr_name.Focus();
                return false;
            }
            if (f_pr_idno.Text == string.Empty)
            {
                Config.Show("身分證號不可空白");
                f_pr_idno.Focus();
                return false;
            }

            //陳昭聰跟劉文賓說不可以這樣的控制 2019/03/07
            //if (prt016.GetWithIdno(f_pr_idno.Text) != null)
            //{
            //    Config.Show("已有此筆資料-相同ID證號\n請用復職作業");
            //    f_pr_idno.Focus();
            //    return false;
            //}

            
            if (f_bank_code.Text != string.Empty)
            {
                if (ntt001.Get(f_bank_code.Text) == null)
                {
                    Config.Show("銀行代碼錯誤");
                    f_bank_code.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool f_Check_Upd()
        {
            if (f_pr_name.Text == string.Empty)
            {
                Config.Show("姓名不可空白");
                f_pr_name.Focus();
                return false;
            }
              

            if (f_bank_code.Text != string.Empty)
            {
                if (ntt001.Get(f_bank_code.Text) == null)
                {
                    Config.Show("銀行代碼錯誤");
                    f_bank_code.Focus();
                    return false;
                }
            }

            return true;
        }


        private string f_Insert()
        {            
            return String.Format("{0}\n{1}\n{2}\n{3}", f_Insert_prt016(), f_Insert_prt027(), f_Insert_prt028(), f_Insert_prvacam());
        }

        private string f_Update()
        {   
            return String.Format("{0}\n{1}", f_Update_prt016(), f_Update_prt028());
        }


        private string f_Update_prt016()
        {
            var p_prt016 = new prt016();
            p_prt016.Pr_no = f_pr_no.Text;
            p_prt016.Pr_dept = f_pr_dept.SelectedValue.ToString();
            p_prt016.Pr_cdept = f_pr_cdept.SelectedValue.ToString();
            p_prt016.Pr_wk_cdept = f_pr_wk_cdept.SelectedValue.ToString();
            p_prt016.Pr_name = f_pr_name.Text;
            p_prt016.Wk_code = f_wk_code.SelectedValue.ToString();
            p_prt016.Pr_work = f_pr_work.SelectedValue.ToString();
            p_prt016.Position = f_position.SelectedValue.ToString();
            p_prt016.Pr_idno = f_pr_idno.Text;
            p_prt016.Pr_sex = f_pr_sex.SelectedValue.ToString();
            p_prt016.Pr_blood = f_pr_blood.SelectedValue.ToString();
            p_prt016.Pr_merry = f_pr_merry.SelectedValue.ToString();
            p_prt016.Pr_local = f_pr_local.Text;
            p_prt016.Pr_clas_code = f_pr_clas_code.SelectedValue.ToString();
            p_prt016.Pr_schl = f_pr_schl.SelectedValue.ToString();
            p_prt016.Pr_long = f_pr_long.SelectedValue.ToString();
            p_prt016.Pr_spec_yearpay = Int32.Parse(f_pr_spec_yearpay.Text);
            p_prt016.Pr_spec_monthpay = Int32.Parse(f_pr_spec_monthpay.Text);
            p_prt016.Pr_tel_no = f_pr_tel_no.Text;
            p_prt016.Pr_in_date = f_pr_in_date_st.Text;

            p_prt016.Pr_insr_date = f_pr_insr_date_st.Text;

            p_prt016.Pr_leave_date = f_pr_leave_date.Text;
            p_prt016.Pr_back_insr_date = f_pr_back_insr_date.Text;



            p_prt016.Pr_direct_type = f_pr_direct_type.SelectedValue.ToString();
            p_prt016.Pr_slry_type = f_pr_slry_type.SelectedValue.ToString();
            p_prt016.Bank_code = f_bank_code.Text;
            p_prt016.Account_no = f_account_no.Text;
            p_prt016.Pr_local_addr = f_pr_local_addr.Text;
            p_prt016.Pr_comm_addr = f_pr_comm_addr.Text;            
            p_prt016.Pr_live_pr = System.Convert.ToInt32(f_pr_live_pr.Value);
            p_prt016.Pr_comm_man = f_pr_comm_man.Text;
            p_prt016.Pr_comm_tel_no = f_pr_comm_tel_no.Text;
            p_prt016.Pr_comm_relative = f_pr_comm_relative.Text;
            p_prt016.Direct_type1 = f_direct_type1.SelectedValue.ToString();
            p_prt016.Direct_type2 = f_direct_type2.SelectedValue.ToString();            
            p_prt016.Pr_birth_date = f_pr_birth_date_st.Text;
            p_prt016.Nation = f_nation.SelectedValue.ToString();
            p_prt016.Old_safe_no = f_old_safe_no.SelectedValue.ToString();
            p_prt016.Medic_safe_no = f_medic_safe_no.SelectedValue.ToString();
            p_prt016.Job_safe_no = f_job_safe_no.SelectedValue.ToString();
            p_prt016.House_safe_no = f_house_safe_no.SelectedValue.ToString();
            p_prt016.Dsc_login = f_dsc_login.Text;
            //----
            p_prt016.Tax_1 = System.Convert.ToDecimal(f_tax_1.Text);
            p_prt016.Tax_2 = System.Convert.ToDecimal(f_tax_2.Text);
            p_prt016.Tax_3 = System.Convert.ToDecimal(f_tax_3.Text);
            p_prt016.Tax_4 = System.Convert.ToDecimal(f_tax_4.Text);
            p_prt016.Tax_5 = System.Convert.ToDecimal(f_tax_5.Text);
            p_prt016.Tax_6 = System.Convert.ToDecimal(f_tax_6.Text);
            return p_prt016.Update(p_prt016.Pr_no);
        }


        private string f_Update_prt028()
        {   
            if ( prt028.Get(f_pr_no.Text) !=null)
            {
                Set_prt028();
                return p_prt0028.Update(f_pr_no.Text);
            }
            else
            {                
                return f_Insert_prt028();
            }
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            //Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_in_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_insr_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_leave_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_back_insr_date, " ");//清空預設日期
            //下拉選單
            f_pr_sex.SelectedIndex = 0;
            f_pr_blood.SelectedIndex = 0;
            f_pr_merry.SelectedIndex = 0;
            f_pr_direct_type.SelectedIndex = 0;
            f_pr_direct_type.SelectedIndex = 0;
            f_pr_slry_type.SelectedIndex = 0;
            f_direct_type1.SelectedIndex = 0;
            f_direct_type2.SelectedIndex = 0;
            f_pr_cdept.SelectedIndex = 0;
            f_pr_schl.SelectedIndex = 0;
            f_pr_long.SelectedIndex = 0;
            f_pr_wk_cdept.SelectedIndex = 0;
            f_position.SelectedIndex = 0;
            f_pr_clas_code.SelectedIndex = 0;
            f_old_safe_no.SelectedIndex = 0;
            f_medic_safe_no.SelectedIndex = 0;
            f_job_safe_no.SelectedIndex = 0;
            f_house_safe_no.SelectedIndex = 0;
            f_pr_work.SelectedIndex = 0;
            f_nation.SelectedIndex = 0;

            D_Safe_old(Dept);//養老保險等級
            D_Safe_medic(Dept);//醫療保險等級
            D_Safe_job(Dept);//失業保險等級
            D_Safe_house(Dept);//住房公積等級
        }

        private void f_Query()
        {
            LS1.Clear();            
            LS1 = prt016.ToDoList(Dept, f_pr_no.Text, f_pr_name.Text, f_pr_idno.Text, null).ToList();
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
                f_pr_no.Text = LS1[idx].Pr_no;
                f_pr_name.Text = LS1[idx].Pr_name;                
                f_pr_dept.SelectedValue = LS1[idx].Pr_dept;
                f_pr_cdept.SelectedValue = LS1[idx].Pr_cdept;
                
                f_pr_wk_cdept.SelectedValue = LS1[idx].Pr_wk_cdept;
                
                f_wk_code.SelectedValue = LS1[idx].Wk_code;
                f_pr_work.SelectedValue = LS1[idx].Pr_work;

                f_position.SelectedValue = LS1[idx].Position;
                f_pr_idno.Text = LS1[idx].Pr_idno;
                f_pr_sex.SelectedValue = LS1[idx].Pr_sex;
                f_pr_blood.SelectedValue = LS1[idx].Pr_blood;
                f_pr_merry.SelectedValue = LS1[idx].Pr_merry;
                f_pr_local.Text = LS1[idx].Pr_local;
                f_pr_clas_code.SelectedValue = LS1[idx].Pr_clas_code;
                f_pr_schl.SelectedValue = LS1[idx].Pr_schl;
                f_pr_long.SelectedValue = LS1[idx].Pr_long;
                f_pr_spec_yearpay.Text = LS1[idx].Pr_spec_yearpay.ToString();
                f_pr_spec_monthpay.Text = LS1[idx].Pr_spec_monthpay.ToString();
                f_pr_tel_no.Text = LS1[idx].Pr_tel_no;
                
                f_pr_direct_type.SelectedValue = LS1[idx].Pr_direct_type;
                f_pr_slry_type.SelectedValue = LS1[idx].Pr_slry_type;
                f_bank_code.Text = LS1[idx].Bank_code;
                f_bank_code_name.Text = ntt001.Get(LS1[idx].Bank_code) == null ? "" : ntt001.Get(LS1[idx].Bank_code).Bank_name;
                f_account_no.Text = LS1[idx].Account_no;
                f_pr_local_addr.Text = LS1[idx].Pr_local_addr;
                f_pr_comm_addr.Text = LS1[idx].Pr_comm_addr;
                f_pr_comm_man.Text = LS1[idx].Pr_comm_man;
                f_pr_comm_tel_no.Text = LS1[idx].Pr_comm_tel_no;
                f_pr_comm_relative.Text = LS1[idx].Pr_comm_relative;
                f_direct_type1.SelectedValue = LS1[idx].Direct_type1;
                f_direct_type2.SelectedValue = LS1[idx].Direct_type2;                
                f_pr_live_pr.Value = LS1[idx].Pr_live_pr;
                f_add_date.Text = LS1[idx].Add_date.ToString();
                f_add_user.Text = LS1[idx].Add_user.Trim();
                f_mod_date.Text = LS1[idx].Mod_date.ToString();
                f_mod_user.Text = LS1[idx].Mod_user.Trim();
                f_nation.SelectedValue = LS1[idx].Nation;

                
                D_Safe_old(Dept);//養老保險等級
                D_Safe_medic(Dept);//醫療保險等級
                D_Safe_job(Dept);//失業保險等級
                D_Safe_house(Dept);//住房公積等級
                f_old_safe_no.SelectedValue = LS1[idx].Old_safe_no;
                f_medic_safe_no.SelectedValue = LS1[idx].Medic_safe_no;
                f_job_safe_no.SelectedValue = LS1[idx].Job_safe_no;
                f_house_safe_no.SelectedValue = LS1[idx].House_safe_no;
                f_dsc_login.Text = LS1[idx].Dsc_login;//TT登入帳號

                f_pr_birth_date_st.Text = string.IsNullOrEmpty(LS1[idx].Pr_birth_date.ToString()) ? "" : LS1[idx].Pr_birth_date.ToString();
                f_pr_in_date_st.Text = string.IsNullOrEmpty(LS1[idx].Pr_in_date.ToString()) ? "" : LS1[idx].Pr_in_date.ToString();
                f_pr_insr_date_st.Text = string.IsNullOrEmpty(LS1[idx].Pr_insr_date.ToString()) ? "" : LS1[idx].Pr_insr_date.ToString();

                //Config.Set_DateTo(f_pr_birth_date, LS1[idx].Pr_birth_date.ToString());
                //Config.Set_DateTo(f_pr_in_date, LS1[idx].Pr_in_date.ToString());
                //Config.Set_DateTo(f_pr_insr_date, LS1[idx].Pr_insr_date.ToString());
                Config.Set_DateTo(f_pr_leave_date, LS1[idx].Pr_leave_date.ToString());
                Config.Set_DateTo(f_pr_back_insr_date, LS1[idx].Pr_back_insr_date.ToString());

                //---
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
            if (f_pr_no.Text != "" && Menu_Sel == "Qry")
            {
                if (f_pr_leave_date.Text.Trim().ToString() != string.Empty)
                {
                    Config.Show("已離職無法異動");
                    return;
                }
                Menu_Sel = "Upd";
                SetMotherboard(this);
                f_pr_dept.Enabled = false;

                f_bank_code_name.Enabled = false;
                f_pr_no.Enabled = false;
                f_dsc_login.Enabled = false;                
                f_pr_leave_date.Enabled = false;
                f_pr_back_insr_date.Enabled = false;
                f_pr_name.Focus();
            }
            else
            {
                Config.Show("請先查詢");
            }
        }
        
        
        private void f_bank_code_bt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Dept))
            {                
                nti001w fm = new nti001w("CN");//銀行代碼視窗
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    f_bank_code.Text = fm.Code as string;
                    f_bank_code_name.Text = fm.Code_desc as string;
                }
            }
        }

        private void f_pr_spec_yearpay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 49 || (byte)e.KeyChar > 57 || (byte)e.KeyChar > 127)//若小於0或大於或中文
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true;//不接受字元
                }
            }
        }

        private void pri019_Load(object sender, EventArgs e)
        {
            //f_pr_birth_date_st.Text = string.Empty;
            //Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期
            //Config.Set_DateTo(f_pr_in_date, " ");//清空預設日期
            //Config.Set_DateTo(f_pr_insr_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_leave_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_back_insr_date, " ");//清空預設日期
        }

        //入廠日
        private void f_pr_in_date_ValueChanged(object sender, EventArgs e)
        {            
            //Config.Set_DateTo(f_pr_in_date, f_pr_in_date.Value.ToString("yyyy/MM/dd"));
            if (Menu_Sel == "Add" || Menu_Sel == "Upd") f_pr_in_date_st.Text = f_pr_in_date.Value.ToString("yyyy/MM/dd");
        }

        //入保日
        private void f_pr_insr_date_ValueChanged(object sender, EventArgs e)
        {
            //Config.Set_DateTo(f_pr_insr_date, f_pr_insr_date.Value.ToString("yyyy/MM/dd"));
            if (Menu_Sel == "Add" || Menu_Sel == "Upd") f_pr_insr_date_st.Text = f_pr_insr_date.Value.ToString("yyyy/MM/dd");
        }

        //出生日
        private void f_pr_birth_date_ValueChanged(object sender, EventArgs e)
        {
            //Config.Set_DateTo(f_pr_birth_date, f_pr_birth_date.Value.ToString("yyyy/MM/dd"));
            if (Menu_Sel=="Add"|| Menu_Sel == "Upd") f_pr_birth_date_st.Text = f_pr_birth_date.Value.ToString("yyyy/MM/dd");
        }


        private string f_Insert_prt016()
        {
            var p_prt016 = new prt016();
            f_pr_no.Text = prt016.GetDscLogin(Dept);//工號
            f_dsc_login.Text = prt016.GetDscLogin(Dept);//TT登入帳號

            p_prt016.Pr_no = f_pr_no.Text;
            p_prt016.Pr_company = Dept;
            p_prt016.Pr_dept = Dept;
            p_prt016.Pr_cdept = f_pr_cdept.SelectedValue.ToString();
            p_prt016.Pr_wk_cdept = f_pr_wk_cdept.SelectedValue.ToString();
            p_prt016.Pr_name = f_pr_name.Text;
            p_prt016.Wk_code = f_wk_code.SelectedValue.ToString();
            p_prt016.Pr_work = f_pr_work.SelectedValue.ToString();
            p_prt016.Position = f_position.SelectedValue.ToString();
            p_prt016.Pr_idno = f_pr_idno.Text;
            p_prt016.Pr_sex = f_pr_sex.SelectedValue.ToString();
            p_prt016.Pr_blood = f_pr_blood.SelectedValue.ToString();
            p_prt016.Pr_merry = f_pr_merry.SelectedValue.ToString();
            p_prt016.Pr_local = f_pr_local.Text;
            p_prt016.Pr_clas_code = f_pr_clas_code.SelectedValue.ToString();
            p_prt016.Pr_schl = f_pr_schl.SelectedValue.ToString();
            p_prt016.Pr_long = f_pr_long.SelectedValue.ToString();
            p_prt016.Pr_spec_yearpay = Int32.Parse(f_pr_spec_yearpay.Text);
            p_prt016.Pr_spec_monthpay = Int32.Parse(f_pr_spec_monthpay.Text);
            p_prt016.Pr_tel_no = f_pr_tel_no.Text;
            p_prt016.Pr_in_date = f_pr_in_date_st.Text;
            p_prt016.Pr_insr_date = f_pr_insr_date_st.Text;
            p_prt016.Pr_leave_date = f_pr_leave_date.Text == " " ? null : f_pr_leave_date.Text;
            p_prt016.Pr_back_insr_date = f_pr_leave_date.Text == " " ? null : f_pr_leave_date.Text;
            p_prt016.Pr_direct_type = f_pr_direct_type.SelectedValue.ToString();
            p_prt016.Pr_slry_type = f_pr_slry_type.SelectedValue.ToString();
            p_prt016.Bank_code = f_bank_code.Text;
            p_prt016.Account_no = f_account_no.Text;
            p_prt016.Pr_local_addr = f_pr_local_addr.Text;
            p_prt016.Pr_comm_addr = f_pr_comm_addr.Text;            
            p_prt016.Pr_live_pr = System.Convert.ToInt32(f_pr_live_pr.Value);
            p_prt016.Pr_comm_man = f_pr_comm_man.Text;
            p_prt016.Pr_comm_tel_no = f_pr_comm_tel_no.Text;
            p_prt016.Pr_comm_relative = f_pr_comm_relative.Text;
            p_prt016.Direct_type1 = f_direct_type1.SelectedValue.ToString();
            p_prt016.Direct_type2 = f_direct_type2.SelectedValue.ToString();
            p_prt016.Pr_birth_date = f_pr_birth_date_st.Text;
            p_prt016.Nation = f_nation.SelectedValue.ToString();
            p_prt016.Old_safe_no = f_old_safe_no.SelectedValue.ToString();
            p_prt016.Medic_safe_no = f_medic_safe_no.SelectedValue.ToString();
            p_prt016.Job_safe_no = f_job_safe_no.SelectedValue.ToString();
            p_prt016.House_safe_no = f_house_safe_no.SelectedValue.ToString();
            p_prt016.Dsc_login = f_dsc_login.Text;            
            return p_prt016.Insert();
        }

        private string f_Insert_prt027()
        {            
            decimal Iseq_no = 0;
            if (prt027.ToDoList(f_pr_no.Text, "").Count() == 0)
                Iseq_no = 1;
            else
                Iseq_no = prt027.ToDoList(f_pr_no.Text, "").Max(a => a.Tr_sqe_no) + 1;
            var p_prt0027 = new prt027();
            p_prt0027.Tr_id_no = f_pr_idno.Text;
            p_prt0027.Tr_sqe_no = Iseq_no;
            p_prt0027.Tr_type = "W";
            p_prt0027.Tr_start_date = f_pr_in_date.Text;
            p_prt0027.Tr_end_date = null;
            p_prt0027.Tr_comp = Dept;
            p_prt0027.Tr_dept_no = Dept;
            p_prt0027.Tr_move_code = f_pr_work.SelectedValue.ToString();
            p_prt0027.Tr_old_comp = Dept;
            p_prt0027.Tr_old_dept = Dept;
            p_prt0027.Tr_old_code = f_pr_work.SelectedValue.ToString();
            p_prt0027.Tr_move_amt = 0;
            p_prt0027.Tr_t1 = "新";
            p_prt0027.Tr_t2 = null;
            p_prt0027.Tr_t3 = null;
            p_prt0027.Tr_comment = "新進";
            p_prt0027.Tr_wk_dept = f_pr_wk_cdept.SelectedValue.ToString();
            p_prt0027.Tr_old_posit = f_position.SelectedValue.ToString();
            p_prt0027.Tr_old_funct = null;
            p_prt0027.Tr_list_flag_ok = null;
            p_prt0027.Bpm_no = null;
            p_prt0027.Trno = null;
            p_prt0027.Pr_no = f_pr_no.Text;
            p_prt0027.CraeteDate = DateTime.Now;
            return p_prt0027.Insert();
        }

        private string f_Insert_prt028()
        {
            Set_prt028();
            return p_prt0028.Insert();
        }

        private void Set_prt028()
        {            
            p_prt0028.Pr_no = f_pr_no.Text;
            p_prt0028.Pr_dept = Dept;
            p_prt0028.Pr_wk_dept = f_pr_wk_cdept.SelectedValue.ToString();
            p_prt0028.Pr_work_type = null;
            p_prt0028.Pr_work = f_pr_work.SelectedValue.ToString();
            p_prt0028.Position = f_pr_work.SelectedValue.ToString();
            p_prt0028.Functions = null;
            p_prt0028.Wk_code = f_wk_code.SelectedValue.ToString();
            p_prt0028.Pr_clas_code = f_pr_clas_code.SelectedValue.ToString();
            p_prt0028.Direct_type5 = null;
            p_prt0028.Pr_fmy = "N";
        }
                

        private string f_Insert_prvacam()
        {
            var p_prvacam = new prvacam()
            {
                Va_year = Int32.Parse(f_pr_in_date.Text.Substring(0, 4)),
                Va_pr_no = f_pr_no.Text,
                Va_id_no = f_pr_idno.Text,
                Va_spec_date = 0,
                Va_spec_month = 0,
                Vaca_a = 0,
                Vaca_b = 0,
                Vaca_c = 0,
                Vaca_d = 0,
                Vaca_e = 0,
                Vaca_f = 0,
                Vaca_g = 0,
                Vaca_h = 0,
                Vaca_i = 0,
                Vaca_j = 0,
                Vaca_k = 0,
                Va_spec_hour = 0
            };
            return p_prvacam.Insert();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //ReportParameter rp1 = new ReportParameter("pr_no");
            //rp1.Values.Add(f_pr_no.Text);
            
            //ReportParameter[] rparray = new ReportParameter[] { rp1 };

            //ReportView fm = new ReportView("/ERP/prr002", rparray);

            //if (fm.ShowDialog() == DialogResult.OK)
            //{
            //}
            menu_print_Click(null, null);
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

        private void pri019_KeyDown(object sender, KeyEventArgs e)
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

               


        //銀行
        private void f_bank_code_TextChanged(object sender, EventArgs e)
        {
            var p_ntt001 = ntt001.Get(f_bank_code.Text);
            f_bank_code_name.Text = (p_ntt001 == null ? "" : p_ntt001.Bank_name.Trim());
        }

        
        private void menu_print_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(f_pr_no.Text))
            {
                Config.Show("請先查詢");
                return;
            }
            var IForm = new crr002();
            IForm.rDept = Dept;//廠部
            IForm.rCdept = f_pr_cdept.SelectedValue.ToString(); //部門            
            IForm.rPrno = f_pr_no.Text;//工號
            IForm.SetValue();
            IForm.ShowDialog();
        }
                

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != "" && Menu_Sel == "Qry")
            {
                if (prt031S.ToDoList(null, null, f_pr_no.Text, null).Count() != 0 ||
                    prt030S.ToDoList(Dept, "", f_pr_no.Text).Count() != 0)
                {
                    Config.Show("已有出勤or薪資資料不可刪除");
                    return;
                }
                if (f_pr_leave_date.Text.Trim().ToString() != string.Empty)
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
            }
        }

        private void f_pr_cdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
                f_pr_wk_cdept.SelectedIndex = f_pr_cdept.SelectedIndex;
            else
                return;
        }

        
    }
}
