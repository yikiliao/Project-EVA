using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using TRawBasicDay.Models;
using System.Collections;
using System.Data;
using System.Configuration;
using System.Threading;
using System.Data.SqlClient;

namespace TRawBasicDay
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            string sorce = ConfigurationManager.ConnectionStrings["TT"].ToString();
            string target = ConfigurationManager.ConnectionStrings["66_8"].ToString();

            //sync 工作站基本資料 eca_file ok
            F3(sorce, target);

            //sync 部門代碼 gem_file ok
            F4(sorce, target);

            //sync 製程資料 ecd_file ok
            F7(sorce, target);

            //sync 班別資料 ecg_file ok
            F10(sorce, target);

            //sync 機台資料 eci_file ok
            F11(sorce, target);

            //sync 不良代碼 qce_file ok
            F12(sorce, target);
        }

        private static void old()
        {
            ////sync 料號同步 ima_file
            //F1(sorce, target); 

            ////sync 工單同步_製造&加工 sfb_file+ ecm_file ok
            //F2(sorce, target);

        }

        private static void F12(string sorce, string target)
        {
            string sql = null;
            sql += "select qce01,qce02,qce03,qce04,qceacti from ew.qce_file where 1=1";
            DataTable dt = DOORC.GetDataTable(sorce, sql);            
            foreach (DataRow dr in dt.Rows)
            {
                qce_file p_qce = new qce_file();
                p_qce.Qce01 = dr["qce01"].ToString();
                p_qce.Qce02 = dr["qce02"].ToString();
                p_qce.Qce03 = dr["qce03"].ToString();
                p_qce.Qce04 = dr["qce04"].ToString();
                p_qce.Qceacti = dr["qceacti"].ToString();
                if (qce_file.HaveRow(p_qce, target).Rows.Count == 0)
                {
                    qce_file.Ins_(p_qce, target);
                }
            }
        }


        private static void F11(string sorce, string target)
        {
            string sql = null;
            sql += "select eci01,eci03,eci06 from ew.eci_file where 1=1";
            DataTable dt = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt.Rows)
            {
                eci_file p_eci = new eci_file();
                p_eci.Eci01 = dr["eci01"].ToString();
                p_eci.Eci03 = dr["eci03"].ToString();
                p_eci.Eci06 = dr["eci06"].ToString();
                if (eci_file.HaveRow(p_eci, target).Rows.Count == 0)
                {
                    eci_file.Ins_(p_eci, target);
                }
            }
        }

        private static void F10(string sorce, string target)
        {
            string sql = null;
            sql += "select ecg01,ecg02,ecgacti from ew.ecg_file where 1=1";            
            DataTable dt = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt.Rows)
            {
                ecg_file p_ecg = new ecg_file();
                p_ecg.Ecg01 = dr["ecg01"].ToString();
                p_ecg.Ecg02 = dr["ecg02"].ToString();
                p_ecg.Ecgacti = dr["ecgacti"].ToString();
                if (ecg_file.HaveRow(p_ecg, target).Rows.Count == 0)
                {
                    ecg_file.Ins_(p_ecg, target);
                }
            }
        }

        private static void F9(string sorce, string target)
        {            
            string sql = null;
            sql += "select ecm01,ecm03,ecm04,ecm45,ecm06,ecm05 from ew.ecm_file where 1=1";
            sql += " and ecm01 like ('JS012%')";
            DataTable dt = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt.Rows)
            {
                ecm_file p_ecm = new ecm_file();
                p_ecm.Ecm01 = dr["ecm01"].ToString();
                p_ecm.Ecm03 = System.Convert.ToInt16(dr["ecm03"]);
                p_ecm.Ecm04 = dr["ecm04"].ToString();
                p_ecm.Ecm45 = dr["ecm45"].ToString();
                p_ecm.Ecm06 = dr["ecm06"].ToString();
                p_ecm.Ecm05 = dr["ecm05"].ToString();
                if (ecm_file.HaveRow(p_ecm, target).Rows.Count == 0)
                {
                    ecm_file.Ins_(p_ecm, target);
                }
            }
        }

        private static void F9(string sorce, string target,string Sfb01)
        {
            string sql = null;
            sql += "select ecm01,ecm03,ecm04,ecm45,ecm06,ecm05 from ew.ecm_file where 1=1";
            sql += " and ecm01 = '" + Sfb01 + "'";
            DataTable dt = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt.Rows)
            {
                ecm_file p_ecm = new ecm_file();
                p_ecm.Ecm01 = dr["ecm01"].ToString();
                p_ecm.Ecm03 = System.Convert.ToInt16(dr["ecm03"]);
                p_ecm.Ecm04 = dr["ecm04"].ToString();
                p_ecm.Ecm45 = dr["ecm45"].ToString();
                p_ecm.Ecm06 = dr["ecm06"].ToString();
                p_ecm.Ecm05 = dr["ecm05"].ToString();
                if (ecm_file.HaveRow(p_ecm, target).Rows.Count == 0)
                {
                    ecm_file.Ins_(p_ecm, target);
                }
            }
        }

        private static void F8(string sorce, string target)
        {
            string sql = null;
            sql += "select occ01,occ02,occacti from ew.occ_file where 1=1";
            DataTable dt = DOORC.GetDataTable(sorce, sql);            
            foreach (DataRow dr in dt.Rows)
            {
                occ_file p_occ = new occ_file();
                p_occ.occ01 = dr["occ01"].ToString();
                p_occ.occ02 = dr["occ02"].ToString();
                p_occ.occacti = dr["occacti"].ToString();
                if (occ_file.HaveRow(p_occ, target).Rows.Count == 0)
                    occ_file.Ins_(p_occ, target);
                //else
                //    occ_file.Upd_(p_occ, target);
            }
        }

        private static void F7(string sorce, string target)
        {
            string sql = null;
            sql += "select ecd01,ecd02,ecd05,ecd06,ecd07,ecdacti from ew.ecd_file WHERE 1=1 ";
            DataTable dt1 = DOORC.GetDataTable(sorce, sql);

            foreach (DataRow dr in dt1.Rows)
            {
                ecd_file p_ecd = new ecd_file();
                p_ecd.Ecd01 = dr["ecd01"].ToString();
                p_ecd.Ecd02 = dr["ecd02"].ToString();
                p_ecd.Ecd05 = dr["ecd05"].ToString();
                p_ecd.Ecd06 = dr["ecd06"].ToString();
                p_ecd.Ecd07 = dr["ecd07"].ToString();
                p_ecd.Ecdacti = dr["ecdacti"].ToString();

                if (ecd_file.HaveRow(p_ecd, target).Rows.Count == 0)
                    ecd_file.Ins_(p_ecd, target);
                //else
                //    ecd_file.Upd_(p_ecd, target);
            }
        }

        private static void F6(string sorce, string target)
        {
            string sql = null;
            sql += "select ecb01,ecb02,ecb03,ecb07,ecb08,ecb06,ecb17 from ew.ecb_file WHERE 1=1 ";
            DataTable dt1 = DOORC.GetDataTable(sorce, sql);

            foreach (DataRow dr in dt1.Rows)
            {
                ecb_file p_ecb = new ecb_file();
                p_ecb.Ecb01 = dr["ecb01"].ToString();
                p_ecb.Ecb02 = dr["ecb02"].ToString();
                p_ecb.Ecb03 = System.Convert.ToDecimal(dr["ecb03"]);
                p_ecb.Ecb07 = dr["ecb07"].ToString();
                p_ecb.Ecb08 = dr["ecb08"].ToString();
                p_ecb.Ecb06 = dr["ecb06"].ToString();
                p_ecb.Ecb17 = dr["ecb17"].ToString();

                if (ecb_file.HaveRow(p_ecb, target).Rows.Count == 0)
                    ecb_file.Ins_(p_ecb, target);
                //else
                //    ecb_file.Upd_(p_ecb, target);
            }
        }

        private static void F5(string sorce, string target)
        {
            string sql = null;
            sql += "select ecu01,ecu02,ecu03,ecu04,ecu05 from ew.ecu_file WHERE 1=1 ";            
            DataTable dt1 = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt1.Rows)
            {
                ecu_file p_ecu = new ecu_file();
                p_ecu.Ecu01 = dr["ecu01"].ToString();
                p_ecu.Ecu02 = dr["ecu02"].ToString();
                p_ecu.Ecu03 = dr["ecu03"].ToString();
                p_ecu.Ecu04 = System.Convert.ToDecimal(dr["ecu04"]);
                p_ecu.Ecu05 = System.Convert.ToDecimal(dr["ecu05"]);

                if (ecu_file.HaveRow(p_ecu, target).Rows.Count == 0)
                    ecu_file.Ins_(p_ecu, target);
                //else
                //    ecu_file.Upd_(p_ecu, target);
            }
        }

        private static void F4(string sorce, string target)
        {
            string sql = null;
            sql += "select gem01,gem02,gemacti from ew.gem_file WHERE 1=1 ";
            DataTable dt1 = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt1.Rows)
            {
                gem_file p_gem = new gem_file();
                p_gem.Gem01 = dr["gem01"].ToString();
                p_gem.Gem02 = dr["gem02"].ToString();
                p_gem.Gemacti = dr["gemacti"].ToString();

                if (gem_file.HaveRow(p_gem, target).Rows.Count == 0)
                    gem_file.Ins_(p_gem, target);
                //else
                //    gem_file.Upd_(p_gem, target);
            }
        }

        private static void F3(string sorce, string target)
        {
            string sql = null;
            sql += "select eca01,eca02,eca03,ecaacti from ew.eca_file WHERE 1=1 ";            
            DataTable dt1 = DOORC.GetDataTable(sorce, sql);
            foreach (DataRow dr in dt1.Rows)
            {
                eca_file p_eca = new eca_file();
                p_eca.Eca01 = dr["eca01"].ToString();
                p_eca.Eca02 = dr["eca02"].ToString();
                p_eca.Eca03 = dr["eca03"].ToString();
                p_eca.Ecaacti = dr["ecaacti"].ToString();

                if (eca_file.HaveRow(p_eca, target).Rows.Count == 0)
                    eca_file.Ins_(p_eca, target);
                //else
                //    eca_file.Upd_(p_eca, target);
            }
        }

        private static void F2(string sorce, string target)
        {
            string BegDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string EndDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            //BegDate = "2021/10/01";
            //EndDate = "2021/11/30";
            string sql1 = null;
            sql1 += "select sfb01,sfb02,sfb05,sfb06,sfb08,sfb04,sfb13,sfb81,sfb223,sfb224 from ew.sfb_file WHERE 1=1 ";
            sql1 += string.Format(" and sfb81 >= TO_DATE('{0}', 'yyyy-mm-dd')", BegDate);//輸入日期
            sql1 += string.Format(" and sfb81 < TO_DATE('{0}', 'yyyy-mm-dd')", EndDate);
            sql1 += " and sfb01 like ('JS012%')";
            //sql1 += " and sfb81 >= TO_DATE('2021-09-01', 'yyyy-mm-dd')"; //輸入日期
            //sql1 += " and sfb81 < TO_DATE('2021-09-30', 'yyyy-mm-dd')";
            DataTable dt1 = DOORC.GetDataTable(sorce, sql1);//來源


            foreach (DataRow dr in dt1.Rows)
            {
                sfb_file p_sfb = new sfb_file();
                p_sfb.Sfb01 = dr["sfb01"].ToString();
                p_sfb.Sfb02 = dr["sfb02"].ToString();
                p_sfb.Sfb05 = dr["sfb05"].ToString();
                p_sfb.Sfb06 = dr["sfb06"].ToString();
                p_sfb.Sfb08 = System.Convert.ToDecimal(dr["sfb08"]);
                p_sfb.Sfb04 = dr["sfb04"].ToString();
                p_sfb.Sfb13 = System.Convert.ToDateTime(dr["sfb13"]).ToString("yyyy/MM/dd");
                p_sfb.Sfb81 = System.Convert.ToDateTime(dr["sfb81"]).ToString("yyyy/MM/dd");
                p_sfb.Sfb223 = dr["sfb223"].ToString();
                p_sfb.Sfb224 = dr["sfb224"].ToString();

                if (sfb_file.HaveRow(p_sfb, target).Rows.Count == 0) {
                    sfb_file.Ins_(p_sfb, target);
                    F9(sorce, target, p_sfb.Sfb01);
                }
                else
                    sfb_file.Upd_(p_sfb, target);
            }
        }

        //private static void F2(string sorce, string target)
        //{
        //    string BegDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
        //    string EndDate = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
        //    BegDate = "2021/10/01";
        //    EndDate = "2021/11/30";
        //    string sql1 = null;
        //    sql1 += "select sfb01,sfb02,sfb05,sfb06,sfb08,sfb04,sfb13,sfb81,sfb223 from ew.sfb_file WHERE 1=1 ";            
        //    sql1 += string.Format(" and sfb81 >= TO_DATE('{0}', 'yyyy-mm-dd')", BegDate);//輸入日期
        //    sql1 += string.Format(" and sfb81 < TO_DATE('{0}', 'yyyy-mm-dd')", EndDate);
        //    //sql1 += " and sfb81 >= TO_DATE('2021-09-01', 'yyyy-mm-dd')"; //輸入日期
        //    //sql1 += " and sfb81 < TO_DATE('2021-09-30', 'yyyy-mm-dd')";
        //    DataTable dt1 = DOORC.GetDataTable(sorce, sql1);//來源


        //    foreach (DataRow dr in dt1.Rows)
        //    {
        //        sfb_file p_sfb = new sfb_file();
        //        p_sfb.Sfb01 = dr["sfb01"].ToString();
        //        p_sfb.Sfb02 = dr["sfb02"].ToString();
        //        p_sfb.Sfb05 = dr["sfb05"].ToString();
        //        p_sfb.Sfb06 = dr["sfb06"].ToString();
        //        p_sfb.Sfb08 = System.Convert.ToDecimal(dr["sfb08"]);
        //        p_sfb.Sfb04 = dr["sfb04"].ToString();
        //        p_sfb.Sfb13 = System.Convert.ToDateTime(dr["sfb13"]).ToString("yyyy/MM/dd");
        //        p_sfb.Sfb81 = System.Convert.ToDateTime(dr["sfb81"]).ToString("yyyy/MM/dd");
        //        p_sfb.Sfb223 = dr["sfb223"].ToString();

        //        if (sfb_file.HaveRow(p_sfb, target).Rows.Count == 0)
        //            sfb_file.Ins_(p_sfb, target);
        //        else
        //            sfb_file.Upd_(p_sfb, target);
        //    }
        //}

        private static void F1(string sorce, string target)
        {
            string sql1 = string.Empty;
            sql1 += "select ima01,ima02,ima021,ima06,imaacti from ew.IMA_FILE WHERE 1=1 ";
            sql1 += " and imaacti='Y'";
            DataTable dt1 = DOORC.GetDataTable(sorce, sql1);//來源

            foreach (DataRow dr in dt1.Rows)
            {
                ima_file p_ima = new ima_file();                
                p_ima.Ima01 = dr["Ima01"].ToString();
                p_ima.Ima02 = dr["Ima02"].ToString();
                p_ima.Ima021 = dr["Ima021"].ToString();
                p_ima.Ima06 = dr["Ima06"].ToString();
                p_ima.Imaacti = dr["Imaacti"].ToString();

                if (ima_file.HaveRow(p_ima, target) == 0)
                    ima_file.Ins_(p_ima, target);
                //else
                    //ima_file.Upd_(p_ima, target);
            }
        }


        //private static void F1(string rDept, string sorce,string target)
        //{
        //    string sql1 = string.Empty;
        //    sql1 += "select ima01,ima02,ima021,ima06,imaacti from ew.IMA_FILE WHERE 1=1 ";
        //    DataTable dt1 = DOORC.GetDataTable(sorce, sql1);//來源

        //    string sql2 = string.Empty;
        //    sql2 += "select ima01,ima02,ima021,ima06,imaacti from ima_file where 1=1";
        //    DataTable dt2 = DOSQL.GetDataTable(target, sql2);//目的            

        //    // 获取两个数据源的差集
        //    IEnumerable<DataRow> query2 = dt1.AsEnumerable().Except(dt2.AsEnumerable(), DataRowComparer.Default);

        //    foreach (DataRow dr in query2)
        //    {
        //        ima_file p_ima = new ima_file();
        //        p_ima.Dept = rDept.ToUpper();
        //        p_ima.Ima01 = dr["Ima01"].ToString();
        //        p_ima.Ima02 = dr["Ima02"].ToString();
        //        p_ima.Ima021 = dr["Ima021"].ToString();
        //        p_ima.Ima06 = dr["Ima06"].ToString();
        //        p_ima.Imaacti = dr["Imaacti"].ToString();

        //        if (ima_file.HaveRow(p_ima, target).Rows.Count == 0)
        //            ima_file.Ins_(p_ima, target);
        //        else
        //            ima_file.Upd_(p_ima, target);
        //    }
        //}



    }
}
