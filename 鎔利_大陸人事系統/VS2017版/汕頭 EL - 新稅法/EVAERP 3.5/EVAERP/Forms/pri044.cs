using EVAERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EVAERP.Forms
{
    public partial class pri044 : Form
    {
        int i = 0;
        static List<prt032> LS1 = new List<prt032>();
        static List<sst903> LS2 = new List<sst903>();
        string Menu_Sel;
        string Dept = Login.DEPT;

        public pri044()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitMotherboard(this);
            set_dept();
            D_YY();//下拉選單-年
            D_MM();//下拉選單-月
            Choice_Sel();//挑年月
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }

        private void Choice_Sel()
        {
            int smm = DateTime.Now.AddMonths(-1).Month;//上一月
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
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
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
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
            }            
            f_dept.Enabled = false;
        }
        //所有欄位限制並清空
        private void InitColumn(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                InitColumn(c);
                if (c is TextBox)
                {
                    (c as TextBox).Text = System.String.Empty;
                    (c as TextBox).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
            }
            detelGridView.Rows.Clear();



        }
        //所有欄位解除並清空
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                SetColumn(a);
                if (a is TextBox)
                {
                    (a as TextBox).Text = System.String.Empty;
                    (a as TextBox).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
            }
            detelGridView.Rows.Clear();            
            f_dept.Enabled = false;
            f_add_date.Enabled = false;
            f_add_user.Enabled = false;
            f_mod_date.Enabled = false;
            f_mod_user.Enabled = false;
        }
        //功能列-第一筆
        private void menu_first_Click(object sender, EventArgs e)
        {
            i = 0;
            f_show(i);
        }
        //功能列-上一筆
        private void menu_previous_Click(object sender, EventArgs e)
        {
            f_show(--i);
            if (i < 0) i = 0;
        }
        //功能列-下一筆
        private void menu_next_Click(object sender, EventArgs e)
        {
            f_show(++i);
            if (i > LS2.Count - 1) i = LS2.Count - 1;

        }
        //功能列-最末筆
        private void menu_last_Click(object sender, EventArgs e)
        {
            i = LS2.Count() - 1;
            f_show(i);
        }
        //功能列-查詢
        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            
        }
        
        
        //功能列-離開
        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        //查詢執行
        private void f_Query()
        {
            LS1.Clear();
            Int32 _yy = Convert.ToInt32(f_yy.SelectedValue);
            Int32 _mm = Convert.ToInt32(f_mm.SelectedValue);
            LS1 = prt032.ToDoGroupList(f_dept.Text, _yy, _mm).ToList();
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
                f_dept.Text = LS1[i].Dept;
                f_yy.Text = LS1[i].Yy.ToString();
                f_mm.Text = LS1[i].Mm.ToString();
                //明細資料
                bindingSource1.Clear();
                bindingSource1.DataSource = prt032.ToDoList(f_dept.Text).Where(m => m.Yy == LS1[i].Yy && m.Mm == LS1[i].Mm).ToList();
            }
        }
        
        
        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);
            }            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
                this.Close();
        }

        //取消
        //private void cancel_Click(object sender, EventArgs e)
        //{
        //    i = 0;
        //    Menu_Sel = System.String.Empty;
        //    LS1.Clear();
        //    detelGridView.DataBindings.Clear();
        //    InitColumn(this);
        //}
        

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

        private void pri044_KeyDown(object sender, KeyEventArgs e)
        {
            //查詢(F3)            
            if (e.KeyCode == Keys.F3)
            {
                menu_query_Click(sender, e);
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
