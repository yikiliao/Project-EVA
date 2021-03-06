using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDHR.Models;

namespace EDHR.Forms
{
    public partial class ssi999 : Form
    {
        public ssi999()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        }

        private void Repass_Load(object sender, EventArgs e)
        {
            var p_sst901 = new sst901();
            p_sst901 = sst901.Get(Home.Id);
            if (p_sst901 == null)
            {
                Config.Show("檔案讀取錯誤\n請通知電腦室");
            }
            f_id.Text = p_sst901.Erp_id;
            f_id.ReadOnly = true;
            f_name.Text = p_sst901.Pr_name;
            f_name.ReadOnly = true;
            f_password1.Focus();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string Usrid = f_id.Text.Trim();
            string Passwd1 = f_password1.Text.Trim();
            string Passwd2 = f_password2.Text.Trim();

            if (f_Check(Usrid, Passwd1, Passwd2) == false)
                return;
            try
            {
                var p_sst901 = new sst901();
                p_sst901 = sst901.Get(Usrid);
                if (p_sst901 == null)
                {
                    Config.Show("檔案讀取錯誤\n請通知電腦室");
                }
                p_sst901.Password = Passwd1;
                Config.Show(p_sst901.Update(Usrid)+"\n請重新登入");
                System.Threading.Thread.Sleep(1000);//停1秒
                Application.Exit();
            }
            catch (Exception ex)
            {
                Config.Show(ex.Message);
            }
        }

        private bool f_Check(string Usrid, string Passwd1, string Passwd2)
        {
            if (Passwd1 == string.Empty)
            {
                Config.Show("新密碼不可空白");
                f_password1.Focus();
                return false;
            }
            if (Passwd2 == string.Empty)
            {
                Config.Show("確認密碼不可空白");
                f_password2.Focus();
                return false;
            }
            if (Passwd1 != Passwd2)
            {
                Config.Show("密碼不符");
                f_password1.Focus();
                return false;
            }
            return true;
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            this.Close();
        }

        private void ssi999_KeyDown(object sender, KeyEventArgs e)
        {
            //離開(Control+Del)
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                menu_exit_Click(sender, e);
            }
        }

        


    }
}
