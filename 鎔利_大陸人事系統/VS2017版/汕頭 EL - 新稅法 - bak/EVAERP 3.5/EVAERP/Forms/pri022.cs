using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVAERP.Models;
using System.Collections;

//using System.Data;
using System.IO;
//using System.Configuration;
//using System.Data.SqlClient;


namespace EVAERP.Forms
{
    public partial class pri022 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt027> LS1 = new List<prt027>();
        decimal Sqe_no = 0;//序號
        prt016 p_prt016 = new prt016();
        Int32 Spec_year = 0;
        Int32 Spec_mon = 0;
        string Dept = Login.DEPT;
        DateTime rCreateDate;

        public string rPrno;//工號
        public string rId;//身分證號
        public string rName;//姓名
        public string rBegdate;//離職日(起)
        public string rEnddate;//離職日(迄)
        public bool rOK = false;//按下確認鍵

        public pri022()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_Cdpet();//部門
            D_Work();//職稱
            D_Position();//職位 
        }

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
        private void D_Cdpet()
        {            
            f_cdept.DataSource = prt001.ToDoList(Dept).ToList();
            f_cdept.DisplayMember = "Department_name_new";
            f_cdept.ValueMember = "Department_code";
        }

        //private void D_Cdpet()
        //{
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt001.ToDoList(Dept).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Department_name_new, i.Department_code));
        //    }
        //    f_cdept.DisplayMember = "Key";
        //    f_cdept.ValueMember = "Value";
        //    f_cdept.DataSource = data;
        //}


        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
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
            get_enable();            
            f_start_date.Value = DateTime.Now;
            f_leav_date.Value = DateTime.Now;
            f_comment.Text = "離職";
            code_dearch_bt_Click(sender, e);            
            bindingNavigator1.Enabled = false;
        }

        private void get_enable()
        {
            f_idno.Enabled = false;
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
            f_dept.Enabled = false;
            f_cdept.Enabled = false;
            f_wk_code.Enabled = false;
            f_pr_work.Enabled = false;
            f_position.Enabled = false;
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
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_pr_no.Text == System.String.Empty)
                    {
                        Config.Show("員工編號不可空白");
                        f_pr_no.Focus();
                        return;
                    }
                    try
                    {
                        Config.Show(f_Insert());
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

        private string f_Insert()
        {
            return String.Format("{0}\n{1}", f_Insert_prt027(), f_Update_prt016());
        }

        private string f_Update()
        {
            return String.Format("{0}\n{1}", f_Update_prt027(), f_Update_prt016());
        }

        private string f_Delete()
        {
            return String.Format("{0}\n{1}", new prt027().Delete(f_idno.Text, Sqe_no), f_Update_prt016());
        }
        private string f_Update_prt016()
        {            
            if (Menu_Sel == "Del")
            {
                p_prt016.Pr_leave_date = null;
                p_prt016.Pr_back_insr_date = null;
                p_prt016.Pr_spec_monthpay = 0;
                p_prt016.Pr_spec_yearpay = 0;
            }
            else
            {
                p_prt016.Pr_leave_date = f_start_date.Value.ToString("yyyy/MM/dd");
                p_prt016.Pr_back_insr_date = f_leav_date.Value.ToString("yyyy/MM/dd");
                p_prt016.Pr_spec_monthpay = Spec_mon;
                p_prt016.Pr_spec_yearpay = Spec_year;
            }
            return p_prt016.Update(f_pr_no.Text);
        }

        private string f_Insert_prt027()
        {
            Get_Spec();
            var p_prt027 = new prt027();
            p_prt027.Tr_id_no = f_idno.Text;
            p_prt027.Tr_sqe_no = prt027.GetSqeNo(p_prt016.Pr_idno);
            p_prt027.Tr_type = "L";
            p_prt027.Tr_comp = Dept;
            p_prt027.Tr_dept_no = f_dept.SelectedValue.ToString();
            p_prt027.Tr_old_comp = Dept;
            p_prt027.Tr_start_date = f_start_date.Value.ToString("yyyy/MM/dd");
            p_prt027.Tr_old_dept = f_cdept.SelectedValue.ToString();
            p_prt027.Tr_old_code = f_pr_work.SelectedValue.ToString();
            p_prt027.Tr_move_amt = Spec_year;//特別年資-年
            p_prt027.Tr_old_amt = Spec_mon;//特別年資-月
            p_prt027.Tr_comment = string.IsNullOrEmpty(f_comment.Text) ? "離職" : f_comment.Text;
            p_prt027.Pr_no = f_pr_no.Text;
            p_prt027.CreateDate = DateTime.Now;
            return p_prt027.Insert();
        }

        //離職天數和入廠日
        private void Get_Spec()
        {
           var pp =  prt016.CalculateWorkAge(p_prt016.Pr_in_date, f_start_date.Value.ToString("yyyy/MM/dd"));
           Spec_year = pp.Work_Year;
           Spec_mon = pp.Work_Month;
        }

        private string f_Update_prt027()
        {   
            Get_Spec();
            var p_prt027 = new prt027();
            p_prt027.Tr_id_no = p_prt016.Pr_idno;
            p_prt027.Tr_sqe_no = Sqe_no;
            p_prt027.Tr_type = "L";
            p_prt027.Tr_dept_no = f_dept.SelectedValue.ToString();
            p_prt027.Tr_start_date = f_start_date.Value.ToString("yyyy/MM/dd");
            p_prt027.Tr_old_dept = f_cdept.SelectedValue.ToString();//p_prt016.Pr_cdept;
            p_prt027.Tr_old_code = f_pr_work.SelectedValue.ToString();//p_prt016.Pr_work;
            p_prt027.Tr_move_amt = Spec_year;//特別年資-年
            p_prt027.Tr_old_amt = Spec_mon;//特別年資-月
            p_prt027.Tr_comment = f_comment.Text;
            return p_prt027.Update(p_prt027.Tr_id_no, Sqe_no);
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
            pri022Q fm = new pri022Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {                
                rPrno = fm.rPrno;//工號                
                rId = fm.rId;//身分證號
                rBegdate = fm.rBegdate;//離職日起
                rEnddate = fm.rEnddate;//離職日迄
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
            LS1 = prt027.ToDoList(Dept, rPrno, rId, rBegdate, rEnddate, "L").ToList();
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
                var q_prt027 = prt027.Get(LS1[idx].Tr_id_no, LS1[idx].Tr_sqe_no);

                Find_p2(prt016.GetWithIdno(q_prt027.Tr_id_no).Pr_no, q_prt027.Tr_dept_no);
                f_start_date.Value = DateTime.Parse(q_prt027.Tr_start_date);//離職日                 
                f_comment.Text = q_prt027.Tr_comment;
                Sqe_no = q_prt027.Tr_sqe_no;
                rCreateDate = q_prt027.CreateDate;
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
        //        Find_p2(prt016.GetWithIdno(LS1[idx].Tr_id_no).Pr_no,LS1[idx].Tr_dept_no);
        //        f_start_date.Value = DateTime.Parse(LS1[idx].Tr_start_date);//離職日                 
        //        f_comment.Text = LS1[idx].Tr_comment;
        //        Sqe_no = LS1[idx].Tr_sqe_no;
        //        rCreateDate = LS1[idx].CreateDate;
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
                //不是當天資料無法異動
                if (rCreateDate.ToString("yyyy/MM/dd") != DateTime.Now.ToString("yyyy/MM/dd"))
                {
                    Config.Show("離職日期已生效，不可以異動。");
                    return;
                }
                Menu_Sel = "Upd";
                SetMotherboard(this);
                get_enable();
                code_dearch_bt.Enabled = false;
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
        //    if (Menu_Sel !="Add")
        //    {   
        //        //不是當天資料無法異動
        //        if (rCreateDate.ToString("yyyy/MM/dd") != DateTime.Now.ToString("yyyy/MM/dd"))
        //        {
        //            Config.Show("離職日期已生效，不可以異動。");
        //            return;
        //        }
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        get_enable();
        //        code_dearch_bt.Enabled = false;
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //        return;
        //    }
        //}

        //private void menu_edit_Click(object sender, EventArgs e)
        //{
        //    if (f_pr_no.Text != "" && Menu_Sel == "Qry")
        //    {   
        //        //不是當天資料無法異動
        //        if (rCreateDate.ToString("yyyy/MM/dd") != DateTime.Now.ToString("yyyy/MM/dd"))
        //        {
        //            Config.Show("離職日期已生效，不可以異動。");
        //            return;
        //        }
                
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        get_enable();
        //        code_dearch_bt.Enabled = false;
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}
        
        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {               
                pri019w fm = new pri019w("I",f_dept.SelectedValue.ToString());//開視窗資料-在職人員名單
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    f_pr_no.Text = fm.Code as string;
                    f_pr_name.Text = fm.Code_desc as string;

                    //找相關資料顯示出來
                    Find_p(f_pr_no.Text);
                }
            }

            if (Menu_Sel == "Qry")
            {
                pri019w fm = new pri019w("L", f_dept.SelectedValue.ToString());//開視窗資料-離職人員名單
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    f_pr_no.Text = fm.Code as string;
                    f_pr_name.Text = fm.Code_desc as string;
                    //找相關資料顯示出來
                    Find_p(f_pr_no.Text);
                }
            }

        }

        private void Find_p(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_idno.Text = p_prt016.Pr_idno;
            f_dept.SelectedValue = p_prt016.Pr_dept;
            f_cdept.SelectedValue = p_prt016.Pr_cdept;
            f_wk_code.Text = p_prt016.Wk_code;
            f_pr_work.SelectedValue = p_prt016.Pr_work;
            f_position.SelectedValue = p_prt016.Position;
        }

        private void Find_p2(string Pr_no,string Dept)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_idno.Text = p_prt016.Pr_idno;
            f_dept.SelectedValue = p_prt016.Pr_dept;
            f_cdept.SelectedValue = p_prt016.Pr_cdept;
            f_wk_code.Text = p_prt016.Wk_code;
            f_pr_work.SelectedValue = p_prt016.Pr_work;
            f_position.SelectedValue = p_prt016.Position;
            f_leav_date.Value = string.IsNullOrEmpty(p_prt016.Pr_back_insr_date) ? DateTime.Parse("1900/01/01") : DateTime.Parse(p_prt016.Pr_back_insr_date);//退保日
        }

        private void f_start_date_ValueChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
                f_leav_date.Value = f_start_date.Value;
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

        private void pri022_KeyDown(object sender, KeyEventArgs e)
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

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
            {
                Menu_Sel = "Del";
                InitMotherboard(this);
                //不是當天資料無法異動
                if (rCreateDate.ToString("yyyy/MM/dd") != DateTime.Now.ToString("yyyy/MM/dd"))
                {
                    Config.Show("離職日期已生效，不可以異動。");
                    return;
                }
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
        //    Menu_Sel = "Del";
        //    InitMotherboard(this);
        //    if (f_pr_no.Text != "" && Menu_Sel == "Del")
        //    {
        //        //不是當天資料無法異動
        //        if (rCreateDate.ToString("yyyy/MM/dd") != DateTime.Now.ToString("yyyy/MM/dd"))
        //        {
        //            Config.Show("離職日期已生效，不可以異動。");
        //            return;
        //        }
        //        confirm_Click(sender, e);
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}

        
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
