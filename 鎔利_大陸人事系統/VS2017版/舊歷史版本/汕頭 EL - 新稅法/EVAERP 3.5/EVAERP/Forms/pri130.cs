using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;
using EVAERP.Models;
using EVAERP.Crpts;

namespace EVAERP.Forms
{
    public partial class pri130 : Form
    {        
        string DataRang;//處理廠部範圍
        public pri130()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            DataRang = sst901.Get(Home.Id).Rang;
            init_Form();
        }

        private void init_Form()
        {
            set_dept();
            set_year();           
            set_type();
        }
        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList().ToList();
            f_comDept.ValueMember = "dept";
        }
        
        private void set_year()
        {
            f_yy.DataSource = prt035L.ToDoList_YY().ToList();
            f_yy.DisplayMember = "yy";
            f_yy.ValueMember = "yy";
            f_yy.Text = DateTime.Now.Year.ToString();
        }

        private void set_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("關帳", "Y"));
            f_type.DisplayMember = "Key";
            f_type.ValueMember = "Value";
            f_type.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            string Dept = f_comDept.SelectedValue.ToString();

            if (prt031L.ToDoList(Yy + 1, 2, string.Empty, null).Count() == 0)
            {
                Config.Show("此年度無二月份薪資，還無法關帳");
                return;
            }
            if (prt035L.ToDoList(Yy, Dept, string.Empty, string.Empty).Count() == 0)
            {
                Config.Show(string.Format("無{0}年考核資料", Yy));
                return;
            }
            if (prt036L.ToDoList(Yy, Dept, string.Empty, string.Empty).Count() == 0)
            {
                Config.Show(string.Format("無{0}年終獎金資料", Yy));
                return;
            }
            if (prt037L.ToDoList(Yy, Dept, string.Empty, string.Empty).Count() == 0)
            {
                Config.Show(string.Format("無{0}年計稅金資料", Yy));
                return;
            }

            if (Config.Message(string.Format("{0}年，{1}廠 年終獎金作業，確定關帳?", Yy, Dept)) == "Y")
            {
                if (Config.Message("關帳後資料皆無法異動，確定關帳？") == "Y")
                {
                    try
                    {
                        Config.Show(String.Format("{0}\n{1}\n{2}\n", f_Insert_prt034_0(), f_Insert_prt034_1(), f_Insert_prt034_2()));                        
                    }
                    catch (Exception ex)
                    {
                        Config.Show(ex.Message);
                    }
                }
            }
        }
                

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (prt036L.ToDoList(System.Convert.ToDecimal(f_yy.SelectedValue), f_comDept.SelectedValue.ToString(), string.Empty, string.Empty).Count() == 0)
        //    {
        //        Config.Show(string.Format("無{0}年終獎金資料",f_yy.SelectedValue.ToString()));
        //        return;
        //    }
        //    else
        //    {
        //        if (Config.Message(string.Format("{0}年，{1}廠 年終獎金作業，確定關帳?", f_yy.SelectedValue.ToString(), f_comDept.SelectedValue.ToString())) == "Y")
        //        {
        //            if (Config.Message("關帳後資料皆無法異動，確定關帳？") == "Y")
        //            {
        //                try
        //                {
        //                    Config.Show(f_Insert());
        //                    Config.Show(f_Close_tax());
        //                }
        //                catch (Exception ex)
        //                {
        //                    Config.Show(ex.Message);
        //                }
        //            }
        //        }
        //    }
        //}

        private string f_Insert_prt034_0()
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            string Dept = f_comDept.SelectedValue.ToString();
            decimal Mm = 77M;
            new prt034().Delete(Yy, Mm, Dept);

            var p_prt034 = new prt034();
            p_prt034.Yy = Yy;
            p_prt034.Mm = Mm;
            p_prt034.Dept = Dept;
            p_prt034.rType = "年終獎金考核關帳完成";
            p_prt034.rClose = "Y";
            p_prt034.Add_user = Home.Id;
            p_prt034.Insert();
            return "年終獎金考核關帳完成";
        }
        private string f_Insert_prt034_1()
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            string Dept = f_comDept.SelectedValue.ToString();
            decimal Mm = 88M;
            new prt034().Delete(Yy, Mm, Dept);

            var p_prt034 = new prt034();
            p_prt034.Yy = Yy;
            p_prt034.Mm = Mm;
            p_prt034.Dept = Dept;
            p_prt034.rType = "年終獎金作業關帳完成";
            p_prt034.rClose = "Y";
            p_prt034.Add_user = Home.Id;
            p_prt034.Insert();
            return "年終獎金作業關帳完成";
        }
        private string f_Insert_prt034_2()
        {
            decimal Yy = System.Convert.ToDecimal(f_yy.SelectedValue);
            string Dept = f_comDept.SelectedValue.ToString();
            decimal Mm = 99M;
            new prt034().Delete(Yy, Mm, Dept);            
            
            var p_prt034 = new prt034();
            p_prt034.Yy = Yy;
            p_prt034.Mm = Mm;
            p_prt034.Dept = Dept;
            p_prt034.rType = "年終獎金計稅關帳完成";
            p_prt034.rClose = "Y";
            p_prt034.Add_user = Home.Id;
            p_prt034.Insert();
            return "年終獎金計稅關帳完成";
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
                Close();
        }

    }
}
