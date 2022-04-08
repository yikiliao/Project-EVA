using EVAERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EVAERP.Forms
{
    public partial class ssi902 : Form
    {
        int i = 0;
        static List<sst902> LS1 = new List<sst902>();
        static List<sst902> LS2 = new List<sst902>();
        string Menu_Sel;
        ssi901w fm1 = new ssi901w();//開視窗資料
        public ssi902()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitMotherboard(this);
        }

        private void ssi902_Load(object sender, EventArgs e)
        {
            
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
            detelGridView.ReadOnly = true;  

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
            detelGridView.ReadOnly = false;
            f_erp_id.Enabled = false;
            f_pr_name.Enabled = false;

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
            detelGridView.ReadOnly = true;
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
            detelGridView.ReadOnly = false;
            detelGridView.Rows.Clear();
            f_erp_id.Enabled = false;
            f_pr_name.Enabled = false;
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
            bindingSource1.DataSource = umenuL.Select().ToList();
            foreach (DataGridViewRow row in detelGridView.Rows)
            {
                detelGridView.Rows[row.Index].Cells[2].Value = "N";
                detelGridView.Rows[row.Index].Cells[3].Value = "N";
                detelGridView.Rows[row.Index].Cells[4].Value = "N";
                detelGridView.Rows[row.Index].Cells[5].Value = "N";
            }
        }
        //功能列修改
        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_erp_id.Text != System.String.Empty && Menu_Sel == "Qry")
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

            LS1 = sst902.ToDoList(f_erp_id.Text).ToList();
            LS2 = LS1.GroupBy(a => a.Erp_id).Select(g => g.First()).ToList();
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
                f_erp_id.Text = LS2[idx].Erp_id;
                f_pr_name.Text = LS2[idx].Pr_name.ToString();                
                f_add_date.Text = LS2[idx].Add_date.ToString();
                f_add_user.Text = LS2[idx].Add_user.Trim();
                f_mod_date.Text = LS2[idx].Mod_date.ToString();
                f_mod_user.Text = LS2[idx].Mod_user.Trim();
                
                bindingSource1.DataSource = sst902.ToDoList(f_erp_id.Text).ToList();
                
            }
        }
        private void user_search_bt_Click(object sender, EventArgs e)
        {
            if (fm1.ShowDialog() == DialogResult.OK)
            {
                f_erp_id.Text = fm1.Erp_id as string;
                f_pr_name.Text = fm1.Pr_name as string;               
            }
        }
        //新增執行
        private void f_Insert()
        {
           
            var p_sst902 = new sst902();
            foreach (DataGridViewRow row in detelGridView.Rows)
            {
              
                
                p_sst902.Erp_id = f_erp_id.Text;
                p_sst902.Pr_name = f_pr_name.Text;
                p_sst902.Id = detelGridView.Rows[row.Index].Cells[0].Value.ToString();
                MessageBox.Show(detelGridView.Rows[row.Index].Cells[3].Value.ToString());
                p_sst902.Idname = detelGridView.Rows[row.Index].Cells[1].Value.ToString();
                p_sst902.Qry = detelGridView.Rows[row.Index].Cells[2].Value.ToString();
                p_sst902.Crt = detelGridView.Rows[row.Index].Cells[3].Value.ToString();
                p_sst902.Upd = detelGridView.Rows[row.Index].Cells[4].Value.ToString();
                p_sst902.Prt = detelGridView.Rows[row.Index].Cells[5].Value.ToString();
                Config.Show((p_sst902.Insert(Menu_Sel)));
            }

        }
        //更新執行
        private void f_Update()
        {
            var p_sst902 = new sst902();

            foreach (DataGridViewRow row in detelGridView.Rows)
            {
               
                p_sst902.Delete(f_erp_id.Text, detelGridView.Rows[row.Index].Cells[0].Value.ToString());

                p_sst902.Erp_id = f_erp_id.Text;
                p_sst902.Pr_name = f_pr_name.Text;
                p_sst902.Id = detelGridView.Rows[row.Index].Cells[0].Value.ToString();
                p_sst902.Idname = detelGridView.Rows[row.Index].Cells[1].Value.ToString();
                p_sst902.Qry = detelGridView.Rows[row.Index].Cells[2].Value.ToString();
                p_sst902.Crt = detelGridView.Rows[row.Index].Cells[3].Value.ToString();
                p_sst902.Upd = detelGridView.Rows[row.Index].Cells[4].Value.ToString();
                p_sst902.Prt = detelGridView.Rows[row.Index].Cells[5].Value.ToString();
                Config.Show((p_sst902.Insert(Menu_Sel)));
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

                    if (f_erp_id.Text == System.String.Empty)
                    {
                        Config.Show("代碼不可空白");
                        f_erp_id.Focus();
                        return;
                    }  
                       

                        detelGridView.ClearSelection();
                    
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
               

                    detelGridView.ClearSelection();
               
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

       
    }
}
