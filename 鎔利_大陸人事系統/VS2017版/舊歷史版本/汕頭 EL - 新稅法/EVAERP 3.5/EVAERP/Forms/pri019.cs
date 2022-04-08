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
using System.IO;

using System.Configuration;
using System.Data.OleDb;
using System.Data.Odbc;
using System.Data.SqlClient;
using EVAERP.Forms;

namespace EVAERP.Forms
{
    public partial class pri019 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt016> LS1 = new List<prt016>();
        prt028 p_prt0028 = new prt028();
        string Dept = Login.DEPT;

        string Imagename = string.Empty;
        DataSet ds = new DataSet();
        string Imagedel = "N";

        public string rCdept;//部門
        public string rPrno;//工號
        public string rId;//身分證號
        public string rName;//姓名
        public string rBirthday;//出生日
        public string rSex;//性別
        public string rType;//離在職


        public bool rOK = false;//按下確認鍵
        string connstr = string.Empty;

        string Docname = string.Empty;
        long rSize = -1;  //檔案大小        
        string Extension = string.Empty;//副檔名
        public pri019()
        {
            InitializeComponent();
            Config.SetFormSize(this);
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
            D_Position();//職位
            D_Schl();//學歷
            D_Class();//班別
            D_Long();//專長
            D_WkCode();//職等
        }

