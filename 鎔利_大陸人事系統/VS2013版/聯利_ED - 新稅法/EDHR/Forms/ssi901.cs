using EDHR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EDHR.Forms
{
    public partial class ssi901 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<sst901> LS1 = new List<sst901>();
        public ssi901()
        {
            InitializeComponent();
            Config.SetFormSize(this);
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
        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);
            f_vaild_yes.Checked = true;
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_erp_id.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
                f_erp_id.Enabled = false;
                f_pr_name.Enabled = false;
            }
            else
            {
                Config.Show("請先查詢");
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

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_erp_id.Text == System.String.Empty)
                    {
                        Config.Show("代碼不可空白");
                        f_erp_id.Focus();
                        return;
                    }
                    try
                    {
                        Config.Show(f_Insert());
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
                        Config.Show(f_Update());
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Delete());
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
                InitMotherboard(Motherboard);
            }

        }

        private string f_Delete()
        {
            return String.Format("{0}", f_Delete_sst901());
        }

        private string f_Delete_sst901()
        {
            var p_sst901 = new sst901();
            return p_sst901.Delete(f_erp_id.Text);
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
        }

        private string f_Insert()
        {
            var p_sst901 = new sst901();
            p_sst901.Erp_id = f_erp_id.Text;
            p_sst901.Pr_name = f_pr_name.Text;
            p_sst901.Password = f_password.Text;
            p_sst901.Mail = f_mail.Text;
            var tmp_vaild = "";
            if (f_vaild_yes.Checked)
                tmp_vaild = "Y";
            if (f_vaild_no.Checked)
                tmp_vaild = "N";
            p_sst901.Vaild = tmp_vaild;
            p_sst901.Rang = f_rang.Text;
            return p_sst901.Insert();
        }

        private string f_Update()
        {
            var p_sst901 = new sst901();
            p_sst901.Erp_id = f_erp_id.Text;
            p_sst901.Pr_name = f_pr_name.Text;
            p_sst901.Password = f_password.Text;
            p_sst901.Mail = f_mail.Text;
            var tmp_vaild = "";
            if (f_vaild_yes.Checked)
                tmp_vaild = "Y";
            if (f_vaild_no.Checked)
                tmp_vaild = "N";
            p_sst901.Vaild = tmp_vaild;  
            return p_sst901.Update(p_sst901.Erp_id);
        }
        private void f_Query()
        {
            LS1.Clear();
            LS1 = sst901.ToDoList(f_erp_id.Text).ToList();
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
                f_erp_id.Text = LS1[idx].Erp_id;
                f_pr_name.Text = LS1[idx].Pr_name;
                f_password.Text = LS1[idx].Password;
                f_mail.Text = LS1[idx].Mail;
                f_add_date.Text = LS1[idx].Add_date.ToString();
                f_add_user.Text = LS1[idx].Add_user.Trim();
                f_mod_date.Text = LS1[idx].Mod_date.ToString();
                f_mod_user.Text = LS1[idx].Mod_user.Trim();                
                if (LS1[idx].Vaild == null)
                    f_vaild_no.Checked = false;
                f_vaild_yes.Checked = false;
                if (LS1[idx].Vaild == "Y")
                    f_vaild_yes.Checked = true;
                if (LS1[idx].Vaild == "N")
                    f_vaild_no.Checked = true;
                f_rang.Text = LS1[idx].Rang;
            }
        }

        private void mnu_del_Click(object sender, EventArgs e)
        {
            if (f_erp_id.Text != "" && Menu_Sel == "Qry")
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

        private void ssi901_KeyDown(object sender, KeyEventArgs e)
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
            //刪除(Control+D)
            if (e.Control && e.KeyCode == Keys.D)
            {
                mnu_del_Click(sender, e);
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
