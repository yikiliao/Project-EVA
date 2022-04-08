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
    public partial class pri023 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt016> LS1 = new List<prt016>();
        prt028 p_prt0028 = new prt028();
        prt016 p_prt016 = new prt016();
        Int32 Spec_year = 0;
        Int32 Spec_mon = 0;
        DateTime o_in_date;
        string Dept = Login.DEPT;

        public string rCdept;//部門
        public string rPrno;//工號
        public string rId;//身分證號
        public string rName;//姓名
        public string rBirthday;//出生日
        public string rSex;//性別
        public bool rOK = false;//按下確認鍵

        public pri023()
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
        //    foreach (var i in prt006.ToDoListCode(Dept, "SC", "Y").OrderByDescending(m => m.Code).ToList())
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
        //    foreach (var i in prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList())
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

        private void D_Cdpet()
        {            
            f_pr_cdept.DataSource = prt001.ToDoList(Dept).ToList();
            f_pr_cdept.DisplayMember = "Department_name_new";
            f_pr_cdept.ValueMember = "Department_code";
        }
        //private void D_Cdpet()
        //{
        //    ArrayList data = new ArrayList();
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
            this.Close();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            {
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

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);                
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定復職?") == "Y")
                {
                    try
                    {                        
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Update(), f_pr_no.Text, f_pr_name.Text));
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
                InitColumn(this);//初始
                InitMotherboard(this);
            }

        }

               

        /// <summary>
        /// 改prt016人是基本檔資料,寫入prt027異動檔,修改prvacam 假別主檔,刪除prvacal假別明細檔
        /// </summary>
        /// <returns></returns>
        private string f_Update()
        {
            return String.Format("{0}\n{1}\n{2}", f_Update_prt016(), f_Insert_prt027(), f_Insert_prvacam());            
        }


        private string f_Update_prt016()
        {
            var p_prt016 = new prt016();
            Get_Spec();
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
            p_prt016.Pr_spec_yearpay = Spec_year;
            p_prt016.Pr_spec_monthpay = Spec_mon;
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
            p_prt016.Pr_leave_date = null;

            p_prt016.Dsc_login = f_dsc_login.Text;
            p_prt016.Nation = f_nation.SelectedValue.ToString();

            p_prt016.Old_safe_no = f_old_safe_no.SelectedValue.ToString();
            p_prt016.Medic_safe_no = f_medic_safe_no.SelectedValue.ToString();
            p_prt016.Job_safe_no = f_job_safe_no.SelectedValue.ToString();
            p_prt016.House_safe_no = f_house_safe_no.SelectedValue.ToString();

            return p_prt016.Update(p_prt016.Pr_no);
        }

        private void Get_Spec()
        {
            Int32 sy1, sy2, sm1, sm2, sd1, sd2, cls_yn = 0;

            sy1 = f_pr_in_date.Value.Year;
            sm1 = f_pr_in_date.Value.Month;
            sd1 = f_pr_in_date.Value.Day;

            sy2 = o_in_date.Year;
            sm2 = o_in_date.Month;
            sd2 = o_in_date.Day;

            if (sd1 < sd2)
            {
                sd1 = sd1 + 30;
                sm1 = sm1 - 1;
            }
            if (sm1 < sm2)
            {
                sm1 = sm1 + 12;
                sy1 = sy1 - 1;
            }

            cls_yn = (sy1 - sy2) * 12 + (sm1 - sm2) + (sd1 - sd2) / 30;
            if (cls_yn > 3)
                Spec_year = 0; Spec_mon = 0;
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
            pri023Q fm = new pri023Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rCdept = fm.rCdept;//部門
                rPrno = fm.rPrno;//工號
                rName = fm.rName;//姓名
                rId = fm.rId;//身分證號
                rBirthday = fm.rBirthday;//出生日                
                rSex = fm.rSex;//性別
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
            LS1 = prt016.ToDoList(f_pr_dept.SelectedValue.ToString(), rCdept, rPrno, rName, rId, rBirthday, rSex, "L").ToList();
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
                var q_prt016 = prt016.Get(LS1[idx].Pr_no);

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
                f_nation.SelectedValue = q_prt016.Nation;//國籍別
                f_dsc_login.Text = q_prt016.Dsc_login;//TT登入帳號

                D_Safe_old(f_pr_dept.SelectedValue.ToString());//養老保險等級
                D_Safe_medic(f_pr_dept.SelectedValue.ToString());//醫療保險等級
                D_Safe_job(f_pr_dept.SelectedValue.ToString());//失業保險等級
                D_Safe_house(f_pr_dept.SelectedValue.ToString());//住房公積等級
                f_old_safe_no.SelectedValue = q_prt016.Old_safe_no;
                f_medic_safe_no.SelectedValue = q_prt016.Medic_safe_no;
                f_job_safe_no.SelectedValue = q_prt016.Job_safe_no;
                f_house_safe_no.SelectedValue = q_prt016.House_safe_no;


                Config.Set_DateTo(f_pr_birth_date, q_prt016.Pr_birth_date.ToString());
                Config.Set_DateTo(f_pr_in_date, q_prt016.Pr_in_date.ToString());
                Config.Set_DateTo(f_pr_insr_date, q_prt016.Pr_insr_date.ToString());
                Config.Set_DateTo(f_pr_leave_date, q_prt016.Pr_leave_date.ToString());
                Config.Set_DateTo(f_pr_back_insr_date, q_prt016.Pr_back_insr_date.ToString());

            }
        }


        

        


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
            }
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                f_pr_dept.Enabled = false;

                f_pr_no.Enabled = false;

                o_in_date = f_pr_in_date.Value;

                f_pr_in_date.Value = DateTime.Now;
                f_pr_insr_date.Value = DateTime.Now;

                f_pr_leave_date.Enabled = false;
                f_pr_back_insr_date.Enabled = false;
                f_pr_name.Enabled = false;
                f_pr_idno.Enabled = false;

                f_pr_sex.Enabled = false;
                f_dsc_login.Enabled = false;
                f_nation.Enabled = false;
                code_dearch_bt.Enabled = false;
                bindingNavigator1.Enabled = false;
            }
            else
            {
                Config.Show("請先查詢");
            }
        }

        //private void menu_edit_Click(object sender, EventArgs e)
        //{
        //    if (f_pr_no.Text != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        f_pr_dept.Enabled = false;
                
        //        f_pr_no.Enabled = false;

        //        o_in_date = f_pr_in_date.Value;

        //        f_pr_in_date.Value = DateTime.Now;
        //        f_pr_insr_date.Value = DateTime.Now;

        //        f_pr_leave_date.Enabled = false;
        //        f_pr_back_insr_date.Enabled = false;
        //        f_pr_name.Enabled = false;
        //        f_pr_idno.Enabled = false;

        //        f_pr_sex.Enabled = false;
        //        f_dsc_login.Enabled = false;
        //        f_nation.Enabled = false;

        //        code_dearch_bt.Enabled = false; 
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
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
        }

        //入廠日
        private void f_pr_in_date_ValueChanged(object sender, EventArgs e)
        {            
            Config.Set_DateTo(f_pr_in_date, f_pr_in_date.Value.ToString("yyyy/MM/dd"));
            f_pr_insr_date.Value = f_pr_in_date.Value;
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


        private string f_Insert_prt027()
        {
            var p_prt0027 = new prt027();
            p_prt0027.Tr_id_no = f_pr_idno.Text;
            p_prt0027.Tr_sqe_no = prt027.GetSqeNo(f_pr_idno.Text);
            p_prt0027.Tr_type = "R";
            p_prt0027.Tr_start_date = f_pr_in_date.Text;
            p_prt0027.Tr_end_date = "";
            p_prt0027.Tr_comp = Dept;
            p_prt0027.Tr_dept_no = f_pr_dept.SelectedValue.ToString();
            p_prt0027.Tr_move_code = f_pr_work.SelectedValue.ToString();
            p_prt0027.Tr_old_comp = Dept;
            p_prt0027.Tr_old_dept = f_pr_dept.SelectedValue.ToString();
            p_prt0027.Tr_old_code = f_pr_work.SelectedValue.ToString();
            p_prt0027.Tr_move_amt = 0;
            p_prt0027.Tr_t1 = "";
            p_prt0027.Tr_t2 = "";
            p_prt0027.Tr_t3 = "";
            p_prt0027.Tr_comment = "復職";
            p_prt0027.Tr_wk_dept = f_pr_wk_cdept.SelectedValue.ToString();
            p_prt0027.Tr_old_posit = f_position.SelectedValue.ToString();
            p_prt0027.Tr_old_funct = "";
            p_prt0027.Tr_list_flag_ok = "";
            p_prt0027.Bpm_no = "";
            p_prt0027.Pr_no = f_pr_no.Text;
            p_prt0027.CreateDate = DateTime.Now;
            return p_prt0027.Insert();
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
            if (prvacam.Get(p_prvacam.Va_year, p_prvacam.Va_pr_no) == null)
            {
                return p_prvacam.Insert();
            }
            else
            {
                return p_prvacam.Update(p_prvacam.Va_year, p_prvacam.Va_pr_no);
            }
        }

        private string f_Delete_prvacal()
        {
            var p_prvacal = new prvacal();
            p_prvacal.Va_year =Int32.Parse(f_pr_in_date.Text.Substring(0, 4));
            p_prvacal.Va_pr_no = f_pr_no.Text;
            return p_prvacal.Delete(p_prvacal.Va_year, p_prvacal.Va_pr_no);
        }

        private string f_Insert_prt029()
        {
            var p_prt0029 = new prt029();
            p_prt0029.Va_year = Int32.Parse(f_pr_in_date.Text.Substring(0, 4));
            p_prt0029.Va_pr_no = f_pr_no.Text;
            p_prt0029.Va_id_no = f_pr_idno.Text;
            p_prt0029.Va_spec_date = 0;
            p_prt0029.Va_spec_hour = 0;
            p_prt0029.Va_spec_month = 1;
            p_prt0029.Vaca_a = 0;
            p_prt0029.Vaca_b = 0;
            p_prt0029.Vaca_c = 0;
            p_prt0029.Vaca_d = 0;
            p_prt0029.Vaca_e = 0;
            p_prt0029.Vaca_f = 0;
            p_prt0029.Vaca_g = 0;
            p_prt0029.Vaca_h = 0;
            p_prt0029.Vaca_i = 0;
            p_prt0029.Vaca_j = 0;
            p_prt0029.Vaca_k = 0;
            p_prt0029.Vaca_l = 0;
            p_prt0029.Vaca_m = 0;
            p_prt0029.Vaca_n = 0;
            p_prt0029.Vaca_o = 0;
            if (prt029.Get(p_prt0029.Va_year, p_prt0029.Va_pr_no) == null)
            {                
                return p_prt0029.Insert();
            }
            else
            {
                return p_prt0029.Update(p_prt0029.Va_year, p_prt0029.Va_pr_no);
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

        private void pri023_KeyDown(object sender, KeyEventArgs e)
        {
            //新增(F1)            
            if (e.KeyCode == Keys.F1)
            {
                menu_add_Click(sender, e);
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

        private void f_job_safe_no_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void f_medic_safe_no_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void f_old_safe_no_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void f_house_safe_no_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        

        

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Qry")
            {
                pri019w fm = new pri019w("L", f_pr_dept.SelectedValue.ToString());//開視窗資料-離職人員名單
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    f_pr_no.Text = fm.Code as string;
                    f_pr_name.Text = fm.Code_desc as string;
                    //找相關資料顯示出來
                    confirm_Click(sender, e);
                }
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


    }
}
