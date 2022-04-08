using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EDHR.Models;
using System.IO;

using System.Collections;
namespace EDHR.Forms
{
    public partial class Login : Form
    {
        public static string DEPT;
        public static int DB;
        public static string ID;
        int TryTime=0;
        public Login()
        {
            InitializeComponent();
            //*******************調整視窗位置大小
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            this.Font = new Font("新細明體", 10);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            //*******************調整視窗位置大小

            init_Form();
        }

        private void init_Form()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("正式區", 1));
            data.Add(new DictionaryEntry("測試區", 2));
            f_db.DisplayMember = "Key";
            f_db.ValueMember = "Value";
            f_db.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {  
            string Usrid = f_id.Text.Trim();
            string Passwd = f_password.Text.Trim();
            //連線資訊**********************
            TINI oTINI = new TINI(Path.Combine(Application.StartupPath, @"ini\Setup.ini"));
            DEPT = oTINI.getKeyValue("LOCAL", "CODE"); //廠部代碼
            DB = (int)f_db.SelectedValue; //登入資料庫
            ID = Usrid; //登入帳號


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

        private bool f_Check(string Usrid,string Passwd)
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
            var p_sst901 = new sst901();
            p_sst901 = sst901.Get(Usrid);
            if (p_sst901 == null)
            {
                Config.Show("無此使用者");
                return false;
            }
            if (p_sst901.Erp_id == Usrid && p_sst901.Password == Passwd)
            {                
                // do nothing
            }
            else
            {
                Config.Show("密碼錯誤");
                return false;
            }
            return true;
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            Application.Exit();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            //離開(Control+Del)
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                menu_exit_Click(sender, e);
            }

            //確認(Escape)
            if (e.KeyCode == Keys.Escape)
            {
                button1_Click(sender, e);
            }
        }

        //產生提示訊息
        private void button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip ttTip = new ToolTip();
            ttTip.SetToolTip(button1, "Escape");
        }


    }
}
