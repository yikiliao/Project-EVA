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
    public partial class pri045 : Form
    {   
        string Menu_Sel;
              
        const string Prgid = "pri045";
        string DataRang;
        string _dg;//處理廠部範圍 
        
        public pri045()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);            
            DataRang = sst901.Get(Home.Id).Rang;                                   
            lb_msg.Text = "";            
        }

        private void Exit_This()
        {
            MessageBox.Show("此程式功能暫停...\n 改由每年 12月15號 凌晨自動執行 計算下年度特休假。\n 如果沒有計算出下年度特休假資料，再請聯絡電腦室。\n 謝謝您!","警告",MessageBoxButtons.OK,MessageBoxIcon.Stop);
            this.Close();
        }
        

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y" || Config.Message("是否離開?") == "N")
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

            //特別假計算截止時間
            string FirstDay = string.Format("{0}-{1}-{2}", DateTime.Now.Year.ToString(), "01", "01");
            dateTimePicker1.Value = DateTime.Parse(FirstDay).AddYears(2).AddDays(-1); //明年的12/31日
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
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Qry")
            {
                string Pr_no = f_pr_no.Text.Trim();
                if (Config.Message("是否開始計算特休? ") == "Y")
                {
                    confirm.Enabled = false;
                    cancel.Enabled = false;

                    var Org_Color = lb_msg.ForeColor;
                    lb_msg.ForeColor = Color.Blue;
                    lb_msg.Text = "資料處理中...請稍候";

                    System.Threading.Thread.Sleep(1000);//停1秒

                    this.Cursor = Cursors.WaitCursor;//漏斗指標

                    Pay_Trn(f_dept.Text, Pr_no);//特別假計算 作業處理

                    this.Cursor = Cursors.Default;//還原預設
                    Config.Show("轉prvacam檔完成");
                    lb_msg.Text = "";
                    lb_msg.ForeColor = Org_Color;
                }
                cancel_Click(sender, e);
            }
        }



        private ArrayList Get_Hoday(string Pr_no, decimal Trn_YY)
        {            
            DateTime dt1;
            DateTime dt2;
            TimeSpan span;
            double dayDiff = 0;
                        
            Int16 ISpace_Date = 0;   //特別休假
            Int16 ISpace_Month = 0;
            Int16 ISpace_Hour = 0;
            Int16 YY = 365;
            ArrayList parm = new ArrayList();

            var p_prt016 = new prt016();            
            p_prt016 = prt016.Get(Pr_no);
            dt1 = Convert.ToDateTime(p_prt016.Pr_in_date); //到職日
            dt2 = Convert.ToDateTime(dateTimePicker1.Value); //明年度的 12/31號
            span = dt2.Subtract(dt1);
            dayDiff = span.Days + 1; //到職日的月日至12月31日的天數＋1


            if (dayDiff >= YY)
            {
                //2.    滿1年未滿2年 （到職日的月日至12月31日的天數＋1）／365）＊5，小數點無條件捨去)
                if (dayDiff >= YY && dayDiff < (YY * 2))
                {
                    ISpace_Date = (Int16)(((dayDiff-YY) / YY) * 5);
                    ISpace_Month = (Int16)(Convert.ToDateTime(p_prt016.Pr_in_date).Month);
                    ISpace_Hour = ISpace_Date;
                }

                //3.	滿2～10年 （5天）
                if (dayDiff >= (YY * 2) && dayDiff < (YY * 11))
                //if (dayDiff >= (YY * 2) && dayDiff < (YY * 10))
                //f (dayDiff < (YY * 11))
                {
                    ISpace_Date = 5;
                    ISpace_Month = 1;
                    ISpace_Hour = ISpace_Date;
                }
                
                //4.	滿11～20年（10天）
                if (dayDiff >= (YY * 11) && dayDiff < (YY * 21))
                //if (dayDiff >= (YY * 2) && dayDiff < (YY * 20))
                //f (dayDiff < (YY * 21))
                {
                    ISpace_Date = 10;
                    ISpace_Month = 1;
                    ISpace_Hour = ISpace_Date;
                }
                
                //5.	滿21年以上（15天）
                if (dayDiff >= (YY * 21))
                {
                    ISpace_Date = 15;
                    ISpace_Month = 1;
                    ISpace_Hour = ISpace_Date;
                }
            }
            else
            {
                //1.	當年度到職的人員，當年度不給予帶薪年休假
                ISpace_Date = 0;
                ISpace_Month = (Int16)(Convert.ToDateTime(p_prt016.Pr_in_date).Month);
                ISpace_Hour = ISpace_Date;
            }

            //台籍派外員工沒有特休
            if (p_prt016.Nation == "1")
            {
                ISpace_Date = 0;
                ISpace_Month = 1;
                ISpace_Hour = ISpace_Date;
            }            
            parm.Add(Trn_YY);
            parm.Add(p_prt016.Pr_no);
            parm.Add(p_prt016.Pr_idno);
            parm.Add(ISpace_Date);
            parm.Add(ISpace_Month);
            parm.Add(ISpace_Hour);
            return parm;
        }



        private void Pay_Trn(string Dept,string Pr_no)
        {   
            ArrayList aL = new ArrayList();
            decimal Trn_YY = Convert.ToDecimal(dateTimePicker1.Value.Year); //特別假年度

            if (!string.IsNullOrEmpty(Pr_no))//算個人
            {
                if (prt016.Get(Pr_no) == null) //人事主檔
                {                    
                    return;
                }

                //計算年度已有資料不轉
                if (prvacam.Get(Trn_YY, Pr_no) != null)
                {
                    return;
                }

                aL.Clear();
                aL = Get_Hoday(Pr_no, Trn_YY);
                                
                prvacam p_prvacam = new prvacam();                
                p_prvacam.Va_year = Convert.ToDecimal(aL[0]);
                p_prvacam.Va_pr_no = Convert.ToString(aL[1]);
                p_prvacam.Va_id_no = Convert.ToString(aL[2]);
                p_prvacam.Va_spec_date = Convert.ToDecimal(aL[3]);
                p_prvacam.Va_spec_month = Convert.ToDecimal(aL[4]);
                p_prvacam.Va_spec_hour = Convert.ToDecimal(aL[5]);
                p_prvacam.Vaca_a = 0;
                p_prvacam.Vaca_b = 0;
                p_prvacam.Vaca_c = 0;
                p_prvacam.Vaca_d = 0;
                p_prvacam.Vaca_e = 0;
                p_prvacam.Vaca_f = 0;
                p_prvacam.Vaca_g = 0;
                p_prvacam.Vaca_h = 0;
                p_prvacam.Vaca_i = 0;
                p_prvacam.Vaca_j = 0;
                p_prvacam.Vaca_k = 0;               
                p_prvacam.Insert();

            }
            else //算全部
            {   
                foreach (var i in prt016.ToDoList(Dept, "", "", "",  "I")) //在職的人
                {
                    if (prt016.Get(i.Pr_no) == null) //人事主檔
                    {                        
                        continue;
                    }

                    //當年度已有資料不轉
                    if (prvacam.Get(Trn_YY, i.Pr_no) != null)
                    {
                        return;
                    }

                    aL.Clear();
                    aL = Get_Hoday(i.Pr_no, Trn_YY);

                    prvacam p_prvacam = new prvacam();
                    p_prvacam.Va_year = Convert.ToDecimal(aL[0]);
                    p_prvacam.Va_pr_no = Convert.ToString(aL[1]);
                    p_prvacam.Va_id_no = Convert.ToString(aL[2]);
                    p_prvacam.Va_spec_date = Convert.ToDecimal(aL[3]);
                    p_prvacam.Va_spec_month = Convert.ToDecimal(aL[4]);
                    p_prvacam.Va_spec_hour = Convert.ToDecimal(aL[5]);
                    p_prvacam.Vaca_a = 0;
                    p_prvacam.Vaca_b = 0;
                    p_prvacam.Vaca_c = 0;
                    p_prvacam.Vaca_d = 0;
                    p_prvacam.Vaca_e = 0;
                    p_prvacam.Vaca_f = 0;
                    p_prvacam.Vaca_g = 0;
                    p_prvacam.Vaca_h = 0;
                    p_prvacam.Vaca_i = 0;
                    p_prvacam.Vaca_j = 0;
                    p_prvacam.Vaca_k = 0;
                    p_prvacam.Insert();
                }
            }
        }

                

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {            
            string _type = "I";//在職            
            //pri019w fm = new pri019w(_type, _dg);//開視窗資料
            pri016w fm = new pri016w(_type, _dg);//開視窗資料
           
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                f_pr_name.Text = fm.Code_desc as string;
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

        private void Col_Disable()
        {
            f_dept.Enabled = false;
            f_pr_no.Enabled = false;
            f_pr_name.Enabled = false;
            dateTimePicker1.Enabled = false;
        }

        

        private void pri045_Load(object sender, EventArgs e)
        {
            Exit_This();
        }
                       

    }
}
