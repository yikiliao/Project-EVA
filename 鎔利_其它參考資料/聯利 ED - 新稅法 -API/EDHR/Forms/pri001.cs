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
using System.Net.Http;
using Newtonsoft.Json;


namespace EDHR.Forms
{
    public partial class pri001 : Form
    {
        //public pri001()
        //{
        //    InitializeComponent();
        //    Config.Set_rpFormSize(this);
        //    bindingSource1.DataSource = prt001.ToDoList(Login.DEPT).ToList();
        //}
        public pri001()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);            
            GetAllProducts();
        }

        private async void GetAllProducts()
        {
            string Url = string.Format("http://192.168.66.17:54546/api/Prt001/Get?DB={0}&Dept={1}&Department_code", Login.DB.ToString(), Login.DEPT);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(Url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            ShowResult(JsonConvert.DeserializeObject<List<prt001>>(responseBody));
        }

        private void ShowResult(List<prt001> p_prt001)
        {
            bindingSource1.DataSource = p_prt001;
        }


    }
}
