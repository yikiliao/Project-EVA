using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using HRM.Models;

namespace HRM.Forms
{
    public partial class Login : Form
    {
        int TryTime = 0;
        public static int DB;
        TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
        public Login()
        {
            InitializeComponent();
            
            this.Font = new Font("新細明體", 11);
            this.StartPosition = FormStartPosition.CenterScreen;//畫面置中
            this.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        }

        private void exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
                Application.Exit();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            f_id.Text = string.Empty;
            f_password.Text = string.Empty;
        }

        private bool f_Check(string Usrid, string Passwd)
        {
            if (Usrid == string.Empty)
            {
                Config.Show("帳號不可空白");
                f_id.Focus();
                return false;
            }
            if (Passwd == string.Empty)
            {
                Config.Show("密碼不可空白");
                f_password.Focus();
                return false;
            }

            var p_login = new hrmlogin();
            p_login = hrmlogin.Get(Usrid);

            if (p_login == null)
            {
                Config.Show("無此使用者");
                return false;
            }

            if (p_login.Erp_id == Usrid && p_login.Password == Passwd)
            {
                // do nothing 成功登入
            }
            else
            {
                Config.Show("密碼或帳號錯誤");
                return false;
            }
            return true;
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            string Usrid = f_id.Text.Trim();
            string Passwd = f_password.Text.Trim();

            TryTime = TryTime + 1;
            if (TryTime > 5)
            {
                Config.Show("登入錯誤次數太多");
                System.Threading.Thread.Sleep(1000);//停1秒
                Application.Exit();
            }

            if (f_Check(Usrid, Passwd) == false)
                return;
            try
            {
                this.Hide();
                Home fm = new Home(Usrid);
                fm.Show();
            }
            catch (Exception ex)
            {
                Config.Show(ex.Message);
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            DB = System.Convert.ToInt16(oTINI.getKeyValue("DB", "NO")); //登入資料庫
        }

    }
}
