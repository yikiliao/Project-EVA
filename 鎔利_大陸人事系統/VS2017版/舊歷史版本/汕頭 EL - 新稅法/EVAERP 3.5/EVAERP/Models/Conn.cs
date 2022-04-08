using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVAERP.Models
{
    class Conn
    {
        public static string GetStr(int Conn)
        {
            if (Conn == 1)
            {
                return "HRST";//正式區
            }
            else
            {
                return "HRST-TEST";//測試區
            }
        }
        public static string GetStrOracle(int Conn)
        {
            if (Conn == 1)
            {
                return "TT";//Oracle正式區
            }
            else
            {
                return "TT-TEST";//Oracle測試區
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
