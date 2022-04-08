using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMmail_Leav.Models
{
    class LogoAttr
    {
        #region 資料屬性
        public string href { get; set; }    //超連結路徑
        public string title { get; set; }   //說明
        public string img { get; set; }     //圖片
        public string alt { get; set; }     //說明
        #endregion

        public static List<LogoAttr> LogoArr(string Dept)
        {
            List<LogoAttr> em = new List<LogoAttr>();
            em.Clear();
            if (Dept == "L" || Dept == "S" || Dept == "D")
            {
                em.Insert(0, new LogoAttr { href = "http://www.evaglory.com.tw/", title = "EVAGLORY", img = "EVA_logo.jpg", alt = "EVAGLORY" });//鎔利
            }
            else
            {
                em.Insert(0, new LogoAttr { href = "http://www.evaglory.com.tw/", title = "EVAGLORY", img = "EVA_logo.jpg", alt = "EVAGLORY" });//鎔利
                em.Insert(1, new LogoAttr { href = "http://www.kingrichfoods.com/", title = "KFI", img = "KFI_logo.jpg", alt = "KFI" });//金豐盛
            }
            return em;
        }

    }
}
