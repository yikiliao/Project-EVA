using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ttt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void but_SelectALL_Click(object sender, EventArgs e)
        {
            GetAllProducts();
        }

        private async void GetAllProducts()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:54546/api/PA");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            ShowResult(JsonConvert.DeserializeObject<List<ZCOND>>(responseBody));
        }

        private void ShowResult(List<ZCOND> zCONDs)
        {
            richTextBox1.Clear();
            foreach (var item in zCONDs)
            {
                richTextBox1.Text += item.Code + " " + item.Code_desc + " " + item.Comm + "\r\n";
            }
        }


        public class ZCOND
        {
            #region 資料屬性
            public string Code { get; set; }
            public string Code_desc { get; set; }
            public string Comm { get; set; }
            #endregion
        }
       

        private void but_Delete_Click(object sender, EventArgs e)
        {
            string p_code = f_code_del.Text;
            Delete(p_code);
        }
        private async void Delete(string p_code)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync(string.Format("http://localhost:54546/api/PA?Code={0}", p_code));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            GetAllProducts();            
        }



        private void but_Insert_Click(object sender, EventArgs e)
        {            
            PostProduct();
        }

        private async void PostProduct()
        {
            ZCOND p_z = new ZCOND();
            p_z.Code = f_cond.Text;
            p_z.Code_desc = f_code_desc.Text;
            p_z.Comm = f_comm.Text;

            string json = JsonConvert.SerializeObject(p_z);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("http://localhost:54546/api/PA", httpContent);            
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            but_SelectALL_Click(this, null);
            //ShowResult(JsonConvert.DeserializeObject<List<ZCOND>>(responseBody));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZCOND p_z = new ZCOND();
            p_z.Code = f_code_upd.Text;
            p_z.Code_desc = f_code_desc_upd.Text;
            p_z.Comm = f_comm_upd.Text;
            PutProduct(p_z);
        }

        private async void PutProduct(ZCOND p_z)
        {
            string json = JsonConvert.SerializeObject(p_z);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync("http://localhost:54546/api/PA", httpContent);
            if (response.IsSuccessStatusCode)
                GetAllProducts();
            else
                MessageBox.Show("修改失敗");            
        }

        


        //private async void PutProduct(ZCOND p_z)
        //{
        //    string json = JsonConvert.SerializeObject(p_z);
        //    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.PutAsync(string.Format("http://localhost:54546/api/PA?Code={0}", p_z.Code), httpContent);
        //    response.EnsureSuccessStatusCode();
        //    string responseBody = await response.Content.ReadAsStringAsync();

        //}
    }
}
