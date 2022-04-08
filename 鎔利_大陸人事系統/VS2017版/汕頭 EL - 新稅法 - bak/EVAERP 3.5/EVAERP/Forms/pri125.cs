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
    public partial class pri125 : Form
    {   
        string Menu_Sel;
        string Dept = Login.DEPT;
        string SType = "prt036L";
        string DataRang;//處理廠部範圍  
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        public pri125()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);

            DataRang = sst901.Get(Home.Id).Rang;
            D_YY();//下拉選單-年            
            lb_msg.Text = "";

            //轉檔進度
            processbar(false);            
            //---------
        }
                                        
        

        private void D_YY()
        {            
            f_yy.DataSource = prt036L.ToDoList_YY().ToList();
            f_yy.DisplayMember = "yy";
            f_yy.ValueMember = "yy";
            f_yy.Text = DateTime.Now.Year.ToString();
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
                //Choice_Sel();//挑年月
                f_dept.Text = Dept;
                f_dept_name.Text = sst011.Get() == null ? "" : sst011.Get().Dept_name;
                f_dept.Enabled = false;
                f_dept_name.Enabled = false;
                f_cdept.Enabled = false;
                f_pr_no.Enabled = false;
        }

        //private void confirm_Click(object sender, EventArgs e)
        //{
        //    decimal C_Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
        //    decimal C_Mm = 99;
        //    string C_Dept = f_dept.Text;

        //    if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
        //    {
        //        Config.Show("此年度資料已關帳，無法異動。");
        //        return;
        //    }

        //    if (Config.Message(string.Format("{0}{1}{2}", "計稅基準將採用", C_Yy + 1, "年二月份薪資 應發金額 計算")) == "N") return;

        //    if (prt031L.ToDoList(C_Yy + 1, 2, string.Empty, null).Count() == 0)
        //    {
        //        Config.Show("此年度無二月份薪資，還無法計稅");
        //        return;
        //    }
        //    else
        //    {
        //        if (Menu_Sel == "Qry")
        //        {
        //            var Err_Cnt = 0;
        //            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
        //            string Dept = f_dept.Text;
        //            string Cdept = f_cdept.Text;
        //            string Pr_no = f_pr_no.Text.Trim();

        //            if (Config.Message("是否開始計算稅額?") == "Y")
        //            {
        //                //轉檔進度
        //                if (progressBar1.Visible == false)
        //                    processbar(true);

        //                if (prt036L.ToDoList(Yy, Dept, Cdept, Pr_no).Count() == 0)
        //                {
        //                    Config.Message("無年終獎金資料");
        //                    menu_query_Click(sender, e);
        //                    return;
        //                }

        //                confirm.Enabled = false;
        //                cancel.Enabled = false;

        //                var Org_Color = lb_msg.ForeColor;
        //                lb_msg.ForeColor = Color.Blue;
        //                lb_msg.Text = "資料處理中...請稍候";

        //                System.Threading.Thread.Sleep(1000);//停1秒

        //                this.Cursor = Cursors.WaitCursor;//漏斗指標

        //                Pay_Trn(Yy, Dept, Cdept, Pr_no);//年終獎金 計稅作業處理  

        //                this.Cursor = Cursors.Default;//還原預設
        //                Config.Show("年終獎金計稅完成");
        //                lb_msg.Text = "";
        //                //把進度不顯示
        //                processbar(false);

        //                Err_Cnt = prt032.ToDoList(Dept).Where(m => m.Yy == Yy && m.Mm == 99).Count();
        //                if (Err_Cnt > 0)
        //                {
        //                    string Err = String.Format("有{0}筆異常資料", Err_Cnt);
        //                    Config.Show(Err);
        //                }
        //                else
        //                {
        //                    Config.Show("無異常資料");
        //                }
        //                lb_msg.ForeColor = Org_Color;
        //                cancel_Click(sender, e);
        //            }
        //        }
        //    }
        //}


        private void confirm_Click(object sender, EventArgs e)
        {
            decimal C_Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            decimal C_Mm = 99;
            string C_Dept = f_dept.Text;

            if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
            {
                Config.Show("此年度資料已關帳，無法異動。");
                return;
            }


            if (Menu_Sel == "Qry")
            {
                    var Err_Cnt = 0;
                    decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
                    string Dept = f_dept.Text;
                    string Cdept = f_cdept.Text;
                    string Pr_no = f_pr_no.Text.Trim();

                    if (Config.Message("是否開始計算稅額?") == "Y")
                    {
                        //轉檔進度
                        if (progressBar1.Visible == false)
                            processbar(true);

                        if (prt036L.ToDoList(Yy, Dept, Cdept, Pr_no).Count() == 0)
                        {
                            Config.Message("無年終獎金資料");
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

                        Pay_Trn(Yy, Dept, Cdept, Pr_no);//年終獎金 計稅作業處理  

                        this.Cursor = Cursors.Default;//還原預設
                        Config.Show("年終獎金計稅完成");
                        lb_msg.Text = "";
                        //把進度不顯示
                        processbar(false);

                        Err_Cnt = prt032.ToDoList(Dept).Where(m => m.Yy == Yy && m.Mm == 99).Count();
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
                        cancel_Click(sender, e);
                    }
                }
            
        }

        //private void Pay_Trn(decimal Yy, string Dept, string Cdept, string Pr_no)
        //{            
        //    new prt032().Delete(Dept,(Int32)Yy, 99);//刪錯誤記錄檔
        //    progressBar1.Maximum = prt036L.ToDoList(Yy, Dept, Cdept, Pr_no).Count(); //進度bar
        //    foreach (var i in prt036L.ToDoList(Yy, Dept, Cdept, Pr_no))//當年有年終獎金的人
        //    {   
        //        //------
        //        prt031L p_prt031L = new prt031L(); //薪資記錄檔
        //        p_prt031L = prt031L.Get(i.Yy + 1, 2, i.Pr_no, 1);//找每年二月份薪資
        //        //扣除社保費
        //        decimal Base_Salary = p_prt031L.Amt_16 - p_prt031L.Amt_29 - p_prt031L.Amt_30 - p_prt031L.Amt_31 - p_prt031L.Amt_28;
                
        //        //依總獎金平均12月;再依 稅率級距表找稅率--                                                
        //        prt012 p_prt012 = new prt012();
        //        p_prt012 = prt012.Get(i.Dept, i.X_bonus / 12);

        //        //--刪除年終獎金稅率檔歷史資料
        //        prt037L p_prt037L = new prt037L();
        //        p_prt037L.Delete(i.Yy, i.Dept, i.Cdept, i.Pr_no);

        //        p_prt037L.Yy = i.Yy;
        //        p_prt037L.Dept = i.Dept;
        //        p_prt037L.Cdept = i.Cdept;
        //        p_prt037L.Pr_no = i.Pr_no;

        //        p_prt037L.Amt_1 = i.X_bonus;//年度總獎金 

        //        //法定減除費用額              
        //        if (Base_Salary > 3500)
        //        {
        //            p_prt037L.Amt_2 = 0;
        //        }
        //        else
        //        {
        //            p_prt037L.Amt_2 = 3500 - Base_Salary;
        //            decimal T_amt3 = p_prt037L.Amt_1 - p_prt037L.Amt_2;
        //            if (T_amt3 < 0)
        //                p_prt037L.Amt_2 = i.X_bonus;//年度總獎金
        //        }
        //        p_prt037L.Amt_2 = Math.Round(p_prt037L.Amt_2, 2, MidpointRounding.AwayFromZero);


        //        //應納稅所得額
        //        p_prt037L.Amt_3 = Math.Round(p_prt037L.Amt_1 - p_prt037L.Amt_2, 2, MidpointRounding.AwayFromZero);
                
        //        //稅率
        //        p_prt037L.Amt_4 = p_prt012.Tax_rate;

        //        //速算扣除數
        //        p_prt037L.Amt_5 = p_prt012.Amt_sub;

        //        //應納稅額
        //        decimal T_amt6 = (p_prt037L.Amt_3 * (p_prt037L.Amt_4 / 100)) - p_prt037L.Amt_5;
        //        p_prt037L.Amt_6 = Math.Round(T_amt6, 2, MidpointRounding.AwayFromZero);
        //        p_prt037L.Insert();
        //        //-------

        //        prt036L p_prt036L = new prt036L();
        //        p_prt036L.S_tax = p_prt037L.Amt_6;//應納稅額
        //        p_prt036L.S_bonus = i.S_bonus;//預付獎金
        //        p_prt036L.Bonus = i.X_bonus - p_prt036L.S_tax - p_prt036L.S_bonus;
        //        if (p_prt036L.Update3(i.Yy,i.Dept,i.Cdept,i.Pr_no) == "修改失敗")
        //        {
        //            //寫入稽核檔
        //            Ins_Err(i.Pr_no, "年終獎金計稅失敗，程式編號:pri046");
        //            continue;
        //        }
        //        progressBar1.Value += progressBar1.Step;
        //    }
        //}

        //2019 開始不再用2月份薪資為依據
        private void Pay_Trn(decimal Yy, string Dept, string Cdept, string Pr_no)
        {
            new prt032().Delete(Dept, (Int32)Yy, 99);//刪錯誤記錄檔
            progressBar1.Maximum = prt036L.ToDoList(Yy, Dept, Cdept, Pr_no).Count(); //進度bar
            foreach (var i in prt036L.ToDoList(Yy, Dept, Cdept, Pr_no))//當年有年終獎金的人
            {
                //------
                prt031L p_prt031L = new prt031L(); //薪資記錄檔
                p_prt031L = prt031L.Get(i.Yy + 1, 2, i.Pr_no, 1);//找每年二月份薪資
                
                //依總獎金平均12月;再依 稅率級距表找稅率--                                                
                prt012 p_prt012 = new prt012();
                p_prt012 = prt012.Get(i.Dept, i.X_bonus / 12);

                //--刪除年終獎金稅率檔歷史資料
                prt037L p_prt037L = new prt037L();
                p_prt037L.Delete(i.Yy, i.Dept, i.Cdept, i.Pr_no);

                p_prt037L.Yy = i.Yy;
                p_prt037L.Dept = i.Dept;
                p_prt037L.Cdept = i.Cdept;
                p_prt037L.Pr_no = i.Pr_no;

                p_prt037L.Amt_1 = i.X_bonus;//年度總獎金

                //法定減除費用額 
                p_prt037L.Amt_2 = 0;

                
                //應納稅所得額
                p_prt037L.Amt_3 = Math.Round(p_prt037L.Amt_1 - p_prt037L.Amt_2, 2, MidpointRounding.AwayFromZero);

                //稅率
                p_prt037L.Amt_4 = p_prt012.Tax_rate;

                //速算扣除數
                p_prt037L.Amt_5 = p_prt012.Amt_sub;

                //應納稅額
                decimal T_amt6 = (p_prt037L.Amt_3 * (p_prt037L.Amt_4 / 100)) - p_prt037L.Amt_5;
                p_prt037L.Amt_6 = Math.Round(T_amt6, 2, MidpointRounding.AwayFromZero);
                p_prt037L.Insert();
                //-------

                prt036L p_prt036L = new prt036L();
                p_prt036L.S_tax = p_prt037L.Amt_6;//應納稅額
                p_prt036L.S_bonus = i.S_bonus;//預付獎金
                p_prt036L.Bonus = i.X_bonus - p_prt036L.S_tax - p_prt036L.S_bonus;
                if (p_prt036L.Update3(i.Yy, i.Dept, i.Cdept, i.Pr_no) == "修改失敗")
                {
                    //寫入稽核檔
                    Ins_Err(i.Pr_no, "年終獎金計稅失敗，程式編號:pri046");
                    continue;
                }
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
            p_prt032.Mm = 99; //年終獎金計稅錯誤 月份定為99
            p_prt032.Memo = Memo;
            p_prt032.Prgid = this.Name;
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

        private void init_prno()
        {
            f_pr_no.Text = string.Empty;
            LPrno.Clear();
        }

        private void init_cdept()
        {
            //清除部門資料
            f_cdept.Text = string.Empty;
            LCdept.Clear();
        }

        private void f_yy_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
        }
                       

    }
}
