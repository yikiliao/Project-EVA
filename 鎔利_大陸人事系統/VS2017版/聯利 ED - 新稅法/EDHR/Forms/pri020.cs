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
    public partial class pri020 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt017> LS1 = new List<prt017>();
        decimal Sqe_no = 0;//序號prt016
        string iid = "";//序號
        prt016 p_prt016 = new prt016();
        string Dept = Login.DEPT;

        public pri020()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            InitColumn(this);
            set_dept();
            D_type();//下拉選單            
            D_Cdpet();//部門
            D_Work();//職稱
            D_Position();//職位
            D_Aclass();//課程類別
            D_Bit();//幣別
        }

        private void D_Position()
        {
            var idList = prt016.ToDoList(Dept, "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();
            f_tr_position.DataSource = prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList();
            f_tr_position.DisplayMember = "Code_desc";
            f_tr_position.ValueMember = "Code";
        }

        private void D_Bit()
        {
            ArrayList data = new ArrayList();
            foreach (var i in sst001.ToDoListCode().ToList())
            {
                data.Add(new DictionaryEntry(i.Code + " " + i.Code_desc, i.Code));
            }
            data.Add(new DictionaryEntry("不需費用", "NAN"));
            f_tr_ntcode.DisplayMember = "Key";
            f_tr_ntcode.ValueMember = "Value";
            f_tr_ntcode.DataSource = data;
        }

        private void D_Aclass()
        {
            f_tr_code.DataSource = prt006.ToDoListCode(Dept, "EU", "Y").ToList();
            f_tr_code.DisplayMember = "Code_desc";
            f_tr_code.ValueMember = "Code";
        }
        private void D_Cdpet()
        {
            f_tr_dept_no.DataSource = prt001.ToDoList(Dept).ToList();
            f_tr_dept_no.DisplayMember = "Department_name_new";
            f_tr_dept_no.ValueMember = "Department_code";
        }
        private void D_Work()
        {
            var idList = prt016.ToDoList(Dept, "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();
            f_tr_work_no.DataSource = prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList();
            f_tr_work_no.DisplayMember = "Code_desc";
            f_tr_work_no.ValueMember = "Code";
        }

        private void set_dept()
        {
            //--廠部下拉選單
            f_tr_comp_dept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_tr_comp_dept.DisplayMember = "dept_name";
            f_tr_comp_dept.ValueMember = "dept";
        }
        private void D_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("請選擇", ""));
            data.Add(new DictionaryEntry("0:內訓", "0"));
            data.Add(new DictionaryEntry("1:外訓", "1"));
            f_tr_type.DisplayMember = "Key";
            f_tr_type.ValueMember = "Value";
            f_tr_type.DataSource = data;
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
            get_enable();
            f_tr_amt.Value = 0;
            f_tr_time.Value = 0;
            code_dearch_bt_Click(null, null);
            f_tr_start_date.Enabled = true;
            f_tr_end_date.Enabled = true;
            f_tr_code.Enabled = true;
            f_tr_ntcode.Enabled = true;
            code_dearch_bt.Enabled = false;
        }

        private void get_enable()
        {
            f_tr_id_no.Enabled = false;
            f_tr_no.Enabled = false;
            f_tr_name.Enabled = false;
            f_tr_comp_no.Enabled = false;
            f_tr_comp_name.Enabled = false;
            f_tr_comp_dept.Enabled = false;
            f_tr_dept_no.Enabled = false;
            
            f_tr_work_no.Enabled = false;
            
            f_tr_position.Enabled = false;
            

            f_tr_start_date.Enabled = false;
            f_tr_end_date.Enabled = false;
            f_tr_code.Enabled = false;
            
            f_tr_ntcode.Enabled = false;
            f_tr_year.Enabled = false;
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
                SetColumn(a);
                if (a is TextBox)
                {
                    (a as TextBox).Text = "";
                    (a as TextBox).Enabled = true;
                    (a as TextBox).ReadOnly = false;
                }
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Value = 0;
                    (a as NumericUpDown).Enabled = true;
                    (a as NumericUpDown).ReadOnly = false;
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
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
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
                if (c is NumericUpDown)
                {
                    (c as NumericUpDown).Value = 0;
                    (c as NumericUpDown).Enabled = false;
                    (c as NumericUpDown).ReadOnly = true;
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
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
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
                if (c is NumericUpDown)
                {                   
                    (c as NumericUpDown).Enabled = false;
                    (c as NumericUpDown).ReadOnly = true;
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
                if (c is DateTimePicker)
                {
                    (c as DateTimePicker).Enabled = false;
                }
            }
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
                if (a is NumericUpDown)
                {
                    (a as NumericUpDown).Enabled = true;
                    (a as NumericUpDown).ReadOnly = false;
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
                if (a is DateTimePicker)
                {
                    (a as DateTimePicker).Enabled = true;
                }
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                if (Config.Message("確定新增?") == "Y")
                {
                    if (f_tr_no.Text == System.String.Empty)
                    {
                        Config.Show("員工編號不可空白");
                        f_tr_no.Focus();
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
                InitMotherboard(this);
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
                else
                {
                    return;
                }
                InitMotherboard(this);
            }



        }

                

        private string f_Insert()
        {            
            return String.Format("{0}\n{1}", f_Insert_prt017(), f_Insert_prt027());
        }

        private string f_Update()
        {
            return String.Format("{0}\n{1}", f_Update_prt017(), f_Update_prt027());
        }

        private string f_Delete()
        {
            return String.Format("{0}\n{1}", f_Delete_prt017(), f_Delete_prt027());
        }

        private string f_Delete_prt017()
        {
            return new prt017().Delete(f_tr_id_no.Text, System.Convert.ToDecimal(iid));
        }

        private string f_Delete_prt027()
        {
            var p_prt027 = new prt027();
            p_prt027 = prt027.Get2(f_tr_id_no.Text, iid);
            if (p_prt027 != null)
                return new prt027().Delete(p_prt027.Tr_id_no, p_prt027.Tr_sqe_no);
            else
                return "";
        }

        private string f_Update_prt017()
        {
            var p_prt017 = new prt017();
            p_prt017.Tr_id_no = f_tr_id_no.Text;
            p_prt017.Tr_sqe_no = Sqe_no;
            p_prt017.Tr_no = f_tr_no.Text;
            p_prt017.Tr_start_date = f_tr_start_date.Text;
            p_prt017.Tr_end_date = f_tr_end_date.Text;
            p_prt017.Tr_time = f_tr_time.Value;            
            p_prt017.Tr_type = f_tr_type.SelectedValue.ToString();
            p_prt017.Tr_anyno = f_tr_anyno.Text;
            p_prt017.Tr_code = f_tr_code.SelectedValue.ToString();
            p_prt017.Tr_comp_no = f_tr_comp_dept.SelectedValue.ToString();
            p_prt017.Tr_dept_no = f_tr_dept_no.SelectedValue.ToString();
            p_prt017.Tr_work_no = f_tr_work_no.SelectedValue.ToString();
            p_prt017.Tr_position = f_tr_position.SelectedValue.ToString();
            p_prt017.Tr_view = f_tr_view.Text;
            p_prt017.Tr_dept = f_tr_dept.Text;
            p_prt017.Tr_ntcode = f_tr_ntcode.SelectedValue.ToString();
            p_prt017.Tr_amt = f_tr_amt.Value;
            p_prt017.Tr_year = System.Convert.ToInt32(f_tr_year.Text);
            p_prt017.Tr_comment = f_tr_comment.Text;
            p_prt017.Dept = f_tr_comp_dept.SelectedValue.ToString();
            return p_prt017.Update(p_prt017.Tr_id_no, p_prt017.Tr_sqe_no);
        }


        private string f_Insert_prt017()
        {   
            var p_prt017 = new prt017();
            p_prt017.Tr_id_no = f_tr_id_no.Text;
            p_prt017.Tr_sqe_no = prt017.GetSqeNo(f_tr_id_no.Text);
            p_prt017.Tr_no = f_tr_no.Text;
            p_prt017.Tr_start_date = f_tr_start_date.Text;
            p_prt017.Tr_end_date = f_tr_end_date.Text;
            p_prt017.Tr_time = f_tr_time.Value;            
            p_prt017.Tr_type = f_tr_type.SelectedValue.ToString();
            p_prt017.Tr_anyno = f_tr_anyno.Text;
            p_prt017.Tr_code = f_tr_code.SelectedValue.ToString();
            p_prt017.Tr_comp_no = f_tr_comp_dept.SelectedValue.ToString();
            p_prt017.Tr_dept_no = f_tr_dept_no.SelectedValue.ToString();
            p_prt017.Tr_work_no = f_tr_work_no.SelectedValue.ToString();
            p_prt017.Tr_position = f_tr_position.SelectedValue.ToString();
            p_prt017.Tr_view = f_tr_view.Text;
            p_prt017.Tr_dept = f_tr_dept.Text;
            p_prt017.Tr_ntcode = f_tr_ntcode.SelectedValue.ToString();
            p_prt017.Tr_amt = f_tr_amt.Value;
            p_prt017.Tr_year = System.Convert.ToInt32(f_tr_year.Text);
            p_prt017.Tr_comment = f_tr_comment.Text;
            p_prt017.Dept = f_tr_comp_dept.SelectedValue.ToString();
            iid = p_prt017.Tr_sqe_no.ToString(); //prt017序號不等於異動檔prt027序號
            return p_prt017.Insert();
        }

        private string f_Insert_prt027()
        {   
            var p_prt027 = new prt027();
            p_prt027.Tr_id_no = f_tr_id_no.Text;
            p_prt027.Tr_sqe_no = prt027.GetSqeNo(f_tr_id_no.Text);
            p_prt027.Tr_type = "E";
            p_prt027.Tr_start_date = f_tr_start_date.Text;
            p_prt027.Tr_end_date = f_tr_end_date.Text;
            p_prt027.Tr_comp = f_tr_comp_dept.SelectedValue.ToString();
            p_prt027.Tr_dept_no = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_wk_dept = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_move_code = f_tr_code.SelectedValue.ToString();
            p_prt027.Tr_posit = null;
            p_prt027.Tr_old_comp = f_tr_comp_dept.SelectedValue.ToString();
            p_prt027.Tr_old_dept = null;
            p_prt027.Tr_old_wk = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_old_posit = f_tr_position.SelectedValue.ToString();
            p_prt027.Tr_old_code = f_tr_work_no.SelectedValue.ToString();
            p_prt027.Tr_move_amt = f_tr_amt.Value;
            p_prt027.Tr_old_amt = f_tr_time.Value;
            p_prt027.Tr_t1 = iid;
            p_prt027.Tr_t2 = null;
            p_prt027.Tr_t3 = null;
            p_prt027.Tr_comment = string.IsNullOrEmpty(f_tr_comment.Text) ? "教育訓練" : f_tr_comment.Text;
            p_prt027.Tr_list_flag_ok = null;
            p_prt027.Pr_no = f_tr_no.Text;
            p_prt027.CraeteDate = DateTime.Now;
            return p_prt027.Insert();
        }
               


        private string f_Update_prt027()
        {   
            var p_prt027 = new prt027();
            p_prt027 = prt027.Get2(f_tr_id_no.Text, iid);
            p_prt027.Tr_type = "E";
            p_prt027.Tr_start_date = f_tr_start_date.Text;
            p_prt027.Tr_end_date = f_tr_end_date.Text;
            p_prt027.Tr_comp = f_tr_comp_dept.SelectedValue.ToString();
            p_prt027.Tr_dept_no = f_tr_comp_dept.SelectedValue.ToString();
            p_prt027.Tr_wk_dept = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_move_code = f_tr_code.SelectedValue.ToString();
            p_prt027.Tr_posit = null;
            p_prt027.Tr_old_comp = f_tr_comp_dept.SelectedValue.ToString();
            p_prt027.Tr_old_dept = null;
            p_prt027.Tr_old_wk = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_old_posit = f_tr_position.SelectedValue.ToString();
            p_prt027.Tr_old_code = f_tr_work_no.SelectedValue.ToString();
            p_prt027.Tr_move_amt = f_tr_amt.Value;
            p_prt027.Tr_old_amt = f_tr_time.Value;
            p_prt027.Tr_t1 = iid;
            p_prt027.Tr_t2 = null;
            p_prt027.Tr_t3 = null;
            p_prt027.Tr_comment = f_tr_comment.Text;
            p_prt027.Tr_list_flag_ok = null;
            return p_prt027.Update(p_prt027.Tr_id_no,p_prt027.Tr_sqe_no);
        }
                

        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            SetColumn(this);
        }

        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt017.ToDoList(f_tr_id_no.Text, f_tr_no.Text, f_tr_comp_dept.SelectedValue.ToString()).ToList();
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
                DateTime dtDate;

                Find_p2(prt016.GetWithIdno(LS1[idx].Tr_id_no).Pr_no, LS1[idx].Dept);

                f_tr_start_date.Text = LS1[idx].Tr_start_date;
                //--判斷是否日期;如果是再給值
                if (DateTime.TryParse(LS1[idx].Tr_start_date, out dtDate))
                {                    
                    f_tr_start_date_dt.Value = System.Convert.ToDateTime(LS1[idx].Tr_start_date);
                }

                f_tr_end_date.Text = LS1[idx].Tr_end_date;
                if (DateTime.TryParse(LS1[idx].Tr_end_date, out dtDate))
                {
                    f_tr_end_date_dt.Value = System.Convert.ToDateTime(LS1[idx].Tr_end_date);
                }
                                
                f_tr_time.Value = LS1[idx].Tr_time;
                f_tr_type.SelectedValue = LS1[idx].Tr_type.ToString();
                f_tr_anyno.Text = LS1[idx].Tr_anyno;
                f_tr_code.SelectedValue = LS1[idx].Tr_code;
                
                f_tr_view.Text = LS1[idx].Tr_view;
                f_tr_dept.Text = LS1[idx].Tr_dept;
                f_tr_ntcode.SelectedValue = LS1[idx].Tr_ntcode;
                f_tr_amt.Value = LS1[idx].Tr_amt;
                f_tr_year.Text = LS1[idx].Tr_year.ToString();
                f_tr_comment.Text = LS1[idx].Tr_comment;

                f_add_user.Text = LS1[idx].Add_user;
                f_add_date.Text = LS1[idx].Add_date;
                f_mod_user.Text = LS1[idx].Mod_user;
                f_mod_date.Text = LS1[idx].Mod_date;

                Sqe_no = LS1[idx].Tr_sqe_no;
                iid = Sqe_no.ToString();
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
            if (f_tr_no.Text != "" && Menu_Sel == "Qry")
            {
                Menu_Sel = "Upd";
                SetMotherboard(this);
                //SetMotherboard(Motherboard);
                get_enable();
                code_dearch_bt.Enabled = false;
                f_tr_time.Focus();
            }
            else
            {
                Config.Show("請先查詢");
            }
        }
        
        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            string _type = "";
            if (Menu_Sel == "Add")
                _type = "I";//在職
            if (Menu_Sel == "Qry")
                _type = null;//全部

            pri019w fm = new pri019w(_type, f_tr_comp_dept.SelectedValue.ToString());//開視窗資料
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_tr_no.Text = fm.Code as string;
                f_tr_name.Text = fm.Code_desc as string;
                //找相關資料顯示出來
                Find_p(f_tr_no.Text);
            }
        }

        private void Find_p(string Pr_no)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_tr_no.Text = p_prt016.Pr_no;
            f_tr_name.Text = p_prt016.Pr_name;
            f_tr_id_no.Text = p_prt016.Pr_idno;
            f_tr_comp_dept.SelectedValue = p_prt016.Pr_dept;
            f_tr_dept_no.SelectedValue = p_prt016.Pr_cdept;
            f_tr_work_no.SelectedValue = p_prt016.Pr_work;
            f_tr_position.SelectedValue = p_prt016.Position;
        }

        private void Find_p2(string Pr_no,string Dept)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_tr_no.Text = p_prt016.Pr_no;
            f_tr_name.Text = p_prt016.Pr_name;
            f_tr_id_no.Text = p_prt016.Pr_idno;
            f_tr_comp_dept.SelectedValue = Dept;
            f_tr_dept_no.SelectedValue = p_prt016.Pr_cdept;          

            f_tr_work_no.SelectedValue = p_prt016.Pr_work;            
            f_tr_position.SelectedValue = p_prt016.Position;
        }

        private void f_tr_end_date_dt_ValueChanged(object sender, EventArgs e)
        {
            f_tr_end_date.Text = f_tr_end_date_dt.Value.ToString("yyyy/MM/dd");
        }

        private void f_tr_start_date_dt_ValueChanged(object sender, EventArgs e)
        {
            if (Menu_Sel == "Add")
            {
                f_tr_start_date.Text = f_tr_start_date_dt.Value.ToString("yyyy/MM/dd");
                f_tr_end_date.Text = f_tr_start_date_dt.Value.ToString("yyyy/MM/dd");
                f_tr_year.Text = f_tr_start_date_dt.Value.Year.ToString();
            }

        }
               
        
        private void f_tr_year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 48 || (byte)e.KeyChar > 57)//若小於0或大於9 
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true; //不可輸;鎖起來
                }
            }

        }

        
        

        private void f_tr_view_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_tr_dept.Focus();
        }

        private void f_tr_dept_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_tr_comment.Focus();
        }

        private void f_tr_anyno_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_tr_view.Focus();
        }

        private void f_tr_type_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                f_tr_anyno.Focus();
        }

        private void f_tr_start_date_dt_MouseUp(object sender, MouseEventArgs e)
        {
            f_tr_start_date_dt_ValueChanged(sender, e);
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

        private void pri020_KeyDown(object sender, KeyEventArgs e)
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

        private void menu_del_Click(object sender, EventArgs e)
        {
            if (f_tr_no.Text != string.Empty)
            {
                if (p_prt016.Pr_leave_date != string.Empty)
                {
                    Config.Show("已離職無法異動");
                    return;
                }
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

        private void f_tr_ntcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Menu_Sel == "Add" || Menu_Sel == "Upd") && f_tr_ntcode.SelectedValue.ToString() == "NAN")
            {
                f_tr_amt.Value = 0;
            }

        }


    }
}
