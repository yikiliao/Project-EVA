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
    public partial class ssi904 : Form
    {
        int i = 0;        
        static List<umenuL> LS1 = new List<umenuL>();
        string Menu_Sel;
        
        public ssi904()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitMotherboard(this);
            label2.Text = "確認 勾選 表示存入";
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
            f_erp_id_from.Enabled = false;
            f_pr_name_from.Enabled = false;
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
            f_erp_id_from.Enabled = false;
            f_pr_name_from.Enabled = false;
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
            if (i > LS1.Count - 1) i = LS1.Count - 1;

        }
        //功能列-最末筆
        private void menu_last_Click(object sender, EventArgs e)
        {
            i = LS1.Count() - 1;
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
            if (f_erp_id.Text != String.Empty && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
                detelGridView.ReadOnly = false;
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
            LS1 = umenuL.ToDoList(f_erp_id.Text).ToList();
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

        //查詢顯示
        private void f_show(int idx)
        {
            if (idx < 0 || idx > LS1.Count - 1)
            {
                Config.Show("已無資料");
            }
            else
            {
                f_erp_id.Text = LS1[idx].User_account;
                f_pr_name.Text = sst901.Get(f_erp_id.Text).Pr_name;
                
                //抓名細資料
                bindingSource1.Clear();//清資料
                bindingSource1.DataSource = umenuL.SelectByUser(f_erp_id.Text).ToList();
                //把gridview 的ckeckbox 設成打勾
                GridView_check_f();
            }
        }
        private void user_search_bt_Click(object sender, EventArgs e)
        {
            ssi901w fm1 = new ssi901w();//開視窗資料
            if (fm1.ShowDialog() == DialogResult.OK)
            {
                f_erp_id.Text = fm1.Erp_id as string;
                f_pr_name.Text = fm1.Pr_name as string;               
            }
        }

        //新增執行
        private string f_Insert()
        {
            var p_umenu = new umenuL();
            foreach (DataGridViewRow row in detelGridView.Rows)
            {
                p_umenu.ParentId = detelGridView.Rows[row.Index].Cells[0].Value.ToString();
                p_umenu.Id = detelGridView.Rows[row.Index].Cells[1].Value.ToString();
                p_umenu.IdName = detelGridView.Rows[row.Index].Cells[2].Value.ToString();
                p_umenu.Programs = detelGridView.Rows[row.Index].Cells[3].Value.ToString();
                p_umenu.User_account = f_erp_id.Text.Trim();

                //--確認打勾才存入
                var isCheck = detelGridView.Rows[row.Index].Cells[4].Value.ToString();
                if (isCheck == "Y")
                {
                    p_umenu.Insert();
                }
            }
            return "新增成功";
        }
                

        //更新執行
        private string f_Update()
        {
            var p_umenu = new umenuL();
            p_umenu.Delete(f_erp_id.Text);
            f_Insert();
            return "修改成功";
        }
                

        private void confirm_Click(object sender, EventArgs e)
        {   
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
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Upd")
            {
                detelGridView.ClearSelection();
                if (Config.Message("確定修改?") == "Y")
                {
                    try
                    {                        
                        Config.Show(String.Format("{0}", f_Update()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    InitMotherboard(Motherboard);
                }
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(Motherboard);
            }

            if (Menu_Sel == "Del")
            {
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

        private string f_Delete()
        {
            var p_umenu = new umenuL();
            return p_umenu.Delete(f_erp_id.Text);
        }
                
        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = System.String.Empty;
            LS1.Clear();
            detelGridView.DataBindings.Clear();
            InitColumn(this);
        }

        private void user_search_from_bt_Click(object sender, EventArgs e)
        {
            ssi901w fm1 = new ssi901w(f_erp_id.Text);//開視窗資料            
            if (fm1.ShowDialog() == DialogResult.OK)
            {
                f_erp_id_from.Text = fm1.Erp_id as string;
                f_pr_name_from.Text = fm1.Pr_name as string;
            }

            //--複製使用者的選單放到GridView
            if (Menu_Sel == "Add")
            {
                bindingSource1.Clear();
                bindingSource1.DataSource = umenuL.SelectByUser(f_erp_id_from.Text).ToList();
                //把gridview 的ckeckbox 設成打勾
                GridView_check_f();
            }
        }

        private void GridView_check_f()
        {
            foreach (DataGridViewRow row in detelGridView.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[4];
                chk.Value = "Y";
            }
        }
        private bool f_Check()
        {
            
            if (f_erp_id.Text == System.String.Empty)
            {
                Config.Show("使用者不可空白");
                f_erp_id.Focus();
                return false;
            }
            if (f_erp_id_from.Text == System.String.Empty)
            {
                Config.Show("選單來源不可空白");
                f_erp_id_from.Focus();
                return false;
            }            
            if (detelGridView.RowCount == 0)
            {
                Config.Show("無明細資料可輸入");
                f_erp_id.Focus();
                return false;
            }
            return true;
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

        private void ssi904_KeyDown(object sender, KeyEventArgs e)
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
       
    }
}
