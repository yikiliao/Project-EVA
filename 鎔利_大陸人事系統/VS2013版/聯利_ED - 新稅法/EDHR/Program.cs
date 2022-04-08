using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EDHR.Forms;


namespace EDHR
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
            
            Application.Run(new Login());//系統登入畫面
                      
            //Application.Run(new pri019Q());//

            //Application.Run(new ssi904());//使用者畫面
            //Application.Run(new Home());//系統選單畫面menu
            //Application.Run(new ssi999());//使用者密碼修改
            //Application.Run(new ssi903());//mailto
            //Application.Run(new ssi901());//加入使用者
            //Application.Run(new Form1());
        }
    }
}
