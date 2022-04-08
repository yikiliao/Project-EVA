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

using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace EVAERP.Forms
{
    public partial class pri020 : Form
    {
        int i = 0;
        string Menu_Sel;
        static List<prt017> LS1 = new List<prt017>();
        decimal Sqe_no = 0;//序號prt016
        string iid = "";//序號
        string Dept = Login.DEPT;
        prt016 p_prt016 = new prt016();

        public string rPrno;//工號
        public string rTrtype;//內外訓別
        public string rTrcode;//課程類別
        public string rTryear;//訓練年度
        public bool rOK = false;//按下確認鍵
        //DateTime rCreateDate;

        string Docname = string.Empty;
        long rSize = -1;  //檔案大小        
        string Extension = string.Empty;//副檔名

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
            f_tr_type.SelectedIndex = 1;

            //--文件處理
            Docname = string.Empty;
            filename.Enabled = false;            
            File_Delete();//刪除存在的文件
        }

        
        private void set_dept()
        {
            //--廠部下拉選單
            f_tr_comp_dept.DataSource = sst011.ToDoList().ToList();
            f_tr_comp_dept.DisplayMember = "dept_name";
            f_tr_comp_dept.ValueMember = "dept";
        }

        private void D_Cdpet()
        {
            f_tr_dept_no.DataSource = prt001.ToDoList(Dept).ToList();
            f_tr_dept_no.DisplayMember = "Department_name_new";
            f_tr_dept_no.ValueMember = "Department_code";
        }

        //private void D_Cdpet()
        //{
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt001.ToDoList(Dept).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Department_name_new, i.Department_code));
        //    }
        //    f_tr_dept_no.DisplayMember = "Key";
        //    f_tr_dept_no.ValueMember = "Value";
        //    f_tr_dept_no.DataSource = data;
        //}

        private void D_Position()
        {
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();
            f_tr_position.DataSource = prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList();
            f_tr_position.DisplayMember = "Code_desc";
            f_tr_position.ValueMember = "Code";
        }

        //private void D_Position()
        //{
        //    var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Position).Distinct().ToList();
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "WT", "Y").Where(m => idList.Contains(m.Code)).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_tr_position.DisplayMember = "Key";
        //    f_tr_position.ValueMember = "Value";
        //    f_tr_position.DataSource = data;
        //}

        private void D_Work()
        {
            var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();
            f_tr_work_no.DataSource = prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList();
            f_tr_work_no.DisplayMember = "Code_desc";
            f_tr_work_no.ValueMember = "Code";
        }

        //private void D_Work()
        //{
        //    var idList = prt016.ToDoList("L", "", "", "", "", "", "").Select(m => m.Pr_work).Distinct().ToList();
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "WK", "Y").Where(m => idList.Contains(m.Code)).ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_tr_work_no.DisplayMember = "Key";
        //    f_tr_work_no.ValueMember = "Value";
        //    f_tr_work_no.DataSource = data;
        //}

        private void D_Aclass()
        {
            f_tr_code.DataSource = prt006.ToDoListCode(Dept, "EU", "Y").ToList();
            f_tr_code.DisplayMember = "Code_desc";
            f_tr_code.ValueMember = "Code";
            
        }

        //private void D_Aclass()
        //{
        //    ArrayList data = new ArrayList();
        //    foreach (var i in prt006.ToDoListCode(Dept, "EU", "Y").ToList())
        //    {
        //        data.Add(new DictionaryEntry(i.Code_desc, i.Code));
        //    }
        //    f_tr_code.DisplayMember = "Key";
        //    f_tr_code.ValueMember = "Value";
        //    f_tr_code.DataSource = data;
        //}


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

        private void D_type()
        {
            List<prt006> LI = new List<prt006>();
            LI.Add(new prt006 { Code_desc = "請選擇", Code = "" });
            LI.Add(new prt006 { Code_desc = "0:內訓", Code = "0" });
            LI.Add(new prt006 { Code_desc = "1:外訓", Code = "1" });
            f_tr_type.DataSource = LI;
            f_tr_type.DisplayMember = "Code_desc";
            f_tr_type.ValueMember = "Code";
        }

        //private void D_type()
        //{
        //    ArrayList data = new ArrayList();
        //    data.Add(new DictionaryEntry("請選擇", ""));
        //    data.Add(new DictionaryEntry("0:內訓", "0"));
        //    data.Add(new DictionaryEntry("1:外訓", "1"));
        //    f_tr_type.DisplayMember = "Key";
        //    f_tr_type.ValueMember = "Value";
        //    f_tr_type.DataSource = data;
        //}

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            {
                File_Delete();//刪除文件
                this.Close();
            }
        }

        private void menu_add_Click(object sender, EventArgs e)
        {            
            Menu_Sel = "Add";
            SetColumn(this);
            get_enable();
            f_tr_amt.Value = 0;//金額
            f_tr_time.Value = 0;//受訓時數
            f_tr_no.Enabled = true;
            f_tr_start_date_dt.Value = DateTime.Now;
            bindingNavigator1.Enabled = false;
            butRead.Enabled = false;
            Docname = string.Empty;
            filename.Enabled = false;
        }

        private void get_enable()
        {
            f_tr_id_no.Enabled = false;
            f_tr_no.Enabled = false;
            f_tr_name.Enabled = false;
            f_tr_comp_dept.Enabled = false;
            f_tr_dept_no.Enabled = false;
            f_tr_work_no.Enabled = false;
            f_tr_position.Enabled = false;
            f_tr_year.Enabled = false;
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
                    Docname = string.Empty;
                    filename.Enabled = false;
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

                        //--文件上傳處理
                        if (filename.Text != string.Empty)
                            prt039.Doc_Insert(Docname, f_tr_no.Text, iid, Extension, rSize);
                        
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
                Docname = string.Empty;
                filename.Enabled = false;
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

                        //--文件修改處理
                        if (filename.Text != string.Empty)
                        {
                            prt039.Doc_Delete(f_tr_no.Text, iid);//刪除資料
                            prt039.Doc_Insert(Docname, f_tr_no.Text, iid, Extension, rSize);//新增資料
                        }
                        else
                            prt039.Doc_Delete(f_tr_no.Text, iid);//刪除資料
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
                        prt039.Doc_Delete(f_tr_no.Text, iid); //刪除上傳資料

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
                            Docname = string.Empty;                            
                            filename.Enabled = false;
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
            p_prt017.Tr_comp_no = Dept;            
            p_prt017.Tr_dept_no = f_tr_dept_no.SelectedValue.ToString();
            p_prt017.Tr_work_no = f_tr_work_no.SelectedValue.ToString();
            p_prt017.Tr_position = f_tr_position.SelectedValue.ToString();
            p_prt017.Tr_view = f_tr_view.Text;            
            p_prt017.Tr_dept = string.IsNullOrEmpty(f_tr_dept.Text) ? "" : f_tr_dept.Text;
            p_prt017.Tr_ntcode = f_tr_ntcode.SelectedValue.ToString();
            p_prt017.Tr_amt = f_tr_amt.Value;
            p_prt017.Tr_year = System.Convert.ToInt32(f_tr_year.Text);
            p_prt017.Tr_comment = f_tr_comment.Text;
            p_prt017.Dept = f_tr_comp_dept.SelectedValue.ToString();
            return p_prt017.Update(p_prt017.Tr_id_no, p_prt017.Tr_sqe_no);
        }


        private string f_Update_prt027()
        {
            var p_prt027 = new prt027();
            p_prt027 = prt027.Get2(f_tr_id_no.Text, iid);
            p_prt027.Tr_type = "E";
            p_prt027.Tr_start_date = f_tr_start_date.Text;
            p_prt027.Tr_end_date = f_tr_end_date.Text;
            p_prt027.Tr_comp = f_tr_comp_dept.SelectedValue.ToString();
            p_prt027.Tr_dept_no = Dept;
            p_prt027.Tr_wk_dept = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_move_code = f_tr_code.SelectedValue.ToString();
            p_prt027.Tr_posit = null;
            p_prt027.Tr_old_comp = f_tr_comp_dept.SelectedValue.ToString();
            p_prt027.Tr_old_dept = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_old_wk = null;
            p_prt027.Tr_old_posit = f_tr_position.SelectedValue.ToString();
            p_prt027.Tr_old_code = f_tr_work_no.SelectedValue.ToString();
            p_prt027.Tr_move_amt = f_tr_amt.Value;
            p_prt027.Tr_old_amt = f_tr_time.Value;
            p_prt027.Tr_t1 = iid;
            p_prt027.Tr_t2 = null;
            p_prt027.Tr_t3 = null;
            p_prt027.Tr_comment = string.IsNullOrEmpty(f_tr_comment.Text) ? "教育訓練" : f_tr_comment.Text;
            p_prt027.Tr_list_flag_ok = null;
            return p_prt027.Update(p_prt027.Tr_id_no, p_prt027.Tr_sqe_no);
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
            p_prt017.Tr_dept = string.IsNullOrEmpty(f_tr_dept.Text) ? "" : f_tr_dept.Text;
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
            p_prt027.Tr_dept_no = Dept;
            p_prt027.Tr_wk_dept = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_move_code = f_tr_code.SelectedValue.ToString();
            p_prt027.Tr_posit = null;
            p_prt027.Tr_old_comp = f_tr_comp_dept.SelectedValue.ToString();            
            p_prt027.Tr_old_dept = f_tr_dept_no.SelectedValue.ToString();
            p_prt027.Tr_old_wk = null;
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
            p_prt027.CreateDate = DateTime.Now;
            return p_prt027.Insert();
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
        
        private void menu_query_Click(object sender, EventArgs e)
        {
            Menu_Sel = "Qry";
            InitColumn(this);
            Docname = string.Empty;            
            filename.Enabled = false;
            FormQuery();//查詢畫面
            if (rOK == true)
                confirm_Click(sender, e);//確認按鍵
            else
                InitColumn(this);//初始
        }

        private void FormQuery()
        {
            pri020Q fm = new pri020Q();
            if (fm.ShowDialog() == DialogResult.OK)
            {
                
                rPrno = fm.rPrno;//工號
                rTrtype = fm.rTrtype;//內外訓
                rTrcode = fm.rTrcode;//課程類別
                rTryear = fm.rTryear;// 年度
                rOK = true;
            }
            else
            {
                rOK = false;
            }
            fm.Dispose();
        }
        private void f_Query()
        {
            LS1.Clear();
            LS1 = prt017.ToDoList(Dept,rPrno,rTrtype,rTrcode,rTryear).ToList();
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
                var q_prt017 = prt017.Get(LS1[idx].Tr_id_no, LS1[idx].Tr_sqe_no);
                
                DateTime dtDate;

                Find_p2(prt016.GetWithIdno(q_prt017.Tr_id_no).Pr_no, q_prt017.Dept);

                f_tr_start_date.Text = q_prt017.Tr_start_date;
                //--判斷是否日期;如果是再給值
                if (DateTime.TryParse(q_prt017.Tr_start_date, out dtDate))
                {
                    f_tr_start_date_dt.Value = System.Convert.ToDateTime(q_prt017.Tr_start_date);
                }

                f_tr_end_date.Text = q_prt017.Tr_end_date;
                if (DateTime.TryParse(q_prt017.Tr_end_date, out dtDate))
                {
                    f_tr_end_date_dt.Value = System.Convert.ToDateTime(q_prt017.Tr_end_date);
                }

                f_tr_time.Value = q_prt017.Tr_time;
                f_tr_type.SelectedValue = q_prt017.Tr_type.ToString();
                f_tr_anyno.Text = q_prt017.Tr_anyno;
                f_tr_code.SelectedValue = q_prt017.Tr_code;
                f_tr_view.Text = q_prt017.Tr_view;
                f_tr_dept.Text = q_prt017.Tr_dept;
                f_tr_ntcode.SelectedValue = q_prt017.Tr_ntcode;
                f_tr_amt.Value = q_prt017.Tr_amt;
                f_tr_year.Text = q_prt017.Tr_year.ToString();
                f_tr_comment.Text = q_prt017.Tr_comment;

                f_add_user.Text = q_prt017.Add_user;
                f_add_date.Text = q_prt017.Add_date;
                f_mod_user.Text = q_prt017.Mod_user;
                f_mod_date.Text = q_prt017.Mod_date;

                Sqe_no = q_prt017.Tr_sqe_no;
                iid = Sqe_no.ToString();
                

                //刪除c:\file.doc文件
                File_Delete();

                //把文件放在c:\file.doc
                prt039.File_Put(f_tr_no.Text, iid);

                //有資料 讀取心得報告按鈕生效 顯示暫存路徑檔名
                FbutRead();
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
        //        DateTime dtDate;

        //        Find_p2(prt016.GetWithIdno(LS1[idx].Tr_id_no).Pr_no, LS1[idx].Dept);

        //        f_tr_start_date.Text = LS1[idx].Tr_start_date;
        //        //--判斷是否日期;如果是再給值
        //        if (DateTime.TryParse(LS1[idx].Tr_start_date, out dtDate))
        //        {                    
        //            f_tr_start_date_dt.Value = System.Convert.ToDateTime(LS1[idx].Tr_start_date);
        //        }

        //        f_tr_end_date.Text = LS1[idx].Tr_end_date;
        //        if (DateTime.TryParse(LS1[idx].Tr_end_date, out dtDate))
        //        {
        //            f_tr_end_date_dt.Value = System.Convert.ToDateTime(LS1[idx].Tr_end_date);
        //        }
                                
        //        f_tr_time.Value = LS1[idx].Tr_time;
        //        f_tr_type.SelectedValue = LS1[idx].Tr_type.ToString();
        //        f_tr_anyno.Text = LS1[idx].Tr_anyno;
        //        f_tr_code.SelectedValue = LS1[idx].Tr_code;
        //        //f_tr_code_name.Text = prt006.Get(f_tr_comp_dept.SelectedValue.ToString(), "EU", LS1[idx].Tr_code)==null ? "" : prt006.Get(f_tr_comp_dept.SelectedValue.ToString(), "EU", LS1[idx].Tr_code).Code_desc;
        //        f_tr_view.Text = LS1[idx].Tr_view;
        //        f_tr_dept.Text = LS1[idx].Tr_dept;
        //        f_tr_ntcode.SelectedValue = LS1[idx].Tr_ntcode;
        //        f_tr_amt.Value = LS1[idx].Tr_amt;
        //        f_tr_year.Text = LS1[idx].Tr_year.ToString();
        //        f_tr_comment.Text = LS1[idx].Tr_comment;

        //        f_add_user.Text = LS1[idx].Add_user;
        //        f_add_date.Text = LS1[idx].Add_date;
        //        f_mod_user.Text = LS1[idx].Mod_user;
        //        f_mod_date.Text = LS1[idx].Mod_date;

        //        Sqe_no = LS1[idx].Tr_sqe_no;
        //        iid = Sqe_no.ToString();
        //    }
        //}

        private void menu_first_Click(object sender, EventArgs e)
        {
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
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
            if (f_tr_no.Text != string.Empty)
            {
                if ( p_prt016.Pr_leave_date != string.Empty)
                {
                    Config.Show("已離職無法異動");
                    return;
                }
                Menu_Sel = "Upd";
                SetMotherboard(this);
                get_enable();
                code_dearch_bt.Enabled = false;
                f_tr_time.Focus();
                bindingNavigator1.Enabled = false;

                //--文件按鈕處理
                butRead.Enabled = false;
                filename.Enabled = false;
                butDnLoad.Enabled = true; //刪除文件按鈕                
            }
            else
            {
                Config.Show("請先查詢");
                return;
            }
        }

        //private void menu_edit_Click(object sender, EventArgs e)
        //{
        //    if (f_tr_no.Text != "" && Menu_Sel == "Qry")
        //    {
        //        Menu_Sel = "Upd";
        //        SetMotherboard(this);
        //        get_enable();
        //        code_dearch_bt.Enabled = false;
        //        f_tr_time.Focus();
        //    }
        //    else
        //    {
        //        Config.Show("請先查詢");
        //    }
        //}
        
        private void code_dearch_bt_Click(object sender, EventArgs e)
        {
            string _type = "";
            if (Menu_Sel == "Add")
                _type = "I";//在職
            if (Menu_Sel == "Qry")
                _type = null;//全部

            pri019w fm = new pri019w(_type,f_tr_comp_dept.SelectedValue.ToString());//開視窗資料
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
            //f_tr_dept_name.Text = prt001.Get(f_tr_dept_no.Text) == null ? "" : prt001.Get(f_tr_dept_no.Text).Department_name_new;            
            f_tr_work_no.SelectedValue = p_prt016.Pr_work;
            //f_tr_work_name.Text = prt003.Get(f_tr_work_no.Text) == null ? "" : prt003.Get(f_tr_work_no.Text).Code_desc;
            f_tr_position.SelectedValue = p_prt016.Position;
            //f_tr_position_name.Text = prt002.Get(f_tr_position.Text) == null ? "" : prt002.Get(f_tr_position.Text).Code_desc;
            
        }

        private void Find_p2(string Pr_no,string Dept)
        {
            p_prt016 = prt016.Get(Pr_no);
            f_tr_no.Text = p_prt016.Pr_no;
            f_tr_name.Text = p_prt016.Pr_name;
            f_tr_id_no.Text = p_prt016.Pr_idno;            
            f_tr_comp_dept.SelectedValue = Dept;
            f_tr_dept_no.SelectedValue = p_prt016.Pr_cdept;
            //f_tr_dept_name.Text = prt001.Get(p_prt016.Pr_cdept) == null ? "" : prt001.Get(p_prt016.Pr_cdept).Department_name_new;

            f_tr_work_no.SelectedValue = p_prt016.Pr_work;
            //f_tr_work_name.Text = prt003.Get(f_tr_work_no.Text) == null ? "" : prt003.Get(f_tr_work_no.Text).Code_desc;
            f_tr_position.SelectedValue = p_prt016.Position;
            //f_tr_position_name.Text = prt002.Get(f_tr_position.Text) == null ? "" : prt002.Get(f_tr_position.Text).Code_desc;

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

        private void f_tr_time_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void f_tr_ntcode_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((byte)e.KeyChar < 48 || (byte)e.KeyChar > 57)//若小於0或大於9 
            {
                if ((byte)e.KeyChar != 8)//不是退位鍵
                {
                    e.Handled = true; //不可輸;鎖起來
                }
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

        //private void f_tr_ntcode_bt_Click(object sender, EventArgs e)
        //{
        //    ssi001w fm = new ssi001w();//開視窗資料-幣別
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_tr_ntcode.Text = fm.Code as string;
        //    }
        //}

        //private void f_tr_code_bt_Click(object sender, EventArgs e)
        //{            
        //    pri006w fm = new pri006w(f_tr_comp_dept.SelectedValue.ToString(), "EU");//開視窗資料-課程類別
        //    if (fm.ShowDialog() == DialogResult.OK)
        //    {
        //        f_tr_code.Text = fm.Code as string;
        //        //f_tr_code_name.Text = fm.Code_desc as string;
        //    }
        //}

        private void f_tr_time_KeyUp(object sender, KeyEventArgs e)
        {

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
            //新增(F1)            
            if (e.KeyCode == Keys.F1)
            {
                menu_add_Click(sender, e);
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

        private void f_tr_ntcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((Menu_Sel == "Add" || Menu_Sel == "Upd") && f_tr_ntcode.SelectedValue.ToString() == "NAN")
            {
                f_tr_amt.Value = 0;
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

        private void pri020_Load(object sender, EventArgs e)
        {
            Form_Rigth();
            
        }

        private void Form_Rigth()
        {
            f_tr_amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tr_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            f_tr_year.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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

        //檔案上傳
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileDialog fdl = new OpenFileDialog();
                fdl.Title = "請選擇";
                fdl.InitialDirectory = @"C:\";
                fdl.Filter = "Image File(*.txt;*.doc;*.docx;*.xls;*.xlsx;*.jpg;*.bmp;*.gif;*.pdf;*.wmv)|*.txt;*doc;*docx;*xls;*xlsx;*.jpg;*.bmp;*.gif;*.pdf;*.wmv";                
                if (fdl.ShowDialog() == DialogResult.OK)
                {   
                    rSize = new FileInfo(fdl.FileName).Length; //檔案大小
                    Extension = Path.GetExtension(fdl.FileName);//副檔名
                    
                    Docname = fdl.FileName;
                    filename.Text = Docname;
                }
                fdl = null;
                //Imagedel = "N";
            }
            catch (System.ApplicationException es)
            {

                Config.Show(es.Message.ToString());
            }

            catch (Exception ex)
            {
                Config.Show(ex.Message.ToString());
            }
            
        }


        private void File_Delete()
        {
            //刪除存在的文件
            FileInfo delFile_1 = new FileInfo(@"C:\file.txt");
            if (delFile_1.Exists)
                delFile_1.Delete();
            FileInfo delFile_2 = new FileInfo(@"C:\file.docx");
            if (delFile_2.Exists)
                delFile_2.Delete();
            FileInfo delFile_3 = new FileInfo(@"C:\file.xlsx");
            if (delFile_3.Exists)
                delFile_3.Delete();
            FileInfo delFile_4 = new FileInfo(@"C:\file.wmv");
            if (delFile_4.Exists)
                delFile_4.Delete();
            FileInfo delFile_5 = new FileInfo(@"C:\file.pdf");
            if (delFile_5.Exists)
                delFile_5.Delete();
            FileInfo delFile_6 = new FileInfo(@"C:\file.jpg");
            if (delFile_6.Exists)
                delFile_6.Delete();
            FileInfo delFile_7 = new FileInfo(@"C:\file.bmp");
            if (delFile_7.Exists)
                delFile_7.Delete();
            FileInfo delFile_8 = new FileInfo(@"C:\file.gif");
            if (delFile_8.Exists)
                delFile_8.Delete();
            FileInfo delFile_9 = new FileInfo(@"C:\file.doc");
            if (delFile_9.Exists)
                delFile_9.Delete();
            FileInfo delFile_10 = new FileInfo(@"C:\file.xls");
            if (delFile_10.Exists)
                delFile_10.Delete();
        }
                
                
        //開啟外部檔
        private void butRead_Click(object sender, EventArgs e)
        {
            if (new FileInfo(@"C:\file.txt").Exists)  System.Diagnostics.Process.Start(@"C:\file.txt");
            if (new FileInfo(@"C:\file.doc").Exists) System.Diagnostics.Process.Start(@"C:\file.doc");
            if (new FileInfo(@"C:\file.docx").Exists) System.Diagnostics.Process.Start(@"C:\file.docx");
            if (new FileInfo(@"C:\file.xls").Exists) System.Diagnostics.Process.Start(@"C:\file.xls");
            if (new FileInfo(@"C:\file.xlsx").Exists) System.Diagnostics.Process.Start(@"C:\file.xlsx");
            if (new FileInfo(@"C:\file.wmv").Exists) System.Diagnostics.Process.Start(@"C:\file.wmv");
            if (new FileInfo(@"C:\file.pdf").Exists) System.Diagnostics.Process.Start(@"C:\file.pdf");
            if (new FileInfo(@"C:\file.jpg").Exists) System.Diagnostics.Process.Start(@"C:\file.jpg");
            if (new FileInfo(@"C:\file.bmp").Exists) System.Diagnostics.Process.Start(@"C:\file.bmp");
            if (new FileInfo(@"C:\file.gif").Exists) System.Diagnostics.Process.Start(@"C:\file.gif");
        }

        private void FbutRead()
        {
            filename.Text = string.Empty;
            if (new FileInfo(@"c:\file.doc").Exists) filename.Text = @"C:\file.doc";
            if (new FileInfo(@"c:\file.docx").Exists) filename.Text = @"C:\file.docx";
            if (new FileInfo(@"c:\file.xls").Exists) filename.Text = @"C:\file.xls";
            if (new FileInfo(@"c:\file.xlsx").Exists) filename.Text = @"C:\file.xlsx";
            if (new FileInfo(@"c:\file.txt").Exists) filename.Text = @"C:\file.txt";
            if (new FileInfo(@"c:\file.pdf").Exists) filename.Text = @"C:\file.pdf";
            if (new FileInfo(@"c:\file.wmv").Exists) filename.Text = @"C:\file.wmv";
            if (new FileInfo(@"c:\file.jpg").Exists) filename.Text = @"C:\file.jpg";
            if (new FileInfo(@"c:\file.bmp").Exists) filename.Text = @"C:\file.bmp";
            if (new FileInfo(@"c:\file.gif").Exists) filename.Text = @"C:\file.gif";
            if (filename.Text != string.Empty)
                butRead.Enabled = true; //讀取文件按鈕
            else
                butRead.Enabled = false;

        }

        //刪除文件按鈕
        private void butDnLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename.Text))
                Config.Message("無文件可刪除");
            else
                filename.Text = string.Empty;
        }


    }
}