        private void D_WkCode()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "1", Code = "1" });
            LI.Add(new prt006 { Code_desc = "2", Code = "2" });
            LI.Add(new prt006 { Code_desc = "3", Code = "3" });
            LI.Add(new prt006 { Code_desc = "4", Code = "4" });
            LI.Add(new prt006 { Code_desc = "5", Code = "5" });
            f_wk_code.DataSource = LI;
            f_wk_code.DisplayMember = "Code_desc";
            f_wk_code.ValueMember = "Code";
        }

        private void D_Long()
        {   
            f_pr_long.DataSource = prt006.ToDoListCode(Dept, "LG", "Y").ToList();
            f_pr_long.DisplayMember = "Code_desc";
            f_pr_long.ValueMember = "Code";
        }

        //private void D_Long()
        //{
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "LG", "Y").ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_pr_long.DisplayMember = "Key";
        //    f_pr_long.ValueMember = "Value";
        //    f_pr_long.DataSource = data;
        //}
        private void D_Class()
        {            
            f_pr_clas_code.DataSource = prt006.ToDoListCode(Dept, "CL", "Y").ToList();
            f_pr_clas_code.DisplayMember = "Code_desc";
            f_pr_clas_code.ValueMember = "Code";
        }

        //private void D_Class()
        //{
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "CL", "Y").ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_pr_clas_code.DisplayMember = "Key";
        //    f_pr_clas_code.ValueMember = "Value";
        //    f_pr_clas_code.DataSource = data;
        //}

        private void D_Schl()
        {            
            f_pr_schl.DataSource = prt006.ToDoListCode(Dept, "SC", "Y").OrderByDescending(m => m.Code).ToList();
            f_pr_schl.DisplayMember = "Code_desc";
            f_pr_schl.ValueMember = "Code";
        }

        //private void D_Schl()
        //{
        //    ArrayList data = new ArrayList();            
        //    foreach (var i in prt006.ToDoListCode(Dept, "SC", "Y").OrderByDescending(m=>m.Code).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_pr_schl.DisplayMember = "Key";
        //    f_pr_schl.ValueMember = "Value";
        //    f_pr_schl.DataSource = data;
        //}

        private void D_Position()
        {
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();            
            f_position.DataSource = prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList();
            f_position.DisplayMember = "Code_desc";
            f_position.ValueMember = "Code";
        }


        //private void D_Position()
        //{            
        //    var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "WT", "Y").Where(m=>idList.Contains(m.Code)) .ToList())            
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_position.DisplayMember = "Key";
        //    f_position.ValueMember = "Value";
        //    f_position.DataSource = data;
        //}
        private void D_Work()
        {   
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();            
            f_pr_work.DataSource = prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList();
            f_pr_work.DisplayMember = "Code_desc";
            f_pr_work.ValueMember = "Code";            
        }

        //private void D_Work()
        //{
        //    var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_pr_work.DisplayMember = "Key";
        //    f_pr_work.ValueMember = "Value";
        //    f_pr_work.DataSource = data;
        //}
        private void D_Cdpet()
        {
            f_pr_cdept.DataSource = prt001.ToDoList(Dept).ToList();
            f_pr_cdept.DisplayMember = "Department_name_new";
            f_pr_cdept.ValueMember = "Department_code";
        }

        private void D_WkCdpet()
        {           
            f_pr_wk_cdept.DataSource = prt001.ToDoList(Dept).ToList();
            f_pr_wk_cdept.DisplayMember = "Department_name_new";
            f_pr_wk_cdept.ValueMember = "Department_code";
        }

        //private void D_WkCdpet()
        //{
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt001.ToDoList(Dept).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Department_name_new, i.Department_code));
        //    }
        //    f_pr_wk_cdept.DisplayMember = "Key";
        //    f_pr_wk_cdept.ValueMember = "Value";
        //    f_pr_wk_cdept.DataSource = data;
        //}
        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList().ToList();
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
        }

        private void D_Sex()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "男", Code = "M" });
            LI.Add(new prt006 { Code_desc = "女", Code = "F" });
            f_pr_sex.DataSource = LI;
            f_pr_sex.DisplayMember = "Code_desc";
            f_pr_sex.ValueMember = "Code";
        }

        //private void D_Sex()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("男", "M"));
        //    data.Add(new DictionaryEntry("女", "F"));
        //    f_pr_sex.DisplayMember = "Key";
        //    f_pr_sex.ValueMember = "Value";
        //    f_pr_sex.DataSource = data;
        //}

        private void D_Blood()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "A型", Code = "A" });
            LI.Add(new prt006 { Code_desc = "B型", Code = "B" });
            LI.Add(new prt006 { Code_desc = "O型", Code = "O" });
            LI.Add(new prt006 { Code_desc = "AB型", Code = "AB" });
            f_pr_blood.DataSource = LI;
            f_pr_blood.DisplayMember = "Code_desc";
            f_pr_blood.ValueMember = "Code";
        }

        //private void D_Blood()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("A型", "A"));
        //    data.Add(new DictionaryEntry("B型", "B"));
        //    data.Add(new DictionaryEntry("O型", "O"));
        //    data.Add(new DictionaryEntry("AB型", "AB"));
        //    //data.Add(new DictionaryEntry("RH+型", "RH+"));
        //    //data.Add(new DictionaryEntry("RH-型", "RH-"));
        //    f_pr_blood.DisplayMember = "Key";
        //    f_pr_blood.ValueMember = "Value";
        //    f_pr_blood.DataSource = data;
        //}

        private void D_Meery()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "未婚", Code = "N" });
            LI.Add(new prt006 { Code_desc = "已婚", Code = "M" });
            f_pr_merry.DataSource = LI;
            f_pr_merry.DisplayMember = "Code_desc";
            f_pr_merry.ValueMember = "Code";
        }


        //private void D_Meery()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("未婚", "N"));
        //    data.Add(new DictionaryEntry("已婚", "M"));
        //    f_pr_merry.DisplayMember = "Key";
        //    f_pr_merry.ValueMember = "Value";
        //    f_pr_merry.DataSource = data;
        //}

        private void D_Pr_direct_type()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "直接(月)", Code = "I" });
            LI.Add(new prt006 { Code_desc = "間接(日)", Code = "E" });
            f_pr_direct_type.DataSource = LI;
            f_pr_direct_type.DisplayMember = "Code_desc";
            f_pr_direct_type.ValueMember = "Code";
        }

        //private void D_Pr_direct_type()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("間接(月)", "I"));
        //    data.Add(new DictionaryEntry("直接(日)", "E"));
        //    f_pr_direct_type.DisplayMember = "Key";
        //    f_pr_direct_type.ValueMember = "Value";
        //    f_pr_direct_type.DataSource = data;
        //}

        private void D_Pr_slry_type()
        {   
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "月薪", Code = "M" });
            LI.Add(new prt006 { Code_desc = "日薪", Code = "D" });
            LI.Add(new prt006 { Code_desc = "計件", Code = "P" });
            f_pr_slry_type.DataSource = LI;
            f_pr_slry_type.DisplayMember = "Code_desc";
            f_pr_slry_type.ValueMember = "Code";
        }

        //private void D_Pr_slry_type()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("月薪", "M"));
        //    data.Add(new DictionaryEntry("日薪", "D"));
        //    data.Add(new DictionaryEntry("計件", "P"));
        //    f_pr_slry_type.DisplayMember = "Key";
        //    f_pr_slry_type.ValueMember = "Value";
        //    f_pr_slry_type.DataSource = data;
        //}

        private void D_Direct_type1()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "直接", Code = "1" });
            LI.Add(new prt006 { Code_desc = "間接", Code = "2" });
            LI.Add(new prt006 { Code_desc = "管理", Code = "21" });
            LI.Add(new prt006 { Code_desc = "製造", Code = "22" });
            LI.Add(new prt006 { Code_desc = "銷售", Code = "23" });
            f_direct_type1.DataSource = LI;
            f_direct_type1.DisplayMember = "Code_desc";
            f_direct_type1.ValueMember = "Code";
        }


        //private void D_Direct_type1()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("直接 ", "1"));
        //    data.Add(new DictionaryEntry("間接", "2"));
        //    data.Add(new DictionaryEntry("管理", "21"));
        //    data.Add(new DictionaryEntry("製造", "22"));
        //    data.Add(new DictionaryEntry("銷售", "23"));
        //    f_direct_type1.DisplayMember = "Key";
        //    f_direct_type1.ValueMember = "Value";
        //    f_direct_type1.DataSource = data;
        //}
        private void D_Direct_type2()
        {            
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "直接", Code = "1" });
            LI.Add(new prt006 { Code_desc = "間接", Code = "2" });
            f_direct_type2.DataSource = LI;
            f_direct_type2.DisplayMember = "Code_desc";
            f_direct_type2.ValueMember = "Code";
        }

        //private void D_Direct_type2()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("直接 ", "1"));
        //    data.Add(new DictionaryEntry("間接", "2"));
        //    f_direct_type2.DisplayMember = "Key";
        //    f_direct_type2.ValueMember = "Value";
        //    f_direct_type2.DataSource = data;
        //}

        private void D_Nation()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "0:本國籍", Code = "0" });
            LI.Add(new prt006 { Code_desc = "1:外國籍", Code = "1" });
            f_nation.DataSource = LI;
            f_nation.DisplayMember = "Code_desc";
            f_nation.ValueMember = "Code";
        }

        //private void D_Nation()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("0:本國籍", "0"));
        //    data.Add(new DictionaryEntry("1:外國籍", "1"));
        //    f_nation.DisplayMember = "Key";
        //    f_nation.ValueMember = "Value";
        //    f_nation.DataSource = data;
        //}

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
                File_Delete();//刪除文件
                this.Close();
            }
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);            
            Col_Disable();
            D_Safe_old(Dept);//養老保險等級
            D_Safe_medic(Dept);//醫療保險等級
            D_Safe_job(Dept);//失業保險等級
            D_Safe_house(Dept);//住房公積等級
            code_dearch_bt.Enabled = false;

            f_pr_cdept.SelectedIndex = 0;
            f_pr_wk_cdept.SelectedIndex = 0;
            f_pr_work.SelectedIndex = 0;
            f_position.SelectedIndex = 0;
            f_pr_schl.SelectedIndex = 0;
            f_pr_clas_code.SelectedIndex = 0;
            f_pr_long.SelectedIndex = 0;            
            f_pr_name.Focus();
            bindingNavigator1.Enabled = false;
            butRead.Enabled = false;
            
            
            //--圖片處理
            Imagename = string.Empty;
            pictureBox1.Image = null;

            //文件處理
            Docname = string.Empty;

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

        }

        private void Col_Disable()
        {   
            f_pr_dept.Enabled = false;            
            f_bank_code_name.Enabled = false;
            f_pr_spec_yearpay.Text = "0";
            f_pr_spec_monthpay.Text = "0";
            f_pr_live_pr.Text = "0";
            f_wk_code.SelectedValue = "1";
            f_pr_leave_date.Enabled = false;
            f_pr_back_insr_date.Enabled = false;

            f_pr_no.Text = "--系統給號--";
            f_pr_no.Enabled = false;
            f_dsc_login.Text = "--系統給號--";
            f_dsc_login.Enabled = false;
            
            //日期
            Config.Set_DateTo(f_pr_birth_date, string.Format("{0}/{1}/{2}",(DateTime.Now.Year-18).ToString(),"01","01"));
            Config.Set_DateTo(f_pr_in_date, DateTime.Now.ToString("yyyy/MM/dd"));
            Config.Set_DateTo(f_pr_insr_date, DateTime.Now.ToString("yyyy/MM/dd"));
            Config.Set_DateTo(f_pr_leave_date, " ");
            Config.Set_DateTo(f_pr_back_insr_date, " ");

            Config.Set_DateTo(f_old_safe_date, " ");
            Config.Set_DateTo(f_medic_safe_date, " ");
            Config.Set_DateTo(f_job_safe_date, " ");
            Config.Set_DateTo(f_house_safe_date, " ");


            //下拉選單
            f_pr_sex.SelectedIndex = 1;
            f_pr_blood.SelectedIndex = 0;
            f_pr_merry.SelectedIndex = 1;
            f_pr_direct_type.SelectedIndex = 1;
            f_pr_direct_type.SelectedIndex = 1;
            f_pr_slry_type.SelectedIndex = 1;
            f_direct_type1.SelectedIndex = 1;
            f_direct_type2.SelectedIndex = 1;
            f_nation.SelectedIndex = 1;
        }

        //private void cancel_Click(object sender, EventArgs e)
        //{
        //    if (Config.Message("是否離開?") == "Y")
        //    {
        //        this.Close();
        //    }
        //    else
        //    {
        //        bindingNavigator1.Enabled = true;
        //    }
        //}

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

        //private void cancel_Click(object sender, EventArgs e)
        //{            
        //    if (Menu_Sel == "Add")
        //    {
        //        i = 0;
        //        Menu_Sel = "";
        //        LS1.Clear();
        //        InitColumn(this);
        //    }
        //    if (Menu_Sel == "Upd")
        //    {
        //        InitMotherboard(this);
        //    }
        //    bindingNavigator1.Enabled = true;
        //}

        private void DisableButton()
        {
            code_dearch_bt.Enabled = false;            
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
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2} TT帳號:{3}", f_Insert(), f_pr_no.Text, f_pr_name.Text, f_dsc_login.Text));
                        //系統通知改由隔天系統自動寄送

                        //--圖片處理
                        if (Imagename != string.Empty)
                            prt038.Img_Insert(Imagename, f_pr_no.Text);

                        //--文件上傳處理
                        if (Docname != string.Empty)
                            prt040.Doc_Insert(Docname, f_pr_no.Text, Extension, rSize);
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
                pictureBox1.Image = null;
                InitMotherboard(this);
            }

            if (Menu_Sel == "Qry")
            {
                InitMotherboard(this); 
                f_Query();               
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定修改?") == "Y")
                {
                    if (f_Check_Upd() == false)
                        return;
                    try
                    {
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Update(), f_pr_no.Text, f_pr_name.Text));
                        //--圖片處理
                        if (pictureBox1.Image != null)
                        {
                            if (Imagename != string.Empty) //有上傳才處理;圖片有異動
                            {                                
                                prt038.Img_Delete(f_pr_no.Text);
                                prt038.Img_Insert(Imagename, f_pr_no.Text);
                            }
                        }
                        else
                        {
                            if (Imagedel == "Y") //原本有圖片刪掉
                            {
                                prt038.Img_Delete(f_pr_no.Text);
                                Imagedel = "N";
                            }
                        }
                        
                        //--文件修改處理
                        if (filename.Text != string.Empty)
                        {
                            if (Docname != string.Empty)//有修改
                            {
                                prt040.Doc_Delete(f_pr_no.Text);//刪除資料
                                prt040.Doc_Insert(Docname, f_pr_no.Text, Extension, rSize);//新增資料
                            }
                        }
                        else
                            prt040.Doc_Delete(f_pr_no.Text);//刪除資料
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
                        //--圖片處理
                        if (pictureBox1.Image != null)
                        {
                            prt038.Img_Delete(f_pr_no.Text);
                        }

                        //刪除上傳資料
                        prt040.Doc_Delete(f_pr_no.Text); 

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

            if (f_pr_idno.Text != string.Empty)
            {
                if (prt016.ToDoList().Where(a => a.Pr_idno == f_pr_idno.Text.Trim()).ToList().Count > 0)
                {
                    Config.Show("已有此筆資料-相同ID證號\n請用復職作業");
                    f_pr_idno.Focus();
                    return false;
                }
            }

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
            p_prt016.Pr_cdept = f_pr_cdept.SelectedValue == null ? "" : f_pr_cdept.SelectedValue.ToString();
            p_prt016.Pr_wk_cdept = f_pr_wk_cdept.SelectedValue == null ? "" : f_pr_wk_cdept.SelectedValue.ToString();
            p_prt016.Pr_name = f_pr_name.Text;
            p_prt016.Wk_code = f_wk_code.SelectedValue.ToString();
            p_prt016.Pr_work = f_pr_work.SelectedValue == null ? "" : f_pr_work.SelectedValue.ToString();
            p_prt016.Position = f_position.SelectedValue == null ? "" : f_position.SelectedValue.ToString();
            p_prt016.Pr_idno = f_pr_idno.Text;
            p_prt016.Pr_sex = f_pr_sex.SelectedValue.ToString();
            p_prt016.Pr_blood = f_pr_blood.SelectedValue.ToString();
            p_prt016.Pr_merry = f_pr_merry.SelectedValue.ToString();
            p_prt016.Pr_local = f_pr_local.Text;
            p_prt016.Pr_clas_code = f_pr_clas_code.SelectedValue == null ? "" : f_pr_clas_code.SelectedValue.ToString();
            p_prt016.Pr_schl = f_pr_schl.SelectedValue == null ? "" : f_pr_schl.SelectedValue.ToString();
            p_prt016.Pr_long = f_pr_long.SelectedValue == null ? "" : f_pr_long.SelectedValue.ToString();
            p_prt016.Pr_spec_yearpay = Int32.Parse(f_pr_spec_yearpay.Text);
            p_prt016.Pr_spec_monthpay = Int32.Parse(f_pr_spec_monthpay.Text);
            p_prt016.Pr_tel_no = f_pr_tel_no.Text;
            p_prt016.Pr_in_date = f_pr_in_date.Text;
            p_prt016.Pr_insr_date = f_pr_insr_date.Text;
            p_prt016.Pr_direct_type = f_pr_direct_type.SelectedValue.ToString();
            p_prt016.Pr_slry_type = f_pr_slry_type.SelectedValue.ToString();
            p_prt016.Bank_code = f_bank_code.Text;
            p_prt016.Account_no = f_account_no.Text;
            p_prt016.Pr_local_addr = f_pr_local_addr.Text;
            p_prt016.Pr_comm_addr = f_pr_comm_addr.Text;
            p_prt016.Pr_live_pr = Int32.Parse(f_pr_live_pr.Text);
            p_prt016.Pr_comm_man = f_pr_comm_man.Text;
            p_prt016.Pr_comm_tel_no = f_pr_comm_tel_no.Text;
            p_prt016.Pr_comm_relative = f_pr_comm_relative.Text;
            p_prt016.Direct_type1 = f_direct_type1.SelectedValue.ToString();
            p_prt016.Direct_type2 = f_direct_type2.SelectedValue.ToString();
            p_prt016.Pr_birth_date = f_pr_birth_date.Text;
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

            p_prt016.Old_safe_date = f_old_safe_date.Text;
            p_prt016.Medic_safe_date = f_medic_safe_date.Text;
            p_prt016.Job_safe_date = f_job_safe_date.Text;
            p_prt016.House_safe_date = f_house_safe_date.Text;

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
            Menu_Sel = "Qry";
            InitColumn(this);
            pictureBox1.Image = null;
            FormQuery();//查詢畫面
            if (rOK == true)
                confirm_Click(sender, e);//確認按鍵                
            else
                InitColumn(this);//初始
        }



        

        private void FormQuery()
        {
            pri019Q fm = new pri019Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rCdept = fm.rCdept;//部門
                rPrno = fm.rPrno;//工號
                rName = fm.rName;//姓名
                rId = fm.rId;//身分證號
                rBirthday = fm.rBirthday;//出生日                
                rSex = fm.rSex;//性別
                rType = fm.rType;//離在職

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
            LS1 = prt016.ToDoList(f_pr_dept.SelectedValue.ToString(), rCdept, rPrno, rName, rId, rBirthday, rSex, rType).ToList();            
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
                //var q_prt016 = prt016.Get(LS1[idx].Pr_no);

                var q_prt016 = prt016.ToDoList().Where(a => a.Pr_no == LS1[idx].Pr_no).ToList()[0];

                f_pr_no.Text = q_prt016.Pr_no;
                f_pr_name.Text = q_prt016.Pr_name;
                f_pr_dept.SelectedValue = q_prt016.Pr_dept;
                f_pr_cdept.SelectedValue = q_prt016.Pr_cdept;
                f_pr_wk_cdept.SelectedValue = q_prt016.Pr_wk_cdept;
                f_wk_code.SelectedValue = q_prt016.Wk_code;
                f_pr_work.SelectedValue = q_prt016.Pr_work;
                f_position.SelectedValue = q_prt016.Position;
                f_pr_idno.Text = q_prt016.Pr_idno;
                f_pr_sex.SelectedValue = q_prt016.Pr_sex;
                f_pr_blood.SelectedValue = q_prt016.Pr_blood;
                f_pr_merry.SelectedValue = q_prt016.Pr_merry;
                f_pr_local.Text = q_prt016.Pr_local;
                f_pr_clas_code.SelectedValue = q_prt016.Pr_clas_code;
                f_pr_schl.SelectedValue = q_prt016.Pr_schl;
                f_pr_long.SelectedValue = q_prt016.Pr_long;
                f_pr_spec_yearpay.Text = q_prt016.Pr_spec_yearpay.ToString();
                f_pr_spec_monthpay.Text = q_prt016.Pr_spec_monthpay.ToString();
                f_pr_tel_no.Text = q_prt016.Pr_tel_no;

                f_pr_direct_type.SelectedValue = q_prt016.Pr_direct_type;
                f_pr_slry_type.SelectedValue = q_prt016.Pr_slry_type;
                f_bank_code.Text = q_prt016.Bank_code;
                f_bank_code_name.Text = ntt001.Get(f_bank_code.Text) == null ? "" : ntt001.Get(f_bank_code.Text).Bank_name;
                f_account_no.Text = q_prt016.Account_no;
                f_pr_local_addr.Text = q_prt016.Pr_local_addr;
                f_pr_comm_addr.Text = q_prt016.Pr_comm_addr;
                f_pr_comm_man.Text = q_prt016.Pr_comm_man;
                f_pr_comm_tel_no.Text = q_prt016.Pr_comm_tel_no;
                f_pr_comm_relative.Text = q_prt016.Pr_comm_relative;
                f_direct_type1.SelectedValue = q_prt016.Direct_type1;
                f_direct_type2.SelectedValue = q_prt016.Direct_type2;
                f_pr_live_pr.Text = q_prt016.Pr_live_pr.ToString();
                f_add_date.Text = q_prt016.Add_date.ToString();
                f_add_user.Text = q_prt016.Add_user.Trim();
                f_mod_date.Text = q_prt016.Mod_date.ToString();
                f_mod_user.Text = q_prt016.Mod_user.Trim();
                f_nation.SelectedValue = q_prt016.Nation;


                D_Safe_old(f_pr_dept.SelectedValue.ToString());//養老保險等級
                D_Safe_medic(f_pr_dept.SelectedValue.ToString());//醫療保險等級
                D_Safe_job(f_pr_dept.SelectedValue.ToString());//失業保險等級
                D_Safe_house(f_pr_dept.SelectedValue.ToString());//住房公積等級
                f_old_safe_no.SelectedValue = q_prt016.Old_safe_no;
                f_medic_safe_no.SelectedValue = q_prt016.Medic_safe_no;
                f_job_safe_no.SelectedValue = q_prt016.Job_safe_no;
                f_house_safe_no.SelectedValue = q_prt016.House_safe_no;
                f_dsc_login.Text = q_prt016.Dsc_login;//TT登入帳號

                if (q_prt016.Pr_birth_date.ToString().Length != 0)
                    Config.Set_DateTo(f_pr_birth_date, DateTime.Parse(q_prt016.Pr_birth_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_pr_birth_date, " ");

                if (q_prt016.Pr_in_date.ToString().Length != 0)
                    Config.Set_DateTo(f_pr_in_date, DateTime.Parse(q_prt016.Pr_in_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_pr_in_date, " ");

                if (q_prt016.Pr_insr_date.ToString().Length != 0)
                    Config.Set_DateTo(f_pr_insr_date, DateTime.Parse(q_prt016.Pr_insr_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_pr_insr_date, " ");

                if (q_prt016.Pr_leave_date.ToString().Length != 0)
                    Config.Set_DateTo(f_pr_leave_date, DateTime.Parse(q_prt016.Pr_leave_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_pr_leave_date, " ");

                if (q_prt016.Pr_back_insr_date.ToString().Length != 0)
                    Config.Set_DateTo(f_pr_back_insr_date, DateTime.Parse(q_prt016.Pr_back_insr_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_pr_back_insr_date, " ");


                //Config.Set_DateTo(f_pr_birth_date, q_prt016.Pr_birth_date.ToString());
                //Config.Set_DateTo(f_pr_in_date, q_prt016.Pr_in_date.ToString());
                //Config.Set_DateTo(f_pr_insr_date, q_prt016.Pr_insr_date.ToString());
                //Config.Set_DateTo(f_pr_leave_date, q_prt016.Pr_leave_date.ToString());
                //Config.Set_DateTo(f_pr_back_insr_date, q_prt016.Pr_back_insr_date.ToString());


                
                if (q_prt016.Old_safe_date.ToString().Length != 0)
                    Config.Set_DateTo(f_old_safe_date, DateTime.Parse(q_prt016.Old_safe_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_old_safe_date, " ");

                if (q_prt016.Medic_safe_date.ToString().Length != 0)
                    Config.Set_DateTo(f_medic_safe_date, DateTime.Parse(q_prt016.Medic_safe_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_medic_safe_date, " ");

                if (q_prt016.Job_safe_date.ToString().Length != 0)
                    Config.Set_DateTo(f_job_safe_date, DateTime.Parse(q_prt016.Job_safe_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_job_safe_date, " ");

                if (q_prt016.House_safe_date.ToString().Length != 0)
                    Config.Set_DateTo(f_house_safe_date, DateTime.Parse(q_prt016.House_safe_date.ToString()).ToString("yyyy/MM/dd"));
                else
                    Config.Set_DateTo(f_house_safe_date, " ");

                
                //Config.Set_DateTo(f_medic_safe_date, q_prt016.Medic_safe_date.ToString());
                //Config.Set_DateTo(f_job_safe_date, q_prt016.Job_safe_date.ToString());
                //Config.Set_DateTo(f_house_safe_date, q_prt016.House_safe_date.ToString());

                

                //--顯示圖片
                Find_HeadPic(f_pr_no.Text);

                //刪除c:\file.doc文件
                File_Delete();

                //把文件放在c:\file.doc
                prt040.File_Put(f_pr_no.Text);

                //有資料 讀取心得報告按鈕生效 顯示暫存路徑檔名
                FbutRead();

                //---
                f_tax_1.Text = q_prt016.Tax_1.ToString();
                f_tax_2.Text = q_prt016.Tax_2.ToString();
                f_tax_3.Text = q_prt016.Tax_3.ToString();
                f_tax_4.Text = q_prt016.Tax_4.ToString();
                f_tax_5.Text = q_prt016.Tax_5.ToString();
                f_tax_6.Text = q_prt016.Tax_6.ToString();

            }
        }

        //不要刪
        //private void f_show(int idx)
        //{
        //    if (idx < 0 || idx > LS1.Count - 1)
        //    {
        //        Config.Show("已無資料");
        //    }
        //    else
        //    {
        //        f_pr_no.Text = LS1[idx].Pr_no;
        //        f_pr_name.Text = LS1[idx].Pr_name;
        //        f_pr_dept.SelectedValue = LS1[idx].Pr_dept;
        //        f_pr_cdept.SelectedValue = LS1[idx].Pr_cdept;
        //        f_pr_wk_cdept.SelectedValue = LS1[idx].Pr_wk_cdept;
        //        f_wk_code.SelectedValue = LS1[idx].Wk_code;
        //        f_pr_work.SelectedValue = LS1[idx].Pr_work;
        //        f_position.SelectedValue = LS1[idx].Position;
        //        f_pr_idno.Text = LS1[idx].Pr_idno;
        //        f_pr_sex.SelectedValue = LS1[idx].Pr_sex;
        //        f_pr_blood.SelectedValue = LS1[idx].Pr_blood;
        //        f_pr_merry.SelectedValue = LS1[idx].Pr_merry;
        //        f_pr_local.Text = LS1[idx].Pr_local;
        //        f_pr_clas_code.SelectedValue = LS1[idx].Pr_clas_code;
        //        f_pr_schl.SelectedValue = LS1[idx].Pr_schl;
        //        f_pr_long.SelectedValue = LS1[idx].Pr_long;
        //        f_pr_spec_yearpay.Text = LS1[idx].Pr_spec_yearpay.ToString();
        //        f_pr_spec_monthpay.Text = LS1[idx].Pr_spec_monthpay.ToString();
        //        f_pr_tel_no.Text = LS1[idx].Pr_tel_no;

        //        f_pr_direct_type.SelectedValue = LS1[idx].Pr_direct_type;
        //        f_pr_slry_type.SelectedValue = LS1[idx].Pr_slry_type;
        //        f_bank_code.Text = LS1[idx].Bank_code;
        //        f_bank_code_name.Text = ntt001.Get(f_bank_code.Text) == null ? "" : ntt001.Get(f_bank_code.Text).Bank_name;
        //        f_account_no.Text = LS1[idx].Account_no;
        //        f_pr_local_addr.Text = LS1[idx].Pr_local_addr;
        //        f_pr_comm_addr.Text = LS1[idx].Pr_comm_addr;
        //        f_pr_comm_man.Text = LS1[idx].Pr_comm_man;
        //        f_pr_comm_tel_no.Text = LS1[idx].Pr_comm_tel_no;
        //        f_pr_comm_relative.Text = LS1[idx].Pr_comm_relative;
        //        f_direct_type1.SelectedValue = LS1[idx].Direct_type1;
        //        f_direct_type2.SelectedValue = LS1[idx].Direct_type2;
        //        f_pr_live_pr.Text = LS1[idx].Pr_live_pr.ToString();
        //        f_add_date.Text = LS1[idx].Add_date.ToString();
        //        f_add_user.Text = LS1[idx].Add_user.Trim();
        //        f_mod_date.Text = LS1[idx].Mod_date.ToString();
        //        f_mod_user.Text = LS1[idx].Mod_user.Trim();
        //        f_nation.SelectedValue = LS1[idx].Nation;


        //        D_Safe_old(f_pr_dept.SelectedValue.ToString());//養老保險等級
        //        D_Safe_medic(f_pr_dept.SelectedValue.ToString());//醫療保險等級
        //        D_Safe_job(f_pr_dept.SelectedValue.ToString());//失業保險等級
        //        D_Safe_house(f_pr_dept.SelectedValue.ToString());//住房公積等級
        //        f_old_safe_no.SelectedValue = LS1[idx].Old_safe_no;
        //        f_medic_safe_no.SelectedValue = LS1[idx].Medic_safe_no;
        //        f_job_safe_no.SelectedValue = LS1[idx].Job_safe_no;
        //        f_house_safe_no.SelectedValue = LS1[idx].House_safe_no;
        //        f_dsc_login.Text = LS1[idx].Dsc_login;//TT登入帳號


        //        Config.Set_DateTo(f_pr_birth_date, LS1[idx].Pr_birth_date.ToString());
        //        Config.Set_DateTo(f_pr_in_date, LS1[idx].Pr_in_date.ToString());
        //        Config.Set_DateTo(f_pr_insr_date, LS1[idx].Pr_insr_date.ToString());
        //        Config.Set_DateTo(f_pr_leave_date, LS1[idx].Pr_leave_date.ToString());
        //        Config.Set_DateTo(f_pr_back_insr_date, LS1[idx].Pr_back_insr_date.ToString());
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
                if (f_pr_leave_date.Text.Trim().ToString() != string.Empty)
                {
                    Config.Show("已離職無法異動");
                    return;
                }
                Menu_Sel = "Upd";
                SetMotherboard(this);                
                DisableButton();
                f_pr_dept.Enabled = false;
                f_bank_code_name.Enabled = false;
                f_pr_no.Enabled = false;
                f_dsc_login.Enabled = false;
                f_pr_leave_date.Enabled = false;
                f_pr_back_insr_date.Enabled = false;
                f_pr_name.Focus();
                bindingNavigator1.Enabled = false;

                //--文件按鈕處理
                butRead.Enabled = false;
                filename.Enabled = false;
                butDnLoad.Enabled = true;   //刪除文件按鈕
                but_PicDel.Visible = true;  //刪除圖片按鈕
                Docname = string.Empty;
                //------
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        

        //private void menu_edit_Click(object sender, EventArgs e)
        //{
        //    if (f_pr_leave_date.Text.Trim().ToString() != string.Empty)
        //    {
        //        Config.Show("已離職無法異動");
        //        return;
        //    }

        //    if (f_pr_no.Text != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        DisableButton();
        //        f_pr_dept.Enabled = false;
        //        f_bank_code_name.Enabled = false;
        //        f_pr_no.Enabled = false;
        //        f_dsc_login.Enabled = false;
        //        f_pr_leave_date.Enabled = false;
        //        f_pr_back_insr_date.Enabled = false;
        //        f_pr_name.Focus();
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}
        
        
                       

        //private void f_pr_schl_bt_Click(object sender, EventArgs e)
        //{
        //    pri006w fm = new pri006w(f_pr_dept.SelectedValue.ToString(),"SC");//學歷視窗
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_pr_schl.Text = fm.Code as string;
        //        f_pr_schl_name.Text = fm.Code_desc as string;
        //    }
        //}

        //private void f_pr_long_bt_Click(object sender, EventArgs e)
        //{
        //    pri006w fm = new pri006w(f_pr_dept.SelectedValue.ToString(),"LG");//專長視窗
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_pr_long.Text = fm.Code as string;
        //        f_pr_long_name.Text = fm.Code_desc as string;
        //    }
        //}

        //private void f_pr_work_bt_Click(object sender, EventArgs e)
        //{
        //    pri006w fm = new pri006w(f_pr_dept.SelectedValue.ToString(), "WK");//職稱視窗
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_pr_work.Text = fm.Code as string;
        //        f_pr_work_name.Text = fm.Code_desc as string;
        //    }
        //}

        //private void f_position_bt_Click(object sender, EventArgs e)
        //{
        //    pri006w fm = new pri006w(f_pr_dept.SelectedValue.ToString(), "WT");//職位視窗
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_position.Text = fm.Code as string;
        //        f_position_name.Text = fm.Code_desc as string;
        //    }
        //}

        //private void f_pr_cdept_bt_Click(object sender, EventArgs e)
        //{            
        //    pri001w fm = new pri001w(f_pr_dept.SelectedValue.ToString());//部門
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_pr_cdept.Text = fm.Code as string;
        //        f_pr_cdept_name.Text = fm.Code_desc as string;
        //    }
        //}

        //private void f_pr_wk_cdept_bt_Click(object sender, EventArgs e)
        //{            
        //    pri001w fm = new pri001w(f_pr_dept.SelectedValue.ToString());//部門
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_pr_wk_cdept.Text = fm.Code as string;
        //        f_pr_wk_cdept_name.Text = fm.Code_desc as string;
        //    }
        //}

        //private void f_pr_clas_code_bt_Click(object sender, EventArgs e)
        //{
        //    pri006w fm = new pri006w(f_pr_dept.SelectedValue.ToString(),"CL");//班別視窗
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_pr_clas_code.Text = fm.Code as string;
        //        f_pr_clas_code_name.Text = fm.Code_desc as string;
        //    }
        //}

        private void f_bank_code_bt_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(f_pr_dept.SelectedValue.ToString()))
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
            Config.Set_DateTo(f_pr_birth_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_in_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_insr_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_leave_date, " ");//清空預設日期
            Config.Set_DateTo(f_pr_back_insr_date, " ");//清空預設日期

            Config.Set_DateTo(f_old_safe_date, " ");//清空預設日
            Config.Set_DateTo(f_medic_safe_date, " ");//清空預設日
            Config.Set_DateTo(f_job_safe_date, " ");//清空預設日
            Config.Set_DateTo(f_house_safe_date, " ");//清空預設日
        }

        //入廠日
        private void f_pr_in_date_ValueChanged(object sender, EventArgs e)
        {            
            Config.Set_DateTo(f_pr_in_date, f_pr_in_date.Value.ToString("yyyy/MM/dd"));
        }

        //入保日
        private void f_pr_insr_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_pr_insr_date, f_pr_insr_date.Value.ToString("yyyy/MM/dd"));
        }

        //出生日
        private void f_pr_birth_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_pr_birth_date, f_pr_birth_date.Value.ToString("yyyy/MM/dd"));
        }


        private string f_Insert_prt016()
        {
            var p_prt016 = new prt016();
            
            f_pr_no.Text = prt016.GetDscLogin();//工號
            f_dsc_login.Text = prt016.GetDscLogin();//TT登入帳號

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
            p_prt016.Pr_in_date = f_pr_in_date.Text;
            p_prt016.Pr_insr_date = f_pr_insr_date.Text;
            p_prt016.Pr_leave_date = f_pr_leave_date.Text == " " ? null : f_pr_leave_date.Text;
            p_prt016.Pr_back_insr_date = f_pr_leave_date.Text == " " ? null : f_pr_leave_date.Text;
            p_prt016.Pr_direct_type = f_pr_direct_type.SelectedValue.ToString();
            p_prt016.Pr_slry_type = f_pr_slry_type.SelectedValue.ToString();
            p_prt016.Bank_code = f_bank_code.Text;
            p_prt016.Account_no = f_account_no.Text;
            p_prt016.Pr_local_addr = f_pr_local_addr.Text;
            p_prt016.Pr_comm_addr = f_pr_comm_addr.Text;
            p_prt016.Pr_live_pr = Int32.Parse(f_pr_live_pr.Text);
            p_prt016.Pr_comm_man = f_pr_comm_man.Text;
            p_prt016.Pr_comm_tel_no = f_pr_comm_tel_no.Text;
            p_prt016.Pr_comm_relative = f_pr_comm_relative.Text;
            p_prt016.Direct_type1 = f_direct_type1.SelectedValue.ToString();
            p_prt016.Direct_type2 = f_direct_type2.SelectedValue.ToString();
            p_prt016.Pr_birth_date = f_pr_birth_date.Text;
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

            p_prt016.Old_safe_date = f_old_safe_date.Text;
            p_prt016.Medic_safe_date = f_medic_safe_date.Text;
            p_prt016.Job_safe_date = f_job_safe_date.Text;
            p_prt016.House_safe_date = f_house_safe_date.Text;            
            return p_prt016.Insert();
        }

        private string f_Insert_prt027()
        {
            var p_prt0027 = new prt027();
            p_prt0027.Tr_id_no = f_pr_idno.Text;
            p_prt0027.Tr_sqe_no = 1;
            p_prt0027.Tr_type = "W";
            p_prt0027.Tr_start_date = f_pr_in_date.Text;
            p_prt0027.Tr_end_date = null;
            p_prt0027.Tr_comp = Dept;
            p_prt0027.Tr_dept_no = f_pr_dept.SelectedValue.ToString();
            p_prt0027.Tr_move_code = f_pr_work.SelectedValue.ToString();
            p_prt0027.Tr_old_comp = Dept;
            p_prt0027.Tr_old_dept = f_pr_dept.SelectedValue.ToString();
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
            p_prt0027.CreateDate = DateTime.Now;
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
            p_prt0028.Pr_dept = f_pr_dept.SelectedValue.ToString();
            p_prt0028.Pr_wk_dept = f_pr_wk_cdept.SelectedValue.ToString();
            p_prt0028.Pr_work_type = null;
            p_prt0028.Pr_work = f_pr_work.SelectedValue.ToString();
            p_prt0028.Position = f_position.SelectedValue.ToString();
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

        //部門
        //private void f_pr_cdept_TextChanged(object sender, EventArgs e)
        //{
        //    var p_prt001 = prt001.Get(f_pr_cdept.Text);
        //    f_pr_cdept_name.Text = (p_prt001 == null ? "" : p_prt001.Department_name_new.Trim());
        //}

        //工作部門
        //private void f_pr_wk_cdept_TextChanged(object sender, EventArgs e)
        //{
        //    var p_prt001 = prt001.Get(f_pr_wk_cdept.Text);
        //    f_pr_wk_cdept_name.Text = (p_prt001 == null ? "" : p_prt001.Department_name_new.Trim());
        //}

        //職稱
        //private void f_pr_work_TextChanged(object sender, EventArgs e)
        //{
        //    var p_prt006 = prt006.Get(f_pr_dept.SelectedValue.ToString(), "WK", f_pr_work.Text);
        //    f_pr_work_name.Text = (p_prt006 == null ? "" : p_prt006.Code_desc.Trim());
        //}

        //職位
        //private void f_position_TextChanged(object sender, EventArgs e)
        //{
        //    var p_prt006 = prt006.Get(f_pr_dept.SelectedValue.ToString(), "WT", f_position.Text);
        //    f_position_name.Text = (p_prt006 == null ? "" : p_prt006.Code_desc.Trim());
        //}

        //班別
        //private void f_pr_clas_code_TextChanged(object sender, EventArgs e)
        //{
        //    var p_prt006 = prt006.Get(f_pr_dept.SelectedValue.ToString(), "CL", f_pr_clas_code.Text);
        //    f_pr_clas_code_name.Text = (p_prt006 == null ? "" : p_prt006.Code_desc.Trim());
        //}

        //學歷
        //private void f_pr_schl_TextChanged(object sender, EventArgs e)
        //{
        //    var p_prt006 = prt006.Get(f_pr_dept.SelectedValue.ToString(), "SC", f_pr_schl.Text);
        //    f_pr_schl_name.Text = (p_prt006 == null ? "" : p_prt006.Code_desc.Trim());
        //}

        //專長
        //private void f_pr_long_TextChanged(object sender, EventArgs e)
        //{
        //    var p_prt006 = prt006.Get(f_pr_dept.SelectedValue.ToString(), "LG", f_pr_long.Text);
        //    f_pr_long_name.Text = (p_prt006 == null ? "" : p_prt006.Code_desc.Trim());
        //}

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
            IForm.rDept = f_pr_dept.SelectedValue.ToString();//廠部
            IForm.rCdept = f_pr_cdept.SelectedValue.ToString(); //部門            
            IForm.rPrno = f_pr_no.Text;//工號
            IForm.SetValue();
            IForm.ShowDialog();
        }

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
            {
                if (prt031L.ToDoList(null, null, f_pr_no.Text, null).Count() != 0 ||
                        prt030L.ToDoList(Dept, "", f_pr_no.Text).Count() != 0)
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
                return;
            }
        }


        //private void menu_del_Click(object sender, EventArgs e)
        //{
        //    if (f_pr_no.Text != "" && Menu_Sel == "Qry")
        //    {
        //        if (prt031L.ToDoList(null, null, f_pr_no.Text, null).Count() != 0 ||
        //            prt030L.ToDoList(Dept, "", f_pr_no.Text).Count() != 0)
        //        {
        //            Config.Show("已有出勤or薪資資料不可刪除");
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

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            string _type = "";
            //if (Menu_Sel == "Add")
            //    _type = "I";//在職
            //if (Menu_Sel == "Qry")
                _type = null;//全部

            pri019w fm = new pri019w(_type, Dept);//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;                
            }
            fm.Dispose();
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

        //private void AllControl_Enter(object sender, EventArgs e)
        //{
        //    //Config.GetColor(sender, e);
        //}

        //private void AllControl_Leave(object sender, EventArgs e)
        //{
        //    //Config.UnColor(sender,e);
        //}

        //上傳圖片按鈕
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fdl = new OpenFileDialog();
                fdl.InitialDirectory = @"C:\";
                fdl.Filter = "Image File(*.jpg;*.bmp;*.gif)|*.jpg;*bmp;*gif";

                if (fdl.ShowDialog() == DialogResult.OK)
                {
                    Imagename = fdl.FileName;
                    Bitmap newimg = new Bitmap(Imagename);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = (Image)newimg;
                }
                fdl = null;
                Imagedel = "N";
            }
            catch (System.ApplicationException es)
            {

                Config.Show(es.Message.ToString());
            }

            catch (Exception ex)
            {
                Config.Show(ex.Message.ToString());
            }
        }

        //刪除圖片按鈕
        private void button3_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                Config.Message("無圖片可刪除");
            else
                pictureBox1.Image = null;
            Imagedel = "Y";
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    if (pictureBox1.Image != null)
        //    {
        //        pictureBox1.Image = null;
        //        Imagedel = "Y";
        //    }
        //}

        private void Find_HeadPic(string Pr_No)
        {
            if (prt038.Img_Show(Pr_No).Length > 0)
            {
                pictureBox1.Image = Image.FromStream(prt038.Img_Show(Pr_No));
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Refresh();
            }
            else
                pictureBox1.Image = null;
        }

        private void butUpLoad_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fdl = new OpenFileDialog();
                fdl.Title = "請選擇";
                fdl.InitialDirectory = @"C:\";
                fdl.Filter = "Image File(*.txt;*.doc;*.docx;*.xls;*.xlsx;*.jpg;*.bmp;*.gif;*.pdf;*.wmv)|*.txt;*doc;*docx;*xls;*xlsx;*.jpg;*.bmp;*.gif;*.pdf;*.wmv";
                if (fdl.ShowDialog() == DialogResult.OK)
                {
                    rSize = new FileInfo(fdl.FileName).Length; //檔案大小
                    Extension = Path.GetExtension(fdl.FileName);//副檔名

                    Docname = fdl.FileName;
                    filename.Text = Docname;
                }
                fdl = null;                
            }
            catch (System.ApplicationException es)
            {

                Config.Show(es.Message.ToString());
            }

            catch (Exception ex)
            {
                Config.Show(ex.Message.ToString());
            }
        }

        private void butDnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename.Text))
                Config.Message("無文件可刪除");
            else
                filename.Text = string.Empty;
            Docname = string.Empty;
        }

        private void butRead_Click(object sender, EventArgs e)
        {
            if (new FileInfo(@"C:\file.txt").Exists) System.Diagnostics.Process.Start(@"C:\file.txt");
            if (new FileInfo(@"C:\file.docx").Exists) System.Diagnostics.Process.Start(@"C:\file.docx");
            if (new FileInfo(@"C:\file.xlsx").Exists) System.Diagnostics.Process.Start(@"C:\file.xlsx");
            if (new FileInfo(@"C:\file.wmv").Exists) System.Diagnostics.Process.Start(@"C:\file.wmv");
            if (new FileInfo(@"C:\file.pdf").Exists) System.Diagnostics.Process.Start(@"C:\file.pdf");
            if (new FileInfo(@"C:\file.jpg").Exists) System.Diagnostics.Process.Start(@"C:\file.jpg");
            if (new FileInfo(@"C:\file.bmp").Exists) System.Diagnostics.Process.Start(@"C:\file.bmp");
            if (new FileInfo(@"C:\file.gif").Exists) System.Diagnostics.Process.Start(@"C:\file.gif");
            if (new FileInfo(@"C:\file.doc").Exists) System.Diagnostics.Process.Start(@"C:\file.doc");
            if (new FileInfo(@"C:\file.xls").Exists) System.Diagnostics.Process.Start(@"C:\file.xls");
        }

        

        private void File_Delete()
        {
            //刪除存在的文件
            FileInfo delFile_1 = new FileInfo(@"C:\file.txt");
            if (delFile_1.Exists)
                delFile_1.Delete();
            FileInfo delFile_2 = new FileInfo(@"C:\file.docx");
            if (delFile_2.Exists)
                delFile_2.Delete();
            FileInfo delFile_3 = new FileInfo(@"C:\file.xlsx");
            if (delFile_3.Exists)
                delFile_3.Delete();
            FileInfo delFile_4 = new FileInfo(@"C:\file.wmv");
            if (delFile_4.Exists)
                delFile_4.Delete();
            FileInfo delFile_5 = new FileInfo(@"C:\file.pdf");
            if (delFile_5.Exists)
                delFile_5.Delete();
            FileInfo delFile_6 = new FileInfo(@"C:\file.jpg");
            if (delFile_6.Exists)
                delFile_6.Delete();
            FileInfo delFile_7 = new FileInfo(@"C:\file.bmp");
            if (delFile_7.Exists)
                delFile_7.Delete();
            FileInfo delFile_8 = new FileInfo(@"C:\file.gif");
            if (delFile_8.Exists)
                delFile_8.Delete();
            FileInfo delFile_9 = new FileInfo(@"C:\file.doc");
            if (delFile_9.Exists)
                delFile_9.Delete();
            FileInfo delFile_10 = new FileInfo(@"C:\file.xls");
            if (delFile_10.Exists)
                delFile_10.Delete();
        }

        private void FbutRead()
        {
            filename.Text = string.Empty;
            if (new FileInfo(@"c:\file.doc").Exists) filename.Text = @"C:\file.doc";
            if (new FileInfo(@"c:\file.docx").Exists) filename.Text = @"C:\file.docx";
            if (new FileInfo(@"c:\file.xls").Exists) filename.Text = @"C:\file.xls";
            if (new FileInfo(@"c:\file.xlsx").Exists) filename.Text = @"C:\file.xlsx";
            if (new FileInfo(@"c:\file.txt").Exists) filename.Text = @"C:\file.txt";
            if (new FileInfo(@"c:\file.pdf").Exists) filename.Text = @"C:\file.pdf";
            if (new FileInfo(@"c:\file.wmv").Exists) filename.Text = @"C:\file.wmv";
            if (new FileInfo(@"c:\file.jpg").Exists) filename.Text = @"C:\file.jpg";
            if (new FileInfo(@"c:\file.bmp").Exists) filename.Text = @"C:\file.bmp";
            if (new FileInfo(@"c:\file.gif").Exists) filename.Text = @"C:\file.gif";
            if (filename.Text != string.Empty)
                butRead.Enabled = true; //讀取文件按鈕
            else
                butRead.Enabled = false;
        }

        //private void NumAllControl_Enter(object sender, EventArgs e)
        //{
        //    //((NumericUpDown)sender).Select(0, 8);
        //    //((NumericUpDown)sender).Focus();
        //    //((NumericUpDown)sender).BackColor = Color.Beige;
        //}
        //private void NumAllControl_Leave(object sender, EventArgs e)
        //{
        //    //((NumericUpDown)sender).BackColor = Color.White;
        //}

        private void AllControl_Enter(object sender, EventArgs e)
        {            
            //((TextBox)sender).BackColor = Color.Beige;
        }
        private void AllControl_Leave(object sender, EventArgs e)
        {
            //((TextBox)sender).BackColor = Color.White;
        }

        private void ComControl_Enter(object sender, EventArgs e)
        {
            //((ComboBox)sender).BackColor = Color.Beige;
        }

        private void ComControl_Leave(object sender, EventArgs e)
        {
            //((ComboBox)sender).BackColor = Color.White;
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

        private void f_old_safe_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_old_safe_date, f_old_safe_date.Value.ToString("yyyy/MM/dd"));
        }

        private void f_medic_safe_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_medic_safe_date, f_medic_safe_date.Value.ToString("yyyy/MM/dd"));
        }

        private void f_job_safe_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_job_safe_date, f_job_safe_date.Value.ToString("yyyy/MM/dd"));
        }

        private void f_house_safe_date_ValueChanged(object sender, EventArgs e)
        {
            Config.Set_DateTo(f_house_safe_date, f_house_safe_date.Value.ToString("yyyy/MM/dd"));
        }

        private void Clear_date(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Name == "button5") Config.Set_DateTo(f_old_safe_date, " "); //清日期資料
            if (btn.Name == "button2") Config.Set_DateTo(f_medic_safe_date, " "); //清日期資料
            if (btn.Name == "button3") Config.Set_DateTo(f_job_safe_date, " "); //清日期資料
            if (btn.Name == "button4") Config.Set_DateTo(f_house_safe_date, " "); //清日期資料
            if (btn.Name == "button6") Config.Set_DateTo(f_pr_birth_date, " "); //清日期資料
            if (btn.Name == "button7") Config.Set_DateTo(f_pr_in_date, " "); //清日期資料
            if (btn.Name == "button8") Config.Set_DateTo(f_pr_insr_date, " "); //清日期資料
        }

    }
}
