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
    public partial class pri043 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt033> LS1 = new List<prt033>();        
        string Dept = Login.DEPT;

        public pri043()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            SetColumnToRight();
            set_dept();
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void SetColumnToRight()
        {
            f_old_amt.TextAlign = HorizontalAlignment.Right;
            f_old_sig_per.TextAlign = HorizontalAlignment.Right;
            f_old_sig_amt.TextAlign = HorizontalAlignment.Right;
            f_old_com_per.TextAlign = HorizontalAlignment.Right;
            f_old_com_amt.TextAlign = HorizontalAlignment.Right;
            f_medic_amt.TextAlign = HorizontalAlignment.Right;
            f_medic_sig_per.TextAlign = HorizontalAlignment.Right;
            f_medic_sig_amt.TextAlign = HorizontalAlignment.Right;
            f_medic_com_per.TextAlign = HorizontalAlignment.Right;
            f_medic_com_amt.TextAlign = HorizontalAlignment.Right;

            f_job_amt.TextAlign = HorizontalAlignment.Right;
            f_job_sig_per.TextAlign = HorizontalAlignment.Right;
            f_job_sig_amt.TextAlign = HorizontalAlignment.Right;
            f_job_com_per.TextAlign = HorizontalAlignment.Right;
            f_job_com_amt.TextAlign = HorizontalAlignment.Right;

            f_house_amt.TextAlign = HorizontalAlignment.Right;
            f_house_sig_per.TextAlign = HorizontalAlignment.Right;
            f_house_sig_amt.TextAlign = HorizontalAlignment.Right;
            f_house_com_per.TextAlign = HorizontalAlignment.Right;
            f_house_com_amt.TextAlign = HorizontalAlignment.Right;

            f_work_amt.TextAlign = HorizontalAlignment.Right;
            f_work_com_per.TextAlign = HorizontalAlignment.Right;
            f_work_com_amt.TextAlign = HorizontalAlignment.Right;

            f_baby_amt.TextAlign = HorizontalAlignment.Right;
            f_baby_com_per.TextAlign = HorizontalAlignment.Right;
            f_baby_com_amt.TextAlign = HorizontalAlignment.Right;
        }

        

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);
            add_zero();
            Col_Disable();
            f_safe_no.Text = prt033.Get_Safe_No(f_dept.SelectedValue.ToString());
            bindingNavigator1.Enabled = false;
        }

        private void Col_Disable()
        {            
            f_dept.Enabled = false;
            f_safe_no.Enabled = false;
            f_old_sig_amt.Enabled = false;
            f_old_com_amt.Enabled = false;
            f_medic_sig_amt.Enabled = false;
            f_medic_com_amt.Enabled = false;
            f_job_sig_amt.Enabled = false;
            f_job_com_amt.Enabled = false;
            f_house_sig_amt.Enabled = false;
            f_house_com_amt.Enabled = false;
            f_work_com_amt.Enabled = false;
            f_baby_com_amt.Enabled = false;
        }

        private void add_zero()
        {
            f_old_amt.Text = "0";
            f_old_sig_per.Text = "0.0";
            f_old_sig_amt.Text = "0.0";
            f_old_com_per.Text = "0.0";
            f_old_com_amt.Text = "0.0";
            f_medic_amt.Text = "0";
            f_medic_sig_per.Text = "0.0";
            f_medic_sig_amt.Text = "0.0";
            f_medic_com_per.Text = "0.0";
            f_medic_com_amt.Text = "0.0";

            f_job_amt.Text = "0";
            f_job_sig_per.Text = "0.0";
            f_job_sig_amt.Text = "0.0";
            f_job_com_per.Text = "0.0";
            f_job_com_amt.Text = "0.0";

            f_house_amt.Text = "0";
            f_house_sig_per.Text = "0.0";
            f_house_sig_amt.Text = "0.0";
            f_house_com_per.Text = "0.0";
            f_house_com_amt.Text = "0.0";

            f_work_amt.Text = "0";
            f_work_com_per.Text = "0.0";
            f_work_com_amt.Text = "0.0";

            f_baby_amt.Text = "0";
            f_baby_com_per.Text = "0.0";
            f_baby_com_amt.Text = "0.0";
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

        //private void cancel_Click(object sender, EventArgs e)
        //{
        //    i = 0;
        //    Menu_Sel = "";
        //    LS1.Clear();
        //    InitColumn(this);
        //}
                

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
                InitColumn(c);
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
                InitMotherboard(c);
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

            bindingNavigator1.Enabled = true;
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
                else
                {
                    return;
                }
                InitColumn(this);//初始
                InitMotherboard(this);
            }

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(this);
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
                else
                {
                    return;
                }
                InitMotherboard(this);
            }

            if (Menu_Sel == "Del")
            {
                if (Config.Message("確定刪除?") == "Y")
                {
                    try
                    {
                        Config.Show(f_Delete());
                        LS1.RemoveAt(i);//刪除List那一筆
                        i = i - 1;//紀錄List的idx
                        if (LS1.Count > 0)
                        {
                            menu_next_Click(sender, e); //自動找下一筆
                        }
                        else
                        {
                            Config.Show("已無資料");
                            InitColumn(this);
                        }
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
            if (f_dept.SelectedValue.ToString() == System.String.Empty)
            {
                Config.Show("廠部不可空白");
                f_dept.Focus();
                return false;
            }
            return true;
        }


        private string f_Insert()
        {
            var p_prt033 = new prt033();
            p_prt033.Comp = Dept;
            p_prt033.Dept = Dept;
            p_prt033.Safe_no = f_safe_no.Text;
            p_prt033.Old_amt = Convert.ToInt32(f_old_amt.Text);
            p_prt033.Old_sig_per = Convert.ToDecimal(f_old_sig_per.Text);
            p_prt033.Old_sig_amt = Convert.ToDecimal(f_old_sig_amt.Text);
            p_prt033.Old_com_per = Convert.ToDecimal(f_old_com_per.Text);
            p_prt033.Old_com_amt = Convert.ToDecimal(f_old_com_amt.Text);
            p_prt033.Medic_amt = Convert.ToInt32(f_medic_amt.Text);
            p_prt033.Medic_sig_per = Convert.ToDecimal(f_medic_sig_per.Text);
            p_prt033.Medic_sig_amt = Convert.ToDecimal(f_medic_sig_amt.Text);
            p_prt033.Medic_com_per = Convert.ToDecimal(f_medic_com_per.Text);
            p_prt033.Medic_com_amt = Convert.ToDecimal(f_medic_com_amt.Text);

            p_prt033.Job_amt = Convert.ToInt32(f_job_amt.Text);
            p_prt033.Job_sig_per = Convert.ToDecimal(f_job_sig_per.Text);
            p_prt033.Job_sig_amt = Convert.ToDecimal(f_job_sig_amt.Text);
            p_prt033.Job_com_per = Convert.ToDecimal(f_job_com_per.Text);
            p_prt033.Job_com_amt = Convert.ToDecimal(f_job_com_amt.Text);

            p_prt033.House_amt = Convert.ToInt32(f_house_amt.Text);
            p_prt033.House_sig_per = Convert.ToDecimal(f_house_sig_per.Text);
            p_prt033.House_sig_amt = Convert.ToDecimal(f_house_sig_amt.Text);
            p_prt033.House_com_per = Convert.ToDecimal(f_house_com_per.Text);
            p_prt033.House_com_amt = Convert.ToDecimal(f_house_com_amt.Text);

            p_prt033.Work_amt = Convert.ToInt32(f_work_amt.Text);
            p_prt033.Work_com_per = Convert.ToDecimal(f_work_com_per.Text);
            p_prt033.Work_com_amt = Convert.ToDecimal(f_work_com_amt.Text);

            p_prt033.Baby_amt = Convert.ToInt32(f_baby_amt.Text);
            p_prt033.Baby_com_per = Convert.ToDecimal(f_baby_com_per.Text);
            p_prt033.Baby_com_amt = Convert.ToDecimal(f_baby_com_amt.Text);
            return p_prt033.Insert();
        }

        private string f_Update()
        {
            var p_prt033 = new prt033();
            p_prt033.Dept = f_dept.SelectedValue.ToString();
            p_prt033.Safe_no = f_safe_no.Text;
            p_prt033.Old_amt = Convert.ToInt32(f_old_amt.Text);
            p_prt033.Old_sig_per = Convert.ToDecimal(f_old_sig_per.Text);
            p_prt033.Old_sig_amt = Convert.ToDecimal(f_old_sig_amt.Text);
            p_prt033.Old_com_per = Convert.ToDecimal(f_old_com_per.Text);
            p_prt033.Old_com_amt = Convert.ToDecimal(f_old_com_amt.Text);
            p_prt033.Medic_amt = Convert.ToInt32(f_medic_amt.Text);
            p_prt033.Medic_sig_per = Convert.ToDecimal(f_medic_sig_per.Text);
            p_prt033.Medic_sig_amt = Convert.ToDecimal(f_medic_sig_amt.Text);
            p_prt033.Medic_com_per = Convert.ToDecimal(f_medic_com_per.Text);
            p_prt033.Medic_com_amt = Convert.ToDecimal(f_medic_com_amt.Text);

            p_prt033.Job_amt = Convert.ToInt32(f_job_amt.Text);
            p_prt033.Job_sig_per = Convert.ToDecimal(f_job_sig_per.Text);
            p_prt033.Job_sig_amt = Convert.ToDecimal(f_job_sig_amt.Text);
            p_prt033.Job_com_per = Convert.ToDecimal(f_job_com_per.Text);
            p_prt033.Job_com_amt = Convert.ToDecimal(f_job_com_amt.Text);

            p_prt033.House_amt = Convert.ToInt32(f_house_amt.Text);
            p_prt033.House_sig_per = Convert.ToDecimal(f_house_sig_per.Text);
            p_prt033.House_sig_amt = Convert.ToDecimal(f_house_sig_amt.Text);
            p_prt033.House_com_per = Convert.ToDecimal(f_house_com_per.Text);
            p_prt033.House_com_amt = Convert.ToDecimal(f_house_com_amt.Text);

            p_prt033.Work_amt = Convert.ToInt32(f_work_amt.Text);
            p_prt033.Work_com_per = Convert.ToDecimal(f_work_com_per.Text);
            p_prt033.Work_com_amt = Convert.ToDecimal(f_work_com_amt.Text);

            p_prt033.Baby_amt = Convert.ToInt32(f_baby_amt.Text);
            p_prt033.Baby_com_per = Convert.ToDecimal(f_baby_com_per.Text);
            p_prt033.Baby_com_amt = Convert.ToDecimal(f_baby_com_amt.Text);
            return p_prt033.Update(p_prt033.Dept, p_prt033.Safe_no);
        }

        private string f_Delete()
        {
            var p_prt033 = new prt033();
            p_prt033.Dept = f_dept.SelectedValue.ToString();
            p_prt033.Safe_no = f_safe_no.Text;
            return p_prt033.Delete(p_prt033.Dept, p_prt033.Safe_no);
        }

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
            confirm_Click(sender, e);
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt033.ToDoList(f_dept.SelectedValue.ToString(),f_safe_no.Text).ToList();
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
                if (idx < 0)
                    menu_first_Click(null, null);
                else
                    menu_last_Click(null, null);
            }
            else
            {
                var q_prt033 = prt033.Get(LS1[idx].Dept, LS1[idx].Safe_no);

                f_dept.SelectedValue = q_prt033.Dept;
                f_safe_no.Text = q_prt033.Safe_no;

                f_old_amt.Text = q_prt033.Old_amt.ToString();
                f_old_sig_per.Text = q_prt033.Old_sig_per.ToString();
                f_old_sig_amt.Text = q_prt033.Old_sig_amt.ToString();
                f_old_com_per.Text = q_prt033.Old_com_per.ToString();
                f_old_com_amt.Text = q_prt033.Old_com_amt.ToString();

                f_medic_amt.Text = q_prt033.Medic_amt.ToString();
                f_medic_sig_per.Text = q_prt033.Medic_sig_per.ToString();
                f_medic_sig_amt.Text = q_prt033.Medic_sig_amt.ToString();
                f_medic_com_per.Text = q_prt033.Medic_com_per.ToString();
                f_medic_com_amt.Text = q_prt033.Medic_com_amt.ToString();

                f_job_amt.Text = q_prt033.Job_amt.ToString();
                f_job_sig_per.Text = q_prt033.Job_sig_per.ToString();
                f_job_sig_amt.Text = q_prt033.Job_sig_amt.ToString();
                f_job_com_per.Text = q_prt033.Job_com_per.ToString();
                f_job_com_amt.Text = q_prt033.Job_com_amt.ToString();

                f_house_amt.Text = q_prt033.House_amt.ToString();
                f_house_sig_per.Text = q_prt033.House_sig_per.ToString();
                f_house_sig_amt.Text = q_prt033.House_sig_amt.ToString();
                f_house_com_per.Text = q_prt033.House_com_per.ToString();
                f_house_com_amt.Text = q_prt033.House_com_amt.ToString();

                f_work_amt.Text = q_prt033.Work_amt.ToString();
                f_work_com_per.Text = q_prt033.Work_com_per.ToString();
                f_work_com_amt.Text = q_prt033.Work_com_amt.ToString();

                f_baby_amt.Text = q_prt033.Baby_amt.ToString();
                f_baby_com_per.Text = q_prt033.Baby_com_per.ToString();
                f_baby_com_amt.Text = q_prt033.Baby_com_amt.ToString();
                f_add_user.Text = q_prt033.Add_user.Trim();
                f_add_date.Text = q_prt033.Add_date.Trim();
                f_mod_date.Text = q_prt033.Mod_date.Trim();
                f_mod_user.Text = q_prt033.Mod_user.Trim();
            }
        }

        //private void f_show(int idx)
        //{
        //    if (idx < 0 || idx > LS1.Count - 1)
        //    {
        //        Config.Show("已無資料");
        //    }
        //    else
        //    {                
        //        f_dept.SelectedValue = LS1[idx].Dept;
        //        f_safe_no.Text = LS1[idx].Safe_no;

        //        f_old_amt.Text = LS1[idx].Old_amt.ToString();
        //        f_old_sig_per.Text = LS1[idx].Old_sig_per.ToString();
        //        f_old_sig_amt.Text = LS1[idx].Old_sig_amt.ToString();
        //        f_old_com_per.Text = LS1[idx].Old_com_per.ToString();
        //        f_old_com_amt.Text = LS1[idx].Old_com_amt.ToString();

        //        f_medic_amt.Text = LS1[idx].Medic_amt.ToString();
        //        f_medic_sig_per.Text = LS1[idx].Medic_sig_per.ToString();
        //        f_medic_sig_amt.Text = LS1[idx].Medic_sig_amt.ToString();
        //        f_medic_com_per.Text = LS1[idx].Medic_com_per.ToString();
        //        f_medic_com_amt.Text = LS1[idx].Medic_com_amt.ToString();

        //        f_job_amt.Text = LS1[idx].Job_amt.ToString();
        //        f_job_sig_per.Text = LS1[idx].Job_sig_per.ToString();
        //        f_job_sig_amt.Text = LS1[idx].Job_sig_amt.ToString();
        //        f_job_com_per.Text = LS1[idx].Job_com_per.ToString();
        //        f_job_com_amt.Text = LS1[idx].Job_com_amt.ToString();

        //        f_house_amt.Text = LS1[idx].House_amt.ToString();
        //        f_house_sig_per.Text = LS1[idx].House_sig_per.ToString();
        //        f_house_sig_amt.Text = LS1[idx].House_sig_amt.ToString();
        //        f_house_com_per.Text = LS1[idx].House_com_per.ToString();
        //        f_house_com_amt.Text = LS1[idx].House_com_amt.ToString();

        //        f_work_amt.Text = LS1[idx].Work_amt.ToString();
        //        f_work_com_per.Text = LS1[idx].Work_com_per.ToString();
        //        f_work_com_amt.Text = LS1[idx].Work_com_amt.ToString();

        //        f_baby_amt.Text = LS1[idx].Baby_amt.ToString();
        //        f_baby_com_per.Text = LS1[idx].Baby_com_per.ToString();
        //        f_baby_com_amt.Text = LS1[idx].Baby_com_amt.ToString();
        //        f_add_user.Text = LS1[idx].Add_user.Trim();
        //        f_add_date.Text = LS1[idx].Add_date.Trim();
        //        f_mod_date.Text = LS1[idx].Mod_date.Trim();
        //        f_mod_user.Text = LS1[idx].Mod_user.Trim();
        //    }
        //}

        private void menu_first_Click(object sender, EventArgs e)
        {
            if (f_safe_no.Text != string.Empty)
            {
                i = 0;
                f_show(i);
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        private void menu_previous_Click(object sender, EventArgs e)
        {
            if (f_safe_no.Text != string.Empty)
            {
                i = i - 1;
                f_show(i);
                if (i < 0) i = 0;
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        private void menu_next_Click(object sender, EventArgs e)
        {
            if (f_safe_no.Text != string.Empty)
            {
                i = i + 1;
                f_show(i);
                if (i > LS1.Count - 1) i = LS1.Count - 1;
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        private void menu_last_Click(object sender, EventArgs e)
        {
            if (f_safe_no.Text != string.Empty)
            {
                i = LS1.Count() - 1;
                f_show(i);
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_safe_no.Text != string.Empty)
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                Col_Disable();
                f_old_amt.Focus();
                bindingNavigator1.Enabled = false;
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        //private void menu_edit_Click(object sender, EventArgs e)
        //{
        //    if (f_dept.SelectedValue.ToString() != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        Col_Disable();                
        //        f_old_amt.Focus();
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_safe_no.Text != string.Empty)
            {
                Menu_Sel = "Del";
                InitMotherboard(this);
                confirm_Click(sender, e);
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        //private void menu_del_Click(object sender, EventArgs e)
        //{
        //    if (f_dept.SelectedValue.ToString() != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Del";
        //        InitMotherboard(this);
        //        confirm_Click(sender, e);
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}

        private void f_wk_code_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar != 46 &&
                 (byte)e.KeyChar != 49 &&
                 (byte)e.KeyChar != 50 &&
                 (byte)e.KeyChar != 51 &&
                 (byte)e.KeyChar != 52 &&
                 (byte)e.KeyChar != 53 &&
                 (byte)e.KeyChar != 54 &&
                 (byte)e.KeyChar != 55 &&
                 (byte)e.KeyChar != 56 &&
                 (byte)e.KeyChar != 57 &&
                 (byte)e.KeyChar != 48 &&
                 (byte)e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }


        private void old_sum(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt2 = 0, amt3 = 0, amt4 = 0, amt5 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt1 = string.IsNullOrEmpty(f_old_amt.Text) ? 0 : Convert.ToDecimal(f_old_amt.Text);
                amt2 = string.IsNullOrEmpty(f_old_sig_per.Text) ? 0 : Convert.ToDecimal(f_old_sig_per.Text);
                amt3 = string.IsNullOrEmpty(f_old_sig_amt.Text) ? 0 : Convert.ToDecimal(f_old_sig_amt.Text);
                amt4 = string.IsNullOrEmpty(f_old_com_per.Text) ? 0 : Convert.ToDecimal(f_old_com_per.Text);
                amt5 = string.IsNullOrEmpty(f_old_com_amt.Text) ? 0 : Convert.ToDecimal(f_old_com_amt.Text);
                
                amt3 = amt1 * (amt2 / 100);
                amt3 = Math.Round(amt3, 2, MidpointRounding.AwayFromZero);
                f_old_sig_amt.Text = amt3.ToString();

                amt5 = amt1 * (amt4 / 100);
                amt5 = Math.Round(amt5, 2, MidpointRounding.AwayFromZero);
                f_old_com_amt.Text = amt5.ToString();
            }
        }

        private void NullToZero()
        {   
            if (string.IsNullOrEmpty(f_old_amt.Text)) f_old_amt.Text = "0";
            if (string.IsNullOrEmpty(f_old_sig_per.Text)) f_old_sig_per.Text = "0";
            if (string.IsNullOrEmpty(f_old_sig_amt.Text)) f_old_sig_amt.Text = "0";
            if (string.IsNullOrEmpty(f_old_com_per.Text)) f_old_com_per.Text = "0";
            if (string.IsNullOrEmpty(f_old_com_amt.Text)) f_old_com_amt.Text = "0";
            if (string.IsNullOrEmpty(f_medic_amt.Text)) f_medic_amt.Text = "0";
            if (string.IsNullOrEmpty(f_medic_sig_per.Text)) f_medic_sig_per.Text = "0";
            if (string.IsNullOrEmpty(f_medic_sig_amt.Text)) f_medic_sig_amt.Text = "0";
            if (string.IsNullOrEmpty(f_medic_com_per.Text)) f_medic_com_per.Text = "0";
            if (string.IsNullOrEmpty(f_medic_com_amt.Text)) f_medic_com_amt.Text = "0";
            if (string.IsNullOrEmpty(f_job_amt.Text)) f_job_amt.Text = "0";
            if (string.IsNullOrEmpty(f_job_sig_per.Text)) f_job_sig_per.Text = "0";
            if (string.IsNullOrEmpty(f_job_sig_amt.Text)) f_job_sig_amt.Text = "0";
            if (string.IsNullOrEmpty(f_job_com_per.Text)) f_job_com_per.Text = "0";
            if (string.IsNullOrEmpty(f_job_com_amt.Text)) f_job_com_amt.Text = "0";

            if (string.IsNullOrEmpty(f_house_amt.Text)) f_house_amt.Text = "0";
            if (string.IsNullOrEmpty(f_house_sig_per.Text)) f_house_sig_per.Text = "0";
            if (string.IsNullOrEmpty(f_house_sig_amt.Text)) f_house_sig_amt.Text = "0";
            if (string.IsNullOrEmpty(f_house_com_per.Text)) f_house_com_per.Text = "0";
            if (string.IsNullOrEmpty(f_house_com_amt.Text)) f_house_com_amt.Text = "0";

            if (string.IsNullOrEmpty(f_work_amt.Text)) f_work_amt.Text = "0";
            if (string.IsNullOrEmpty(f_work_com_per.Text)) f_work_com_per.Text = "0";
            if (string.IsNullOrEmpty(f_work_com_amt.Text)) f_work_com_amt.Text = "0";

            if (string.IsNullOrEmpty(f_baby_amt.Text)) f_baby_amt.Text = "0";
            if (string.IsNullOrEmpty(f_baby_com_per.Text)) f_baby_com_per.Text = "0";
            if (string.IsNullOrEmpty(f_baby_com_amt.Text)) f_baby_com_amt.Text = "0";

        }
             

        


        private void old_medic(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt2 = 0, amt3 = 0, amt4 = 0, amt5 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt1 = string.IsNullOrEmpty(f_medic_amt.Text) ? 0 : Convert.ToDecimal(f_medic_amt.Text);
                amt2 = string.IsNullOrEmpty(f_medic_sig_per.Text) ? 0 : Convert.ToDecimal(f_medic_sig_per.Text);
                amt3 = string.IsNullOrEmpty(f_medic_sig_amt.Text) ? 0 : Convert.ToDecimal(f_medic_sig_amt.Text);
                amt4 = string.IsNullOrEmpty(f_medic_com_per.Text) ? 0 : Convert.ToDecimal(f_medic_com_per.Text);
                amt5 = string.IsNullOrEmpty(f_medic_com_amt.Text) ? 0 : Convert.ToDecimal(f_medic_com_amt.Text);

                amt3 = amt1 * (amt2 / 100);
                amt3 = Math.Round(amt3, 0, MidpointRounding.AwayFromZero);
                f_medic_sig_amt.Text = amt3.ToString();

                amt5 = amt1 * (amt4 / 100);
                amt5 = Math.Round(amt5, 0, MidpointRounding.AwayFromZero);
                f_medic_com_amt.Text = amt5.ToString();
            }
        }

        private void job_sum(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt2 = 0, amt3 = 0, amt4 = 0, amt5 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt1 = string.IsNullOrEmpty(f_job_amt.Text) ? 0 : Convert.ToDecimal(f_job_amt.Text);
                amt2 = string.IsNullOrEmpty(f_job_sig_per.Text) ? 0 : Convert.ToDecimal(f_job_sig_per.Text);
                amt3 = string.IsNullOrEmpty(f_job_sig_amt.Text) ? 0 : Convert.ToDecimal(f_job_sig_amt.Text);
                amt4 = string.IsNullOrEmpty(f_job_com_per.Text) ? 0 : Convert.ToDecimal(f_job_com_per.Text);
                amt5 = string.IsNullOrEmpty(f_job_com_amt.Text) ? 0 : Convert.ToDecimal(f_job_com_amt.Text);

                amt3 = amt1 * (amt2 / 100);
                amt3 = Math.Round(amt3, 2, MidpointRounding.AwayFromZero);
                f_job_sig_amt.Text = amt3.ToString();

                amt5 = amt1 * (amt4 / 100);
                amt5 = Math.Round(amt5, 2, MidpointRounding.AwayFromZero);
                f_job_com_amt.Text = amt5.ToString();
            }
        }

        private void house_sum(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt2 = 0, amt3 = 0, amt4 = 0, amt5 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt1 = string.IsNullOrEmpty(f_house_amt.Text) ? 0 : Convert.ToDecimal(f_house_amt.Text);
                amt2 = string.IsNullOrEmpty(f_house_sig_per.Text) ? 0 : Convert.ToDecimal(f_house_sig_per.Text);
                amt3 = string.IsNullOrEmpty(f_house_sig_amt.Text) ? 0 : Convert.ToDecimal(f_house_sig_amt.Text);
                amt4 = string.IsNullOrEmpty(f_house_com_per.Text) ? 0 : Convert.ToDecimal(f_house_com_per.Text);
                amt5 = string.IsNullOrEmpty(f_house_com_amt.Text) ? 0 : Convert.ToDecimal(f_house_com_amt.Text);

                amt3 = amt1 * (amt2 / 100);
                amt3 = Math.Round(amt3, 2, MidpointRounding.AwayFromZero);
                f_house_sig_amt.Text = amt3.ToString();

                amt5 = amt1 * (amt4 / 100);
                amt5 = Math.Round(amt5, 2, MidpointRounding.AwayFromZero);
                f_house_com_amt.Text = amt5.ToString();
            }
        }

        private void work_sum(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt4 = 0, amt5 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt1 = string.IsNullOrEmpty(f_work_amt.Text) ? 0 : Convert.ToDecimal(f_work_amt.Text);
                amt4 = string.IsNullOrEmpty(f_work_com_per.Text) ? 0 : Convert.ToDecimal(f_work_com_per.Text);
                amt5 = string.IsNullOrEmpty(f_work_com_amt.Text) ? 0 : Convert.ToDecimal(f_work_com_amt.Text);

                amt5 = amt1 * (amt4 / 100);
                amt5 = Math.Round(amt5, 2, MidpointRounding.AwayFromZero);
                f_work_com_amt.Text = amt5.ToString();
            }
        }

        private void baby_sum(object sender, EventArgs e)
        {
            decimal amt1 = 0, amt4 = 0, amt5 = 0;
            if (Menu_Sel == "Add" || Menu_Sel == "Upd")
            {
                NullToZero();
                amt1 = string.IsNullOrEmpty(f_baby_amt.Text) ? 0 : Convert.ToDecimal(f_baby_amt.Text);
                amt4 = string.IsNullOrEmpty(f_baby_com_per.Text) ? 0 : Convert.ToDecimal(f_baby_com_per.Text);
                amt5 = string.IsNullOrEmpty(f_baby_com_amt.Text) ? 0 : Convert.ToDecimal(f_baby_com_amt.Text);

                amt5 = amt1 * (amt4 / 100);
                amt5 = Math.Round(amt5, 2, MidpointRounding.AwayFromZero);
                f_baby_com_amt.Text = amt5.ToString();
            }
        }

        private void f_old_amt_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_old_sig_per.Focus();
        }

        private void f_old_sig_per_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_old_com_per.Focus();
        }

        
        private void f_old_com_per_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_medic_amt.Focus();
        }

        private void f_medic_amt_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyData == Keys.Enter)
            //    f_medic_sig_per.Focus();
        }

        private void f_medic_sig_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_medic_com_per.Focus();
        }

        private void f_medic_com_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_job_amt.Focus();
        }

        private void f_job_amt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_job_sig_per.Focus();
        }

        private void f_job_sig_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_job_com_per.Focus();
        }

        private void f_job_com_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_house_amt.Focus();
        }

        private void f_house_amt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_house_sig_per.Focus();
        }

        private void f_house_sig_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_house_com_per.Focus();
        }

        private void f_house_com_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
               f_work_amt.Focus();
        }

        private void f_work_amt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_work_com_per.Focus();
        }

        private void f_work_com_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_baby_amt.Focus();
        }

        private void f_baby_amt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_baby_com_per.Focus();
        }

        private void f_baby_com_per_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_old_amt.Focus();
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

        private void pri043_KeyDown(object sender, KeyEventArgs e)
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

    }
}
