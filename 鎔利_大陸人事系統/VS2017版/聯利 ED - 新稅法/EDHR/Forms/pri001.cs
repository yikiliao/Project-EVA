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

namespace EDHR.Forms
{
    public partial class pri001 : Form
    {
        public pri001()
        {
            InitializeComponent();            
            Config.Set_rpFormSize(this);
            bindingSource1.DataSource = prt001.ToDoList(Login.DEPT).ToList();
        }
        
    }
}
