using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVAERP.Models;

namespace EVAERP.Forms
{
    public partial class pri001 : Form
    {        

        public pri001()
        {
            InitializeComponent();
            Config.SetWindowSize(this);            
            bindingSource1.DataSource = prt001.ToDoList(Login.DEPT).ToList();
            label1.Text = "資料由TT來，如需維護請聯絡TT相關人員";
        }


    }
}
