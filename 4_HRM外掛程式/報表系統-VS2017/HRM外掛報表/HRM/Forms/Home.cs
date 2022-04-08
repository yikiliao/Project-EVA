using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HRM.Models;

namespace HRM.Forms
{
    public partial class Home : Form
    {
        public static string Id;//使用者帳號
        static List<hrmmenu> LS1 = new List<hrmmenu>();
        public Home()
        {
            InitializeComponent();
            Config.SetHomeSize(this);
        }

        public Home(string Userid)
        {
            InitializeComponent();
            Config.SetHomeSize(this);
            Id = Userid;
            this.Text = String.Format("[登入使用者:{0}－{1}]", hrmlogin.Get(Id).Pr_name.Trim(), Conn.GetName(Login.DB));
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
                Application.Exit();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Query();
            PopulateTreeView("", null);
        }

        private void Query()
        {
            LS1.Clear();
            LS1 = hrmmenu.Treeview(Id).ToList();//依使用者抓menu
            if (LS1.Count() == 0)
            {
                MessageBox.Show("無符合資料");
                return;
            }
        }

        private void PopulateTreeView(string parentId, TreeNode parentNode)
        {
            var filteredItems = LS1.Where(item => item.ParentId == parentId);
            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {
                if (parentNode == null)
                    childNode = treeView1.Nodes.Add(i.Id, i.IdName);
                else
                    childNode = parentNode.Nodes.Add(i.Id, i.IdName);

                PopulateTreeView(i.Id, childNode);
            }
        }
                

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            formshow(e.Node.Name);
        }

        private void formshow(string formname)
        {
            //看是否有權力執行薪資相關報表
            string Apply = "";
            Apply = hrmlogin.Get(Home.Id).Vaild;

            switch (formname)
            {
                case "hrm100":  //禮品清冊
                    var BMhrm100 = new hrm100();
                    //Set_Form(BMhrm100); //這方法可以將畫面放到panel當中
                    BMhrm100.Show();
                    break;
                case "hrm110":  //壽星名單
                    var BMhrm110 = new hrm110();
                    BMhrm110.Show();
                    break;
                case "hrm120":  //員工特休假清冊
                    var BMhrm120 = new hrm120();
                    BMhrm120.Show();
                    break;
                case "hrm130":  //員工明細表 
                    var BMhrm130 = new hrm130();
                    BMhrm130.Show();
                    break;
                case "hrm150":  //員工薪資清冊
                    if (Apply == "Y")
                    {
                        var BMhrm150 = new hrm150();
                        BMhrm150.Show();
                    }
                    else
                    {
                        Config.Show("...無執行權利此程式...");
                    }
                    break;
                case "hrm160":  //年終獎金
                    if (Apply == "Y")
                    {
                        var BMhrm160 = new hrm160();
                        BMhrm160.Show();
                    }
                    else
                    {
                        Config.Show("...無執行權利此程式...");
                    }
                    break;


                case "hrm180":  //員工薪資項目表(舊)
                    if (Apply == "Y")
                    {
                        var BMhrm180 = new hrm180();
                        BMhrm180.Show();
                    }
                    else
                    {
                        Config.Show("...無執行權利此程式...");
                    }
                    break;

                case "hrm190":  //員工薪資項目表(新)
                    if (Apply == "Y")
                    {
                        var BMhrm190 = new hrm190();
                        BMhrm190.Show();
                    }
                    else
                    {
                        Config.Show("...無執行權利此程式...");
                    }
                    break;


                case "hrm220":  //員工特休假到期結算表
                    if (Apply == "Y")
                    {
                        var BMhrm220 = new hrm220();
                        BMhrm220.Show();
                    }
                    else
                    {
                        Config.Show("...無執行權利此程式...");
                    }
                    break;

                case "hrm230":  //員工薪資項目(加、扣、所得稅)
                    if (Apply == "Y")
                    {
                        var BMhrm230 = new hrm230();
                        BMhrm230.Show();
                    }
                    else
                    {
                        Config.Show("...無執行權利此程式...");
                    }
                    break;


                case "hrm250":  //考勤明細表
                    var BMhrm250 = new hrm250();
                    BMhrm250.Show();
                    break;

                case "hrm270":  //加班申請表
                    var BMhrm270 = new hrm270();
                    BMhrm270.Show();
                    break;

                case "ssi999":  //使用者密碼修改
                    var BMssi999 = new ssi999();
                    BMssi999.Show();
                    break;
            }
        }

        

    }
}
