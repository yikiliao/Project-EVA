using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDHR.Models;

namespace EDHR.Forms
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

        public pri022()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            code_dearch_bt.Enabled = false;

            D_Cdpet();//部門
            D_Work();//職稱
            D_Position();//職位
        }

        //private void D_Position()
        //{
        //    var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();
        //    f_position.DataSource = prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList();
        //    f_position.DisplayMember = "Code_desc";
        //    f_position.ValueMember = "Code";
        //}

        private void D_Position()
        {   
            f_position.DataSource = prt006.ToDoListCode(Dept, "WT", "Y").OrderBy(a=>a.Code_desc).ToList();
            f_position.DisplayMember = "Code_desc";
            f_position.ValueMember = "Code";
        }
        private void D_Work()
        {
            f_pr_work.DataSource = prt006.ToDoListCode(Dept, "WK", "Y").OrderBy(a=>a.Code_desc).ToList();
            f_pr_work.DisplayMember = "Code_desc";
            f_pr_work.ValueMember = "Code";
        }

        //private void D_Work()
        //{
        //    var idList = prt016.ToDoList(Dept, "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();
        //    f_pr_work.DataSource = prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList();
        //    f_pr_work.DisplayMember = "Code_desc";
        //    f_pr_work.ValueMember = "Code";
        //}

        private void D_Cdpet()
        {
            f_cdept.DataSource = prt001.ToDoList(Dept).OrderBy(a=>a.Department_name_new).ToList();
            f_cdept.DisplayMember = "Department_name_new";
            f_cdept.ValueMember = "Department_code";
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
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
            code_dearch_bt.Enabled = false;
            code_dearch_bt_Click(null, null);
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
                        //系統通知改由隔天系統自動寄送 離職人員通知
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
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Update());
                        //系統通知改由隔天系統自動寄送  離職人員通知
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
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

        private string f_Update_prt016()
        {
            p_prt016.Pr_leave_date = f_start_date.Value.ToString("yyyy/MM/dd");
            p_prt016.Pr_back_insr_date = f_leav_date.Value.ToString("yyyy/MM/dd");
            p_prt016.Pr_spec_monthpay = Spec_mon;
            p_prt016.Pr_spec_yearpay = Spec_year;
            return p_prt016.Update(f_pr_no.Text);
        }

        private string f_Insert_prt027()
        {
            Get_Spec();
            var p_prt027 = new prt027();
            p_prt027.Tr_id_no = f_idno.Text;
            p_prt027.Tr_sqe_no = prt027.GetSqeNo(p_prt016.Pr_idno);
            p_prt027.Tr_type = "L";
            p_prt027.Tr_comp = f_dept.SelectedValue.ToString();
            p_prt027.Tr_dept_no = f_dept.SelectedValue.ToString();
            p_prt027.Tr_old_comp = f_dept.SelectedValue.ToString();
            p_prt027.Tr_start_date = f_start_date.Value.ToString("yyyy/MM/dd");//離職日
            p_prt027.Tr_end_date = f_leav_date.Value.ToString("yyyy/MM/dd");//退保日
            p_prt027.Tr_old_dept = f_cdept.SelectedValue.ToString();
            p_prt027.Tr_old_code = f_pr_work.SelectedValue.ToString();
            p_prt027.Tr_move_amt = Spec_year;//特別年資-年
            p_prt027.Tr_old_amt = Spec_mon;//特別年資-月
            p_prt027.Tr_comment = string.IsNullOrEmpty(f_comment.Text) ? "離職" : f_comment.Text;
            p_prt027.Pr_no = f_pr_no.Text;
            p_prt027.CraeteDate = DateTime.Now;
            return p_prt027.Insert();
        }

        //離職天數和入廠日
        private void Get_Spec()
        {
            Int32 sy1, sy2, sm1, sm2, sd1, sd2 = 0;
            DateTime in_date = System.Convert.ToDateTime(p_prt016.Pr_in_date);//入廠日
            DateTime comp_date = f_start_date.Value.AddDays(-1);//離職天數
            sy1 = comp_date.Year;
            sm1 = comp_date.Month;
            sd1 = comp_date.Day;

            sy2 = in_date.Year;
            sm2 = in_date.Month;
            sd2 = in_date.Day;

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
            Spec_year = sy1 - sy2 + (string.IsNullOrEmpty(p_prt016.Pr_spec_yearpay.ToString()) ? 0 : p_prt016.Pr_spec_yearpay);
            Spec_mon = sm1 - sm2 + (string.IsNullOrEmpty(p_prt016.Pr_spec_monthpay.ToString()) ? 0 : p_prt016.Pr_spec_monthpay);
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
            p_prt027.Tr_old_dept = f_cdept.SelectedValue.ToString(); //p_prt016.Pr_cdept;
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
            SetColumn(this);
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt027.ToDoList(f_idno.Text, "L",f_dept.SelectedValue.ToString()).ToList();
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
                Find_p2(prt016.GetWithIdno(LS1[idx].Tr_id_no).Pr_no,LS1[idx].Tr_dept_no);
                f_start_date.Value = DateTime.Parse(LS1[idx].Tr_start_date);//離職日
                f_leav_date.Value = DateTime.Parse(LS1[idx].Tr_end_date);//退保日
                f_comment.Text = LS1[idx].Tr_comment;
                Sqe_no = LS1[idx].Tr_sqe_no;
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
                Menu_Sel = "Upd";
                SetMotherboard(this);
                get_enable();
                code_dearch_bt.Enabled = false;
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
            f_dept.SelectedValue = Dept;
            f_cdept.SelectedValue = p_prt016.Pr_cdept;
            
            f_wk_code.Text = p_prt016.Wk_code;
            f_pr_work.SelectedValue = p_prt016.Pr_work;
            f_position.SelectedValue = p_prt016.Position;
        }

        private void f_start_date_ValueChanged(object sender, EventArgs e)
        {
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
