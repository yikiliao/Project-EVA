using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace EDHR.Models
{
    class Conn
    {
        public static string GetStr(int Conn)
        {
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
            if (Conn == 1)
            {                
                return oTINI.getKeyValue("LOCAL", "HRST");//正式區
            }
            else
            {                
                return oTINI.getKeyValue("LOCAL", "HRST-TEST");//測試區
            }
        }

        public static string GetStrOracle(int Conn)
        {
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
            if (Conn == 1)
            {                
                return oTINI.getKeyValue("LOCAL", "TT");//正式區
            }
            else
            {   
                return oTINI.getKeyValue("LOCAL", "TT-TEST");//測試區
            }
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
