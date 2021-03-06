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
    public partial class pri030 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt027> LS1 = new List<prt027>();
        decimal Sqe_no = 0;//序號
        prt016 p_prt016 = new prt016();
        string Dept = Login.DEPT;
        public string rPrno;//工號
        public string rId;//身分證號
        public bool rOK = false;//按下確認鍵
        
        public pri030()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_type();//下拉選單

            D_Cdpet();//部門
            D_Work();//職稱
            D_Position();//職位
            D_TRCdpet();//新部門
            D_TRWork();//新職稱
            D_TRPosition();//新職位
        }
        private void D_Position()
        {
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();
            ArrayList data = new ArrayList();
            foreach (var i in prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList())
            {
                data.Add(new DictionaryEntry(i.Code_desc, i.Code));
            }
            f_position.DisplayMember = "Key";
            f_position.ValueMember = "Value";
            f_position.DataSource = data;
        }

        private void D_TRPosition()
        {
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();
            ArrayList data = new ArrayList();
            foreach (var i in prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList())
            {
                data.Add(new DictionaryEntry(i.Code_desc, i.Code));
            }
            f_tr_posit.DisplayMember = "Key";
            f_tr_posit.ValueMember = "Value";
            f_tr_posit.DataSource = data;
        }
        private void D_Work()
        {
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();
            ArrayList data = new ArrayList();
            foreach (var i in prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList())
            {
                data.Add(new DictionaryEntry(i.Code_desc, i.Code));
            }
            f_pr_work.DisplayMember = "Key";
            f_pr_work.ValueMember = "Value";
            f_pr_work.DataSource = data;
        }
        private void D_TRWork()
        {
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();
            ArrayList data = new ArrayList();
            foreach (var i in prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList())
            {
                data.Add(new DictionaryEntry(i.Code_desc, i.Code));
            }
            f_tr_move_code.DisplayMember = "Key";
            f_tr_move_code.ValueMember = "Value";
            f_tr_move_code.DataSource = data;
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
        private void D_TRCdpet()
        {
            ArrayList data = new ArrayList();
            foreach (var i in prt001.ToDoList(Dept).ToList())
            {
                data.Add(new DictionaryEntry(i.Department_name_new, i.Department_code));
            }
            f_tr_wk_dept.DisplayMember = "Key";
            f_tr_wk_dept.ValueMember = "Value";
            f_tr_wk_dept.DataSource = data;
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void D_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("0:新任", "新任"));
            data.Add(new DictionaryEntry("1:調升", "調升"));
            data.Add(new DictionaryEntry("2:調降", "調降"));
            data.Add(new DictionaryEntry("3:異動", "異動"));
            f_tr_t1.DisplayMember = "Key";
            f_tr_t1.ValueMember = "Value";
            f_tr_t1.DataSource = data;
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
            f_trno.Text = "--系統給號--";
            f_tr_move_amt.Text = "0";
            get_enable();
            f_tr_t1.SelectedIndex = 4;
            code_dearch_bt_Click(sender, e);
            f_start_date_dt.Value = DateTime.Now;   //生效日            
            bindingNavigator1.Enabled = false;
        }

        private void get_enable()
        {
            f_idno.Enabled = false;
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
            f_dept.Enabled = false;
            f_cdept.Enabled = false;
            
            f_pr_work.Enabled = false;
            
            f_position.Enabled = false;
            
            f_trno.Enabled = false;
            f_start_date.Enabled = false;
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
                    if (f_Check() == false)
                        return;
                    try
                    {
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Insert(), f_pr_no.Text, f_pr_name.Text));
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
                        Config.Show(String.Format("{0}\n工號:{1} 姓名:{2}", f_Delete(), f_pr_no.Text, f_pr_name.Text));
                        //
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
                //InitColumn(this);//初始
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
            if (f_start_date.Text == System.String.Empty)
            {
                Config.Show("生效日不可空白");
                f_start_date.Focus();
                return false;
            }
            if (f_tr_move_amt.Text == System.String.Empty)
            {
                Config.Show("人事命令不可空白");
                f_tr_move_amt.Focus();
                return false;
            }
            return true;
        }


        

        private string f_Insert()
        {
            return String.Format("{0}\n{1}", f_Insert_prt027(), f_Update_prt016());
        }

        private string f_Update()
        {
            return String.Format("{0}\n{1}", f_Update_prt027(), f_Update_prt016());
        }

        //新的異動部門
        private string f_Update_prt016()
        {  
            var p_prt016 = new prt016();
            p_prt016 = prt016.Get(f_pr_no.Text);
            p_prt016.Pr_cdept = f_tr_wk_dept.SelectedValue.ToString();
            p_prt016.Pr_wk_cdept = f_tr_wk_dept.SelectedValue.ToString();
            p_prt016.Pr_work = f_tr_move_code.SelectedValue.ToString();
            p_prt016.Position = f_tr_posit.SelectedValue.ToString();
            return p_prt016.Update(f_pr_no.Text);
        }

        
        private string f_Delete()
        {
            return String.Format("{0}\n{1}", f_Delete_prt027(), f_Chang_prt016());
        }


        //舊的部門
        private string f_Chang_prt016()
        {
            var p_prt016 = new prt016();
            p_prt016 = prt016.Get(f_pr_no.Text);
            p_prt016.Pr_cdept = f_cdept.SelectedValue.ToString();
            p_prt016.Pr_wk_cdept = f_cdept.SelectedValue.ToString();
            p_prt016.Pr_work = f_pr_work.SelectedValue.ToString();
            p_prt016.Position = f_position.SelectedValue.ToString();
            return p_prt016.Update(f_pr_no.Text);
        }

        private string Get_sTyep()
        {
            string s_Type = string.Empty;
            if (f_tr_t1.SelectedIndex == 1) s_Type = "Z"; //新任
            if (f_tr_t1.SelectedIndex == 2) s_Type = "U"; //調升
            if (f_tr_t1.SelectedIndex == 3) s_Type = "D"; //調降
            if (f_tr_t1.SelectedIndex == 4) s_Type = "M"; //異動
            return s_Type;
        }

        private string f_Insert_prt027()
        {
            var p_prt027 = new prt027();
            p_prt027.Tr_id_no = f_idno.Text;
            p_prt027.Tr_sqe_no = prt027.GetSqeNo(f_idno.Text);
            p_prt027.Tr_type = Get_sTyep();
            p_prt027.Tr_start_date = f_start_date.Text;
            p_prt027.Tr_comp = Dept;
            p_prt027.Tr_dept_no = f_dept.SelectedValue.ToString();

            p_prt027.Tr_wk_dept = f_tr_wk_dept.SelectedValue.ToString();
            p_prt027.Tr_move_code = f_tr_move_code.SelectedValue.ToString();
            p_prt027.Tr_posit = f_tr_posit.SelectedValue.ToString();

            p_prt027.Tr_old_comp = Dept;
            p_prt027.Tr_old_wk = f_cdept.SelectedValue.ToString();
            p_prt027.Tr_old_code = f_pr_work.SelectedValue.ToString();
            p_prt027.Tr_old_posit = f_position.SelectedValue.ToString();

            p_prt027.Tr_move_amt = System.Convert.ToInt32(f_tr_move_amt.Text);
            p_prt027.Tr_t1 = f_tr_t1.SelectedValue.ToString();
            p_prt027.Tr_list_flag_ok = "3";
            p_prt027.Tr_comment = string.IsNullOrEmpty(f_comment.Text) ? f_tr_t1.SelectedValue.ToString() : f_comment.Text;
            p_prt027.Trno = new Config().SerialNumber(f_dept.SelectedValue.ToString(), "PR", "02");
            p_prt027.Pr_no = f_pr_no.Text;
            p_prt027.CreateDate = DateTime.Now;
            //p_prt027.CraeteDate = DateTime.Now;
            f_trno.Text = p_prt027.Trno;  
            return p_prt027.Insert();
        }
               

        private string f_Update_prt027()
        {
            var p_prt027 = new prt027();
            p_prt027 = prt027.Get(f_idno.Text,Sqe_no);

            p_prt027.Tr_start_date = f_start_date.Text;
            p_prt027.Tr_comp = Dept;
            p_prt027.Tr_dept_no = f_dept.SelectedValue.ToString();

            p_prt027.Tr_wk_dept = f_tr_wk_dept.SelectedValue.ToString();
            p_prt027.Tr_move_code = f_tr_move_code.SelectedValue.ToString();
            p_prt027.Tr_posit = f_tr_posit.SelectedValue.ToString();

            p_prt027.Tr_old_comp = Dept;
            p_prt027.Tr_old_wk = f_cdept.SelectedValue.ToString();
            p_prt027.Tr_old_code = f_pr_work.SelectedValue.ToString();
            p_prt027.Tr_old_posit = f_position.SelectedValue.ToString();

            p_prt027.Tr_move_amt = System.Convert.ToInt32(f_tr_move_amt.Text);
            p_prt027.Tr_t1 = f_tr_t1.SelectedValue.ToString();
            p_prt027.Tr_list_flag_ok = "3";
            p_prt027.Tr_comment = f_comment.Text;            
            return p_prt027.Update(f_idno.Text, Sqe_no);
        }

        private string f_Delete_prt027()
        {
            var p_prt027 = new prt027();
            return p_prt027.Delete(f_idno.Text, Sqe_no);
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
            pri030Q fm = new pri030Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {   
                rPrno = fm.rPrno;//工號
                rId = fm.rId;//身分證號
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
            LS1 = prt027.ToDoList(Dept,rPrno,rId,"","","").Where(a => a.Tr_type == "Z" || a.Tr_type == "U" || a.Tr_type == "D" || a.Tr_type == "M").ToList();
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

                Find_p(prt016.GetWithIdno(q_prt027.Tr_id_no) == null ? "" : prt016.GetWithIdno(q_prt027.Tr_id_no).Pr_no);
                //---
                f_cdept.SelectedValue = q_prt027.Tr_old_wk;
                f_pr_work.SelectedValue = q_prt027.Tr_old_code;
                f_position.SelectedValue = q_prt027.Tr_old_posit;
                f_tr_wk_dept.SelectedValue = q_prt027.Tr_wk_dept;
                f_tr_move_code.SelectedValue = q_prt027.Tr_move_code;
                f_tr_posit.SelectedValue = q_prt027.Tr_posit;

                //---
                f_start_date.Text = q_prt027.Tr_start_date;
                if (!string.IsNullOrEmpty(q_prt027.Tr_start_date))
                    f_start_date_dt.Value = System.Convert.ToDateTime(q_prt027.Tr_start_date);
                f_trno.Text = q_prt027.Trno;
                f_tr_t1.SelectedValue = q_prt027.Tr_t1;
                f_tr_move_amt.Text = System.Convert.ToInt32(q_prt027.Tr_move_amt).ToString();
                f_comment.Text = q_prt027.Tr_comment;
                Sqe_no = q_prt027.Tr_sqe_no;
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
        //        Find_p(prt016.GetWithIdno(LS1[idx].Tr_id_no)==null ? "" :prt016.GetWithIdno(LS1[idx].Tr_id_no).Pr_no);
        //        //---
        //        f_cdept.SelectedValue = LS1[idx].Tr_old_wk;
                
        //        f_pr_work.SelectedValue = LS1[idx].Tr_old_code;
                
        //        f_position.SelectedValue = LS1[idx].Tr_old_posit;
                

        //        f_tr_wk_dept.SelectedValue = LS1[idx].Tr_wk_dept;;
                
        //        f_tr_move_code.SelectedValue = LS1[idx].Tr_move_code;
                
        //        f_tr_posit.SelectedValue = LS1[idx].Tr_posit;
                
        //        //---
        //        f_start_date.Text = LS1[idx].Tr_start_date;
        //        if (!string.IsNullOrEmpty(LS1[idx].Tr_start_date ))
        //            f_start_date_dt.Value = System.Convert.ToDateTime(LS1[idx].Tr_start_date);
        //        f_trno.Text = LS1[idx].Trno;
        //        f_tr_t1.SelectedValue = LS1[idx].Tr_t1;
        //        f_tr_move_amt.Text = System.Convert.ToInt32(LS1[idx].Tr_move_amt).ToString();
        //        f_comment.Text = LS1[idx].Tr_comment;
        //        Sqe_no = LS1[idx].Tr_sqe_no;
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
                if (p_prt016.Pr_leave_date != string.Empty)
                {
                    Config.Show("已離職無法異動");
                    return;
                }
                Menu_Sel = "Upd";
                SetMotherboard(this);
                get_enable();
                code_dearch_bt.Enabled = false;
                f_tr_move_amt.Focus();
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
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        get_enable();
        //        code_dearch_bt.Enabled = false;
        //        f_tr_move_amt.Focus();
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}
        
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
                if (Menu_Sel == "Add" || Menu_Sel == "Qry")
                    Find_p(f_pr_no.Text);
            }
        }

        private void Find_p(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            if (p_prt016 == null)
                return;
            if (Menu_Sel =="Add")
            {
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;
            f_idno.Text = p_prt016.Pr_idno;
            f_dept.SelectedValue = p_prt016.Pr_dept;

            f_cdept.SelectedValue = p_prt016.Pr_cdept;
            
            f_pr_work.SelectedValue = p_prt016.Pr_work;
            
            f_position.SelectedValue = p_prt016.Position;
            

            f_tr_wk_dept.SelectedValue = p_prt016.Pr_cdept;
            
            f_tr_move_code.SelectedValue = p_prt016.Pr_work;
            
            f_tr_posit.SelectedValue = p_prt016.Position;
            
            }
            if (Menu_Sel != "Add")
            {
                f_pr_no.Text = p_prt016.Pr_no;
                f_pr_name.Text = p_prt016.Pr_name;
                f_idno.Text = p_prt016.Pr_idno;
                f_dept.SelectedValue = p_prt016.Pr_dept;
            }
            
        }
                


        private void f_start_date_ValueChanged(object sender, EventArgs e)
        {
            //if (System.DateTime.Now < f_start_date_dt.Value)
            //{
            //    Config.Show("生效日期不可大於今天");
            //    f_start_date_dt.Value = DateTime.Now;
            //}
            f_start_date.Text = f_start_date_dt.Value.ToString("yyyy/MM/dd");
        }



        private void f_tr_move_amt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 48 || (byte)e.KeyChar > 57)//若小於0或大於9 
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true; //不可輸;鎖起來
                }
            }

        }

        private void f_tr_t1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_tr_t1.SelectedIndex == 0)
                    f_tr_t1.SelectedIndex = 1;
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

        private void pri030_KeyDown(object sender, KeyEventArgs e)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_no.Text != string.Empty)
            {
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

    }
}
