using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;

namespace HRM.Models
{
    class Conn
    {
        //public static string GetStr(int Conn)
        //{
        //    if (Conn == 1)
        //    {                
        //        return "MFPD";//正式區
        //    }
        //    else
        //    {                
        //        return "MFPDTEST";//測試區
        //    }
        //}
                
        public static string GetStr(int Conn)
        {
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));            
            return oTINI.getKeyValue("DB", "MFPD");           
        }

        public static string GetStrHRM(int Conn)
        {
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
            return oTINI.getKeyValue("DB", "HRM");
        }

        public static string GetStrEVA(int Conn)
        {
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
            return oTINI.getKeyValue("DB", "EVA");
        }

        public static string GetStrHRMPL(int Conn)
        {
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
            return oTINI.getKeyValue("DB", "HRMPL");
        }


        //public static string GetStrOracle(int Conn)
        //{
        //    if (Conn == 1)
        //    {
        //        return "TT";//Oracle正式區
        //    }
        //    else
        //    {
        //        return "TTEST";//Oracle測試區
        //    }
        //}

        public static string GetStrOracle(int Conn)
        {
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
            return oTINI.getKeyValue("DB", "TT");
        }

        public static string GetName(int Conn)
        {
            if (Conn == 1)
            {
                return "正式區";//正式區
            }
            else
            {
                return "測試區";//測試區
            }
        }

    }
}
