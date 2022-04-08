using EDHR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDHR.Forms
{
    public partial class ssi903 : Form
    {
        int i = 0;
        static List<sst903> LS1 = new List<sst903>();
        static List<sst903> LS2 = new List<sst903>();
        string Menu_Sel;
        ssi011w fm3 = new ssi011w();

        public ssi903()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitMotherboard(this);
            
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
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
            }
            f_id.Enabled = false;
            f_id_name.Enabled = false;
            f_pr_dept.Enabled = false;
            f_dept_name.Enabled = false;
        }
        //所有欄位限制並清空
        private void InitColumn(Control ctl_false)
        {
            foreach (Control c in ctl_false.Controls)
            {
                if (c is Panel) InitColumn(c);
                if (c is TextBox)
                {
                    (c as TextBox).Text = System.String.Empty;
                    (c as TextBox).Enabled = false;
                }
                if (c is Button)
                {
                    (c as Button).Enabled = false;
                }
            }
            detelGridView.Rows.Clear();



        }
        //所有欄位解除並清空
        private void SetColumn(Control ctl_true)
        {
            foreach (Control a in ctl_true.Controls)
            {
                if (a is Panel) SetColumn(a);
                if (a is TextBox)
                {
                    (a as TextBox).Text = System.String.Empty;
                    (a as TextBox).Enabled = true;
                }
                if (a is Button)
                {
                    (a as Button).Enabled = true;
                }
            }
            detelGridView.Rows.Clear();
            f_id.Enabled = false;
            f_id_name.Enabled = false;
            f_pr_dept.Enabled = false;
            f_dept_name.Enabled = false;
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
        //功能列-新增
        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);//給初值
        }
        //功能列修改
        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_id.Text != System.String.Empty && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
            }
            else
            {
                Config.Show("請先查詢");
            }
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

            LS1 = sst903.ToDoList(f_id.Text,f_pr_dept.Text).ToList();

            LS2 = LS1.GroupBy(a => new {a.Id, a.Pr_dept }).Select(g => g.First()).ToList();

            if (LS2.Count() == 0)
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
        //查詢顯示
        private void f_show(int idx)
        {
            if (idx < 0 || idx > LS2.Count - 1)
            {
                Config.Show("已無資料");
            }
            else
            {
                f_id.Text = LS2[idx].Id;
                f_id_name.Text = umenuS.Get(LS2[idx].Id).IdName;
                f_subject.Text = LS2[idx].Subject.ToString();
                f_pr_dept.Text = LS2[idx].Pr_dept.ToString();
                f_dept_name.Text = sst011.Get(Login.DEPT) == null ? "" : sst011.Get(Login.DEPT).Company_shname;
                f_add_date.Text = LS2[idx].Add_date.ToString();
                f_add_user.Text = LS2[idx].Add_user.Trim();
                f_mod_date.Text = LS2[idx].Mod_date.ToString();
                f_mod_user.Text = LS2[idx].Mod_user.Trim();
                f_subject.Text = LS2[idx].Subject;
                bindingSource1.DataSource = sst903.GridView(f_id.Text,f_pr_dept.Text).ToList();
            }
        }
        //新增執行
        private void f_Insert()
        {
            var p_sst903 = new sst903();
            foreach (DataGridViewRow row in detelGridView.Rows)
            {
                if (row.Index == detelGridView.Rows.Count - 1)
                {
                    break;
                }

                p_sst903.Id = f_id.Text;
                p_sst903.Subject = f_subject.Text;
                p_sst903.Pr_dept = f_pr_dept.Text;
                p_sst903.Erp_id = detelGridView.Rows[row.Index].Cells[0].Value.ToString();
                p_sst903.Pr_name = detelGridView.Rows[row.Index].Cells[1].Value.ToString();
                p_sst903.Mail = detelGridView.Rows[row.Index].Cells[2].Value.ToString();

                Config.Show((p_sst903.Insert(Menu_Sel)));
            }

        }
        //更新執行
        private void f_Update()
        {
            var p_sst903 = new sst903();

            foreach (DataGridViewRow row in detelGridView.Rows)
            {
                if (row.Index == detelGridView.Rows.Count - 1)
                {
                    break;
                }
                p_sst903.Delete(f_id.Text, detelGridView.Rows[row.Index].Cells[0].Value.ToString(),f_pr_dept.Text);

                p_sst903.Id = f_id.Text;
                p_sst903.Subject = f_subject.Text;
                p_sst903.Pr_dept = f_pr_dept.Text;
                p_sst903.Erp_id = detelGridView.Rows[row.Index].Cells[0].Value.ToString();
                p_sst903.Pr_name = detelGridView.Rows[row.Index].Cells[1].Value.ToString();
                p_sst903.Mail = detelGridView.Rows[row.Index].Cells[2].Value.ToString();
                p_sst903.Add_date = f_add_date.Text;
                p_sst903.Add_user = f_add_user.Text;
                Config.Show((p_sst903.Insert(Menu_Sel)));
            }
        }
        private void confirm_Click(object sender, EventArgs e)
        {

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(Motherboard);
               
            }
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {

                    if (f_id.Text == System.String.Empty)
                    {
                        Config.Show("代碼不可空白");
                        f_id.Focus();
                        return;
                    }

                    foreach (DataGridViewRow row in detelGridView.Rows)
                    {
                        if (detelGridView.Rows[row.Index].Cells[0].Value == null && row.Index < detelGridView.Rows.Count - 1)
                        {
                            detelGridView.Rows[row.Index].Selected = true;
                            Config.Show("...號頭內容不可空白...");
                            return;
                        }

                        detelGridView.ClearSelection();
                    }
                    try
                    {
                        f_Insert();
                        InitMotherboard(Motherboard);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
            if (Menu_Sel == "Upd")
            {
                foreach (DataGridViewRow row in detelGridView.Rows)
                {
                    if (detelGridView.Rows[row.Index].Cells[0].Value == null && row.Index < detelGridView.Rows.Count - 1)
                    {
                        detelGridView.Rows[row.Index].Selected = true;
                        Config.Show("...號頭內容不可空白...");
                        return;
                    }

                    detelGridView.ClearSelection();
                }
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {
                        f_Update();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    InitMotherboard(Motherboard);
                }

            }
        }
        //取消
        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = System.String.Empty;
            LS1.Clear();
            detelGridView.DataBindings.Clear();
            InitColumn(this);
        }
        private void id_search_bt_Click(object sender, EventArgs e)
        {
            menuw fm1 = new menuw();//開視窗資料
            if (fm1.ShowDialog() == DialogResult.OK)
            {
                f_id.Text = fm1.Id as string;
                f_id_name.Text = fm1.IdName as string;
            }

        }

        private void select_Click(object sender, EventArgs e)
        {
            ssi901w fm2 = new ssi901w();
            if (fm2.ShowDialog() == DialogResult.OK)
            {
                sst903 sst903s = new sst903();
                sst903s.Erp_id = fm2.Erp_id as string;
                sst903s.Pr_name = fm2.Pr_name as string;               
                sst903s.Mail = fm2.Mail as string;
                bindingSource1.Add(sst903s);
            }        
        }

        private void dept_search_btn_Click(object sender, EventArgs e)
        {
            if (fm3.ShowDialog() == DialogResult.OK)
            {
                f_pr_dept.Text = fm3.Company as string;
                f_dept_name.Text = fm3.Company_shname as string;                
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

        private void ssi903_KeyDown(object sender, KeyEventArgs e)
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
