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
    public partial class pri100 : Form
    {   
        string Menu_Sel;
        string Dept = Login.DEPT;                
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        public pri100()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);            
            D_YY();//下拉選單-年            
            lb_msg.Text = "";

            //轉檔進度
            processbar(false);            
            //---------
        }
                                        
        

        private void D_YY()
        {
            ArrayList data = new ArrayList();
            int pyy = DateTime.Now.AddYears(-1).Year;
            int nyy = DateTime.Now.Year;
            data.Add(new DictionaryEntry(string.Format("{0}年", pyy), pyy));
            data.Add(new DictionaryEntry(string.Format("{0}年", nyy), nyy));
            f_yy.DisplayMember = "Key";
            f_yy.ValueMember = "Value";
            f_yy.DataSource = data;
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

        


        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);            
            f_dept.Text = Dept;
            f_dept_name.Text = sst011.Get() == null ? "" : sst011.Get().Dept_name;
            f_dept.Enabled = false;
            f_dept_name.Enabled = false;
            f_sdate.Enabled = false;
               
        }
                
        private void confirm_Click(object sender, EventArgs e)
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            decimal Mm = 77;
            string Dept = f_dept.Text;
            string Sdate = f_sdate.Text;
            

            if (Config.ClosePay(Yy, Mm, Dept) == true)
            {
                Config.Show("此年度資料已關帳，無法異動。");
                return;
            }
            if (string.IsNullOrEmpty(f_sdate.Text))
            {
                Config.Show("請選擇到職日");
                f_sdate_s.Focus();
                f_sdate_s.Select();                
                return;
            }

            if (Config.Message(string.Format("將會清除{0}年 {1}廠，考核設定、年終獎金、計稅等相關資料，是否確認？", f_yy.SelectedValue.ToString(), f_dept.Text)) == "N") return;

            if (Menu_Sel == "Qry")
            {  
                if (Config.Message("是否開設定?") == "Y")
                {
                    //轉檔進度
                    if (progressBar1.Visible == false)
                        processbar(true);

                    confirm.Enabled = false;
                    cancel.Enabled = false;

                    var Org_Color = lb_msg.ForeColor;
                    lb_msg.ForeColor = Color.Blue;
                    lb_msg.Text = "資料處理中...請稍候";

                    System.Threading.Thread.Sleep(1000);//停1秒

                    this.Cursor = Cursors.WaitCursor;//漏斗指標

                    Pay_Trn(Yy, Dept, Sdate);//設定 作業處理  

                    this.Cursor = Cursors.Default;//還原預設
                    Config.Show("設定完成");
                    lb_msg.Text = "";
                    //把進度不顯示
                    processbar(false);                    
                    lb_msg.ForeColor = Org_Color;
                    cancel_Click(sender, e);
                }
            }
        }

        private void Pay_Trn(decimal Yy, string Dept, string Sdate)
        {           
            //刪除已經設定資料
            new prt032().Delete(Dept, (Int32)Yy, 0);//錯誤記錄檔
            new prt035L().Delete(Yy, Dept); //考核基數
            new prt036L().Delete(Yy, Dept); //年終獎金
            new prt037L().Delete(Yy, Dept); //所得稅
            new prt034().Delete(Yy, 77, Dept); //解除 考核基數 關帳
            new prt034().Delete(Yy, 88, Dept); //解除 年終獎金 關帳
            new prt034().Delete(Yy, 99, Dept); //解除  所得稅 關帳

            //資料設定
            var _p = prt016.ToDoListPrno3(Dept, string.Empty, string.Empty, Sdate);
            progressBar1.Maximum = _p.Count(); //進度bar
            foreach (var i in _p)//當年有年終獎金的人
            {
                prt035L a_prt035L = new prt035L();
                a_prt035L.Yy = Yy;
                a_prt035L.Dept = Dept;
                a_prt035L.Cdept = i.Pr_cdept;
                a_prt035L.Pr_no = i.Pr_no;
                a_prt035L.A_leader = 0.0000M;
                a_prt035L.B_leader = 0.0000M;
                a_prt035L.C_leader = 0.0000M;
                a_prt035L.D_leader = 0.0000M;
                a_prt035L.E_leader = 0.0000M;
                a_prt035L.Tot = 0.0000M;
                a_prt035L.Memo = string.Empty;
                a_prt035L.Add_user = Home.Id;
                a_prt035L.Insert();
                progressBar1.Value += progressBar1.Step;
            }            
        }
        
        
        
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
            //查詢(F3)
            if (e.KeyCode == Keys.F3)
            {
                menu_query_Click(sender, e);
            }
            //確認(Escape)
            if (e.KeyCode == Keys.Escape)
            {
                confirm_Click(sender, e);
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
        }

        private void processbar(bool rs)
        {
            lb_process.Visible = rs;
            progressBar1.Value = 0;
            progressBar1.Visible = rs;
        }

        private void f_sdate_s_ValueChanged(object sender, EventArgs e)
        {
            f_sdate.Text = f_sdate_s.Value.ToString("yyyy/MM/dd");
        }

                       

    }
}
