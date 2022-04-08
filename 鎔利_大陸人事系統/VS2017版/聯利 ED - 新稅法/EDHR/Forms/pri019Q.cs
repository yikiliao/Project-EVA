using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using EDHR.Models;
using System.Collections;

namespace EDHR.Forms
{
    public partial class pri019Q : Form
    {
        List<bool> LCdept = new List<bool>();//存 部門勾選
        List<bool> LPrno = new List<bool>();//存 工號勾選

        List<prt016> LS1 = new List<prt016>();

        private string PrNo;
        
        public pri019Q()
        {            
            InitializeComponent();
            Config.SetFormSize(this);            
            this.Font = new Font("新細明體", 10);
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            this.Width = System.Convert.ToInt32(DeskWidth * 0.95);
            this.Height = System.Convert.ToInt32(DeskHeight * 0.95);
            initForm();
            set_dept();
            f_type.SelectedIndex = 1;
        }

        private void initForm()
        {
            Config.TextReadOnly(f_cdept);
            Config.TextReadOnly(f_pr_no);
            set_dept();//部門
            set_type();//離在職
        }

        private void set_dept()
        {
            //--廠部下拉選單            
            f_comDept.DataSource = sst011.ToDoList(Login.DEPT).ToList();
            f_comDept.DisplayMember = "dept_name";
            f_comDept.ValueMember = "dept";
        }
        private void set_type()
        {
            ArrayList data = new ArrayList();
            data.Add(new DictionaryEntry("--全選--", ""));
            data.Add(new DictionaryEntry("在職", "I"));
            data.Add(new DictionaryEntry("離職", "L"));
            f_type.DisplayMember = "Key";
            f_type.ValueMember = "Value";
            f_type.DataSource = data;
        }

        private void f_cdept_bt_Click(object sender, EventArgs e)
        {
            wCdept fm = new wCdept(f_comDept.SelectedValue.ToString());//部門
            fm.LS = LCdept;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_cdept.Text = fm.Code as string;
                LCdept = fm.LS;
            }
            init_prno();
        }
                

        private void f_pr_no_bt_Click(object sender, EventArgs e)
        {
            var Dept = f_comDept.SelectedValue.ToString();
            var Cdept = f_cdept.Text;
            var Type = string.Empty;
            wPrno fm = new wPrno(Dept, Cdept, Type);
            fm.LS = LPrno;
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_pr_no.Text = fm.Code as string;
                LPrno = fm.LS;
            }
        }

        private void init_prno()
        {
            f_pr_no.Text = string.Empty;
            LPrno.Clear();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            f_Query();
        }

        private void f_Query()
        {   
            string Dept = f_comDept.SelectedValue.ToString();
            string Cdept = f_cdept.Text;
            string PrNo = f_pr_no.Text;
            string inDept = f_type.SelectedValue.ToString();

            dataGridView1.Rows.Clear();
            LS1.Clear();
            LS1 = prt016.ToDoList(Dept, Cdept, PrNo, inDept).ToList();
            if (LS1.Count() == 0)
            {
                Config.Show("無符合資料");
                Cancel();
                return;
            }
            else
            {
                f_show();//顯示畫面
            }
        }

        void f_show()
        {
            this.dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "工號";
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[1].HeaderText = "姓名";
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].HeaderText = "部門";
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[3].HeaderText = "說明";
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].HeaderText = "證號";
            dataGridView1.Columns[4].Width = 200;
            dataGridView1.Columns[5].HeaderText = "地址";
            dataGridView1.Columns[5].Width = 450;
            
            int i = 0;
            foreach (var item in LS1)
            {
                string Cdept_name = string.IsNullOrEmpty(item.Pr_cdept) ? string.Empty : prt001.Get(item.Pr_cdept).Department_name_new;
                dataGridView1.Rows.Add(new object[] { item.Pr_no, item.Pr_name, item.Pr_cdept, Cdept_name, item.Pr_idno, item.Pr_local_addr });                
            }
        }

        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        void Cancel()
        {
            LS1.Clear();
            f_cdept.Text = string.Empty;
            f_pr_no.Text = string.Empty;
            dataGridView1.Rows.Clear();
        }

        private void mnu_exit_Click(object sender, EventArgs e)
        {
            if (Config.Message("是否離開?") == "Y")
                this.Close();
        }

        //新增
        private void menu_add_Click(object sender, EventArgs e)
        {
            pri019 fm = new pri019("Add", string.Empty);            
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_Query();
            }
            else
            {
                
            }
            fm.Dispose();
        }

        //查詢
        private void menu_query_Click(object sender, EventArgs e)
        {
            pri019 fm = new pri019("Qry", PrNo);
            if (fm.ShowDialog() == DialogResult.OK)
            {                
                f_Query();
            }
            else
            {

            }
            fm.Dispose();
        }

        //修改
        private void menu_edit_Click(object sender, EventArgs e)
        {
            pri019 fm = new pri019("Upd", PrNo);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_Query();
            }
            else
            {

            }
            fm.Dispose();
        }

        //刪除
        private void menu_del_Click(object sender, EventArgs e)
        {
            pri019 fm = new pri019("Del", PrNo);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                f_Query();
            }
            else
            {

            }
            fm.Dispose();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
                return;
            
            PrNo = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();//工號
            //整列反藍
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1_Click(sender, e);
            menu_query_Click(this, null);
        }

        private void pri019Q_Load(object sender, EventArgs e)
        {
            f_Query();
        }
    }
}
