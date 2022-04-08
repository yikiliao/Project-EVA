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
    public partial class pri041 : Form
    {   
        string Menu_Sel;
        
        const string Comp = "6";
        const string Dept = "L";
        const string Prgid = "pri041";
        string DataRang;//處理廠部範圍  

        public pri041()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);           
            DataRang = sst901.Get(Home.Id).Rang;
            D_YY();//下拉選單-年
            D_MM();//下拉選單-月
            Choice_Sel();//挑年月
            lb_msg.Text = "";
        }
                                        
        private void Choice_Sel()
        {
            int smm =  DateTime.Now.AddMonths(-1).Month;//上一月
            if (smm == 12)
            {
                //去年
                f_yy.SelectedIndex = 1;
            }
            else
            {
                //當年
                f_yy.SelectedIndex = 0;
            }
            f_mm.SelectedIndex = smm - 1;
        }

        private void D_YY()
        {
            int NYY = DateTime.Now.Year;
            int PYY = NYY - 1;
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(NYY.ToString(), NYY));
            data.Add(new DictionaryEntry(PYY.ToString(), PYY));
            f_yy.DisplayMember = "Key";
            f_yy.ValueMember = "Value";
            f_yy.DataSource = data;
        }

        private void D_MM()
        {   
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("一月", 1));
            data.Add(new DictionaryEntry("二月", 2));
            data.Add(new DictionaryEntry("三月", 3));
            data.Add(new DictionaryEntry("四月", 4));
            data.Add(new DictionaryEntry("五月", 5));
            data.Add(new DictionaryEntry("六月", 6));
            data.Add(new DictionaryEntry("七月", 7));
            data.Add(new DictionaryEntry("八月", 8));
            data.Add(new DictionaryEntry("九月", 9));
            data.Add(new DictionaryEntry("十月", 10));
            data.Add(new DictionaryEntry("十一月", 11));
            data.Add(new DictionaryEntry("十二月", 12));
            f_mm.DisplayMember = "Key";
            f_mm.ValueMember = "Value";
            f_mm.DataSource = data;
        }


        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        
        private void cancel_Click(object sender, EventArgs e)
        {  
            Menu_Sel = "";
            InitColumn(this);
            //lb_msg.Text = "";
        }
                

        //所有欄位解除並清空
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                if (a is Panel) SetColumn(a);
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
                if (c is Panel) InitColumn(c);
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
                if (c is Panel) InitMotherboard(c);
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
                if (a is Panel) SetMotherboard(a);
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

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            Choice_Sel();//挑年月
            f_dept.Text = Dept;
            f_dept_name.Text = sst011.Get(Login.DEPT) == null ? "" : sst011.Get(Login.DEPT).Company_shname;
            f_dept.Enabled = false;
            f_dept_name.Enabled = false;
            f_cdept.Enabled = false;
            f_cdept_name.Enabled = false;
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Qry")
            {
                Int32 _yy = Convert.ToInt32(f_yy.SelectedValue);//所選-年
                Int32 _mm = Convert.ToInt32(f_mm.SelectedValue);//所選-月
                Int32 Err_Cnt = 0;//轉檔錯誤筆數

                string Pr_no = f_pr_no.Text.Trim();


                if (Config.Message("是否開始轉薪資? ") == "Y")
                {
                    //轉全部
                    if (string.IsNullOrEmpty(Pr_no))
                    {
                        if (prt030L.ToDoListByGroup(Dept, _yy, _mm).Count() == 0)
                        {
                            Config.Message("無出勤資料,請用薪資維護作業");
                            menu_query_Click(sender, e);
                            return;
                        }

                        confirm.Enabled = false;
                        cancel.Enabled = false;

                        var Org_Color = lb_msg.ForeColor;
                        lb_msg.ForeColor = Color.Blue;
                        lb_msg.Text = "資料處理中...請稍候";

                        System.Threading.Thread.Sleep(1000);//停1秒

                        this.Cursor = Cursors.WaitCursor;//漏斗指標

                        Pay_Trn(Dept, _yy, _mm, "", f_cdept.Text);//轉新資作業處理                       
                        this.Cursor = Cursors.Default;//還原預設
                        Config.Show("轉檔薪資主檔完成");
                        lb_msg.Text = "";
                        Err_Cnt = prt032.ToDoList(Dept).Where(m => m.Yy == _yy && m.Mm == _mm).Count();
                        if (Err_Cnt > 0)
                        {
                            string Err = String.Format("有{0}筆異常資料", Err_Cnt);
                            Config.Show(Err);
                        }
                        else
                        {
                            Config.Show("無異常資料");
                        }
                        lb_msg.ForeColor = Org_Color;
                    }
                    else //轉個人
                    {
                        if (prt030L.ToDoListByGroup(Dept, _yy, _mm, Pr_no).Count() == 0)
                        {
                            Config.Message(string.Format("工號{0} 無出勤資料,請用薪資維護作業", Pr_no));
                            menu_query_Click(sender, e);
                            return;
                        }
                        confirm.Enabled = false;
                        cancel.Enabled = false;

                        var Org_Color = lb_msg.ForeColor;
                        lb_msg.ForeColor = Color.Blue;
                        lb_msg.Text = "資料處理中...請稍候";

                        System.Threading.Thread.Sleep(1000);//停1秒

                        this.Cursor = Cursors.WaitCursor;//漏斗指標
                        Pay_Trn(Dept, _yy, _mm, Pr_no, f_cdept.Text);//轉新資作業處理                        
                        this.Cursor = Cursors.Default;//還原預設
                        Config.Show("轉檔薪資主檔完成");
                        lb_msg.Text = "";
                        Err_Cnt = prt032.ToDoList(Dept).Where(m => m.Yy == _yy && m.Mm == _mm).Count();
                        if (Err_Cnt > 0)
                        {
                            string Err = String.Format("有{0}筆異常資料", Err_Cnt);
                            Config.Show(Err);
                        }
                        else
                        {
                            Config.Show("無異常資料");
                        }
                        lb_msg.ForeColor = Org_Color;
                    }
                }
                cancel_Click(sender, e);
            }
        }
                

        private void Del_prt032()
        {
            var p_prt032 = new prt032();
            p_prt032.Delete(f_dept.Text, (Int32)f_yy.SelectedValue, (Int32)f_mm.SelectedValue);
        }

        private void Pay_Trn(string Dept, Int32 Yy, Int32 Mm, string Pr_no, string Cdept)
        {
            const decimal seq_no = 1;//工號的序號固定1
            decimal amt1 = 0;
            decimal amt2 = 0;
            decimal amt3 = 0;
            decimal amt4 = 0;
            decimal amt5 = 0;
            decimal amt6 = 0;
            decimal amt7 = 0;
            Del_prt032();//刪錯誤記錄檔
            if (!string.IsNullOrEmpty(Pr_no))//算個人
            {
                if (prt016.Get(Pr_no) == null) //人事主檔
                {
                    Ins_Err(Pr_no, "人事主檔沒資料(pri019)");
                    return;
                }
                int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
                if (prt021.Get(Pr_no, Last_seq) == null)
                {
                    Ins_Err(Pr_no, "薪資設定沒資料(pri029)");
                    return;
                }
                if (prt030L.ToDoListByGroup(Dept, Yy, Mm, Pr_no, Cdept).Count() > 0)
                {
                    //出勤時數(平日)
                    amt1 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "1").Sum(m => m.Pr_wtime);

                    //請假時數(扣薪)va_time1
                    amt2 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Va_time1);

                    //請假時數(不扣薪)va_time2
                    amt3 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Va_time2);

                    //曠職時數.pr_ntime
                    amt4 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Sum(m => m.Pr_ntime);

                    //tot_atime1平日加班
                    amt5 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "1").Sum(m => m.Pr_atime);

                    //tot_atime2假日加班
                    amt6 = prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "2").Sum(m => m.Pr_wtime) +
                                        prt030L.ToDoList(Dept, Yy, Mm, Pr_no).Where(m => m.Va_code3 == "2").Sum(m => m.Pr_atime);

                    //總加班時數
                    amt7 = amt5 + amt6;
                }
                var p_prt031L = new prt031L();
                p_prt031L.Delete(Yy, Mm, Pr_no, seq_no);//刪除資料
                p_prt031L = prt031L.Pay_TrnSingle(Dept, Yy, Mm, Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7);
                p_prt031L.Add_user = Home.Id;
                if (p_prt031L.Insert() == "新增失敗")
                {
                    //寫入轉新資稽核檔
                    Ins_Err(Pr_no, "新增入薪資檔錯誤(pri041)");
                    return;
                }
            }
            else //算全部
            {
                foreach (var i in prt030L.ToDoListByGroup(Dept, Yy, Mm, "", Cdept))//當月有輸入出勤資料的人
                {
                    if (prt016.Get(i.Pr_no) == null) //人事主檔
                    {
                        Ins_Err(i.Pr_no, "人事主檔沒資料(pri019)");
                        continue;
                    }
                    int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
                    if (prt021.Get(i.Pr_no, Last_seq) == null)
                    {
                        Ins_Err(i.Pr_no, "薪資設定沒資料(pri029)");
                        continue;
                    }
                    //-------
                    if (prt030L.ToDoListByGroup(Dept, Yy, Mm, i.Pr_no, Cdept).Count() > 0)
                    {
                        amt1 = 0;
                        amt2 = 0;
                        amt3 = 0;
                        amt4 = 0;
                        amt5 = 0;
                        amt6 = 0;
                        amt7 = 0;
                        //出勤時數(平日)
                        amt1 = prt030L.ToDoList(Dept, Yy, Mm, i.Pr_no).Where(m => m.Va_code3 == "1").Sum(m => m.Pr_wtime);

                        //請假時數(扣薪)va_time1
                        amt2 = prt030L.ToDoList(Dept, Yy, Mm, i.Pr_no).Sum(m => m.Va_time1);

                        //請假時數(不扣薪)va_time2
                        amt3 = prt030L.ToDoList(Dept, Yy, Mm, i.Pr_no).Sum(m => m.Va_time2);

                        //曠職時數.pr_ntime
                        amt4 = prt030L.ToDoList(Dept, Yy, Mm, i.Pr_no).Sum(m => m.Pr_ntime);

                        //tot_atime1平日加班
                        amt5 = prt030L.ToDoList(Dept, Yy, Mm, i.Pr_no).Where(m => m.Va_code3 == "1").Sum(m => m.Pr_atime);

                        //tot_atime2假日加班
                        amt6 = prt030L.ToDoList(Dept, Yy, Mm, i.Pr_no).Where(m => m.Va_code3 == "2").Sum(m => m.Pr_wtime) +
                               prt030L.ToDoList(Dept, Yy, Mm, i.Pr_no).Where(m => m.Va_code3 == "2").Sum(m => m.Pr_atime);

                        //總加班時數
                        amt7 = amt5 + amt6;
                    }
                    var p_prt031L = new prt031L();
                    p_prt031L.Delete(Yy, Mm, i.Pr_no, seq_no);//刪除資料
                    p_prt031L = prt031L.Pay_TrnSingle(Dept, Yy, Mm, i.Pr_no, seq_no, amt1, amt2, amt3, amt4, amt5, amt6, amt7);
                    p_prt031L.Add_user = Home.Id;
                    if (p_prt031L.Insert() == "新增失敗")
                    {
                        //寫入轉新資稽核檔
                        Ins_Err(i.Pr_no, "新增入薪資檔錯誤(pri041)");
                        return;
                    }
                    //-------
                }
            }

        }
                

        private void Ins_Err(string Pr_no, string Memo)
        {
            var p_prt032 = new prt032();
            p_prt032.Dept = Dept;
            p_prt032.Pr_no = Pr_no;
            p_prt032.Pr_name = prt016.Get(Pr_no) == null ? "" : prt016.Get(Pr_no).Pr_name;
            p_prt032.Yy = (Int32)f_yy.SelectedValue;
            p_prt032.Mm = (Int32)f_mm.SelectedValue;
            p_prt032.Memo = Memo;
            p_prt032.Prgid = Prgid;
            p_prt032.Insert();
        }



        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            f_pr_no.Text = "";
            f_pr_name.Text = "";
            pri019w fm = new pri019w(f_dept.Text, (Int32)f_yy.SelectedValue, (Int32)f_mm.SelectedValue, "", f_cdept.Text);//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f_cdept.Text = "";
            f_cdept_name.Text = "";
            f_pr_no.Text = "";
            f_pr_name.Text = "";
            pri001w fm = new pri001w(f_dept.Text, (Int32)f_yy.SelectedValue, (Int32)f_mm.SelectedValue);//部門            
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_cdept.Text = fm.Code as string;
                f_cdept_name.Text = fm.Code_desc as string;
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

        private void pri041_KeyDown(object sender, KeyEventArgs e)
        {
            //查詢(Control+Q)
            if (e.Control && e.KeyCode == Keys.Q)
            {
                menu_query_Click(sender, e);
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
