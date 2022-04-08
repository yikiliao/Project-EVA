﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.Models;
using HRM.Forms;

namespace HRM
{
    /// <summary>
    /// 所有視窗的設定寫在這裡
    /// </summary>
    public class Config
    {   
        
        // <summary>
        /// 設定視窗為根據桌面調整大小;並禁止改變 
        /// </summary>
        //public static void SetFormSize(Form Fm, string Type)
        //{
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    //DeskWidth = 1440;
        //    Fm.Width = System.Convert.ToInt32(DeskWidth * 0.90);
        //    Fm.Height = System.Convert.ToInt32(DeskHeight * 0.90);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            
        //    if (Type == "F") //維護畫面
        //    {
        //        Fm.MaximizeBox = false;
        //        Fm.ControlBox = false;
        //    }
        //    if (Type == "R" || Type == "Q" || Type == "W") //報表主畫面R;或維護畫面查詢Q;或開窗下拉畫面W
        //    {
        //        if (Type == "Q" || Type == "W")
        //        {
        //            Fm.Width = System.Convert.ToInt32(DeskWidth * 0.35);
        //            Fm.Height = System.Convert.ToInt32(DeskHeight * 0.40);
        //        }
        //        Fm.MaximizeBox = false;
        //        Fm.MinimizeBox = false;
        //    }
        //    if (Type == "M") //選單
        //    {
        //        Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        //    }
        //    if (Type == "F" || Type == "R")
        //    {
        //        Fm.Text = string.Format("{0}－{1}", Fm.Text, Conn.GetName(Login.DB));
        //    }
        //}

        //public static void SetFormSize(Form Fm,string Type)
        //{   
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;          
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    Fm.Width = System.Convert.ToInt32(DeskWidth * 0.95);
        //    Fm.Height = System.Convert.ToInt32(DeskHeight * 0.95);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    if (Type == "R"||Type=="Q"||Type=="W") //報表主畫面R;或維護畫面查詢Q;或開窗下拉畫面W
        //    {
        //        if (Type == "Q" || Type == "W")
        //        {
        //            Fm.Width = System.Convert.ToInt32(DeskWidth * 0.35);
        //            Fm.Height = System.Convert.ToInt32(DeskHeight * 0.40);
        //        }
        //    }
        //}


        //public static void SetFontSize(Form Fm)
        //{
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    //DeskWidth = 1440;
        //    if (DeskWidth < 1280)
        //    {
        //        Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
        //        Application.Exit();
        //    }
            
        //    switch (DeskWidth)
        //    {
        //        case 1920 :                    
        //            Fm.Font = new Font("新細明體", 11);
        //            break;
        //        case 1680:
        //            Fm.Font = new Font("新細明體", 10.5f);
        //            break;
        //        case 1600:
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //        case 1440:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //        case 1366:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        case 1360:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        case 1280:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;                
        //        default:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //    }
            
        //}

        public static void SetFormSize(Form Fm, string Type)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;     //畫面寬
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;   //畫面高
            decimal Resize = 0.9M; //畫面縮放比
            //DeskWidth = 1440;
            //DeskHeight = 900;
            if (DeskWidth < 1280)
            {
                Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
                Application.Exit();
            }

