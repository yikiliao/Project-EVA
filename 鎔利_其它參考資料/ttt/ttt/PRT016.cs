using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;
using Newtonsoft.Json;

namespace ttt
{
    public partial class PRT016 : Form
    {
        public PRT016()
        {
            InitializeComponent();
        }

        private void but_Insert_Click(object sender, EventArgs e)
        {
            prt016 p_z = new prt016();

            p_z.Pr_no = "AAAA";
            p_z.Pr_company = "A";
            p_z.Pr_dept = "A";
            p_z.Pr_cdept = "AA";
            PostProduct(p_z);
        }

        private async void PostProduct(prt016 p_z)
        {
            string json = JsonConvert.SerializeObject(p_z);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("http://localhost:54546/api/Prt016/Insert", httpContent);            
            if (!response.IsSuccessStatusCode)
                MessageBox.Show("新增失敗");
            else
                MessageBox.Show("新增成功");
                        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prt016 p_z = new prt016();
            p_z.Pr_no = "AAAA";
            p_z.Pr_company = "B";
            p_z.Pr_dept = "B";
            p_z.Pr_cdept = "BB";
            PutProduct(p_z);
        }

        private async void PutProduct(prt016 p_z)
        {
            string json = JsonConvert.SerializeObject(p_z);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync("http://localhost:54546/api/Prt016/Update", httpContent);
            if (!response.IsSuccessStatusCode)                
                MessageBox.Show("修改失敗");
            else
                MessageBox.Show("修改成功");
        }

        private void button2_Click(object sender, EventArgs e)
        {   
            Delete();
        }

        private async void Delete()
        {
            string Pr_no = "AAAA";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(string.Format("http://localhost:54546/api/Prt016/Delete?Pr_no={0}", Pr_no));            
            if (!response.IsSuccessStatusCode)
                MessageBox.Show("刪除失敗");
            else
                MessageBox.Show("刪除成功");
        }

        //private async void Delete()
        //{
        //    string Pr_no = "AAAA";
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.DeleteAsync(string.Format("http://localhost:54546/api/Prt016/Delete?Pr_no={0}", Pr_no));
        //    //response.EnsureSuccessStatusCode();
        //    //string responseBody = await response.Content.ReadAsStringAsync();
        //    if (!response.IsSuccessStatusCode)
        //        MessageBox.Show("刪除失敗");
        //    else
        //        MessageBox.Show("刪除成功");
        //}


    }
}

public class prt016
{
    #region 資料屬性
    public string Pr_no { get; set; }
    public string Pr_company { get; set; }
    public string Pr_dept { get; set; }
    public string Pr_cdept { get; set; }
    public string Pr_wk_cdept { get; set; }
    public string Pr_name { get; set; }
    public string Wk_code { get; set; }
    public string Pr_work { get; set; }
    public string Position { get; set; }
    public string Pr_idno { get; set; }
    public string Pr_sex { get; set; }
    public string Pr_blood { get; set; }
    public string Pr_merry { get; set; }
    public string Pr_local { get; set; }
    public string Pr_clas_code { get; set; }
    public string Pr_schl { get; set; }
    public string Pr_long { get; set; }
    public Int32 Pr_spec_yearpay { get; set; }
    public Int32 Pr_spec_monthpay { get; set; }
    public string Pr_tel_no { get; set; }
    public string Pr_in_date { get; set; }
    public string Pr_insr_date { get; set; }
    public string Pr_leave_date { get; set; }
    public string Pr_back_insr_date { get; set; }
    public string Pr_direct_type { get; set; }
    public string Pr_slry_type { get; set; }
    public string Bank_code { get; set; }
    public string Account_no { get; set; }
    public string Pr_local_addr { get; set; }
    public string Pr_comm_addr { get; set; }
    public Int32 Pr_live_pr { get; set; }
    public string Pr_comm_man { get; set; }
    public string Pr_comm_tel_no { get; set; }
    public string Pr_comm_relative { get; set; }
    public string Direct_type1 { get; set; }
    public string Direct_type2 { get; set; }
    public string Add_date { get; set; }
    public string Add_user { get; set; }
    public string Mod_date { get; set; }
    public string Mod_user { get; set; }
    public string Pr_birth_date { get; set; }
    public string Nation { get; set; }
    public string Old_safe_no { get; set; }
    public string Medic_safe_no { get; set; }
    public string Job_safe_no { get; set; }
    public string House_safe_no { get; set; }
    public string Dsc_login { get; set; }

    public decimal Tax_1 { get; set; }
    public decimal Tax_2 { get; set; }
    public decimal Tax_3 { get; set; }
    public decimal Tax_4 { get; set; }
    public decimal Tax_5 { get; set; }
    public decimal Tax_6 { get; set; }


    public int Work_Year { get; set; }//工作年資-年
    public int Work_Month { get; set; }//工作年資-月
    public int Work_Day { get; set; }//工作年資-日
    #endregion







}
