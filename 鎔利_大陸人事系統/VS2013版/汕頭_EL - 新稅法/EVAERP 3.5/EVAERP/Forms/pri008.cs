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
    public partial class pri008 : Form
    {
        int i = 0;
        static List<prt008> LS1 = new List<prt008>();
        string Menu_Sel;
        string Dept = Login.DEPT;
        

        public pri008()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_YY();//下拉選單-年
            Gridview_D0();//班別
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void D_YY()
        {
            int CYY = DateTime.Now.Year;
            int PYY = CYY - 1;
            int NYY = CYY + 1;
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry(PYY.ToString(), PYY));
            data.Add(new DictionaryEntry(CYY.ToString(), CYY));
            data.Add(new DictionaryEntry(NYY.ToString(), NYY));
            f_yy.DisplayMember = "Key";
            f_yy.ValueMember = "Value";
            f_yy.DataSource = data;
        }

        private void Gridview_D0()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("N-否", "N"));
            data.Add(new DictionaryEntry("Y-是", "Y"));
            work.DisplayMember = "Key";
            work.ValueMember = "Value";
            work.DataSource = data;
        }



        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (dataGridView1.RowCount == 0)
                {
                    Config.Show("無明細資料");
                    f_yy.Focus();
                    return;
                }
                if (Config.Message("確定新增?") == "Y")
                {
                    if (prt008.ToDoList(f_dept.SelectedValue.ToString(), Convert.ToInt16(f_yy.SelectedValue), "", "", "").Count() == 0)
                    {
                        Config.Show("將產生所有部門資料");
                        try
                        {
                            Config.Show(String.Format("{0}", f_Insert_ALL()));
                        }
                        catch (Exception ex)
                        {
                            Config.Show(ex.Message);
                        }
                    }
                    else
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
                }
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Upd")
            {
                if (dataGridView1.RowCount == 0)
                {
                    Config.Show("無明細資料");
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
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Del")
            {
                if (dataGridView1.RowCount == 0)
                {
                    Config.Show("無明細資料");
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
                InitMotherboard(Motherboard);
            }

        }

        

        private bool f_Check()
        {   
            if (f_dept.Text == String.Empty)
            {
                Config.Show("廠部不可空白");
                f_dept.Focus();
                return false;
            }
            if (f_cdept.Text == String.Empty)
            {
                Config.Show("部門不可空白");
                f_cdept.Focus();
                return false;
            }
            if (dataGridView1.RowCount == 0)
            {
                Config.Show("無明細資料可輸入");
                f_yy.Focus();
                return false;
            }
            return true;
        }



        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt008.ToDoListGroup(f_dept.SelectedValue.ToString(), Convert.ToInt32(f_yy.SelectedValue), f_cdept.Text, "").ToList();
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
                MessageBox.Show("已無資料");
            }
            else
            {
                //Master 資料
                f_dept.Text = LS1[idx].Dept;                
                f_cdept.Text = LS1[idx].Cdept;
                f_cdept_name.Text = prt001.Get(f_cdept.Text) == null ? "" : prt001.Get(f_cdept.Text).Department_name_new;
                f_yy.SelectedValue = LS1[idx].Yy;
               
                //抓名細資料
                bindingSource1.Clear();//清資料
                foreach (var i in prt008.ToDoList(f_dept.SelectedValue.ToString(), Convert.ToInt32(f_yy.SelectedValue), f_cdept.Text, ""))
                {
                    prt008 a_prt008 = new prt008();
                    a_prt008.Ho_date =Convert.ToDateTime(i.Ho_date).ToString("yyyy/MM/dd");
                    a_prt008.Ho_desc = i.Ho_desc;
                    a_prt008.Work = i.Work;
                    bindingSource1.Add(a_prt008);
                }

            }
        }

        
        private string f_Update()
        {
            f_Delete();
            f_Insert();
            return "修改成功";
        }

        private string f_Delete()
        {            
            var p_prt008 = new prt008();
            p_prt008.Delete(f_dept.SelectedValue.ToString(), Convert.ToInt16(f_yy.SelectedValue), f_cdept.Text, "");
            if (Menu_Sel == "Del")
                dataGridView1.Rows.Clear();
            return "刪除成功";
        }

        private string f_Insert()
        {   
            var p_prt008 = new prt008();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                p_prt008.Dept = f_dept.SelectedValue.ToString();
                p_prt008.Yy = Convert.ToInt16(f_yy.SelectedValue);
                p_prt008.Cdept = f_cdept.Text;
                p_prt008.Ho_date = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                p_prt008.Ho_code = "H";
                p_prt008.Work = dataGridView1.Rows[row.Index].Cells[2].Value.ToString();
                p_prt008.Ho_desc = dataGridView1.Rows[row.Index].Cells[1].Value.ToString();
                p_prt008.Delete(p_prt008.Dept, p_prt008.Yy, p_prt008.Cdept, p_prt008.Ho_date);
                p_prt008.Insert();
            }
            return "新增成功";
        }

        private string f_Insert_ALL()
        {
            new prt008().Delete(f_dept.SelectedValue.ToString(), Convert.ToInt16(f_yy.SelectedValue), "", "");
            foreach (var i in prt001.ToDoList(f_dept.SelectedValue.ToString()).ToList())
            {
                var p_prt008 = new prt008();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    p_prt008.Dept = f_dept.SelectedValue.ToString();
                    p_prt008.Yy = Convert.ToInt16(f_yy.SelectedValue);
                    p_prt008.Cdept = i.Department_code;
                    p_prt008.Ho_date = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
                    p_prt008.Ho_code = "H";
                    p_prt008.Work = dataGridView1.Rows[row.Index].Cells[2].Value.ToString();
                    p_prt008.Ho_desc = dataGridView1.Rows[row.Index].Cells[1].Value.ToString();
                    p_prt008.Delete(p_prt008.Dept, p_prt008.Yy, p_prt008.Cdept, p_prt008.Ho_date);
                    p_prt008.Insert();
                }
                this.Cursor = Cursors.WaitCursor;//漏斗指標
            }
            this.Cursor = Cursors.Default;//還原預設
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
        }

        private void Col_Disable()
        {
            if (Menu_Sel == "Upd")
            {
                f_yy.Enabled = false;
            }
            f_dept.Enabled = false;
            f_cdept.Enabled = false;
            f_cdept_name.Enabled = false;
            select.Enabled = false;
        }

        private void Col_vol()
        {
            f_yy.SelectedValue = DateTime.Now.Year;
        }


        private void menu_edit_Click(object sender, EventArgs e)
        {
            if ( f_cdept.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
                Col_Disable();
                if (dataGridView1.Rows.Count > 0)
                {
                    select.Enabled = true;
                }
                code_dearch_bt.Enabled = false;
                dataGridView1.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("請先查詢");
            }
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            dataGridView1.Rows.Clear();
            dataGridView1.DataBindings.Clear();
            dataGridView1.ReadOnly = true;
            Col_Disable();
            Col_vol();
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
            this.Close();
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
                if (c is Panel) InitColumn(c);
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
                if (c is Panel) InitMotherboard(c);
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
                if (a is Panel) SetColumn(a);
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
                if (a is Panel) SetMotherboard(a);
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
            pri001w fm = new pri001w(f_dept.SelectedValue.ToString());//部門
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_cdept.Text = fm.Code as string;
                f_cdept_name.Text = fm.Code_desc as string;
                if (Menu_Sel == "Add")
                {
                    if (prt008.ToDoList(f_dept.SelectedValue.ToString(), Convert.ToInt16(f_yy.SelectedValue), f_cdept.Text, "").Count() > 0)
                    {
                        Config.Show("此部門已有資料請用查詢作業");
                        return;
                    }
                    Create_Date();//產生整年度日期
                }
            }
        }

        //產生整年度日期
        private void Create_Date()
        {
            Int32 _yy = Convert.ToInt32(f_yy.SelectedValue);
            DateTime Beg_date, End_date, Chk_date = new DateTime();
            string _dd1 = String.Format("{0}/1/1", _yy);
            string _dd2 = String.Format("{0}/12/31", _yy);
            Beg_date = DateTime.Parse(_dd1);//起始日
            End_date = DateTime.Parse(_dd2);//結束日

            bindingSource1.Clear();
            for (int i = 0; i < 365; i++)
            {
                var a_prt008 = new prt008();
                var p_prt008 = new prt008();
                Chk_date = Beg_date.AddDays(i);
                if (Chk_date > End_date)
                    break;
                p_prt008 = prt008.Get(f_dept.SelectedValue.ToString(), _yy, f_cdept.Text, Chk_date.ToString("yyyy/MM/dd"));
                if (p_prt008 == null)
                {
                    Int16 _weekday = Convert.ToInt16(Chk_date.DayOfWeek);//判斷是否星期日跟星期六                
                    if (_weekday == 6 || _weekday == 0)
                    {
                        a_prt008.Ho_date = Chk_date.ToString("yyyy/MM/dd");
                        a_prt008.Ho_desc = _weekday == 6 ? "星期六" : "星期日";
                        a_prt008.Work = "N";
                        bindingSource1.Add(a_prt008);
                    }
                    else
                    {
                        if (Chk_date.Month == 1 && Chk_date.Day == 1)
                        {
                            a_prt008.Ho_date = Chk_date.ToString("yyyy/MM/dd");
                            a_prt008.Ho_desc = "元旦";
                            a_prt008.Work = "N";
                            bindingSource1.Add(a_prt008);
                        }
                        if (Chk_date.Month == 5 && Chk_date.Day == 1)
                        {
                            a_prt008.Ho_date = Chk_date.ToString("yyyy/MM/dd");
                            a_prt008.Ho_desc = "勞動節";
                            a_prt008.Work = "N";
                            bindingSource1.Add(a_prt008);
                        }
                        if (Chk_date.Month == 10 && Chk_date.Day == 1)
                        {
                            a_prt008.Ho_date = Chk_date.ToString("yyyy/MM/dd");
                            a_prt008.Ho_desc = "國慶日";
                            a_prt008.Work = "N";
                            bindingSource1.Add(a_prt008);
                        }
                    }
                }
                else
                {
                    a_prt008.Ho_date = Convert.ToDateTime(p_prt008.Ho_date).ToString("yyyy/MM/dd");
                    a_prt008.Ho_desc = p_prt008.Ho_desc;
                    a_prt008.Work = p_prt008.Work;
                    bindingSource1.Add(a_prt008);
                }
            }
        }



        
        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_cdept.Text != "" && f_dept.Text !="" && Menu_Sel == "Qry")
            {   
                Menu_Sel = "Del";
                InitMotherboard(Motherboard);
                confirm_Click(sender, e);
            }
            else
            {
                Config.Show("請先查詢");
            }
        }

        private void select_Click(object sender, EventArgs e)
        {
            pri0081 fm = new pri0081();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                var p_prt008 = new prt008();
                p_prt008.Ho_date = fm.Ho_date as string;
                p_prt008.Ho_desc = fm.Ho_desc as string;
                p_prt008.Work = "N";
                if (p_prt008.Ho_date != string.Empty)
                {
                    bindingSource1.Add(p_prt008);
                }
            }
        }

        private void f_yy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                f_dept.Text = "";
                f_cdept.Text = "";
                f_cdept_name.Text = "";
                dataGridView1.Rows.Clear();
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

        private void pri008_KeyDown(object sender, KeyEventArgs e)
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{tab}");
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void pri008_Load(object sender, EventArgs e)
        {
            //Exit_This();
        }
        private void Exit_This()
        {
            MessageBox.Show("此程式功能暫停...\n 不需執行此作業，如需詳情，再請聯絡電腦室。\n 謝謝您!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            this.Close();
        }
               
    }
}
