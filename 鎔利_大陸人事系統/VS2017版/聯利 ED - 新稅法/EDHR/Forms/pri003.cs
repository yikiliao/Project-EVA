using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDHR.Models;

namespace EDHR.Forms
{
    public partial class pri003 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt001> LS1 = new List<prt001>();
        string DataRang;//處理廠部範圍

        public pri003()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            DataRang = Login.DEPT;
            set_dept();
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能暫停...\n 改由TT維護資料。\n 如果沒有資料，再請聯絡電腦室。\n 謝謝您!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            menu_query_Click(null, null);
            confirm_Click(null, null);
            return;
            //Menu_Sel = "Add";
            //SetColumn(this);
            //f_dept.Enabled = false;
            //f_dept_name.Enabled = false;
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
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
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {   
                    if (f_department_code.Text == System.String.Empty)
                    {
                        Config.Show("代碼不可空白");
                        f_department_code.Focus();
                        return;
                    }
                    try
                    {
                        //Config.Show(f_Insert());
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

            if (Menu_Sel == "Upd")
            {
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {
                       // Config.Show(f_Update());
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                InitMotherboard(Motherboard);
            }

        }


        //private string f_Insert()
        //{
        //    var p_prt001 = new prt001();
        //    p_prt001.Dept = f_dept.Text;
        //    p_prt001.Department_code = f_department_code.Text;
        //    p_prt001.Department_name_new = f_department_name_new.Text;
        //    p_prt001.Department_name_old = f_department_name_old.Text;
        //    var tmp_vaild = "";
        //    if (f_vaild_yes.Checked)
        //        tmp_vaild = "Y";
        //    if (f_vaild_no.Checked)
        //        tmp_vaild = "N";
        //    p_prt001.Vaild = tmp_vaild;
        //    p_prt001.Remark = f_remark.Text;
        //    return p_prt001.Insert();
        //}

        //private string f_Update()
        //{
        //    var p_prt001 = new prt001();
        //    p_prt001.Dept = f_dept.Text;
        //    p_prt001.Department_code = f_department_code.Text;
        //    p_prt001.Department_name_new = f_department_name_new.Text;
        //    p_prt001.Department_name_old = f_department_name_old.Text;
        //    var tmp_vaild = "";
        //    if (f_vaild_yes.Checked)
        //        tmp_vaild = "Y";
        //    if (f_vaild_no.Checked)
        //        tmp_vaild = "N";
        //    p_prt001.Vaild = tmp_vaild;
        //    p_prt001.Remark = f_remark.Text;
        //    return p_prt001.Update(p_prt001.Dept, p_prt001.Department_code);
        //}
                

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            confirm_Click(null, null);
            //code_dearch_bt_Click(null, null);
        }

        private void f_Query()
        {            
            LS1.Clear();
            LS1 = prt001.ToDoList(f_dept.SelectedValue.ToString()).ToList();
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
                f_dept.Text = LS1[idx].Dept;
                //f_dept_name.Text = sst012.Get(LS1[idx].Dept).Dept_name;
                f_department_code.Text = LS1[idx].Department_code;
                f_department_name_new.Text = LS1[idx].Department_name_new;
                //f_department_name_old.Text = LS1[idx].Department_name_old;
                //f_add_date.Text = LS1[idx].Add_date.ToString();
                //f_add_user.Text = LS1[idx].Add_user.Trim();
                //f_mod_date.Text = LS1[idx].Mod_date.ToString();
                //f_mod_user.Text = LS1[idx].Mod_user.Trim();
                //f_remark.Text = LS1[idx].Remark;
                //if (LS1[idx].Vaild == null)
                //    f_vaild_no.Checked = false;
                //f_vaild_yes.Checked = false;
                //if (LS1[idx].Vaild == "Y")
                //    f_vaild_yes.Checked = true;
                //if (LS1[idx].Vaild == "N")
                //    f_vaild_no.Checked = true;
            }
        }

        private void menu_first_Click(object sender, EventArgs e)
        {
            i = 0;
            f_show(i);
        }

        private void menu_previous_Click(object sender, EventArgs e)
        {
            i = i - 1;
            f_show(i);
            if (i < 0) i = 0;
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            i = i + 1;
            f_show(i);
            if (i > LS1.Count - 1) i = LS1.Count - 1;
        }

        private void menu_last_Click(object sender, EventArgs e)
        {
            i = LS1.Count() - 1;
            f_show(i);
        }


        private void menu_edit_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此功能暫停...\n 改由TT維護資料。\n 如果沒有資料，再請聯絡電腦室。\n 謝謝您!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return;
            //if (f_department_code.Text != "" && Menu_Sel == "Qry")
            //{
            //    Menu_Sel = "Upd";
            //    SetMotherboard(Motherboard);
            //    f_dept.Enabled = false;
            //    f_dept_name.Enabled = false;
            //    f_department_code.Enabled = false;
            //    code_dearch_bt.Enabled = false;
            //    f_department_name_new.Focus();
            //}
            //else
            //{
            //    Config.Show("請先查詢");
            //}
        }

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            ssi011w fm = new ssi011w();//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_dept.Text = fm.Company as string;
                f_dept_name.Text = fm.Company_shname as string;
            }
            confirm_Click(null, null);
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


        private void pri001_KeyDown(object sender, KeyEventArgs e)
        {
            //新增(Control+A)
            if (e.Control && e.KeyCode == Keys.A)
            {
                menu_add_Click(sender, e);
            }
            //查詢(Control+Q)
            if (e.Control && e.KeyCode == Keys.Q)
            {
                menu_query_Click(sender, e);
            }
            //修改(Control+E)
            if (e.Control && e.KeyCode == Keys.E)
            {
                menu_edit_Click(sender, e);
            }

            //第一筆(Control+F)
            if (e.Control && e.KeyCode == Keys.F)
            {
                menu_first_Click(sender, e);
            }

            //上一筆(Control+P)
            if (e.Control && e.KeyCode == Keys.P)
            {
                menu_previous_Click(sender, e);
            }

            //下一筆(Control+N)
            if (e.Control && e.KeyCode == Keys.N)
            {
                menu_next_Click(sender, e);
            }

            //最後一筆(Control+L)
            if (e.Control && e.KeyCode == Keys.L)
            {
                menu_last_Click(sender, e);
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
