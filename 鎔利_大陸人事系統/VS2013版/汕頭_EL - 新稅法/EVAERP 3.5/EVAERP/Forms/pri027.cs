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
    public partial class pri027 : Form
    {        
        static List<prt030L> LS1 = new List<prt030L>();
        static List<prt030L> AR1 = new List<prt030L>();
        string Menu_Sel;
        string Dept = Login.DEPT;

        int tmp_cdept_selectidx = 0; //記錄下拉部門selectidx        

        public pri027()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_YY();//下拉選單-年
            D_MM();//下拉選單-月
            Choice_Sel();//挑年月
            D_Cdpet();//部門
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_pr_dept.DataSource = sst011.ToDoList().ToList();
            f_pr_dept.DisplayMember = "dept_name";
            f_pr_dept.ValueMember = "dept";
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


        private void confirm_Click(object sender, EventArgs e)
        {
            decimal C_Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            decimal C_Mm = System.Convert.ToDecimal(f_mm.SelectedValue); ;
            string C_Dept = f_pr_dept.SelectedValue.ToString();

            if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
            {
                Config.Show("此薪資料已關帳，無法異動。");
                return;
            }
            if (Menu_Sel == "Add")
            {  
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_Check() == false)
                        return;
                    try
                    {
                        System.Threading.Thread.Sleep(1000);//停1秒

                        this.Cursor = Cursors.WaitCursor;//漏斗指標
                        Config.Show(String.Format("{0}", f_Insert()));
                        this.Cursor = Cursors.Default;//還原預設
                        tmp_cdept_selectidx = f_cdept.SelectedIndex;
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
            if (dataGridView1.RowCount == 0)
            {
                Config.Show("無明細資料可輸入");
                f_yy.Focus();
                return false;
            }
            return true;
        }



        //private string f_Insert()
        //{
        //    decimal _yy, _mm = 0;
        //    _yy = Convert.ToDecimal(f_yy.SelectedValue);
        //    _mm = Convert.ToDecimal(f_mm.SelectedValue);
        //    var p_prt031L = new prt031L();

        //    foreach (DataGridViewRow row in dataGridView1.Rows)            
        //    {   
        //        string Pr_no = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
        //        decimal Pr_seq = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[3].Value);
        //        p_prt031L = prt031L.Get(_yy, _mm, Pr_no, Pr_seq);

        //        p_prt031L.Pr_no = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
        //        p_prt031L.Pr_name = prt016.Get(p_prt031L.Pr_no) == null ? "" : prt016.Get(p_prt031L.Pr_no).Pr_name;
        //        p_prt031L.Cdept_no = dataGridView1.Rows[row.Index].Cells[2].Value.ToString();
        //        p_prt031L.Amt_9 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[4].Value);
        //        p_prt031L.Amt_10 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[5].Value);
        //        p_prt031L.Amt_27 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[6].Value);
        //        p_prt031L.Amt_32 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[7].Value);
        //        p_prt031L.Amt_4 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[8].Value);
        //        p_prt031L.Amt_17 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[9].Value);
        //        p_prt031L.Amt_20 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[10].Value);
        //        p_prt031L.Amt_29 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[11].Value);
        //        p_prt031L.Amt_30 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[12].Value);
                
        //        //應發金額
        //         p_prt031L.Amt_16 = p_prt031L.Amt_1 + p_prt031L.Amt_2 + p_prt031L.Amt_3 + 
        //         p_prt031L.Amt_5 + p_prt031L.Amt_6 + p_prt031L.Amt_7 + p_prt031L.Amt_8 + p_prt031L.Amt_9 +
        //         p_prt031L.Amt_10 + p_prt031L.Amt_13 + p_prt031L.Amt_27 + p_prt031L.Amt_32 - p_prt031L.Amt_11 - p_prt031L.Amt_12 - p_prt031L.Amt_15;

        //         p_prt031L.Amt_16 = Math.Round(p_prt031L.Amt_16, 0, MidpointRounding.AwayFromZero);

        //         //******找稅率*******要加入
        //         DateTime wk_date1, wk_date2 = new DateTime();
        //         string _dd = String.Format("{0}/{1}/1", f_yy.SelectedValue, f_mm.SelectedValue);
        //         wk_date1 = DateTime.Parse(_dd);//當月第一天
        //         wk_date2 = wk_date1.AddMonths(1).AddDays(-1);//當月最後一天
                 
        //         //所得稅(amt19)
        //         //******找稅率*******
        //         var p_prt016 = prt016.Get(Pr_no);
        //         p_prt031L.Amt_19 = 0;
        //         decimal tmp_16 = 0;
        //         if (p_prt016 != null)
        //         {
        //             //應發新資-免稅額
        //             tmp_16 = p_prt031L.Amt_16 - (p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30 + p_prt031L.Amt_31) - prt013.GetWith(Dept, p_prt016.Nation, wk_date1.ToString("yyyy/MM/dd")).Tax_amt;

        //             if (tmp_16 > 0)
        //             {
        //                 //找級距
        //                 var p_prt012 = new prt012();
        //                 p_prt012 = prt012.Get(Dept, tmp_16);
        //                 p_prt031L.Amt_19 = tmp_16 * (p_prt012.Tax_rate * Convert.ToDecimal(0.01)) - p_prt012.Amt_sub;
        //             }
        //             if (p_prt031L.Amt_19 < 0)
        //                 p_prt031L.Amt_19 = 0;
        //         }
        //         p_prt031L.Amt_19 = Math.Round(p_prt031L.Amt_19, 2, MidpointRounding.AwayFromZero);


        //         //實發金額
        //         p_prt031L.Amt_25 = p_prt031L.Amt_16 - p_prt031L.Amt_17 - p_prt031L.Amt_19 - p_prt031L.Amt_20 - (p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30 + p_prt031L.Amt_31);

        //         p_prt031L.Amt_25 = Math.Round(p_prt031L.Amt_25, 2, MidpointRounding.AwayFromZero);//小數兩位 四捨五入

        //         p_prt031L.Update(_yy, _mm, Pr_no, Pr_seq);
        //    }
        //    return "新增成功";
        //}

        private string f_Insert()
        {
            decimal _yy, _mm = 0;
            _yy = Convert.ToDecimal(f_yy.SelectedValue);
            _mm = Convert.ToDecimal(f_mm.SelectedValue);
            var p_prt031L = new prt031L();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                string Pr_no = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                decimal Pr_seq = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[3].Value);
                p_prt031L = prt031L.Get(_yy, _mm, Pr_no, Pr_seq);

                p_prt031L.Pr_no = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                p_prt031L.Pr_name = prt016.Get(p_prt031L.Pr_no) == null ? "" : prt016.Get(p_prt031L.Pr_no).Pr_name;
                p_prt031L.Cdept_no = dataGridView1.Rows[row.Index].Cells[2].Value.ToString();
                p_prt031L.Amt_9 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[4].Value);
                p_prt031L.Amt_10 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[5].Value);
                p_prt031L.Amt_27 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[6].Value);
                p_prt031L.Amt_32 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[7].Value);
                p_prt031L.Amt_4 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[8].Value);
                p_prt031L.Amt_17 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[9].Value);
                p_prt031L.Amt_20 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[10].Value);
                p_prt031L.Amt_29 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[11].Value);
                p_prt031L.Amt_30 = Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[12].Value);

                //應發金額
                p_prt031L.Amt_16 = p_prt031L.Amt_1 + p_prt031L.Amt_2 + p_prt031L.Amt_3 +
                p_prt031L.Amt_5 + p_prt031L.Amt_6 + p_prt031L.Amt_7 + p_prt031L.Amt_8 + p_prt031L.Amt_9 +
                p_prt031L.Amt_10 + p_prt031L.Amt_13 + p_prt031L.Amt_27 + p_prt031L.Amt_32 - p_prt031L.Amt_11 - p_prt031L.Amt_12 - p_prt031L.Amt_15;

                p_prt031L.Amt_16 = Math.Round(p_prt031L.Amt_16, 0, MidpointRounding.AwayFromZero);

                //------                
                p_prt031L.Amt_19 = CalcuteTax.Get(_yy, _mm, Pr_no, p_prt031L.Amt_16, p_prt031L.Amt_28, p_prt031L.Amt_29, p_prt031L.Amt_30, p_prt031L.Amt_31).Amt_20;
                if (p_prt031L.Amt_19 < 0) p_prt031L.Amt_19 = 0;
                p_prt031L.Amt_19 = Math.Round(p_prt031L.Amt_19, 2, MidpointRounding.AwayFromZero);
                //------


                //實發金額
                p_prt031L.Amt_25 = p_prt031L.Amt_16 - p_prt031L.Amt_17 - p_prt031L.Amt_19 - p_prt031L.Amt_20 - (p_prt031L.Amt_28 + p_prt031L.Amt_29 + p_prt031L.Amt_30 + p_prt031L.Amt_31);

                p_prt031L.Amt_25 = Math.Round(p_prt031L.Amt_25, 2, MidpointRounding.AwayFromZero);//小數兩位 四捨五入

                p_prt031L.Update(_yy, _mm, Pr_no, Pr_seq);
            }
            return "新增成功";
        }

        
        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);//給初值

            f_pr_dept.SelectedValue = Dept;
            f_pr_dept.Enabled = false;

            dataGridView1.Rows.Clear();
            dataGridView1.DataBindings.Clear();
            dataGridView1.ReadOnly = false;

            //--部門下拉處理,並觸發事件            
            f_cdept.SelectedIndex = tmp_cdept_selectidx;
            f_cdept.Focus();
            f_cdept_SelectedIndexChanged(sender, e);
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
                this.Close();
            }
            else
            {
                return;
            }
        }

        //private void cancel_Click(object sender, EventArgs e)
        //{
        //    //i = 0;
        //    Menu_Sel = "";
        //    LS1.Clear();
        //    InitColumn(this);
        //    bindingSource1.Clear();//清資料
        //}
                

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

        

        
                

        
        private void button1_Click(object sender, EventArgs e)
        {            
            decimal _yy,_mm=0;
            _yy = Convert.ToDecimal(f_yy.SelectedValue);
            _mm = Convert.ToDecimal(f_mm.SelectedValue);
            string cdept = string.Format("'{0}'", f_cdept.SelectedValue.ToString());

            var _p = prt031L.ToDoList(_yy, _mm, cdept, "", null);
            bindingSource1.Clear();
            foreach (var i in _p.ToList())
            {
                prt031L a_prt031L = new prt031L();
                a_prt031L.Pr_no = i.Pr_no;
                a_prt031L.Pr_name = prt016.Get(i.Pr_no) == null ? "" : prt016.Get(i.Pr_no).Pr_name;
                a_prt031L.Cdept_no = i.Cdept_no;
                a_prt031L.Pr_sqe = i.Pr_sqe;
                a_prt031L.Amt_9 = i.Amt_9;
                a_prt031L.Amt_10 = i.Amt_10;
                a_prt031L.Amt_27 = i.Amt_27;
                a_prt031L.Amt_4 = i.Amt_4;
                a_prt031L.Amt_17 = i.Amt_17;
                a_prt031L.Amt_20 = i.Amt_20;
                a_prt031L.Amt_29 = i.Amt_29;
                a_prt031L.Amt_30 = i.Amt_30;
                a_prt031L.Amt_32 = i.Amt_32;
                bindingSource1.Add(a_prt031L);
            };
            
        }

        private void f_yy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                button1_Click(sender, e);
            }
        }

        private void f_mm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                button1_Click(sender, e);
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

        private void pri027_KeyDown(object sender, KeyEventArgs e)
        {
            //新增(F1)            
            if (e.KeyCode == Keys.F1)
            {
                menu_add_Click(sender, e);
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void pri027_Load(object sender, EventArgs e)
        {
            //數字靠右
            DataGrid_Right();
        }

        private void DataGrid_Right()
        {            
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void f_cdept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                button1_Click(sender, e);
            }
        }

               
    }
}
