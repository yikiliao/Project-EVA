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
    public partial class pri006 : Form
    {
        int i = 0;
        static List<prt006> LS1 = new List<prt006>();
        string Menu_Sel;
        string _Type;        
        string Dept = Login.DEPT;

        public string rCode;//代碼
        public bool rOK = false;

        public pri006()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);            
            set_dept();
            D_Type_f();//下拉選單 類別
        }
        private void set_dept()
        {
            //--廠部下拉選單
            f_dept.DataSource = sst011.ToDoList().ToList();
            f_dept.DisplayMember = "dept_name";
            f_dept.ValueMember = "dept";
        }
        private void D_Type_f()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("--請選擇--", ""));
            data.Add(new DictionaryEntry("EU-教育訓練", "EU"));
            data.Add(new DictionaryEntry("LG-專長", "LG"));
            data.Add(new DictionaryEntry("SC-學歷", "SC"));
            data.Add(new DictionaryEntry("UD-講懲", "UD"));
            data.Add(new DictionaryEntry("CL-班別代號", "CL"));
            data.Add(new DictionaryEntry("WK-職稱代號", "WK"));
            data.Add(new DictionaryEntry("WT-職位代號", "WT"));
            data.Add(new DictionaryEntry("VC-假別代號", "VC"));
            f_type_f.DisplayMember = "Key";
            f_type_f.ValueMember = "Value";
            f_type_f.DataSource = data;
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

        private string f_Delete()
        {
            return string.Format("prt006{0}\n ",
                new prt006().Delete(Dept,f_type_f.SelectedValue.ToString(),f_code.Text));
        }

        private bool f_Check()
        {
            if (f_dept.Text == System.String.Empty)
            {
                Config.Show("廠部不可空白");
                f_dept.Focus();
                return false;
            }
            
            if (f_type_f.SelectedValue.ToString() == System.String.Empty)
            {
                Config.Show("請選擇分類");
                f_type_f.SelectedIndex = 1;
                f_type_f.Focus();
                return false;
            }
            if (f_code.Text == System.String.Empty)
            {
                Config.Show("代碼不可空白");
                f_code.Focus();
                return false;
            }
            return true;
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt006.ToDoList(Dept, rCode).ToList();
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
                if (idx < 0)
                    menu_first_Click(null, null);
                else
                    menu_last_Click(null, null);
            }
            else
            {
                var q_prt006 = prt006.Get(LS1[idx].Dept, LS1[idx].Type_f.ToString(), LS1[idx].Code);

                f_dept.Text = q_prt006.Dept;
                f_type_f.SelectedValue = q_prt006.Type_f.ToString();
                f_code.Text = q_prt006.Code;
                f_code_desc.Text = q_prt006.Code_desc;
                f_add_date.Text = q_prt006.Add_date.ToString();
                f_add_user.Text = q_prt006.Add_user.Trim();
                f_mod_date.Text = q_prt006.Mod_date.ToString();
                f_mod_user.Text = q_prt006.Mod_user.Trim();
                f_remark.Text = q_prt006.Remark;
                if (q_prt006.Vaild == null)
                    f_vaild_no.Checked = false;
                f_vaild_yes.Checked = false;
                if (q_prt006.Vaild == "Y")
                    f_vaild_yes.Checked = true;
                if (q_prt006.Vaild == "N")
                    f_vaild_no.Checked = true;
            }
        }

        //private void f_show(int idx)
        //{
        //    if (idx < 0 || idx > LS1.Count - 1)
        //    {
        //        MessageBox.Show("已無資料");
        //    }
        //    else
        //    {
        //        f_dept.Text = LS1[idx].Dept;
        //        f_type_f.SelectedValue = LS1[idx].Type_f.ToString();
        //        f_code.Text = LS1[idx].Code;
        //        f_code_desc.Text = LS1[idx].Code_desc;                
        //        f_add_date.Text = LS1[idx].Add_date.ToString();
        //        f_add_user.Text = LS1[idx].Add_user.Trim();
        //        f_mod_date.Text = LS1[idx].Mod_date.ToString();
        //        f_mod_user.Text = LS1[idx].Mod_user.Trim();
        //        f_remark.Text = LS1[idx].Remark;
        //        if (LS1[idx].Vaild == null)
        //            f_vaild_no.Checked = false;
        //        f_vaild_yes.Checked = false;
        //        if (LS1[idx].Vaild == "Y")
        //            f_vaild_yes.Checked = true;
        //        if (LS1[idx].Vaild == "N")
        //            f_vaild_no.Checked = true;
        //    }
        //}

        private string f_Update()
        {
            var p_prt006 = new prt006();
            p_prt006.Dept = Dept;
            p_prt006.Type_f = f_type_f.SelectedValue.ToString();
            p_prt006.Code = f_code.Text;
            p_prt006.Code_desc = f_code_desc.Text;
            var tmp_vaild = "";
            if (f_vaild_yes.Checked)
                tmp_vaild = "Y";
            if (f_vaild_no.Checked)
                tmp_vaild = "N";
            p_prt006.Vaild = tmp_vaild;
            p_prt006.Remark = f_remark.Text;
            return p_prt006.Update(p_prt006.Dept, p_prt006.Type_f, p_prt006.Code);
        }

        private string f_Insert()
        {
            var p_prt006 = new prt006();
            p_prt006.Dept = Dept;
            p_prt006.Type_f = f_type_f.SelectedValue.ToString();
            p_prt006.Code = f_code.Text;
            p_prt006.Code_desc = f_code_desc.Text;
            var tmp_vaild="";
            if (f_vaild_yes.Checked)
                tmp_vaild = "Y";
            if (f_vaild_no.Checked)
                tmp_vaild = "N";
            p_prt006.Vaild = tmp_vaild;
            p_prt006.Remark = f_remark.Text;
            return p_prt006.Insert();
        }

        private void menu_add_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Add";
            SetColumn(this);//給初值
            Col_Disable();
            f_vaild_yes.Checked = true;
            bindingNavigator1.Enabled = false;
        }

        private void Col_Disable()
        {
            f_dept.Enabled = false;
            f_type_f.SelectedIndex = 0;
        }

        private void menu_edit_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                Config.Show("請先查詢");
                return;
            }
            else
            {
                if (f_code.Text != string.Empty)
                {
                    Menu_Sel = "Upd";
                    SetMotherboard(this);
                    f_dept.Enabled = false;
                    f_type_f.Enabled = false;
                    f_code.Enabled = false;
                    f_code_desc.Focus();
                    bindingNavigator1.Enabled = false;
                }
                else
                {
                    Config.Show("請先查詢");
                    return;
                }
            }
        }

        //private void menu_edit_Click(object sender, EventArgs e)
        //{
        //    if (f_code.Text != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        f_dept.Enabled = false;                                
        //        f_type_f.Enabled = false;
        //        f_code.Enabled = false;
        //        f_code_desc.Focus();
        //    }
        //    else
        //    {
        //        MessageBox.Show("請先查詢");
        //    }
        //}

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            FormQuery();//查詢畫面
            if (rOK == true)
                confirm_Click(sender, e);//確認按鍵
            else
                InitColumn(this);//初始
            //SetColumn(this);
            //f_type_f.SelectedIndex = 0;
            //f_vaild_yes.Checked = false;
            //f_vaild_no.Checked = false;
        }

        private void FormQuery()
        {
            pri006Q fm = new pri006Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                rCode = fm.rCode;
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();
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
            if (Config.Message("是否離開?") == "Y")
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

        //private void cancel_Click(object sender, EventArgs e)
        //{
        //    i = 0;
        //    Menu_Sel = "";
        //    LS1.Clear();
        //    InitColumn(this);
        //}

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
                if (c is ComboBox)
                {
                    (c as ComboBox).Enabled = false;
                }
            }
            bindingNavigator1.Enabled = true;
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
                if (a is ComboBox)
                {
                    (a as ComboBox).Enabled = true;
                }
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



        private void pri006_KeyDown(object sender, KeyEventArgs e)
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

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                Config.Show("請先查詢");
                return;
            }
            else
            {
                if (f_code.Text != string.Empty)
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
        }

        //private void menu_del_Click(object sender, EventArgs e)
        //{
        //    if (f_code.Text != "" && Menu_Sel == "Qry")
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