            switch (DeskWidth)
            {
                case 1920:
                    Fm.Font = new Font("新細明體", 11);                    
                    break;
                case 1680:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1600:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1440:                    
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 1;
                    break;
                case 1366:                    
                    Fm.Font = new Font("新細明體",10);
                    Resize = 1;
                    break;
                case 1360:                    
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                case 1280:                    
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                default:                    
                    Fm.Font = new Font("新細明體", 10);
                    Resize = 1;
                    break;
            }
            Fm.Width = System.Convert.ToInt32(DeskWidth * Resize);
            Fm.Height = System.Convert.ToInt32(DeskHeight * Resize);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            if (Type == "F") //維護畫面
            {
                Fm.MaximizeBox = false;
                Fm.ControlBox = false;
            }
            if (Type == "R" || Type == "Q" || Type == "W") //報表主畫面R;或維護畫面查詢Q;或開窗下拉畫面W
            {
                if (Type == "Q")
                {
                    Fm.Width = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.45);
                    Fm.Height = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height* 0.3);                    
                }
                if (Type == "W")
                {
                    Fm.Width = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Width * 0.35);
                    Fm.Height = System.Convert.ToInt32(Screen.PrimaryScreen.WorkingArea.Height * 0.40);
                }
                Fm.MaximizeBox = false;
                Fm.MinimizeBox = false;
            }
            if (Type == "M") //選單
            {
                Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            }
            if (Type == "F" || Type == "R")
            {
                //Fm.Text = string.Format("{0}－{1}", Fm.Text, Conn.GetName(Login.DB));
            }

            setTag(Fm);
        }

        private static void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }

        //public static void SetFormSize(Form Fm, string Type)
        //{
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    DeskWidth = 1440;
        //    if (DeskWidth < 1280)
        //    {
        //        Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
        //        Application.Exit();
        //    }
        //    switch (DeskWidth)
        //    {
        //        case 1920:
        //            Fm.Font = new Font("新細明體", 11);
        //            break;
        //        case 1680:
        //            Fm.Font = new Font("新細明體", 10.5f);
        //            break;
        //        case 1600:
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //        case 1440:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //        case 1366:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        case 1360:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        case 1280:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("Lucida Fax", 9);
        //            break;
        //        default:
        //            Fm.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        //            Fm.AutoSize = false;
        //            Fm.Font = new Font("新細明體", 10);
        //            break;
        //    }

        //    Fm.Width = System.Convert.ToInt32(DeskWidth * 0.90);
        //    Fm.Height = System.Convert.ToInt32(DeskHeight * 0.90);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    if (Type == "F") //維護畫面
        //    {
        //        Fm.MaximizeBox = false;
        //        Fm.ControlBox = false;
        //    }
        //    if (Type == "R" || Type == "Q" || Type == "W") //報表主畫面R;或維護畫面查詢Q;或開窗下拉畫面W
        //    {
        //        if (Type == "Q" || Type == "W")
        //        {
        //            Fm.Width = System.Convert.ToInt32(DeskWidth * 0.35);
        //            Fm.Height = System.Convert.ToInt32(DeskHeight * 0.40);
        //        }
        //        Fm.MaximizeBox = false;
        //        Fm.MinimizeBox = false;
        //    }
        //    if (Type == "M") //選單
        //    {
        //        Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        //    }
        //    if (Type == "F" || Type == "R")
        //    {
        //        Fm.Text = string.Format("{0}－{1}", Fm.Text, Conn.GetName(Login.DB));
        //    }


        //}




        public static void SetPer(Form Fm)
        {            
            // 找出字體大小,並算出比例
            float dpiX, dpiY;
            Graphics graphics = Fm.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;
            int intPercent = (dpiX == 96) ? 100 : (dpiX == 120) ? 125 : 150; 
            float Per = intPercent / 100;
            
            //電腦螢幕字體如果有變大;怕畫面會擠不下去;所以設定為10
            if (Per >1)                
                Fm.Font = new Font("新細明體", 10);
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

        //public static void SetHomeSize(Form Fm)
        //{
        //    Fm.Font = new Font("新細明體", 11);
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    Fm.Width = 3508;
        //    Fm.Height = 2480;
        //    Fm.Width = System.Convert.ToInt32(Fm.Width * 0.9);
        //    Fm.Height = System.Convert.ToInt32(Fm.Height * 0.9);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消

        //    //Fm.ControlBox = true;
        //    //Fm.MaximizeBox = false;//隱藏最大視窗
        //    //Fm.MinimizeBox = false;//隱藏最小視窗
        //    //Fm.FormBorderStyle = FormBorderStyle.None;//邊框都取消

        //}

        //public static void SetFormSize(Form Fm)
        //{
        //    Fm.Font = new Font("新細明體", 11);
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    Fm.Width = 3508;
        //    Fm.Height = 2480;
        //    Fm.Width = System.Convert.ToInt32(Fm.Width * 0.9);
        //    Fm.Height = System.Convert.ToInt32(Fm.Height * 0.9);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;//邊框都取消
        //    Fm.MaximizeBox = false;//隱藏最大視窗
        //    Fm.MinimizeBox = false;//隱藏最小視窗
        //    Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        //    Fm.ControlBox = true;//保留邊框
        //}

        public static void SetHomeSize(Form Fm)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;     //畫面寬
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;   //畫面高
            decimal Resize = 0.95M; //畫面縮放比
            //int DeskWidth = 1440;
            //int DeskHeight = 900;
            if (DeskWidth < 1280)
            {
                Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
                Application.Exit();
            }
            switch (DeskWidth)
            {
                case 1920:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1680:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1600:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1440:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 1;
                    break;
                case 1366:
                    Fm.Font = new Font("新細明體", 10);
                    Resize = 1;
                    break;
                case 1360:
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                case 1280:
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                default:
                    Fm.Font = new Font("新細明體", 10);
                    Resize = 1;
                    break;
            }
            Fm.Width = System.Convert.ToInt32(DeskWidth * Resize);
            Fm.Height = System.Convert.ToInt32(DeskHeight * Resize);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
        }

        public static void SetFormSize(Form Fm)
        {
            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;     //畫面寬
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;   //畫面高
            decimal Resize = 0.9M; //畫面縮放比
            //int DeskWidth = 1440;
            //int DeskHeight = 900;
            if (DeskWidth < 1280)
            {
                Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
                Application.Exit();
            }
            switch (DeskWidth)
            {
                case 1920:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1680:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1600:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 0.95M;
                    break;
                case 1440:
                    Fm.Font = new Font("新細明體", 11);
                    Resize = 1;
                    break;
                case 1366:
                    Fm.Font = new Font("新細明體", 10);
                    Resize = 1;
                    break;
                case 1360:
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                case 1280:
                    Fm.Font = new Font("新細明體", 9);
                    Resize = 1;
                    break;
                default:
                    Fm.Font = new Font("新細明體", 10);
                    Resize = 1;
                    break;
            }
            Fm.Width = System.Convert.ToInt32(DeskWidth * Resize);
            Fm.Height = System.Convert.ToInt32(DeskHeight * Resize);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.MaximizeBox = false;//隱藏最大視窗
            Fm.MinimizeBox = false;//隱藏最小視窗
            Fm.ControlBox = false;//保留邊框;把最大控制,小等的控制項取消
            Fm.ControlBox = true;//保留邊框
        }

        //public static void SetWindowSize(Form Fm)
        //{
        //    int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;
        //    int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;
        //    Fm.Width = System.Convert.ToInt32(DeskWidth * 0.17);
        //    Fm.Height = System.Convert.ToInt32(DeskHeight * 0.4);
        //    Fm.StartPosition = FormStartPosition.CenterScreen;
        //    Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //    Fm.MaximizeBox = false;
        //    Fm.MinimizeBox = false;
        //    Fm.Font = new Font("新細明體", 11);
        //}

        public static void SetWindowSize(Form Fm)
        {

            int DeskWidth = Screen.PrimaryScreen.WorkingArea.Width;     //畫面寬
            int DeskHeight = Screen.PrimaryScreen.WorkingArea.Height;   //畫面高
            decimal WResize = 0.25M; //畫面縮放比 寬
            decimal HResize = 0.40M; //畫面縮放比 高
            //int DeskWidth = 1440;
            //int DeskHeight = 900;
            if (DeskWidth < 1280)
            {
                Config.Show("螢幕解析度設定太低，畫面會顯示不完全，程式無法執行，請聯絡電腦室。");
                Application.Exit();
            }
            switch (DeskWidth)
            {
                case 1920:
                    Fm.Font = new Font("新細明體", 11);
                    WResize = 0.25M;
                    break;
                case 1680:
                    Fm.Font = new Font("新細明體", 11);
                    WResize = 0.25M;
                    break;
                case 1600:
                    Fm.Font = new Font("新細明體", 11);
                    WResize = 0.25M;
                    break;
                case 1440:
                    Fm.Font = new Font("新細明體", 11);
                    WResize = 0.28M;
                    break;
                case 1366:
                    Fm.Font = new Font("新細明體", 10);
                    WResize = 0.28M;
                    break;
                case 1360:
                    Fm.Font = new Font("新細明體", 9);
                    WResize = 0.30M;
                    break;
                case 1280:
                    Fm.Font = new Font("新細明體", 9);
                    WResize = 0.30M;
                    break;
                default:
                    Fm.Font = new Font("新細明體", 10);
                    WResize = 0.25M;
                    break;
            }

            Fm.Width = System.Convert.ToInt32(DeskWidth * WResize);
            Fm.Height = System.Convert.ToInt32(DeskHeight * HResize);
            Fm.StartPosition = FormStartPosition.CenterScreen;
            Fm.FormBorderStyle = FormBorderStyle.FixedDialog;
            Fm.MaximizeBox = false;
            Fm.MinimizeBox = false;
        }

    }
}
