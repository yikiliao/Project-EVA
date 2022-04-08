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
    public partial class pri021 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt017> LS1 = new List<prt017>();
        decimal Sqe_no = 0;//序號prt016
        string iid = "";//序號
        prt016 p_prt016 = new prt016();
        string Dept = Login.DEPT;

        public string rPrno;//工號
        public string rTrcode;//課程類別
        public bool rOK = false;//按下確認鍵

        public pri021()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_type();//下拉選單
            D_Aclass();
        }
        private void D_Aclass()
        {            
            f_tr_code.DataSource = prt006.ToDoListCode(Dept, "EU", "Y").ToList();
            f_tr_code.DisplayMember = "Code_desc";
            f_tr_code.ValueMember = "Code";
        }

        //private void D_Aclass()
        //{
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "EU", "Y").ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_tr_code.DisplayMember = "Key";
        //    f_tr_code.ValueMember = "Value";
        //    f_tr_code.DataSource = data;
        //}
        private void set_dept()
        {
            //--廠部下拉選單
            f_tr_comp_dept.DataSource = sst011.ToDoList().ToList();
            f_tr_comp_dept.DisplayMember = "dept_name";
            f_tr_comp_dept.ValueMember = "dept";
        }

        private void D_type()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "是", Code = "Y" });
            LI.Add(new prt006 { Code_desc = "否", Code = "N" });
            f_come_code.DataSource = LI;
            f_come_code.DisplayMember = "Code_desc";
            f_come_code.ValueMember = "Code";
        }

        //private void D_type()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("是", "Y"));
        //    data.Add(new DictionaryEntry("否", "N"));
        //    f_come_code.DisplayMember = "Key";
        //    f_come_code.ValueMember = "Value";
        //    f_come_code.DataSource = data;
        //}

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
            f_tr_anyno.Enabled = false;
            f_tr_view.Enabled = false;

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
                else
                {
                    return;
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
            FormQuery();//查詢畫面
            if (rOK == true)
                confirm_Click(sender, e);//確認按鍵
            else
                InitColumn(this);//初始
        }
        private void FormQuery()
        {
            pri021Q fm = new pri021Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rPrno = fm.rPrno;//工號
                rTrcode = fm.rTrcode;//課程類別
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
            LS1 = prt017.ToDoList(Dept, rPrno, "1", rTrcode, string.Empty).ToList();//外訓
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
                var q_prt017 = prt017.Get(LS1[idx].Tr_id_no, LS1[idx].Tr_sqe_no);

                Find_p(prt016.GetWithIdno(q_prt017.Tr_id_no).Pr_no);

                f_tr_start_date.Text = q_prt017.Tr_start_date;
                f_tr_end_date.Text = q_prt017.Tr_end_date;
                f_tr_anyno.Text = q_prt017.Tr_anyno;
                f_tr_code.SelectedValue = q_prt017.Tr_code;
                f_tr_view.Text = q_prt017.Tr_view;
                f_come_code.SelectedValue = q_prt017.Come_code;
                f_acc_memo.Text = q_prt017.Acc_memo;

                f_add_user.Text = q_prt017.Add_user;
                f_add_date.Text = q_prt017.Add_date;
                f_mod_user.Text = q_prt017.Mod_user;
                f_mod_date.Text = q_prt017.Mod_date;

                Sqe_no = q_prt017.Tr_sqe_no;
                iid = Sqe_no.ToString();

                //--顯示圖片
                Find_HeadPic(f_tr_no.Text);
            }
        }

        private void menu_first_Click(object sender, EventArgs e)
        {
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
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
                f_acc_memo.Focus();
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
        //    if (f_tr_no.Text != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        get_enable();
        //        code_dearch_bt.Enabled = false;
        //        f_acc_memo.Focus();
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

            pri019w fm = new pri019w(_type,Dept);//開視窗資料
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pri021_Load(object sender, EventArgs e)
        {
            Exit_This();
        }
        private void Exit_This()
        {
            MessageBox.Show("此程式功能暫停...\n 整合到［pri020教育訓練資料維護］\n 如有問題再請聯絡電腦室。\n 謝謝您!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            this.Close();
        }
    }
}
