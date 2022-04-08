using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using HRTranf.Models;

namespace HRTranf
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            //Application.Run(new Form1());//系統登入畫面

            f_1(); //銀行代碼資料移轉
            f_2("EL");//移轉部門EL
            f_2("ES");//移轉部門ES
            f_2("ED");//移轉部門ED
            f_3();//幣別
            f_4("EL");//公司資料
            f_4("ES");//公司資料
            f_4("ED");//公司資料
        }

        private static void f_1()
        {
            ntt001 p_ntt001 = new ntt001();
            //刪除資料 
            ntt001.Delete();
            //寫入資料
            foreach (var i in nmt_file.ToDoList("CN").ToList())
            {
                p_ntt001.Country_code = "CN";
                p_ntt001.Bank_shortcode = i.NMT01.Substring(0, 3);
                p_ntt001.Bank_code = i.NMT01;
                p_ntt001.Bank_name = i.NMT02;
                p_ntt001.Vaild = "Y";
                p_ntt001.Add_user = "sys";
                p_ntt001.Insert();
            }
        }

        private static void f_2(string Dept)
        {
            prt001 p_prt001 = new prt001();
            //刪除資料
            prt001.Delete(Dept);
            //寫入資料
            foreach (var i in gem_file.ToDoList(Dept))
            {
                p_prt001.Dept = Dept.Substring(1, 1);
                p_prt001.Department_code = i.GEM01;
                p_prt001.Department_name_new = i.GEM02;
                p_prt001.Department_name_old = i.GEM02;
                p_prt001.Vaild = "Y";
                p_prt001.Add_user = "sys";
                p_prt001.Insert();
            }
        }

        private static void f_3()
        {
            sst001 p_sst001 = new sst001();
            //刪除資料
            p_sst001.Delete();
            //寫入資料
            foreach (var i in azi_file.ToDoList().ToList())
            {
                if (i.AZI01 == "502") continue;
                p_sst001.Code = i.AZI01;
                p_sst001.Code_desc = i.AZI02;
                p_sst001.Vaild = "Y";
                p_sst001.Add_user = "sys";
                p_sst001.Insert();
            }
        }

        private static void f_4(string Dept)
        {
            string Comp = Dept.Substring(1, 1);
            sst011 p_sst011 = new sst011();
            p_sst011.Delete(Comp);

            foreach (var i in zo_file.ToDoList(Dept))
            {
                p_sst011.Company = Comp;
                p_sst011.Company_shname = i.ZO07;
                p_sst011.Company_name = i.ZO02;
                p_sst011.Company_address1 = i.ZO041;
                p_sst011.Company_address2 = i.ZO042;
                p_sst011.Phone = i.ZO05;
                p_sst011.Fax = i.ZO09;
                p_sst011.Vaild = "Y";
                p_sst011.Add_user = "sys";
                p_sst011.Insert();
            }
        }
    }
}
