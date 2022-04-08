using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EVAERP.Models;
using EVAERP.Forms;

using System.Data;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace EVAERP
{
    /// <summary>
    /// 所有視窗的設定寫在這裡
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 設定視窗為根據桌面調整大小;並禁止改變 
        /// </summary>
        /// <param name="Fm"></param>
        public static void SetFormSize(Form Fm)
        {
            Fm.Font = new Font("新細明體", 11);            
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //Fm.Width = 1440;
            //Fm.Height = 900;
            Fm.Width = DeskWidth;
            Fm.Height = DeskHeight;
            Fm.Width = System.Convert.ToInt32(Fm.Width * 0.95);
            Fm.Height = System.Convert.ToInt32(Fm.Height * 0.95);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.MaximizeBox = false;
            Fm.ControlBox = false;
            Fm.Text = string.Format("{0}－{1}", Fm.Text, Conn.GetName(Login.DB));
        }

        public static void Set_rpFormSize(Form Fm)
        {
            Fm.Font = new Font("新細明體", 11);
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //Fm.Width = 1440;
            //Fm.Height = 900;
            Fm.Width = DeskWidth;
            Fm.Height = DeskHeight;
            Fm.Width = System.Convert.ToInt32(Fm.Width * 0.95);
            Fm.Height = System.Convert.ToInt32(Fm.Height * 0.95);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.MaximizeBox = false;
            Fm.MinimizeBox = false;
            Fm.Text = string.Format("{0}－{1}", Fm.Text, Conn.GetName(Login.DB));            
           // Fm.ControlBox = false;

        }
        public static void SetHomeSize(Form Fm)
        {
            Fm.Font = new Font("新細明體", 11);
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //Fm.Width = 3508;
            //Fm.Height = 2480;
            Fm.Width = DeskWidth;
            Fm.Height = DeskHeight;
            Fm.Width = System.Convert.ToInt32(Fm.Width * 0.95);
            Fm.Height = System.Convert.ToInt32(Fm.Height * 0.95);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            //Fm.MaximizeBox = false;//隱藏最大視窗
            //Fm.MinimizeBox = false;//隱藏最小視窗
            //Fm.FormBorderStyle = FormBorderStyle.None;//邊框都取消

        }

        public static void SetWindowSize(Form Fm)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //Fm.Width = System.Convert.ToInt32(DeskWidth * 0.25);
            //Fm.Width = System.Convert.ToInt32(DeskWidth * 0.40);
            Fm.Width = System.Convert.ToInt32(DeskWidth * 0.30);
            //Fm.Height = System.Convert.ToInt32(DeskHeight * 0.25);
            Fm.Height = System.Convert.ToInt32(DeskHeight * 0.40);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.MaximizeBox = false;
            Fm.MinimizeBox = false;
            //Fm.FormBorderStyle = FormBorderStyle.None;
            Fm.Font = new Font("新細明體", 11);
        }
        public static void SetQuerySize(Form Fm)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;            
            Fm.Width = System.Convert.ToInt32(DeskWidth * 0.40);            
            Fm.Height = System.Convert.ToInt32(DeskHeight * 0.40);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.MaximizeBox = false;
            Fm.MinimizeBox = false;
            //Fm.ControlBox = false;
            //Fm.FormBorderStyle = FormBorderStyle.None;
            Fm.Font = new Font("新細明體", 11);
        }
        
        public static void SetWindowSizeNoControlBox(Form Fm)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
            Fm.Width = System.Convert.ToInt32(DeskWidth * 0.25);
            Fm.Height = System.Convert.ToInt32(DeskHeight * 0.3);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.ControlBox = false;
            Fm.Font = new Font("新細明體", 11);
        }

        public static void TextReadOnly(TextBox e)
        {
            //清空欄位
            e.Text = string.Empty;
            //先將原本的BackColor取出來
            Color backColor = e.BackColor;
            //設定ReadOnly=true
            e.ReadOnly = true;
            //把原本的BackColor Assign回去    
            e.BackColor = backColor;
            //固定白色
            //e.BackColor = Color.White;
        }

        /// <summary>
        /// 訊息視窗,出現確認,取消
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public static string Message(string Msg)
        {
            var ans = "";
            DialogResult result = MessageBox.Show(Msg, "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
                ans = "Y";
            if (result == DialogResult.Cancel)
                ans = "N";
            return ans;
        }

        /// <summary>
        /// 訊息視窗,只回應確定
        /// </summary>
        /// <param name="Msg"></param>
        public static void Show(string Msg)
        {
            MessageBox.Show(Msg, "訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        /// <summary>
        /// 設定DateTimePicker 日期
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="vd"></param>
        public static void Set_DateTo(DateTimePicker dt, string vd)
        {
            if (vd == null || vd == "" || vd == " ")
            {
                dt.Format = DateTimePickerFormat.Custom;
                dt.CustomFormat = " ";
            }
            else
            {
                dt.Format = DateTimePickerFormat.Custom;
                dt.CustomFormat = vd;
                dt.Value = DateTime.Parse(vd);
            }
        }

        


        /// <summary>
        /// 流水自動編號
        /// </summary>
        /// <param name="Dept">廠部編號</param>
        /// <param name="Subsystem"></param>
        /// <param name="No">型態</param>
        /// <returns>流水編號</returns>
        public string SerialNumber(string Dept, string Subsystem, string No)
        {
            string Serialnumber = "";
            List<sst013> LS1 = new List<sst013>();
            LS1 = sst013.SerialNumbers(Dept, Subsystem, No, "Y").ToList();
            Serialnumber = LS1[0].Dept;
            Serialnumber += LS1[0].Subsystem;
            Serialnumber += LS1[0].No;
            switch (LS1[0].No_mod)
            {
                case 1:
                    Serialnumber += DateTime.Today.ToString("yyyyMM");
                    Serialnumber += (LS1[0].Receipt_no).ToString("00000");
                    break;
                case 2:
                    Serialnumber += DateTime.Today.ToString("yyyy");
                    Serialnumber += (LS1[0].Receipt_no).ToString("0000000");
                    break;
                case 3:
                    Serialnumber += DateTime.Today.ToString("yyyyMMdd");

                    Serialnumber += (LS1[0].Receipt_no).ToString("000");
                    break;
            }

            var p_sst013 = new sst013();
            p_sst013.Dept = LS1[0].Dept;
            p_sst013.Subsystem = LS1[0].Subsystem;
            p_sst013.No = LS1[0].No;
            p_sst013.Receipt_no = LS1[0].Receipt_no + 1;
            p_sst013.UpdateSerialNumbers(p_sst013.Dept, p_sst013.Subsystem, p_sst013.No);
            //Show("流水編號:" + Serialnumber);
            return Serialnumber;

        }

        //判斷是否薪資關帳
        public static bool ClosePay(decimal Yy, decimal Mm, string Dept)
        {            
            prt034 p_prt034 = new prt034();
            p_prt034 = prt034.Get(Yy, Mm, Dept);
            if (p_prt034 == null)
            {
                return false;
            }
            return true;
        }

        //字體是否加粗
        public static void FontBlod(Control ctl_false, bool Blod)
        {
            foreach (Control c in ctl_false.Controls)
            {
                var fm = new FontFamily(c.Font.Name);//控制項字型
                var fs = c.Font.Size;//控制項字體大小                
                if (c is TextBox)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is ComboBox)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is DateTimePicker)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                if (c is NumericUpDown)
                {
                    if (Blod == true)
                    {
                        c.Font = new Font(fm, fs, FontStyle.Bold);//加粗
                    }
                    else
                    {
                        c.Font = new Font(fm, fs, FontStyle.Regular);//一般
                    }
                }
                FontBlod(c, Blod);
            }
        }

        public static void GetColor(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).BackColor = Color.Beige;
            if (sender is ComboBox)
                ((ComboBox)sender).BackColor = Color.Beige;
            if (sender is NumericUpDown)
                ((NumericUpDown)sender).BackColor = Color.Beige;
            
        }

        public static void UnColor(object sender, EventArgs e)
        {
            if (sender is TextBox)
                ((TextBox)sender).BackColor = Color.White;
            if (sender is ComboBox)
                ((ComboBox)sender).BackColor = Color.White;
            if (sender is NumericUpDown)
                ((NumericUpDown)sender).BackColor = Color.White;
        }

        public static void GetCol(object TX)
        {
            if (TX is TextBox)
            {
                int str = 0;
                int end = ((TextBox)TX).TextLength;
                ((TextBox)TX).ForeColor = Color.Beige;
                ((TextBox)TX).Select(str, end);
                ((TextBox)TX).Focus();
            }
        }

        public static void UnCol(object TX)
        {
            ((TextBox)TX).BackColor = Color.White;
        }

    }
}
