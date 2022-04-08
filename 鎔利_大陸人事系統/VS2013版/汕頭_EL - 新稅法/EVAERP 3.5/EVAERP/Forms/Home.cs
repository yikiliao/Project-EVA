using EVAERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;

namespace EVAERP.Forms
{
    public partial class Home : Form
    {
        public static string Id;//使用者帳號
       // Mainbody mainbody = new Mainbody();
        static List<umenuL> LS1 = new List<umenuL>();
        PanelControl panelcontrol = new PanelControl();
        int _menu = 0;
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
            //label1.Text = String.Format("[登入使用者:{0}-{1}]", sst901.Get(Id).Pr_name.Trim(),Conn.GetName(Login.DB));
            label1.Text = null;
            this.Text += String.Format("         {0}  【登入使用者：{1}－{2}】", sst011.Get().Company_name, sst901.Get(Id).Pr_name.Trim(), Conn.GetName(Login.DB));
        }
                

        private void Home_Load(object sender, EventArgs e)
        {
            Query();
            PopulateTreeView("", null);
           
        }      
        private void Query()
        {
            LS1.Clear();
            LS1 = umenuL.Treeview(Id).ToList();//依使用者抓menu
            if (LS1.Count() == 0)
            {
                MessageBox.Show("無符合資料");
                return;
            }            
        }        
        private void PopulateTreeView(string parentId, TreeNode parentNode)
        {
            var filteredItems = LS1.Where(item =>item.ParentId == parentId); 
            TreeNode childNode;
            foreach (var i in filteredItems.ToList())
            {   
                if (parentNode == null)
                    childNode = treeView1.Nodes.Add(i.Id,i.IdName);
                else
                    childNode = parentNode.Nodes.Add(i.Id, i.IdName);

                PopulateTreeView(i.Id, childNode);
            }
        }
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            panelcontrol.formshow(e.Node.Name);            
        }

        public void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           panelcontrol.panelshow(e.Node.Name, panel2);   
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Homebtn_Click(object sender, EventArgs e)
        {
            panelcontrol.panelshow("Mainbody", panel2);
        }

        private void menu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
            Application.Exit();
        }

        private void Home_KeyDown(object sender, KeyEventArgs e)
        {
            //離開(Control+Del)
            if (e.Control && e.KeyCode == Keys.Delete)
            {
                menu_exit_Click(sender, e);
            }
        }
       
       
    }
}
