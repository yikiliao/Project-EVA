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
    public partial class pri036 : Form
    {
        int i = 0;
        static List<prt030L> LS1 = new List<prt030L>();
        static List<prt030L> AR1 = new List<prt030L>();
        string Menu_Sel;
        string Dept = Login.DEPT;
        DateTime tmp_date;//出勤日暫存

        public string rCdept;//部門
        public string rBegdate;//離職日(起)
        public string rEnddate;//離職日(迄)
        public bool rOK = false;//按下確認鍵
        public pri036()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            Gridview_D1();//班別
            Gridview_D2();//下拉選單-遲到
            Gridview_D3();//下拉選單-早退
            Gridview_D4();//下拉選單-輪班津貼
            Gridview_D5();//下拉選單-夜餐補助
            D_Cdpet();//部門
            label1.Text = "確認 勾選 表示存入";
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

        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList().ToList();
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
        }
        private void Gridview_D1()
        {

            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("1.平日", "1"));
            data.Add(new DictionaryEntry("2.假日", "2"));
            Va_code3.DisplayMember = "Key";
            Va_code3.ValueMember = "Value";
            Va_code3.DataSource = data;
        }

        private void Gridview_D2()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("N:準時", "N"));
            data.Add(new DictionaryEntry("A: 4-5 分鐘", "A"));
            data.Add(new DictionaryEntry("B:6-15 分鐘", "B"));
            data.Add(new DictionaryEntry("C:15分鐘以上", "C"));
            data.Add(new DictionaryEntry("D:一小時以上", "D"));
            va_code1.DisplayMember = "Key";
            va_code1.ValueMember = "Value";
            va_code1.DataSource = data;
        }

        private void Gridview_D3()
        {
            ArrayList data = new ArrayList();
            //data.Add(new DictionaryEntry("", ""));
            data.Add(new DictionaryEntry("N:準時", "N"));
            data.Add(new DictionaryEntry("A:早退", "A"));
            va_code2.DisplayMember = "Key";
            va_code2.ValueMember = "Value";
            va_code2.DataSource = data;
        }

        private void Gridview_D4()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("0", 0));
            data.Add(new DictionaryEntry("10", 10));
            pr_add1.DisplayMember = "Key";
            pr_add1.ValueMember = "Value";
            pr_add1.DataSource = data;
        }

        private void Gridview_D5()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("0", 0));
            data.Add(new DictionaryEntry("3", 3));
            pr_add2.DisplayMember = "Key";
            pr_add2.ValueMember = "Value";
            pr_add2.DataSource = data;
        }



        private void confirm_Click(object sender, EventArgs e)
        {   
            if (Menu_Sel == "Add")
            {
                decimal Yy = System.Convert.ToDateTime(f_pr_date.Text).Year;
                decimal Mm = System.Convert.ToDateTime(f_pr_date.Text).Month;
                if (Config.ClosePay(Yy, Mm, Dept) == true)
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
                        Config.Show(String.Format("{0}", f_Insert()));
                        dataGridView1.Rows.Clear();
                        //把出勤日存起來
                        tmp_date = Convert.ToDateTime(f_pr_date.Text);
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

            if (Menu_Sel == "Upd")
            {
                decimal Yy = System.Convert.ToDateTime(f_pr_date.Text).Year;
                decimal Mm = System.Convert.ToDateTime(f_pr_date.Text).Month;
                if (Config.ClosePay(Yy, Mm, Dept) == true)
                {
                    Config.Show("此薪資料已關帳，無法異動。");
                    return;
                }
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {   
                        Config.Show(String.Format("{0}", f_Update()));
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

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);
            }

            if (Menu_Sel == "Del")
            {
                decimal Yy = System.Convert.ToDateTime(f_pr_date.Text).Year;
                decimal Mm = System.Convert.ToDateTime(f_pr_date.Text).Month;
                if (Config.ClosePay(Yy, Mm, Dept) == true)
                {
                    Config.Show("此薪資料已關帳，無法異動。");
                    return;
                }
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {   
                        Config.Show(String.Format("{0}", f_Delete()));
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

        

        private bool f_Check()
        {
            if (f_pr_dept.Text == System.String.Empty)
            {
                Config.Show("廠部不可空白");
                f_pr_dept.Focus();
                return false;
            }

            //if (f_cdept.Text == string.Empty)
            //{
            //    Config.Show("部門代碼不可空白");
            //    f_cdept.Focus();
            //    return false;
            //}
            //else
            //{
            //    if (prt001.Get(f_cdept.Text) == null)
            //    {
            //        Config.Show("部門代碼錯誤");
            //        f_cdept.Focus();
            //        return false;
            //    }
            //}

            if (f_pr_date.Text == System.String.Empty)
            {
                Config.Show("出勤日期不可空白");
                f_pr_date.Focus();
                return false;
            }
            if (dataGridView1.RowCount == 0)
            {
                Config.Show("無明細資料可輸入");
                f_pr_date.Focus();
                return false;
            }
            return true;
        }



        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt030L.ToDoListGroup(Dept, rCdept, rBegdate, rEnddate).ToList();            
            if (LS1.Count() == 0)
            {
                MessageBox.Show("無符合資料");
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
                //Master 資料
                f_pr_dept.SelectedValue = LS1[idx].Pr_dept;                
                f_cdept.SelectedValue = LS1[idx].Pr_cdept;
                
                f_pr_date.Text = Convert.ToDateTime(LS1[idx].Pr_date).ToString("yyyy/MM/dd");
                f_pr_date_s.Value = Convert.ToDateTime(LS1[idx].Pr_date);
                f_add_date.Text = string.Empty;
                f_add_user.Text = string.Empty;
                f_mod_date.Text = string.Empty;
                f_mod_user.Text = string.Empty;                
                //抓名細資料
                bindingSource1.Clear();//清資料
                foreach (var i in prt030L.ToDoList(f_pr_dept.SelectedValue.ToString(),f_pr_date.Text,"").Where(m=>m.Pr_cdept==f_cdept.SelectedValue.ToString()))
                {
                    prt030L a_prt030L = new prt030L();
                    a_prt030L.Pr_no = i.Pr_no;
                    a_prt030L.Pr_name = prt016.Get(i.Pr_no) == null ? "" : prt016.Get(i.Pr_no).Pr_name;
                    a_prt030L.Va_code3 = i.Va_code3;
                    a_prt030L.Pr_wtime = i.Pr_wtime;
                    a_prt030L.Pr_atime = i.Pr_atime;
                    a_prt030L.Pr_add1 = i.Pr_add1;
                    a_prt030L.Pr_add2 = i.Pr_add2;
                    a_prt030L.Va_time1 = i.Va_time1;
                    a_prt030L.Va_time2 = i.Va_time2;
                    a_prt030L.Pr_ntime = i.Pr_ntime;
                    a_prt030L.Va_code1 = i.Va_code1;
                    a_prt030L.Va_code2 = i.Va_code2;
                    bindingSource1.Add(a_prt030L);
                }
                //把gridview 的ckeckbox 設成打勾
                GridView_check_f();
            }
        }

        
        private string f_Update()
        {   
            var p_prt030L = new prt030L();
            p_prt030L.Delete(f_pr_dept.SelectedValue.ToString(),f_cdept.SelectedValue.ToString(), f_pr_date.Text);
            f_Insert();
            return "修改成功";
        }

        private string f_Delete()
        {
            var p_prt030L = new prt030L();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                p_prt030L.Pr_no = dataGridView1.Rows[row.Index].Cells[1].Value.ToString();                
                p_prt030L.Delete(f_pr_date.Text, p_prt030L.Pr_no);
            }
            dataGridView1.Rows.Clear();
            return "刪除成功";
        }

        private string f_Insert()
        {
            var p_prt030L = new prt030L();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                p_prt030L.Pr_company = Dept;
                p_prt030L.Pr_dept = f_pr_dept.SelectedValue.ToString();
                p_prt030L.Pr_cdept = f_cdept.SelectedValue.ToString();
                p_prt030L.Pr_date = f_pr_date.Text;
                p_prt030L.Pr_no = dataGridView1.Rows[row.Index].Cells[1].Value.ToString();
                p_prt030L.Va_code3 = dataGridView1.Rows[row.Index].Cells[3].Value.ToString();
                p_prt030L.Pr_wtime = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[4].Value);
                p_prt030L.Pr_atime = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[5].Value);
                p_prt030L.Pr_add1 = Convert.ToInt32(dataGridView1.Rows[row.Index].Cells[6].Value);
                p_prt030L.Pr_add2 = Convert.ToInt32(dataGridView1.Rows[row.Index].Cells[7].Value);
                p_prt030L.Va_time1 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[8].Value);
                p_prt030L.Va_time2 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[9].Value);
                p_prt030L.Pr_ntime = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[10].Value);
                p_prt030L.Va_code1 = dataGridView1.Rows[row.Index].Cells[11].Value.ToString();
                p_prt030L.Va_code2 = dataGridView1.Rows[row.Index].Cells[12].Value.ToString();
                
                var isCheck = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                if (isCheck == "Y")
                {
                    p_prt030L.Delete(f_pr_date.Text, p_prt030L.Pr_no);                    
                    p_prt030L.Add_user = Home.Id;
                    p_prt030L.Insert();
                }
            }
            return "新增成功";
        }

        

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);//給初值
            Col_Disable();
            Col_vol();
            dataGridView1.Rows.Clear();
            dataGridView1.DataBindings.Clear();
            dataGridView1.ReadOnly = false;
            f_cdept.SelectedIndex = 0;
            f_cdept.Focus();
            f_pr_date.Enabled = true;
            f_cdept_SelectedIndexChanged(sender, e);
            bindingNavigator1.Enabled = false;
        }

        private void Col_Disable()
        {   
            f_pr_dept.Enabled = false;
            
            f_pr_date.Enabled = false;
            if (Menu_Sel == "Upd")
            {
                f_cdept.Enabled = false;
            }
        }

        private void Col_vol()
        {   
            f_pr_dept.SelectedValue = Dept;
            f_pr_date_s.Value = DateTime.Now.AddDays(-1);

            var Dday = tmp_date.ToString("yyyy/MM/dd");
            if (Dday != "0001/01/01")
            {
                f_pr_date_s.Value = tmp_date;
            }            
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_pr_date.Text != string.Empty)
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                Col_Disable();
                f_pr_date_s.Enabled = false;
                dataGridView1.ReadOnly = false;
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
        //    if ( f_cdept.SelectedValue.ToString() != "" && (Menu_Sel == "Qry"||Menu_Sel=="Upd"))
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        Col_Disable();
                
        //        f_pr_date_s.Enabled = false;
        //        dataGridView1.ReadOnly = false;
        //    }
        //    else
        //    {
        //        MessageBox.Show("請先查詢");
        //    }
        //}

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
            pri036Q fm = new pri036Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rCdept = fm.rCdept;//部門
                rBegdate = fm.rBegdate;//開始日期
                rEnddate = fm.rEnddate;//結束日期
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();
        }

        //private void menu_query_Click(object sender, EventArgs e)
        //{
        //    Menu_Sel = "Qry";
        //    InitColumn(this);
        //    SetColumn(this);
        //    dataGridView1.Rows.Clear();
        //    dataGridView1.DataBindings.Clear();
        //    dataGridView1.ReadOnly = true;
        //    f_pr_dept.SelectedValue = Dept;
        //    Col_Disable();
        //    f_cdept.Enabled = true;
        //    f_cdept.Text = string.Empty;
        //    f_cdept_name.Text = string.Empty;
        //    f_pr_date.Text = string.Empty;
        //}

        private void menu_next_Click(object sender, EventArgs e)
        {
            if (f_pr_date.Text != string.Empty)
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
                

        private void menu_previous_Click(object sender, EventArgs e)
        {
            if (f_pr_date.Text != string.Empty)
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

        private void mnu_exit_Click(object sender, EventArgs e)
        {            
            if (Config.Message("是否離開?")=="Y")
            Close();
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
                    bindingSource1.Clear();//清資料
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
        //    bindingSource1.Clear();//清資料
        //}

        private void menu_last_Click(object sender, EventArgs e)
        {
            if (f_pr_date.Text != string.Empty)
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

        private void menu_first_Click(object sender, EventArgs e)
        {
            if (f_pr_date.Text != string.Empty)
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

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
            base.OnKeyPress(e);
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
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Checked = false;
                    (c as RadioButton).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
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
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
            }
            bindingNavigator1.Enabled = true;
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
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Checked = false;
                    (a as RadioButton).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
            }
            f_add_date.Enabled = false;
            f_add_user.Enabled = false;
            f_mod_date.Enabled = false;
            f_mod_user.Enabled = false;
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
                }
                if (a is RadioButton)
                {
                    (a as RadioButton).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
            }
        }

        
        

        private void f_pr_date_s_ValueChanged(object sender, EventArgs e)
        {
            if (f_pr_date_s.Value > DateTime.Now)
            {
                Config.Show("出勤日期 > 系統日期 ");
                f_pr_date_s.Value = DateTime.Now.AddDays(-1);
            }
            f_pr_date.Text = f_pr_date_s.Value.ToString("yyyy/MM/dd");
            if (Menu_Sel == "Add")
            {
                button1_Click(sender, e);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (f_pr_date.Text == null || f_pr_date.Text == string.Empty) return;
            string p_code3="1";
            //找那天是否假日,假日記錄2,平常記錄1
            var _ho = prt008.ToDoList(f_pr_dept.SelectedValue.ToString(), Convert.ToDateTime(f_pr_date.Text).Year, f_cdept.SelectedValue.ToString(), f_pr_date.Text);
            if (_ho.Count()>0)
            {
                p_code3 = "2";
            }
            else
            {
                if ((int)DateTime.Now.DayOfWeek == 0 || (int)DateTime.Now.DayOfWeek == 6)
                    p_code3 = "2";
                else
                    p_code3 = "1";
            }

            var _p = prt016.ToDoListPrno2(f_pr_dept.SelectedValue.ToString(), f_cdept.SelectedValue.ToString(), f_pr_date.Text);
            bindingSource1.Clear();
            foreach (var i in _p.ToList())
            {
                prt030L a_prt030L = new prt030L();
                prt030L p_prt030L = new prt030L();
                p_prt030L = prt030L.Get(f_pr_date.Text, i.Pr_no);
                if (p_prt030L == null)
                {
                    a_prt030L.Pr_no = i.Pr_no;
                    a_prt030L.Pr_name = i.Pr_name;
                    a_prt030L.Va_code3 = p_code3;
                    a_prt030L.Pr_wtime = Convert.ToDecimal("8.0");
                    a_prt030L.Pr_atime = Convert.ToDecimal("0.0");
                    a_prt030L.Pr_add1 = 0;
                    a_prt030L.Pr_add2 = 0;
                    a_prt030L.Va_time1 = Convert.ToDecimal("0.0");
                    a_prt030L.Va_time2 = Convert.ToDecimal("0.0");
                    a_prt030L.Pr_ntime = Convert.ToDecimal("0.0");
                    a_prt030L.Va_code1 = "N";
                    a_prt030L.Va_code2 = "N";
                }
                else
                {
                    a_prt030L.Pr_no = i.Pr_no;
                    a_prt030L.Pr_name = i.Pr_name;
                    a_prt030L.Va_code3 = p_prt030L.Va_code3;
                    a_prt030L.Pr_wtime = p_prt030L.Pr_wtime;
                    a_prt030L.Pr_atime = p_prt030L.Pr_atime;
                    a_prt030L.Pr_add1 = p_prt030L.Pr_add1;
                    a_prt030L.Pr_add2 = p_prt030L.Pr_add2;
                    a_prt030L.Va_time1 = p_prt030L.Va_time1;
                    a_prt030L.Va_time2 = p_prt030L.Va_time2;
                    a_prt030L.Pr_ntime = p_prt030L.Pr_ntime;
                    a_prt030L.Va_code1 = p_prt030L.Va_code1;
                    a_prt030L.Va_code2 = p_prt030L.Va_code2;
                }
                bindingSource1.Add(a_prt030L);
            };
            //把gridview 的ckeckbox 設成打勾
            GridView_check_f();
        }

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_pr_date.Text != string.Empty)
            {
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
        //    if (f_cdept.SelectedValue.ToString() != "" && f_pr_date.Text !="" && (Menu_Sel == "Qry"||Menu_Sel=="Del"))
        //    {   
        //        Menu_Sel = "Del";
        //        InitMotherboard(this);
        //        confirm_Click(sender, e);
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}


        private void GridView_check_f()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = "Y";


                //抓BPM請假公差時數                
                decimal sYY = Convert.ToDateTime(f_pr_date.Text).Year;//年度
                string sPr_no = row.Cells[1].Value.ToString();//工號                                
                row.Cells[14].Value = prvacal.ToDoList(sYY, sPr_no, f_pr_date.Text, f_pr_dept.SelectedValue.ToString()).Where(m => m.Va_vaca == "B01").Sum(m => m.Va_sum_time);//公差時數
                row.Cells[15].Value = prvacal.ToDoList(sYY, sPr_no, f_pr_date.Text, f_pr_dept.SelectedValue.ToString()).Where(m => m.Va_vaca != "B01").Sum(m => m.Va_sum_time);//請假時數

                //抓BPM請假區間及說明                
                var tmp_Va_vaca = "";//放暫存假別
                var va_desc = ""; //假別說明
                DateTime Sd = new DateTime();//請假開始日暫存
                DateTime Ed = new DateTime();//請假結束日暫存
                var Sdt = "";
                var Edt = "";
                var cnt = 0;
                foreach (var item in prvacal.ToDoList(sYY, sPr_no, f_pr_date.Text, f_pr_dept.SelectedValue.ToString()))
                {
                    //請假區間
                    cnt = cnt + 1;
                    if (cnt == 1)
                    {
                        Sd = Convert.ToDateTime(item.Va_start_date);
                        Sdt = item.Va_start_date;
                    }

                    if (Sd > Convert.ToDateTime(item.Va_start_date))//找這一段期間最小
                        Sdt = item.Va_start_date;
                    if (Ed < Convert.ToDateTime(item.Va_end_date))//找這一段期間最大
                        Edt = item.Va_end_date;
                    Sd = Convert.ToDateTime(item.Va_start_date);
                    Ed = Convert.ToDateTime(item.Va_end_date);

                    //假別說明
                    if (item.Va_vaca == "B01") continue;
                    if (tmp_Va_vaca != item.Va_vaca)//有相同假別代碼只抓一個
                    {
                        va_desc += String.Format("{0}{1} ", item.Va_vaca, item.Va_vaca_name);
                    }
                    tmp_Va_vaca = item.Va_vaca;//放暫存
                }
                row.Cells[13].Value = string.IsNullOrEmpty(Sdt) ? "" : string.Format("{0}～{1}", Sdt.Replace("-", "/"), Edt.Replace("-", "/"));//請假區間
                row.Cells[16].Value = va_desc;//假別說明
            }
        }
                

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[6].Value == null)
                return;
            if ((int)dataGridView1.Rows[e.RowIndex].Cells[6].Value > 0)
            {                
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = 3;
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

        private void pri036_KeyDown(object sender, KeyEventArgs e)
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

        private void f_cdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                button1_Click(sender, e);
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

        private void pri036_Load(object sender, EventArgs e)
        {
            //數字靠右
            DataGrid_Right();
        }

        private void DataGrid_Right()
        {
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;            
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[14].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[15].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
               
    }
}
