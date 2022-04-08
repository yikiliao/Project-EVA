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
    public partial class pri035 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt030D> LS1 = new List<prt030D>();
        prt016 p_prt016 = new prt016();
        string Dept = Login.DEPT;        

        public pri035()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D0();//下拉選單-班別
            D3();//下拉選單-夜班津貼
            
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
        }
        private void D0()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("1.平日", "1"));
            data.Add(new DictionaryEntry("2.假日", "2"));
            f_va_code3.DisplayMember = "Key";
            f_va_code3.ValueMember = "Value";
            f_va_code3.DataSource = data;
        }
                

        private void D3()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("N", "N"));
            data.Add(new DictionaryEntry("Y", "Y"));
            f_va_code1.DisplayMember = "Key";
            f_va_code1.ValueMember = "Value";
            f_va_code1.DataSource = data;
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
            QueryDate(false);
            code_dearch_bt_Click(sender, e);
            f_va_code3.SelectedIndex = 1;
        }

        private void Col_Disable()
        {
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
            f_pr_dept.Enabled = false;
            f_pr_cdept.Enabled = false;
            f_pr_cdept_name.Enabled = false;
            f_pr_date.Enabled = false;
        }

        private void Col_Vol()
        {
            if (Menu_Sel == "Add")
            {
                f_pr_date_s.Value = DateTime.Now.AddDays(-1);
                f_pr_wtime.Text = "0.0"; //上班時數
                f_pr_atime.Text = "0.0";//加班時數
                f_va_code1.SelectedIndex = 1;//夜班津貼
                f_va_time1.Text = "0.0";//請假時數
                f_va_time2.Text = "0.0";//曠職時數
                f_pr_add1.Text = "0";//遲到
                f_pr_add2.Text = "0";//早退
            }
            if (Menu_Sel == "Qry")
            {
                f_pr_date.Text = null;
                f_va_code1.SelectedIndex = 0;
            }
        }

        
        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
            QueryDate(false);
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

        private bool isClose()
        {
            decimal Yy = System.Convert.ToDateTime(f_pr_date.Text).Year;
            decimal Mm = System.Convert.ToDateTime(f_pr_date.Text).Month;            
            if (Config.ClosePay(Yy, Mm, Dept) == true)
            {
                return true;
            }
            return false;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Qry" && string.IsNullOrEmpty(f_pr_date.Text) && string.IsNullOrEmpty(f_pr_date_end.Text))
            {
                Config.Show("請輸入日期查詢區間");
                f_pr_date.Focus();
                f_pr_date.Select();
                return;
            }

            if (Menu_Sel == "Add")
            {
                if (isClose() == true)
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
                QueryDate(false);
            }

            if (Menu_Sel == "Upd")
            {
                if (isClose() == true)
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
                if (isClose() == true)
                {
                    Config.Show("此薪資料已關帳，無法異動。");
                    return;
                }
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
            if (prt030D.Get(f_pr_date.Text, f_pr_no.Text) != null)
            {
                Config.Show("已有此筆資料");
                f_pr_date_s.Focus();
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
            var p_prt030D = new prt030D();
            p_prt030D.Pr_company = Dept;//公司
            p_prt030D.Pr_dept = Dept;//廠部
            p_prt030D.Pr_cdept = f_pr_cdept.Text;//部門代碼
            p_prt030D.Pr_date = f_pr_date_s.Value.ToString("yyyy/MM/dd");//日期
            p_prt030D.Pr_no = f_pr_no.Text;//工號
            p_prt030D.Va_code3 = f_va_code3.SelectedValue.ToString();//班別
            p_prt030D.Pr_wtime = string.IsNullOrEmpty(f_pr_wtime.Text) ? 0 : System.Convert.ToDecimal(f_pr_wtime.Text);//上班時數
            p_prt030D.Pr_atime = string.IsNullOrEmpty(f_pr_atime.Text) ? 0 : System.Convert.ToDecimal(f_pr_atime.Text);//加班時數
            p_prt030D.Va_code1 = f_va_code1.SelectedValue.ToString();//夜班津貼
            p_prt030D.Va_time1 = string.IsNullOrEmpty(f_va_time1.Text) ? 0 : System.Convert.ToDecimal(f_va_time1.Text);//請假時數
            p_prt030D.Va_time2 = string.IsNullOrEmpty(f_va_time2.Text) ? 0 : System.Convert.ToDecimal(f_va_time2.Text);//曠職時數
            p_prt030D.Pr_add1 = string.IsNullOrEmpty(f_pr_add1.Text) ? 0 : System.Convert.ToInt32(f_pr_add1.Text);//遲到
            p_prt030D.Pr_add2 = string.IsNullOrEmpty(f_pr_add2.Text) ? 0 : System.Convert.ToInt32(f_pr_add2.Text);//早退
            p_prt030D.Status_code = "N";//狀態
            return p_prt030D.Insert();
        }


        private string f_Update_1()
        {   
            var p_prt030D = new prt030D();            
            p_prt030D.Pr_dept = Dept;//廠部
            p_prt030D.Pr_cdept = f_pr_cdept.Text;//部門代碼
            p_prt030D.Pr_date = f_pr_date_s.Value.ToString("yyyy/MM/dd");//日期
            p_prt030D.Pr_no = f_pr_no.Text;//工號
            p_prt030D.Va_code3 = "1";//班別-S 廠用不到
            p_prt030D.Pr_wtime = string.IsNullOrEmpty(f_pr_wtime.Text) ? 0 : System.Convert.ToDecimal(f_pr_wtime.Text);//上班時數
            p_prt030D.Pr_atime = string.IsNullOrEmpty(f_pr_atime.Text) ? 0 : System.Convert.ToDecimal(f_pr_atime.Text);//加班時數
            p_prt030D.Va_code1 = f_va_code1.SelectedValue.ToString();//夜班津貼
            p_prt030D.Va_time1 = string.IsNullOrEmpty(f_va_time1.Text) ? 0 : System.Convert.ToDecimal(f_va_time1.Text);//請假時數
            p_prt030D.Va_time2 = string.IsNullOrEmpty(f_va_time2.Text) ? 0 : System.Convert.ToDecimal(f_va_time2.Text);//曠職時數
            p_prt030D.Pr_add1 = string.IsNullOrEmpty(f_pr_add1.Text) ? 0 : System.Convert.ToInt32(f_pr_add1.Text);//遲到
            p_prt030D.Pr_add2 = string.IsNullOrEmpty(f_pr_add2.Text) ? 0 : System.Convert.ToInt32(f_pr_add2.Text);//早退
            p_prt030D.Status_code = "N";//狀態
            return p_prt030D.Update(p_prt030D.Pr_date, p_prt030D.Pr_no);
        }

        private string f_Delete_1()
        {
            var p_prt030D = new prt030D();
            return p_prt030D.Delete(f_pr_date.Text, f_pr_no.Text);
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            Col_Vol();
            QueryDate(true);
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt030D.ToDoListEndDate(f_pr_dept.SelectedValue.ToString(), f_pr_date.Text, f_pr_date_end.Text, f_pr_no.Text).ToList();            
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
                f_pr_dept.SelectedValue = LS1[idx].Pr_dept;
                f_pr_cdept.Text = LS1[idx].Pr_cdept;
                f_pr_no.Text = LS1[idx].Pr_no;

                Find_p(LS1[idx].Pr_no);
                f_pr_date.Text =  DateTime.Parse(LS1[idx].Pr_date).ToString("yyyy/MM/dd");
                f_pr_date_s.Value = DateTime.Parse(LS1[idx].Pr_date);//日期
                f_pr_wtime.Text = LS1[idx].Pr_wtime.ToString();//上班時數
                f_pr_atime.Text = LS1[idx].Pr_atime.ToString();//加班時數
                f_va_code1.SelectedValue = LS1[idx].Va_code1;//夜班津貼
                f_va_code3.SelectedValue = LS1[idx].Va_code3;//班別
                f_va_time1.Text = LS1[idx].Va_time1.ToString();//請假時數
                f_va_time2.Text = LS1[idx].Va_time2.ToString();//曠職時數
                f_pr_add1.Text = LS1[idx].Pr_add1.ToString();//遲到
                f_pr_add2.Text = LS1[idx].Pr_add2.ToString();//早退
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
                f_pr_wtime.Focus();
            }
            else
            {
                Config.Show("請先查詢");
            }
        }

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
           // pri019w fm = new pri019w(Dept, null, f_pr_date.Text);//開視窗資料
            pri019w fm = new pri019w("I", f_pr_dept.SelectedValue.ToString());//開視窗資料;找在職I；離職是L
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                //Find_p(f_pr_no.Text);
                Find_p_Add(f_pr_no.Text);
            }
            if (Menu_Sel == "Add")
                f_pr_wtime.Focus();
        }

        //private void code_dearch_bt_Click(object sender, EventArgs e)
        //{
        //    pri019w fm = new pri019w(Dept, null, f_pr_date.Text);//開視窗資料
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_pr_no.Text = fm.Code as string;
        //        f_pr_name.Text = fm.Code_desc as string;
        //        //找相關資料顯示出來
        //        //Find_p(f_pr_no.Text);
        //        Find_p_Add(f_pr_no.Text);
        //    }
        //    if (Menu_Sel == "Add")
        //        f_pr_wtime.Focus();
        //}

        private void Find_p(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            if (p_prt016 == null)
            {
                Config.Show(string.Format("工號{0}\n人事主檔無此資料", Pr_no));
            }
            f_pr_name.Text = prt016.Get(Pr_no) == null ? "" : prt016.Get(Pr_no).Pr_name;            
            f_pr_cdept_name.Text = prt001.Get(f_pr_cdept.Text) == null ? "" : prt001.Get(f_pr_cdept.Text).Department_name_new;
        }

        private void Find_p_Add(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_pr_no.Text = p_prt016.Pr_no;
            f_pr_name.Text = p_prt016.Pr_name;            
            f_pr_dept.SelectedValue = p_prt016.Pr_dept;
            f_pr_cdept.Text = p_prt016.Pr_cdept;
            f_pr_cdept_name.Text = prt001.Get(f_pr_cdept.Text) == null ? "" : prt001.Get(f_pr_cdept.Text).Department_name_new;
        }

        private void f_pr_date_ValueChanged(object sender, EventArgs e)
        {
            //if (f_pr_date_s.Value >= DateTime.Now)
            //{
            //    Config.Show("日期不可大於今天");
            //    f_pr_date_s.Value = DateTime.Now.AddDays(-1);
            //}
            f_pr_date.Text = f_pr_date_s.Value.ToString("yyyy/MM/dd");
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

       

        private void f_va_code1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_va_code1.SelectedIndex == 0)
                    f_va_code1.SelectedIndex = 1;
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

        private void isInt(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 48 || (byte)e.KeyChar > 57)//若小於0或大於9 
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true; //不可輸;鎖起來
                }
            }

        }

        private void f_pr_date_s_end_CloseUp(object sender, EventArgs e)
        {
            f_pr_date_end.Text = f_pr_date_s_end.Value.ToString("yyyy/MM/dd");
        }

        private void f_pr_date_s_end_ValueChanged(object sender, EventArgs e)
        {
            f_pr_date_end.Text = f_pr_date_s_end.Value.ToString("yyyy/MM/dd");
        }

        private void QueryDate(bool ss)
        {
            f_pr_date_end.Visible = ss;
            f_pr_date_s_end.Visible = ss;
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

        private void pri035_KeyDown(object sender, KeyEventArgs e)
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

        private void f_va_code3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                if (f_va_code3.SelectedIndex == 0)
                    f_va_code3.SelectedIndex = 1;
            }
        }

        

    }
}
