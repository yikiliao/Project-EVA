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
    public partial class pri110 : Form
    {   
        string Menu_Sel;

        string Comp = Login.DEPT;
        string Dept = Login.DEPT;
        string Prgid = "pri042";
        string SType = "prt035D";        
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        public pri110()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            D_YY();//下拉選單-年
            lb_msg.Text = "";
            
            label4.ForeColor = Color.Blue;//字體顏色
            label4.Text = "年終獎金轉檔依據 ［薪資設定:pri040］......\n［基本薪＋職務津貼＋技術津貼＋工作津貼＋主管津貼］\n為計算基準";
            //轉檔進度
            processbar(false);
            //---------
        }
                                        
        

        private void D_YY()
        {
            f_yy.DataSource = prt035D.ToDoList_YY().ToList();
            f_yy.DisplayMember = "yy";
            f_yy.ValueMember = "yy";            
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

        private void menu_query_Click(object sender, EventArgs e)
        {            
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            f_dept.Text = Dept;
            f_dept_name.Text = sst011.Get(Login.DEPT) == null ? "" : sst011.Get(Login.DEPT).Company_shname;
            f_dept.Enabled = false;
            f_dept_name.Enabled = false;
            f_cdept.Enabled = false;
            f_pr_no.Enabled = false;
            
            //-------
            f_bonus_base.Value = 1M;
            f_bonus_base.Select(0, 8);
            f_bonus_base.Focus();
            dataGridView1.Visible = false;

        }

        private void confirm_Click(object sender, EventArgs e)
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            decimal Mm = 88;
            string Dept = f_dept.Text;
            string Cdept = f_cdept.Text;
            string Pr_no = f_pr_no.Text.Trim();

            if (Config.ClosePay(Yy, Mm, Dept) == true)
            {
                Config.Show("此年度資料已關帳，無法異動。");
                return;
            }

            if (Menu_Sel == "Qry")
            {
                var Err_Cnt = 0;
                if (f_bonus_base.Value == 0)
                {
                    Config.Show("年度基準基礎參數為0");
                    f_bonus_base.Focus();
                    f_bonus_base.Select();
                    return;
                }

                if (Config.Message("已轉入資料將會清除，是否開始轉年終獎金? ") == "Y")
                {
                    //轉檔進度
                    if (progressBar1.Visible == false)
                        processbar(true);

                    if (prt035D.ToDoList(Yy, Dept, Cdept, Pr_no).Where(a => a.Tot > 0).Count() == 0)
                    {
                        Config.Message("無考核基數資料,請到 年終獎金考核基數作業 維護");
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

                    Pay_Trn(Yy, Dept, Cdept, Pr_no);//轉年終獎金作業處理  
                    this.Cursor = Cursors.Default;//還原預設
                    Config.Show("轉檔薪資主檔完成");
                    lb_msg.Text = "";
                    //把進度不顯示
                    processbar(false);

                    Err_Cnt = prt032.ToDoList(Dept).Where(m => m.Yy == Yy && m.Mm == 0).Count();
                    if (Err_Cnt > 0)
                    {
                        Config.Show(String.Format("有{0}筆異常資料", Err_Cnt));
                        dataGridView1.Visible = true;
                        bindingSource1.Clear();
                        bindingSource1.DataSource = prt032.ToDoList(Dept).Where(m => m.Yy == Yy && m.Mm == 0).ToList();
                    }
                    else
                    {
                        Config.Show("無異常資料");
                    }
                    lb_msg.ForeColor = Org_Color;
                    cancel_Click(sender, e);
                }
            }
        }
                       
                

        private void Pay_Trn(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            new prt032().Delete(Dept, (Int32)Yy, 0);

            progressBar1.Maximum = prt035D.ToDoList(Yy, Dept, Cdept, Pr_no).Where(a => a.Tot > 0).Count();
            foreach (var i in prt035D.ToDoList(Yy, Dept, Cdept, Pr_no).Where(a => a.Tot > 0))//當年有考核基數的人
            {
                if (prt016.Get(i.Pr_no) == null) //人事主檔
                {
                    //寫入稽核檔
                    Ins_Err(i.Pr_no, "執行pri110程式，人事主檔［程式編號:pri019］沒資料");
                    continue;
                }
                int Last_seq = prt021.Get_Last_Seq_no(Pr_no);
                if (prt021.Get(i.Pr_no, Last_seq) == null)
                {
                    //寫入稽核檔
                    Ins_Err(i.Pr_no, "執行pri110程式，薪資參數［程式編號:pri029］沒資料");
                    continue;
                }

                var p_prt036D = new prt036D();
                p_prt036D.Delete(i.Yy, i.Dept, i.Cdept, i.Pr_no);//刪除資料               

                decimal Base_v = f_bonus_base.Value;
                p_prt036D = prt036D.Calcute_Bonus(i.Yy, i.Dept, i.Cdept, i.Pr_no, Base_v); //計算年終獎金
                p_prt036D.Add_user = Home.Id;
                if (p_prt036D.Insert() == "新增失敗")
                {
                    //寫入稽核檔
                    Ins_Err(i.Pr_no, "執行pri110程式，轉年終獎金［程式編號:pri110］失敗");
                    continue;
                }
                //-------
                progressBar1.Value += progressBar1.Step;
            }
        }



        private void Ins_Err(string Pr_no, string Memo)
        {
            var p_prt032 = new prt032();
            p_prt032.Dept = Dept;
            p_prt032.Pr_no = Pr_no;
            p_prt032.Pr_name = prt016.Get(Pr_no) == null ? "" : prt016.Get(Pr_no).Pr_name;
            p_prt032.Yy = (Int32)f_yy.SelectedValue;
            p_prt032.Mm = 88;
            p_prt032.Memo = Memo;
            p_prt032.Prgid = Prgid;
            p_prt032.Insert();
        }



        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            var Cdept = f_cdept.Text;
                        
            wPrno fm = new wPrno(Yy, Dept, Cdept, SType);
            fm.LS = LPrno;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                LPrno = fm.LS;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            var Yy = System.Convert.ToDecimal(f_yy.SelectedValue);

            wCdept fm = new wCdept(Yy, Dept, SType);//部門
            fm.LS = LCdept;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_cdept.Text = fm.Code as string;
                LCdept = fm.LS;
            }
            init_prno();
        }

        private void init_prno()
        {
            f_pr_no.Text = string.Empty;
            LPrno.Clear();
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

        private void pri042_KeyDown(object sender, KeyEventArgs e)
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

        private void processbar(bool rs)
        {
            lb_process.Visible = rs;
            progressBar1.Value = 0;
            progressBar1.Visible = rs;
        }

    }
}
