using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using EDHR.Models;

namespace EDHR.Forms
{
    public partial class ssi011 : Form
    {
        int i = 0;
        static List<sst011> LS1 = new List<sst011>();
        ssi001w fm = new ssi001w();//開視窗資料
        string Menu_Sel;
        public ssi011()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            //Comb1();//下拉選單類別
           // Comb2();//下拉選單付款基準日期
            //Comb3();//下拉選單票據日期
        }

        

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {                
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_company.Text == System.String.Empty)
                    {   
                        Config.Show("代碼不可空白");
                        f_company.Focus();
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

            if (Menu_Sel == "Qry")
            {
                f_Query();
                InitMotherboard(Motherboard);
            }
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1= sst011.ToDoList(Login.DEPT).ToList();
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
                f_company.Text = LS1[idx].Company;

                f_company_shname.Text = LS1[idx].Company_shname;
                f_company_name.Text = LS1[idx].Company_name;
                f_company_address1.Text = LS1[idx].Company_address1;
                f_company_address2.Text = LS1[idx].Company_address2;
                f_company_man.Text = LS1[idx].Company_man;
                f_company_license.Text = LS1[idx].Company_license;
                f_company_taxid.Text = LS1[idx].Company_taxid;
                f_company_taxno.Text = LS1[idx].Company_taxno;
                f_company_labor.Text = LS1[idx].Company_labor;
                f_company_health.Text = LS1[idx].Company_health;
                f_phone.Text = LS1[idx].Phone;
                f_fax.Text = LS1[idx].Fax;
                f_en_name.Text = LS1[idx].En_name;
                f_en_address.Text = LS1[idx].En_address;
                f_accounting_currency.Text = LS1[idx].Accounting_currency;
                f_add_date.Text = LS1[idx].Add_date.ToString();
                f_add_user.Text = LS1[idx].Add_user.Trim();
                f_mod_date.Text = LS1[idx].Mod_date.ToString();
                f_mod_user.Text = LS1[idx].Mod_user.Trim();
                f_remark.Text = LS1[idx].Remark;
                if (LS1[idx].Vaild == null)
                    f_vaild_no.Checked = false;
                f_vaild_yes.Checked = false;
                if (LS1[idx].Vaild == "Y")
                    f_vaild_yes.Checked = true;
                if (LS1[idx].Vaild == "N")
                    f_vaild_no.Checked = true;
            }
        }

        private string f_Update()
        {
            var p_sst011 = new sst011();
            p_sst011.Company = f_company.Text;
            p_sst011.Company_shname = f_company_shname.Text;
            p_sst011.Company_name = f_company_name.Text;
            p_sst011.Company_address1 = f_company_address1.Text;
            p_sst011.Company_address2 = f_company_address2.Text;
            p_sst011.Company_man = f_company_man.Text;
            p_sst011.Company_license = f_company_license.Text;
            p_sst011.Company_taxid = f_company_taxid.Text;
            p_sst011.Company_taxno = f_company_taxno.Text;
            p_sst011.Company_labor = f_company_labor.Text;
            p_sst011.Company_health = f_company_health.Text;
            p_sst011.Phone = f_phone.Text;
            p_sst011.Fax = f_fax.Text;
            p_sst011.En_name = f_en_name.Text;
            p_sst011.En_address = f_en_address.Text;
            p_sst011.Accounting_currency = f_accounting_currency.Text;
            
            var tmp_vaild = "";
            if (f_vaild_yes.Checked)
                tmp_vaild = "Y";
            if (f_vaild_no.Checked)
                tmp_vaild = "N";
            p_sst011.Vaild = tmp_vaild;
            p_sst011.Remark = f_remark.Text;
            return p_sst011.Update(p_sst011.Company);
        }

        private string f_Insert()
        {
            var p_sst011 = new sst011();
            p_sst011.Company = f_company.Text;
            p_sst011.Company_shname = f_company_shname.Text;
            p_sst011.Company_name = f_company_name.Text;
            p_sst011.Company_address1 = f_company_address1.Text;
            p_sst011.Company_address2 = f_company_address2.Text;
            p_sst011.Company_man = f_company_man.Text;
            p_sst011.Company_license = f_company_license.Text;
            p_sst011.Company_taxid = f_company_taxid.Text;
            p_sst011.Company_taxno = f_company_taxno.Text;
            p_sst011.Company_labor = f_company_labor.Text;
            p_sst011.Company_health = f_company_health.Text;
            p_sst011.Phone = f_phone.Text;
            p_sst011.Fax = f_fax.Text;
            p_sst011.En_name = f_en_name.Text;
            p_sst011.En_address = f_en_address.Text;
            p_sst011.Accounting_currency = f_accounting_currency.Text;
            var tmp_vaild="";
            if (f_vaild_yes.Checked)
                tmp_vaild = "Y";
            if (f_vaild_no.Checked)
                tmp_vaild = "N";
            p_sst011.Vaild = tmp_vaild;
            p_sst011.Remark = f_remark.Text;
            return p_sst011.Insert();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);//給初值            
            f_vaild_yes.Checked = true;
            f_accounting_currency.Enabled = false;
        }

        

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (f_company.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(Motherboard);
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
            Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            i = 0;
            Menu_Sel = "";
            LS1.Clear();
            InitColumn(this);
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

        
       

        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_accounting_currency.Text = fm.Code as string;
            }
        }

        private void f_add_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void Motherboard_Paint(object sender, PaintEventArgs e)
        {

        }

        

    }
}
