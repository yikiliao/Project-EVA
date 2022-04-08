using EDHR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EDHR.Forms
{
    public partial class pri0081 : Form
    {
        public pri0081()
        {
            InitializeComponent();
            Config.SetWindowSize(this);
        }
        public string Ho_date { get; set; }
        public string Ho_desc { get; set; }
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (f_Check() == false)
                return;
            Ho_date = f_ho_date.Text;
            Ho_desc = f_ho_desc.Text;
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private bool f_Check()
        {
            if (f_ho_date.Text == String.Empty)
            {
                Config.Show("日期不可空白");
                f_ho_date.Focus();
                return false;
            }

            if (f_ho_desc.Text == String.Empty)
            {
                Config.Show("說明不可空白");
                f_ho_desc.Focus();
                return false;
            }
            return true;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Int16 _weekday = Convert.ToInt16(dateTimePicker1.Value.DayOfWeek);//判斷是否星期日跟星期六
            string _weekname="";
            if (_weekday == 0 || _weekday == 6)
                _weekname = _weekday == 6 ? "星期六" : "星期日";
            f_ho_date.Text = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            f_ho_desc.Text = _weekname;
        }
    }
}
