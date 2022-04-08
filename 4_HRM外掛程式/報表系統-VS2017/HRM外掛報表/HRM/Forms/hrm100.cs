using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using HRM.Models;
using HRM.Crpts;

namespace HRM.Forms
{
    public partial class hrm100 : Form
    {
        public hrm100()
        {
            InitializeComponent();
            Config.SetFormSize(this);
            //
            f_holdaytype.SelectedIndex = 0;//下拉選單第一項
            cboSoup.SelectedIndex = 0;
            cboNum.SelectedIndex = 0;
            f_begdate.Value = DateTime.Now.AddYears(-35);
            dayselect_lock();
        }


        private void dayselect_lock()
        {
            f_begdate.Enabled = false;
            f_enddate.Enabled = false;
        }
        private void dayselect_unlock()
        {
            f_begdate.Enabled = true;
            f_enddate.Enabled = true;
        }

        private void cboSoup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstOrder.Items.Clear();
            lstSource.Items.Clear();

            if (cboSoup.SelectedIndex == 0)
            {
                lstSource.Items.Add("全聯社");
                lstSource.Items.Add("家樂福");
                lstSource.Items.Add("大買家");
                lstSource.Items.Add("台中中友");
                lstSource.Items.Add("豐原太平洋");
            }
            else
            {
                lstSource.Items.Add("次小腿");
            }
        }

        private void butOrder_Click(object sender, EventArgs e)
        {
            if (lstSource.SelectedItem != null)
            {
                lstOrder.Items.Add(lstSource.SelectedItem);
                lstSource.Items.Remove(lstSource.SelectedItem);
            }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            if (lstOrder.SelectedItem != null)
            {
                lstSource.Items.Add(lstOrder.SelectedItem);
                lstOrder.Items.Remove(lstOrder.SelectedItem);
            }
        }

        private void butRenew_Click(object sender, EventArgs e)
        {
            cboSoup_SelectedIndexChanged(sender, e); //觸發下拉選單
            cboNum.SelectedIndex = 0;
            f_cname.Text = "";
            f_code.Text = "";
            f_holdaytype.SelectedIndex = 0;
            f_forg_type.SelectedIndex = 0;
        }

