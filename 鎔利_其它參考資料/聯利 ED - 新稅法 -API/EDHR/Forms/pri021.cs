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
    public partial class pri021 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt017> LS1 = new List<prt017>();
        decimal Sqe_no = 0;//序號prt016
        string iid = "";//序號
        prt016 p_prt016 = new prt016();
        

        public pri021()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_type();//下拉選單
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_tr_comp_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_tr_comp_dept.DisplayMember = "dept_name";
            f_tr_comp_dept.ValueMember = "dept";
        }
        private void D_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("是", "Y"));
            data.Add(new DictionaryEntry("否", "N"));
            f_come_code.DisplayMember = "Key";
            f_come_code.ValueMember = "Value";
            f_come_code.DataSource = data;
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        

        private void get_enable()
        {
            f_tr_id_no.Enabled = false;
            f_tr_no.Enabled = false;
            f_tr_name.Enabled = false;
            f_tr_comp_dept.Enabled = false;

            f_tr_start_date.Enabled = false;
            f_tr_end_date.Enabled = false;
            f_tr_code.Enabled = false;
            f_tr_code_name.Enabled = false;

            f_tr_anyno.Enabled = false;
            f_tr_view.Enabled = false;

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

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);
            }

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定?") == "Y")
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

        }

        

        private string f_Update()
        {
            return String.Format("{0}", f_Update_prt017());
        }

        

        private string f_Update_prt017()
        {
            var p_prt017 = new prt017();
            p_prt017 = prt017.Get(f_tr_id_no.Text, Sqe_no);
            p_prt017.Come_code = f_come_code.SelectedValue.ToString();
            p_prt017.Acc_memo = f_acc_memo.Text;
            return p_prt017.Update(f_tr_id_no.Text, Sqe_no);
        }
     

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            f_come_code.SelectedIndex = 0;
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt017.ToDoList(f_tr_id_no.Text, "1", f_tr_comp_dept.SelectedValue.ToString()).ToList();//外訓
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
                Find_p(prt016.GetWithIdno(LS1[idx].Tr_id_no).Pr_no);

                f_tr_start_date.Text = LS1[idx].Tr_start_date;
                f_tr_end_date.Text = LS1[idx].Tr_end_date;
                f_tr_anyno.Text = LS1[idx].Tr_anyno;
                f_tr_code.Text = LS1[idx].Tr_code;
                f_tr_code_name.Text = prt006.Get(f_tr_comp_dept.SelectedValue.ToString(), "EU", LS1[idx].Tr_code) == null ? "" : prt006.Get(f_tr_comp_dept.SelectedValue.ToString(), "EU", LS1[idx].Tr_code).Code_desc;
                f_tr_view.Text = LS1[idx].Tr_view;
                f_come_code.SelectedValue = LS1[idx].Come_code;
                f_acc_memo.Text = LS1[idx].Acc_memo;


                f_add_user.Text = LS1[idx].Add_user;
                f_add_date.Text = LS1[idx].Add_date;
                f_mod_user.Text = LS1[idx].Mod_user;
                f_mod_date.Text = LS1[idx].Mod_date;

                Sqe_no = LS1[idx].Tr_sqe_no;
                iid = Sqe_no.ToString();
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
            if (f_tr_no.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                get_enable();
                code_dearch_bt.Enabled = false;
                f_acc_memo.Focus();
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
                        
            pri019w fm = new pri019w(_type, f_tr_comp_dept.SelectedValue.ToString());//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_tr_no.Text = fm.Code as string;
                f_tr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                Find_p(f_tr_no.Text);
            }
        }

        private void Find_p(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_tr_no.Text = p_prt016.Pr_no;
            f_tr_name.Text = p_prt016.Pr_name;
            f_tr_id_no.Text = p_prt016.Pr_idno;
            f_tr_comp_dept.SelectedValue = p_prt016.Pr_dept;
        }



        private void f_tr_code_bt_Click(object sender, EventArgs e)
        {
            pri006w fm = new pri006w(f_tr_comp_dept.SelectedValue.ToString(),"EU");//開視窗資料-課程類別
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_tr_code.Text = fm.Code as string;
                f_tr_code_name.Text = fm.Code_desc as string;
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

        private void pri021_KeyDown(object sender, KeyEventArgs e)
        {
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

        private void pri021_Load(object sender, EventArgs e)
        {
            MessageBox.Show("此程式功能暫停...\n 整合到［pri020教育訓練資料維護］\n 如有問題再請聯絡電腦室。\n 謝謝您!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            this.Close();
        }


    }
}
