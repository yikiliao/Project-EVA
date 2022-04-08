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
    public partial class pri105 : Form
    {
        int i = 0;
        static List<prt030L> LS1 = new List<prt030L>();
        static List<prt030L> AR1 = new List<prt030L>();
        string Menu_Sel;
        string Dept = Login.DEPT;
        string SType = "prt035L";        
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        public pri105()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);            
            label1.Text = "確認 勾選 表示存入";
        }

       

        private void confirm_Click(object sender, EventArgs e)
        {
            decimal C_Yy = System.Convert.ToDecimal(f_year.SelectedValue);
            decimal C_Mm = 88;
            string C_Dept = f_pr_dept.Text;
            
            if (Config.ClosePay(C_Yy, C_Mm, C_Dept) == true)
            {
                Config.Show("此年度資料已關帳，無法異動。");
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
                        Config.Show(String.Format("{0}", f_Insert()));                        
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                InitMotherboard(this);
            }

            if (Menu_Sel == "Upd")
            {
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
                InitMotherboard(this);
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);
            }

            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {   
                        Config.Show(String.Format("{0}", f_Delete()));
                        dataGridView1.Rows.Clear();
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
            if (f_cdept.Text == System.String.Empty)
            {
                Config.Show("部們不可空白");
                f_cdept.Focus();
                code_dearch_bt_Click(null, null);
                return false;
            }
            
            if (dataGridView1.RowCount == 0)
            {
                Config.Show("無明細資料可輸入");
                f_cdept.Focus();
                return false;
            }
            return true;
        }



        private void f_Query()
        {
        }

        private void f_show(int idx)
        {
            
        }

        
        private string f_Update()
        {   
            //var p_prt030L = new prt030L();
            //p_prt030L.Delete(f_pr_dept.Text,f_cdept.Text, f_pr_date.Text);
            //f_Insert();
            return "修改成功";
        }

        private string f_Delete()
        {
            var p_prt035L = new prt035L();
            var p_prt036L = new prt036L();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                p_prt035L.Yy = System.Convert.ToDecimal(f_year.SelectedValue);
                p_prt035L.Dept = Dept;
                p_prt035L.Cdept = dataGridView1.Rows[row.Index].Cells[1].Value.ToString();
                p_prt035L.Pr_no = dataGridView1.Rows[row.Index].Cells[3].Value.ToString();

                p_prt035L.Delete(p_prt035L.Yy, p_prt035L.Dept, p_prt035L.Cdept, p_prt035L.Pr_no);//刪考核基礎檔
                p_prt036L.Delete(p_prt035L.Yy, p_prt035L.Dept, p_prt035L.Cdept, p_prt035L.Pr_no);//刪獎金維護檔
            }
            
            return "刪除成功";
        }

        


        private string f_Insert()
        {
            confirm.Enabled = false;
            var p_prt035L = new prt035L();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                p_prt035L.Yy = System.Convert.ToDecimal(f_year.SelectedValue);
                p_prt035L.Dept = Dept;
                p_prt035L.Cdept = dataGridView1.Rows[row.Index].Cells[1].Value.ToString();
                p_prt035L.Pr_no = dataGridView1.Rows[row.Index].Cells[3].Value.ToString();
                p_prt035L.A_leader = System.Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[5].Value.ToString());
                p_prt035L.B_leader = System.Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[6].Value.ToString());
                p_prt035L.C_leader = System.Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[7].Value.ToString());
                p_prt035L.D_leader = System.Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[8].Value.ToString());
                p_prt035L.E_leader = System.Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[9].Value.ToString());
                p_prt035L.Tot = System.Convert.ToDecimal(dataGridView1.Rows[row.Index].Cells[10].Value.ToString());
                p_prt035L.Memo = dataGridView1.Rows[row.Index].Cells[11].Value.ToString();

                var isCheck = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                if (isCheck == "Y")
                {
                    p_prt035L.Delete(p_prt035L.Yy, p_prt035L.Dept, p_prt035L.Cdept, p_prt035L.Pr_no);
                    p_prt035L.Add_user = Home.Id;
                    
                    p_prt035L.Insert();
                }
            }
            dataGridView1.Rows.Clear();
            return "新增成功";
            
        }




        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);//給初值
            Col_Disable();
            dataGridView1.Rows.Clear();
            dataGridView1.DataBindings.Clear();
            dataGridView1.ReadOnly = false;
            f_cdept.Focus();
        }

        private void Col_Disable()
        {            
            f_pr_dept.Enabled = false;
            f_pr_dept_name.Enabled = false;
            f_pr_dept.Text = Dept;
            f_pr_dept_name.Text = sst011.Get() == null ? "" : sst011.Get().Dept_name;
            f_cdept.Enabled = false;
            f_pr_no.Enabled = false;
            set_year();
        }

        private void set_year()
        {
            f_year.DataSource = prt035L.ToDoList_YY().ToList();
            f_year.DisplayMember = "yy";
            f_year.ValueMember = "yy";
            f_year.Text = DateTime.Now.Year.ToString();
        }


        //private void set_year()
        //{
        //    ArrayList data = new ArrayList();
        //    int iyy = DateTime.Now.AddYears(-1).Year;
        //    string nyy = string.Format("{0} 年", iyy);
        //    data.Add(new DictionaryEntry(nyy, iyy));            
        //    f_year.DisplayMember = "Key";
        //    f_year.ValueMember = "Value";
        //    f_year.DataSource = data;
        //}
        
        private void menu_edit_Click(object sender, EventArgs e)
        {            
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            dataGridView1.Rows.Clear();
            dataGridView1.DataBindings.Clear();
            dataGridView1.ReadOnly = true;
            f_pr_dept.Text = Dept;
            f_pr_dept_name.Text = sst011.Get() == null ? "" : sst011.Get().Dept_name;
            Col_Disable();
            f_cdept.Enabled = true;
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            i = i + 1;
            f_show(i);
            if (i > LS1.Count - 1) i = LS1.Count - 1;
        }
                

        private void menu_previous_Click(object sender, EventArgs e)
        {
            i = i - 1;
            f_show(i);
            if (i < 0) i = 0;
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {            
            if (Config.Message("是否離開?")=="Y")
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "Cancel";
            LS1.Clear();
            InitColumn(this);
            bindingSource1.Clear();//清資料            
        }

        private void menu_last_Click(object sender, EventArgs e)
        {
            i = LS1.Count() - 1;
            f_show(i);
        }

        private void menu_first_Click(object sender, EventArgs e)
        {
            i = 0;
            f_show(i);
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

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {   
            var Yy = System.Convert.ToDecimal(f_year.SelectedValue);
                        
            wCdept fm = new wCdept(Yy, Dept, SType);//部門
            fm.LS = LCdept;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_cdept.Text = fm.Code as string;
                LCdept = fm.LS;
            }
            init_prno();
            if (Menu_Sel == "Add")
            {
                button1_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (f_cdept.Text == null || f_cdept.Text == string.Empty) return;
            decimal YY = System.Convert.ToDecimal(f_year.SelectedValue);
            string Check_Date = string.Format("{0}/{1}/{2}", YY, "12", "31");


            var Org_Color = label4.ForeColor;
            Cursor_wait(); //改變滑鼠游標漏斗指標

                        
            var _p = prt016.ToDoListPrno3(f_pr_dept.Text, f_cdept.Text,f_pr_no.Text, Check_Date);
            bindingSource1.Clear();
            foreach (var i in _p.ToList())
            {
                prt035L a_prt035L = new prt035L();
                prt035L p_prt035L = new prt035L();
                p_prt035L = prt035L.Get(YY, i.Pr_dept, i.Pr_cdept,i.Pr_no);
                if (p_prt035L == null)
                {
                    a_prt035L.Cdept = i.Pr_cdept;
                    //Cdept_Name = prt001.Get(p.Field<string>("pr_cdept").Trim()) == null ? "" : prt001.Get(p.Field<string>("pr_cdept").Trim()).Department_name_new,                    
                    a_prt035L.CdeptName = prt001.Get(i.Pr_cdept) == null ? "" : prt001.Get(i.Pr_cdept).Department_name_new;
                    a_prt035L.Pr_no = i.Pr_no;
                    a_prt035L.Pr_name = i.Pr_name;
                    a_prt035L.A_leader = 0.0000M;
                    a_prt035L.B_leader = 0.0000M;
                    a_prt035L.C_leader = 0.0000M;
                    a_prt035L.D_leader = 0.0000M;
                    a_prt035L.E_leader = 0.0000M;
                    a_prt035L.Tot = 0.0000M;
                    a_prt035L.Memo = string.Empty;                    
                }
                else
                {
                    a_prt035L.Cdept = p_prt035L.Cdept;
                    //a_prt035L.CdeptName = prt001.Get(p_prt035L.Cdept).Department_name_new;
                    a_prt035L.CdeptName = prt001.Get(i.Pr_cdept) == null ? "" : prt001.Get(i.Pr_cdept).Department_name_new;
                    a_prt035L.Pr_no = p_prt035L.Pr_no;
                    a_prt035L.Pr_name = prt016.Get(p_prt035L.Pr_no).Pr_name;
                    a_prt035L.A_leader = p_prt035L.A_leader;
                    a_prt035L.B_leader = p_prt035L.B_leader;
                    a_prt035L.C_leader = p_prt035L.C_leader;
                    a_prt035L.D_leader = p_prt035L.D_leader;
                    a_prt035L.E_leader = p_prt035L.E_leader;
                    a_prt035L.Tot = p_prt035L.Tot;
                    a_prt035L.Memo = p_prt035L.Memo;
                }
                   
                bindingSource1.Add(a_prt035L);
            }

            UnCursor_wait(Org_Color); //改變滑鼠游標還原預設

            if (dataGridView1.Rows.Count == 0)
            {
                Config.Show("無符合資料");                
                code_dearch_bt_Click(null, null); //開啟下拉視窗
                return;
            }

            //把gridview 的ckeckbox 設成打勾
            GridView_check_f();
        }

        private void Cursor_wait()
        {
            label4.ForeColor = Color.Blue;
            label4.Text = "資料處理中...請稍候";
            System.Threading.Thread.Sleep(1000);//停1秒
            this.Cursor = Cursors.WaitCursor;//漏斗指標
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            label4.ForeColor = Org_Color;
            this.Cursor = Cursors.Default;//還原預設
            label4.Text = "";
        }


        private void menu_del_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Del";
            InitMotherboard(this);
            if (dataGridView1.Rows.Count == 0)
            {
                Config.Show("無資料可刪除");
                return;
            }
            confirm_Click(sender, e);
        }

        private void GridView_check_f()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                chk.Value = "Y";
            }

            //設定第一列第5個欄位反白
            dataGridView1.Rows[0].Cells[0].Selected = false;
            dataGridView1.Rows[0].Cells[5].Selected = true;
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Menu_Sel == "Del" || Menu_Sel == "Cancel") return;

            dataGridView1.Rows[e.RowIndex].Cells[10].Value = Math.Round((decimal)dataGridView1.Rows[e.RowIndex].Cells[5].Value +
                                                             (decimal)dataGridView1.Rows[e.RowIndex].Cells[6].Value +
                (decimal)dataGridView1.Rows[e.RowIndex].Cells[7].Value +
                (decimal)dataGridView1.Rows[e.RowIndex].Cells[8].Value +
                (decimal)dataGridView1.Rows[e.RowIndex].Cells[9].Value,3);
        }

        private void DataGrid_Right()
        {
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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

        private void pri047_KeyDown(object sender, KeyEventArgs e)
        {
            //新增(F1)            
            if (e.KeyCode == Keys.F1)
            {
                menu_add_Click(sender, e);
            }
            ////查詢(Control+Q)
            ////if (e.Control && e.KeyCode == Keys.Q)
            //if (e.KeyCode == Keys.Q)
            //{
            //    menu_query_Click(sender, e);
            //}
            ////修改(Control+E)
            ////if (e.Control && e.KeyCode == Keys.E)
            //if (e.KeyCode == Keys.U)
            //{
            //    menu_edit_Click(sender, e);
            //}
            
            //刪除(F2)            
            if (e.KeyCode == Keys.F2)
            {
                menu_del_Click(sender, e);
            }

            ////第一筆(Control+F)
            ////if (e.Control && e.KeyCode == Keys.F)
            //if (e.KeyCode == Keys.F)
            //{
            //    menu_first_Click(sender, e);
            //}

            ////上一筆(Control+P)
            ////if (e.Control && e.KeyCode == Keys.P)
            //if (e.KeyCode == Keys.P)
            //{
            //    menu_previous_Click(sender, e);
            //}

            ////下一筆(Control+N)
            ////if (e.Control && e.KeyCode == Keys.N)
            //if (e.KeyCode == Keys.N)
            //{
            //    menu_next_Click(sender, e);
            //}

            ////最後一筆(Control+L)
            ////if (e.Control && e.KeyCode == Keys.L)
            //if (e.KeyCode == Keys.L)
            //{
            //    menu_last_Click(sender, e);
            //}

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

            ////離開(F10)
            if (e.KeyCode == Keys.F10)
            {
                mnu_exit_Click(sender, e);
            }            
            
        }


        private void pri047_Load(object sender, EventArgs e)
        {
            //DataGrid 數字欄位靠右
            DataGrid_Right();
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].ErrorText = "";

            if (e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9 || e.ColumnIndex == 10)
            {
                float newFloat = 0.0000f;
                if (!float.TryParse(e.FormattedValue.ToString(), out newFloat) || newFloat < 0.0000)
                {
                    e.Cancel = true;
                    dataGridView1.Rows[e.RowIndex].ErrorText = "格式錯誤,請重新輸入";
                    MessageBox.Show("格式錯誤,請重新輸入。");
                    return;
                }
                //int newInteger = 0;
                //if (!int.TryParse(e.FormattedValue.ToString(), out newInteger) || newInteger < 0)
                //{
                //    e.Cancel = true;
                //    dataGridView1.Rows[e.RowIndex].ErrorText = "题数格式错误，请重新输入。";
                //    MessageBox.Show("题数格式错误，请重新输入。");
                //    return;
                //}
            }

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)        
        {   
            if (e.ColumnIndex == 5)
                dataGridView1.Rows[e.RowIndex].Cells[5].Selected=true;
            if (e.ColumnIndex == 6)
                dataGridView1.Rows[e.RowIndex].Cells[6].Selected = true;
            if (e.ColumnIndex == 7)
                dataGridView1.Rows[e.RowIndex].Cells[7].Selected = true;
            if (e.ColumnIndex == 8)
                dataGridView1.Rows[e.RowIndex].Cells[8].Selected = true;
            if (e.ColumnIndex == 9)
                dataGridView1.Rows[e.RowIndex].Cells[9].Selected = true;
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

        private void button2_Click(object sender, EventArgs e)
        {
            decimal Yy = System.Convert.ToDecimal(f_year.SelectedValue);
            var Cdept = f_cdept.Text;

            wPrno fm = new wPrno(Yy, Dept, Cdept, SType);
            fm.LS = LPrno;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                LPrno = fm.LS;
            }
            if (Menu_Sel == "Add")
            {
                button1_Click(sender, e);
            }
        }

        private void init_prno()
        {            
            //清除工號資料
            f_pr_no.Text = string.Empty;
            LPrno.Clear();
        }

        private void init_cdept()
        {
            //清除部門資料
            f_cdept.Text = string.Empty;
            LCdept.Clear();        
        }

        private void f_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_cdept();
            init_prno();
            dataGridView1.Rows.Clear();
        }
               
    }
}