        private void f_cond1_CheckedChanged(object sender, EventArgs e)
        {
            if (f_cond1.Checked == true)
            {
                dayselect_unlock();
            }
            else
            {
                dayselect_lock();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (lstOrder.Items.Count == 0)
            {
                Config.Show("請選擇禮品");
                return;
            }
            else
            {
                var Org_Color = lb_msg.ForeColor;
                Cursor_wait(); //改變滑鼠游標漏斗指標
                Print_cs();
                UnCursor_wait(Org_Color); //改變滑鼠游標還原預設
            }
        }

        private void Cursor_wait()
        {
            lb_msg.ForeColor = Color.Blue;
            lb_msg.Text = "資料處理中...請稍候";
            System.Threading.Thread.Sleep(1000);//停1秒
            this.Cursor = Cursors.WaitCursor;//漏斗指標
        }

        private void UnCursor_wait(System.Drawing.Color Org_Color)
        {
            lb_msg.ForeColor = Org_Color;
            this.Cursor = Cursors.Default;//還原預設
            lb_msg.Text = "";
        }

        private void Print_cs()
        {
            CrystalReport_hrm100 rp = new CrystalReport_hrm100();

            rp.SetDataSource(mhrm100.ToDoList(f_code.Text, f_cname.Text, f_forg_type.SelectedIndex, f_begdate.Value, f_enddate.Value, f_cond1.Checked));

            string Report_Type = f_holdaytype.SelectedItem.ToString();//型態名稱五一..端午                       
            string _Type = cboSoup.SelectedItem.ToString(); //禮品類型
            string _Numm = cboNum.SelectedItem.ToString();  //禮品金額

            rp.SetParameterValue("ReportTypeParm", Report_Type);
            rp.SetParameterValue("GF_Count_Parm", lstOrder.Items.Count);
            if (lstOrder.Items.Count == 1)
            {
                rp.SetParameterValue("GF_Type_1_Parm", _Type);
                rp.SetParameterValue("GF_Text_1_Parm", lstOrder.Items[0]);
                rp.SetParameterValue("GF_Num_1_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_2_Parm", _Type);
                rp.SetParameterValue("GF_Text_2_Parm", "");
                rp.SetParameterValue("GF_Num_2_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_3_Parm", _Type);
                rp.SetParameterValue("GF_Text_3_Parm", "");
                rp.SetParameterValue("GF_Num_3_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_4_Parm", _Type);
                rp.SetParameterValue("GF_Text_4_Parm", "");
                rp.SetParameterValue("GF_Num_4_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_5_Parm", _Type);
                rp.SetParameterValue("GF_Text_5_Parm", "");
                rp.SetParameterValue("GF_Num_5_Parm", _Numm);
            }
            if (lstOrder.Items.Count == 2)
            {
                rp.SetParameterValue("GF_Type_1_Parm", _Type);
                rp.SetParameterValue("GF_Text_1_Parm", lstOrder.Items[0]);
                rp.SetParameterValue("GF_Num_1_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_2_Parm", _Type);
                rp.SetParameterValue("GF_Text_2_Parm", lstOrder.Items[1]);
                rp.SetParameterValue("GF_Num_2_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_3_Parm", _Type);
                rp.SetParameterValue("GF_Text_3_Parm", "");
                rp.SetParameterValue("GF_Num_3_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_4_Parm", _Type);
                rp.SetParameterValue("GF_Text_4_Parm", "");
                rp.SetParameterValue("GF_Num_4_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_5_Parm", _Type);
                rp.SetParameterValue("GF_Text_5_Parm", "");
                rp.SetParameterValue("GF_Num_5_Parm", _Numm);
            }
            if (lstOrder.Items.Count == 3)
            {
                rp.SetParameterValue("GF_Type_1_Parm", _Type);
                rp.SetParameterValue("GF_Text_1_Parm", lstOrder.Items[0]);
                rp.SetParameterValue("GF_Num_1_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_2_Parm", _Type);
                rp.SetParameterValue("GF_Text_2_Parm", lstOrder.Items[1]);
                rp.SetParameterValue("GF_Num_2_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_3_Parm", _Type);
                rp.SetParameterValue("GF_Text_3_Parm", lstOrder.Items[2]);
                rp.SetParameterValue("GF_Num_3_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_4_Parm", _Type);
                rp.SetParameterValue("GF_Text_4_Parm", "");
                rp.SetParameterValue("GF_Num_4_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_5_Parm", _Type);
                rp.SetParameterValue("GF_Text_5_Parm", "");
                rp.SetParameterValue("GF_Num_5_Parm", _Numm);
            }
            if (lstOrder.Items.Count == 4)
            {
                rp.SetParameterValue("GF_Type_1_Parm", _Type);
                rp.SetParameterValue("GF_Text_1_Parm", lstOrder.Items[0]);
                rp.SetParameterValue("GF_Num_1_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_2_Parm", _Type);
                rp.SetParameterValue("GF_Text_2_Parm", lstOrder.Items[1]);
                rp.SetParameterValue("GF_Num_2_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_3_Parm", _Type);
                rp.SetParameterValue("GF_Text_3_Parm", lstOrder.Items[2]);
                rp.SetParameterValue("GF_Num_3_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_4_Parm", _Type);
                rp.SetParameterValue("GF_Text_4_Parm", lstOrder.Items[3]);
                rp.SetParameterValue("GF_Num_4_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_5_Parm", _Type);
                rp.SetParameterValue("GF_Text_5_Parm", "");
                rp.SetParameterValue("GF_Num_5_Parm", _Numm);
            }
            if (lstOrder.Items.Count == 5)
            {
                rp.SetParameterValue("GF_Type_1_Parm", _Type);
                rp.SetParameterValue("GF_Text_1_Parm", lstOrder.Items[0]);
                rp.SetParameterValue("GF_Num_1_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_2_Parm", _Type);
                rp.SetParameterValue("GF_Text_2_Parm", lstOrder.Items[1]);
                rp.SetParameterValue("GF_Num_2_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_3_Parm", _Type);
                rp.SetParameterValue("GF_Text_3_Parm", lstOrder.Items[2]);
                rp.SetParameterValue("GF_Num_3_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_4_Parm", _Type);
                rp.SetParameterValue("GF_Text_4_Parm", lstOrder.Items[3]);
                rp.SetParameterValue("GF_Num_4_Parm", _Numm);
                //--
                rp.SetParameterValue("GF_Type_5_Parm", _Type);
                rp.SetParameterValue("GF_Text_5_Parm", lstOrder.Items[4]);
                rp.SetParameterValue("GF_Num_5_Parm", _Numm);
            }
            crystalReportViewer1.ReportSource = rp;
            crystalReportViewer1.Refresh();
        }

    }
}
