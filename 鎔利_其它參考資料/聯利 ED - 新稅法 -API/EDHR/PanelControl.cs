using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EDHR.Forms;
using Microsoft.Reporting.WinForms;
using EDHR.Models;

namespace EDHR
{   
    class PanelControl
    {      
        //流程圖顯示
        public string panelshow(string formname,Control panelname)
        {

            switch (formname)
            {
                case "Mainbody":
                    panelname.Controls.Clear();
                    Mainbody mainbody = new Mainbody();
                    mainbody.FormBorderStyle = FormBorderStyle.None;//無邊框
                    mainbody.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(mainbody);//添加到Panel
                    mainbody.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    mainbody.Show();
                    break;               
                
                case "PR":
                    panelname.Controls.Clear();
                    PR PRform = new PR();
                    PRform.FormBorderStyle = FormBorderStyle.None;
                    PRform.TopLevel = false;
                    panelname.Controls.Add(PRform);
                    PRform.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    PRform.Show();
                    break;                
                case "PR10001":
                    panelname.Controls.Clear();
                    PR10001 pr10001 = new PR10001();
                    pr10001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr10001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr10001);//添加到Panel
                    pr10001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr10001.Show();
                    break;
                case "PR01001":
                    panelname.Controls.Clear();
                    PR01001 pr01001 = new PR01001();
                    pr01001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr01001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr01001);//添加到Panel
                    pr01001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr01001.Show();
                    break;
                case "PR01101":
                    panelname.Controls.Clear();
                    PR01101 pr01101 = new PR01101();
                    pr01101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr01101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr01101);//添加到Panel
                    pr01101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr01101.Show();
                    break;
                case "PR10101":
                    panelname.Controls.Clear();
                    PR10101 pr10101 = new PR10101();
                    pr10101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr10101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr10101);//添加到Panel
                    pr10101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr10101.Show();
                    break;
                case "PR11101":
                    panelname.Controls.Clear();
                    PR11101 pr11101 = new PR11101();
                    pr11101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr11101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr11101);//添加到Panel
                    pr11101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr11101.Show();
                    break;
                case "PR02001":
                    panelname.Controls.Clear();
                    PR02001 pr02001 = new PR02001();
                    pr02001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr02001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr02001);//添加到Panel
                    pr02001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr02001.Show();
                    break;
                case "PR02101":
                    panelname.Controls.Clear();
                    PR02101 pr02101 = new PR02101();
                    pr02101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr02101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr02101);//添加到Panel
                    pr02101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr02101.Show();
                    break;
                case "PR03001":
                    panelname.Controls.Clear();
                    PR03001 pr03001 = new PR03001();
                    pr03001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr03001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr03001);//添加到Panel
                    pr03001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr03001.Show();
                    break;
                case "PR03101":
                    panelname.Controls.Clear();
                    PR03101 pr03101 = new PR03101();
                    pr03101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr03101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr03101);//添加到Panel
                    pr03101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr03101.Show();
                    break;
                case "PR03201":
                    panelname.Controls.Clear();
                    PR03201 pr03201 = new PR03201();
                    pr03201.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr03201.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr03201);//添加到Panel
                    pr03201.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr03201.Show();
                    break;
                case "PR04001":
                    panelname.Controls.Clear();
                    PR04001 pr04001 = new PR04001();
                    pr04001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr04001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr04001);//添加到Panel
                    pr04001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr04001.Show();
                    break;
                case "PR04101":
                    panelname.Controls.Clear();
                    PR04101 pr04101 = new PR04101();
                    pr04101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr04101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr04101);//添加到Panel
                    pr04101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr04101.Show();
                    break;
                case "PR04201":
                    panelname.Controls.Clear();
                    PR04201 pr04201 = new PR04201();
                    pr04201.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr04201.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr04201);//添加到Panel
                    pr04201.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr04201.Show();
                    break;
                case "PR04301":
                    panelname.Controls.Clear();
                    PR04301 pr04301 = new PR04301();
                    pr04301.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr04301.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr04301);//添加到Panel
                    pr04301.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr04301.Show();
                    break;
                case "PR04401":
                    panelname.Controls.Clear();
                    PR04401 pr04401 = new PR04401();
                    pr04401.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr04401.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr04401);//添加到Panel
                    pr04401.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr04401.Show();
                    break;
                case "PR05001":
                    panelname.Controls.Clear();
                    PR05001 pr05001 = new PR05001();
                    pr05001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr05001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr05001);//添加到Panel
                    pr05001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr05001.Show();
                    break;
                case "PR05101":
                    panelname.Controls.Clear();
                    PR05101 pr05101 = new PR05101();
                    pr05101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr05101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr05101);//添加到Panel
                    pr05101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr05101.Show();
                    break;
                case "PR05201":
                    panelname.Controls.Clear();
                    PR05201 pr05201 = new PR05201();
                    pr05201.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr05201.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr05201);//添加到Panel
                    pr05201.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr05201.Show();
                    break;
                case "PR06001":
                    panelname.Controls.Clear();
                    PR06001 pr06001 = new PR06001();
                    pr06001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr06001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr06001);//添加到Panel
                    pr06001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr06001.Show();
                    break;
                case "PR07001":
                    panelname.Controls.Clear();
                    PR07001 pr07001 = new PR07001();
                    pr07001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr07001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr07001);//添加到Panel
                    pr07001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr07001.Show();
                    break;
                case "PR07101":
                    panelname.Controls.Clear();
                    PR07101 pr07101 = new PR07101();
                    pr07101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr07101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr07101);//添加到Panel
                    pr07101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr07101.Show();
                    break;
                case "PR07201":
                    panelname.Controls.Clear();
                    PR07201 pr07201 = new PR07201();
                    pr07201.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr07201.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr07201);//添加到Panel
                    pr07201.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr07201.Show();
                    break;
                case "PR07301":
                    panelname.Controls.Clear();
                    PR07301 pr07301 = new PR07301();
                    pr07301.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr07301.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr07301);//添加到Panel
                    pr07301.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr07301.Show();
                    break;
                case "PR08001":
                    panelname.Controls.Clear();
                    PR08001 pr08001 = new PR08001();
                    pr08001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr08001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr08001);//添加到Panel
                    pr08001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr08001.Show();
                    break;
                case "PR09001":
                    panelname.Controls.Clear();
                    PR09001 pr09001 = new PR09001();
                    pr09001.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr09001.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr09001);//添加到Panel
                    pr09001.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr09001.Show();
                    break;
                case "PR09101":
                    panelname.Controls.Clear();
                    PR09101 pr09101 = new PR09101();
                    pr09101.FormBorderStyle = FormBorderStyle.None;//無邊框
                    pr09101.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(pr09101);//添加到Panel
                    pr09101.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    pr09101.Show();
                    break;


            }
            return null;
        }
         //表單程式顯示  
        
        public string formshow_Old(string formname)
        {
            //in ('S','L')
            char[] sarray = new char[] { ',' };
            string DataRang = sst901.Get(Home.Id).Rang;
            string[] sarray2 = DataRang.Replace("in ('", "").Replace("')", "").Replace("'", "").Split(sarray);




            switch (formname)
            {                
                
                //case "prf101":
                //   prf101 PRprf101 = new prf101();
                //   PRprf101.Show();
                //   break;
                //case "prf102":
                //   prf102 PRprf102 = new prf102();
                //   PRprf102.Show();
                //   break;
                //case "prf104":
                //   prf104 PRprf104 = new prf104();
                //   PRprf104.Show();
                //   break;
                //case "prf105":
                //   prf105 PRprf105 = new prf105();
                //   PRprf105.Show();
                //   break;
                //case "prf106":
                //   prf106 PRprf106 = new prf106();
                //   PRprf106.Show();
                //   break;
                //case "prf107":
                //   prf107 PRprf107 = new prf107();
                //   PRprf107.Show();
                //   break;
                //case "prf108":
                //   prf108 PRprf108 = new prf108();
                //   PRprf108.Show();
                //   break;
                //case "prf109":
                //   prf109 PRprf109 = new prf109();
                //   PRprf109.Show();
                //   break;
                //case "prf110":
                //   prf110 PRprf110 = new prf110();
                //   PRprf110.Show();
                //   break;
                //case "prf111":
                //   prf111 PRprf111 = new prf111();
                //   PRprf111.Show();
                //   break;
                case "pri001":
                    pri001 PRpri001 = new pri001();
                    PRpri001.Show();
                    break;
                //case "pri002":
                //   pri002 PRpri002 = new pri002();
                //   PRpri002.Show();
                //   break;
                //case "pri003":
                //   pri003 PRpri003 = new pri003();
                //   PRpri003.Show();
                //   break;
                //case "pri004":
                //   pri004 PRpri004 = new pri004();
                //   PRpri004.Show();
                //   break;
                //case "pri005":
                //   pri005 PRpri005 = new pri005();
                //   PRpri005.Show();
                //   break;
                case "pri006":
                    pri006 PRpri006 = new pri006();
                    PRpri006.Show();
                    break;
                //case "pri007":
                //   pri007 PRpri007 = new pri007();
                //   PRpri007.Show();
                //   break;
                case "pri008":
                    MessageBox.Show("此程式不要要維護");
                    break;
                    //pri008 PRpri008 = new pri008();
                    //PRpri008.Show();
                    //break;
                //case "pri009":
                //   pri009 PRpri009 = new pri009();
                //   PRpri009.Show();
                //   break;
                //case "pri010":
                //   pri010 PRpri010 = new pri010();
                //   PRpri010.Show();
                //   break;
                case "pri011":
                    pri011 PRpri011 = new pri011();
                    PRpri011.Show();
                    break;
                case "pri012":
                    pri012 PRpri012 = new pri012();
                    PRpri012.Show();
                    break;
                case "pri013":
                    pri013 PRpri013 = new pri013();
                    PRpri013.Show();
                    break;
                //case "pri014":
                //   pri014 PRpri014 = new pri014();
                //   PRpri014.Show();
                //   break;
                //case "pri015":
                //   pri015 PRpri015 = new pri015();
                //   PRpri015.Show();
                //   break;
                //case "pri016":
                //   pri016 PRpri016 = new pri016();
                //   PRpri016.Show();
                //   break;
                //case "pri017":
                //   pri017 PRpri017 = new pri017();
                //   PRpri017.Show();
                //   break;
                //case "pri018":
                //   pri018 PRpri018 = new pri018();
                //   PRpri018.Show();
                //   break;
                case "pri019":
                    pri019 PRpri019 = new pri019();
                    PRpri019.Show();
                    break;
                case "pri020":
                    pri020 PRpri020 = new pri020();
                    PRpri020.Show();
                    break;
                case "pri021":
                    pri021 PRpri021 = new pri021();
                    PRpri021.Show();
                    break;
                case "pri022":
                    pri022 PRpri022 = new pri022();
                    PRpri022.Show();
                    break;
                case "pri023":
                    pri023 PRpri023 = new pri023();
                    PRpri023.Show();
                    break;
                //case "pri024":
                //   pri024 PRpri024 = new pri024();
                //   PRpri024.Show();
                //   break;
                case "pri025":
                    pri025 PRpri025 = new pri025();
                    PRpri025.Show();
                    break;
                case "pri026":
                    pri026 PRpri026 = new pri026();
                    PRpri026.Show();
                    break;
                case "pri027":
                    pri027 PRpri027 = new pri027();
                    PRpri027.Show();
                    break;
                //case "pri028":
                //   pri028 PRpri028 = new pri028();
                //   PRpri028.Show();
                //   break;
                case "pri029":
                    pri029 PRpri029 = new pri029();
                    PRpri029.Show();
                    break;
                case "pri030":
                    pri030 PRpri030 = new pri030();
                    PRpri030.Show();
                    break;
                case "pri034":
                    pri034 PRpri034 = new pri034();
                    PRpri034.Show();
                    break;
                case "pri035":
                    pri035 PRpri035 = new pri035();
                    PRpri035.Show();
                    break;
                case "pri036":
                    pri036 PRpri036 = new pri036();
                    PRpri036.Show();
                    break;
                case "pri037":
                    pri037 PRpri037 = new pri037();
                    PRpri037.Show();
                    break;
                case "pri038":
                    MessageBox.Show("此程式目前不需要服務", "警告");
                    break;
                    //pri038 PRpri038 = new pri038();
                    //PRpri038.Show();
                    //break;
                case "pri040":
                    pri040 PRpri040 = new pri040();
                    PRpri040.Show();
                    break;
                case "pri041":
                    pri041 PRpri041 = new pri041();
                    PRpri041.Show();
                    break;
                case "pri042":
                    pri042 PRpri042 = new pri042();
                    PRpri042.Show();
                    break;
                case "pri043":
                    pri043 PRpri043 = new pri043();
                    PRpri043.Show();
                    break;
                case "pri044":
                    pri044 PRpri044 = new pri044();
                    PRpri044.Show();
                    break;
                case "pri045":
                    pri045 PRpri045 = new pri045();
                    PRpri045.Show();
                    break;
                case "pri046":
                    pri046 PRpri046 = new pri046();
                    PRpri046.Show();
                    break;

                case "prr001":

                    ReportParameter dept = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray = new ReportParameter[] { dept };
                    ReportView fm1 = new ReportView("/ERP/prr001", rparray);
                    fm1.Show();
                    break;
                case "prr003":
                    ReportParameter dept1 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept1.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray1 = new ReportParameter[] { dept1 };

                    ReportView fm2 = new ReportView("/ERP/prr003", rparray1);
                    fm2.Show();
                    break;
                case "prr004":
                    ReportParameter dept2 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept2.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray2 = new ReportParameter[] { dept2 };

                    ReportView fm3 = new ReportView("/ERP/prr004", rparray2);
                    fm3.Show();
                    break;
                case "prr005":
                    ReportParameter dept3 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept3.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray3 = new ReportParameter[] { dept3 };

                    ReportView fm4 = new ReportView("/ERP/prr005", rparray3);
                    fm4.Show();
                    break;
                case "prr006":
                    ReportParameter dept4 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept4.Visible = false;
                    }

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept4.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray4 = new ReportParameter[] { dept4 };

                    ReportView fm5 = new ReportView("/ERP/prr006", rparray4);
                    fm5.Show();
                    break;
                case "prr007":
                    ReportParameter dept5 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept5.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray5 = new ReportParameter[] { dept5 };

                    ReportView fm6 = new ReportView("/ERP/prr007", rparray5);
                    fm6.Show();
                    break;
                case "prr008":
                    ReportParameter dept6 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept6.Visible = false;
                    }

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept6.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray34 = new ReportParameter[] { dept6 };

                    ReportView fm35 = new ReportView("/ERP/prr008", rparray34);
                    fm35.Show();
                    break;
                case "prr009":
                    ReportParameter dept7 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept7.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray7 = new ReportParameter[] { dept7 };

                    ReportView fm8 = new ReportView("/ERP/prr009", rparray7);
                    fm8.Show();
                    break;
                case "prr010":
                    ReportParameter dept8 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept8.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray8 = new ReportParameter[] { dept8 };

                    ReportView fm9 = new ReportView("/ERP/prr010", rparray8);
                    fm9.Show();
                    break;
                case "prr011":
                    ReportParameter dept9 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept9.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray9 = new ReportParameter[] { dept9 };

                    ReportView fm10 = new ReportView("/ERP/prr011", rparray9);
                    fm10.Show();
                    break;
                case "prr012":
                    ReportParameter dept10 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept10.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray10 = new ReportParameter[] { dept10 };

                    ReportView fm11 = new ReportView("/ERP/prr012", rparray10);
                    fm11.Show();
                    break;
                case "prr013":
                    ReportParameter dept11 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept11.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray11 = new ReportParameter[] { dept11 };

                    ReportView fm12 = new ReportView("/ERP/prr013", rparray11);
                    fm12.Show();
                    break;
                case "prr014":
                    ReportParameter dept12 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept12.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray12 = new ReportParameter[] { dept12 };

                    ReportView fm13 = new ReportView("/ERP/prr014", rparray12);
                    fm13.Show();
                    break;
                case "prr015":
                    ReportParameter dept13 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept13.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray13 = new ReportParameter[] { dept13 };

                    ReportView fm14 = new ReportView("/ERP/prr015", rparray13);
                    fm14.Show();
                    break;
                case "prr016":
                    ReportParameter dept14 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept14.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray14 = new ReportParameter[] { dept14 };

                    ReportView fm15 = new ReportView("/ERP/prr016", rparray14);
                    fm15.Show();
                    break;
                case "prr017":
                    ReportParameter dept15 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept15.Visible = false;
                    }

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept15.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray15 = new ReportParameter[] { dept15 };

                    ReportView fm16 = new ReportView("/ERP/prr017", rparray15);
                    fm16.Show();
                    break;
                case "prr018":
                    ReportParameter dept16 = new ReportParameter("dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept16.Visible = false;
                    }
                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept16.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray16 = new ReportParameter[] { dept16 };

                    ReportView fm17 = new ReportView("/ERP/prr018", rparray16);
                    fm17.Show();
                    break;
                case "prr019":
                    ReportParameter dept17 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept17.Visible = false;
                    }
                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept17.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray17 = new ReportParameter[] { dept17 };

                    ReportView fm18 = new ReportView("/ERP/prr019", rparray17);
                    fm18.Show();
                    break;
                case "prr020":
                    ReportParameter dept18 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept18.Visible = false;
                    }

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept18.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray18 = new ReportParameter[] { dept18 };

                    ReportView fm19 = new ReportView("/ERP/prr020", rparray18);
                    fm19.Show();
                    break;
                case "prr022":
                    // DateTime today = new DateTime();
                    //int yy, mm;
                    //if (today.Day >= 10)
                    //{
                    //yy = today.Year;
                    //mm = today.Month;
                    //}
                    //else
                    //{
                    //if (today.Month == 1)
                    //{
                    //yy = today.Year - 1;
                    //mm = 12;
                    //}
                    //else
                    //{
                    //yy = today.Year;
                    //mm = today.Month - 1;
                    //}
                    //}
                    ReportParameter dept19 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept19.Values.Add(sarray2[i]);
                    }

                    //ReportParameter yy01 = new ReportParameter("y");
                    // yy01.Values.Add(yy + "");

                    //ReportParameter mm01 = new ReportParameter("mm01");
                    //mm01.Values.Add(mm + "");                    


                    ReportParameter[] rparray19 = new ReportParameter[] { dept19 };
                    ReportView fm20 = new ReportView("/ERP/prr022", rparray19);
                    fm20.Show();
                    break;
                case "prr024-L":
                    ReportParameter dept20 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept20.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray20 = new ReportParameter[] { dept20 };

                    ReportView fm21 = new ReportView("/ERP/prr024-L", rparray20);
                    fm21.Show();
                    break;
                case "prr024-S1":
                    ReportParameter dept21 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept21.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray21 = new ReportParameter[] { dept21 };

                    ReportView fm22 = new ReportView("/ERP/prr024-S1", rparray21);
                    fm22.Show();
                    break;
                case "prr025":

                    ReportParameter dept36 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept36.Visible = false;
                    }
                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept36.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray22 = new ReportParameter[] { dept36 };

                    ReportView fm23 = new ReportView("/ERP/prr025", rparray22);
                    fm23.Show();
                    break;
                case "prr026":
                    ReportParameter dept22 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept22.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray23 = new ReportParameter[] { dept22 };

                    ReportView fm24 = new ReportView("/ERP/prr026", rparray23);
                    fm24.Show();
                    break;
                case "prr027":
                    ReportParameter dept23 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept23.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray24 = new ReportParameter[] { dept23 };

                    ReportView fm25 = new ReportView("/ERP/prr027", rparray24);
                    fm25.Show();
                    break;
                case "prr028":
                    ReportParameter dept35 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept35.Visible = false;
                    }

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept35.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray25 = new ReportParameter[] { dept35 };

                    ReportView fm26 = new ReportView("/ERP/prr028", rparray25);
                    fm26.Show();
                    break;
                case "prr029":
                    ReportParameter dept24 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept24.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray26 = new ReportParameter[] { dept24 };

                    ReportView fm27 = new ReportView("/ERP/prr029", rparray26);
                    fm27.Show();
                    break;
                case "prr032":
                    ReportParameter[] rparray27 = new ReportParameter[] { };

                    ReportView fm28 = new ReportView("/ERP/prr032", rparray27);
                    fm28.Show();
                    break;
                case "prr033":
                    ReportParameter[] rparray28 = new ReportParameter[] { };

                    ReportView fm29 = new ReportView("/ERP/prr033", rparray28);
                    fm29.Show();
                    break;
                case "prr035":
                    ReportParameter dept44 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept44.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray29 = new ReportParameter[] { };

                    ReportView fm30 = new ReportView("/ERP/prr035", rparray29);
                    fm30.Show();
                    break;
                case "prr036":
                    ReportParameter dept37 = new ReportParameter("pr_dept");
                    if (sarray2.Count() <= 1)
                    {
                        dept37.Visible = false;
                    }

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept37.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray30 = new ReportParameter[] { dept37 };

                    ReportView fm31 = new ReportView("/ERP/prr036", rparray30);
                    fm31.Show();
                    break;
                case "prr023-L":
                    ReportParameter dept25 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept25.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray31 = new ReportParameter[] { dept25 };

                    ReportView fm32 = new ReportView("/ERP/prr023-L", rparray31);
                    fm32.Show();
                    break;
                case "prr023-S":
                    ReportParameter dept26 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept26.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray32 = new ReportParameter[] { dept26 };

                    ReportView fm33 = new ReportView("/ERP/prr023-S", rparray32);
                    fm33.Show();
                    break;
                case "prr034":
                    ReportParameter dept27 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept27.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray33 = new ReportParameter[] { dept27 };

                    ReportView fm34 = new ReportView("/ERP/prr034", rparray33);
                    fm34.Show();
                    break;

                case "prr031-L":
                    ReportParameter dept28 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept28.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray35 = new ReportParameter[] { dept28 };

                    ReportView fm36 = new ReportView("/ERP/prr031-L", rparray35);
                    fm36.Show();
                    break;
                case "prr031-S":
                    ReportParameter dept29 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept29.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray36 = new ReportParameter[] { dept29 };

                    ReportView fm37 = new ReportView("/ERP/prr031-S", rparray36);
                    fm37.Show();
                    break;
                case "prr024-S2":
                    ReportParameter dept30 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept30.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray37 = new ReportParameter[] { dept30 };

                    ReportView fm38 = new ReportView("/ERP/prr024-S2", rparray37);
                    fm38.Show();
                    break;
                case "prr032-S":
                    ReportParameter[] rparray38 = new ReportParameter[] { };

                    ReportView fm39 = new ReportView("/ERP/prr032-S", rparray38);
                    fm39.Show();
                    break;
                case "prr034-S":
                    ReportParameter dept32 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept32.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray39 = new ReportParameter[] { dept32 };

                    ReportView fm40 = new ReportView("/ERP/prr034-S", rparray39);
                    fm40.Show();
                    break;
                case "prr033-S":
                    ReportParameter[] rparray40 = new ReportParameter[] { };

                    ReportView fm41 = new ReportView("/ERP/prr033-S", rparray40);
                    fm41.Show();
                    break;
                case "prr030-S1":
                    ReportParameter dept38 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept38.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray41 = new ReportParameter[] { dept38 };

                    ReportView fm42 = new ReportView("/ERP/prr030-S1", rparray41);
                    fm42.Show();
                    break;
                case "prr030-L1":
                    ReportParameter dept39 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept39.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray42 = new ReportParameter[] { dept39 };

                    ReportView fm43 = new ReportView("/ERP/prr030-L1", rparray42);
                    fm43.Show();
                    break;
                case "prr037":
                    ReportParameter dept40 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept40.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray43 = new ReportParameter[] { dept40 };

                    ReportView fm44 = new ReportView("/ERP/prr037", rparray43);
                    fm44.Show();
                    break;
                case "prr002":
                    // ReportParameter dept41 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        // dept41.Values.Add("L");
                    }
                    ReportParameter[] rparray44 = new ReportParameter[] { };

                    ReportView fm45 = new ReportView("/ERP/prr002", rparray44);
                    fm45.Show();
                    break;
                case "prr038":
                    ReportParameter dept42 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept42.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray45 = new ReportParameter[] { dept42 };

                    ReportView fm46 = new ReportView("/ERP/prr038", rparray45);
                    fm46.Show();
                    break;
                case "prr039":
                    ReportParameter[] rparray46 = new ReportParameter[] { };

                    ReportView fm47 = new ReportView("/ERP/prr039", rparray46);
                    fm47.Show();
                    break;
                case "prr024-S3":
                    ReportParameter dept43 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept43.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray47 = new ReportParameter[] { dept43 };

                    ReportView fm48 = new ReportView("/ERP/prr024-S3", rparray47);
                    fm48.Show();
                    break;
                case "prr023-L1":
                    ReportParameter dept45 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept45.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray48 = new ReportParameter[] { dept45 };

                    ReportView fm49 = new ReportView("/ERP/prr023-L1", rparray48);
                    fm49.Show();
                    break;
                case "prr024-S4":
                    ReportParameter dept46 = new ReportParameter("dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept46.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray49 = new ReportParameter[] { dept46 };

                    ReportView fm50 = new ReportView("/ERP/prr024-S4", rparray49);
                    fm50.Show();
                    break;

                
                case "ssi011":
                    ssi011 FAssi011 = new ssi011();
                    FAssi011.Show();
                    break;
                
                
                case "ssi901":
                    ssi901 FAssi901 = new ssi901();
                    FAssi901.Show();
                    break;
                
                case "ssi903":
                    ssi903 FAssi903 = new ssi903();
                    FAssi903.Show();
                    break;
                case "ssi904":
                    ssi904 FAssi904 = new ssi904();
                    FAssi904.Show();
                    break;
                case "ssi999":
                    ssi999 fm = new ssi999();
                    fm.Show();
                    break;
            }
            return null;
        }
        //表單程式顯示  
        public string formshow(string formname)
        {
            //in ('S','L')
            char[] sarray = new char[] { ',' };
            string DataRang = sst901.Get(Home.Id).Rang;
            string[] sarray2 = DataRang.Replace("in ('", "").Replace("')", "").Replace("'", "").Split(sarray);
            switch (formname)
            {                
                
                case "pri001":
                    pri001 PRpri001 = new pri001();
                    PRpri001.Show();
                    break;
                
                case "pri006":
                    pri006 PRpri006 = new pri006();
                    PRpri006.Show();
                    break;
                
                case "pri008":
                    MessageBox.Show("此程式功能暫停，如有問題請聯絡電腦室。\n 謝謝您!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
                    //pri008 PRpri008 = new pri008();
                    //PRpri008.Show();
                    //break;
                
                case "pri011":
                    pri011 PRpri011 = new pri011();
                    PRpri011.Show();
                    break;
                case "pri012":
                    pri012 PRpri012 = new pri012();
                    PRpri012.Show();
                    break;
                case "pri013":
                    pri013 PRpri013 = new pri013();
                    PRpri013.Show();
                    break;
                
                case "pri019":
                    pri019 PRpri019 = new pri019();                    
                    PRpri019.Show();
                    
                    break;
                case "pri020":
                    pri020 PRpri020 = new pri020();
                    PRpri020.Show();
                    break;
                case "pri021":
                    pri021 PRpri021 = new pri021();
                    PRpri021.Show();
                    break;
                case "pri022":
                    pri022 PRpri022 = new pri022();
                    PRpri022.Show();
                    break;
                case "pri023":                    
                    pri023 PRpri023 = new pri023();
                    PRpri023.Show();
                    break;                
                case "pri025":
                    pri025 PRpri025 = new pri025();
                    PRpri025.Show();
                    break;
                case "pri026":
                    pri026 PRpri026 = new pri026();
                    PRpri026.Show();
                    break;
                case "pri027":
                    pri027 PRpri027 = new pri027();
                    PRpri027.Show();
                    break;
                
                case "pri029":
                    pri029 PRpri029 = new pri029();
                    PRpri029.Show();
                    break;
                case "pri030":
                    pri030 PRpri030 = new pri030();
                    PRpri030.Show();
                    break;
                case "pri034":
                    pri034 PRpri034 = new pri034();
                    PRpri034.Show();
                    break;
                case "pri035":
                    pri035 PRpri035 = new pri035();
                    PRpri035.Show();
                    break;
                case "pri036":
                    pri036 PRpri036 = new pri036();
                    PRpri036.Show();
                    break;
                case "pri037":
                    pri037 PRpri037 = new pri037();
                    PRpri037.Show();
                    break;
                case "pri038":
                    MessageBox.Show("此程式功能暫停，如有問題請聯絡電腦室。\n 謝謝您!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);                    
                    break;
                    //pri038 PRpri038 = new pri038();
                    //PRpri038.Show();
                    //break;
                case "pri040":
                    pri040 PRpri040 = new pri040();
                    PRpri040.Show();
                    break;
                case "pri041":
                    pri041 PRpri041 = new pri041();
                    PRpri041.Show();
                    break;
                case "pri042":
                    pri042 PRpri042 = new pri042();
                    PRpri042.Show();
                    break;
                case "pri043":
                    pri043 PRpri043 = new pri043();
                    PRpri043.Show();
                    break;
                case "pri044":
                    pri044 PRpri044 = new pri044();
                    PRpri044.Show();
                    break;
                case "pri045":
                    pri045 PRpri045 = new pri045();
                    PRpri045.Show();
                    break;
                case "pri046":
                    pri046 PRpri046 = new pri046();
                    PRpri046.Show();
                    break;

                
                //系統整體設定
                case "ssi011":
                    ssi011 FAssi011 = new ssi011();
                    FAssi011.Show();
                    break;
                            
                case "ssi901":
                    ssi901 FAssi901 = new ssi901();
                    FAssi901.Show();
                    break;
                
                case "ssi903":
                    ssi903 FAssi903 = new ssi903();
                    FAssi903.Show();
                    break;
                case "ssi904":
                    ssi904 FAssi904 = new ssi904();
                    FAssi904.Show();
                    break;
                case "ssi999":
                    ssi999 fm = new ssi999();
                    fm.Show();
                    break;

                 
                //CR報表
                //工號對照表
                case "crr001":
                    crr001 crr001 = new crr001();
                    crr001.Show();
                    break;
                //員工資料表
                case "crr002":
                    crr002 crr002 = new crr002();
                    crr002.Show();
                    break;
                //壽星明細表
                case "crr003":
                    crr003 crr003 = new crr003();
                    crr003.Show();
                    break;
                //人事資料明細表
                case "crr004":
                    crr004 crr004 = new crr004();
                    crr004.Show();
                    break;
                //地址資料明細表
                case "crr005":
                    crr005 crr005 = new crr005();
                    crr005.Show();
                    break;
                //人員表
                case "crr006":
                    crr006 crr006 = new crr006();
                    crr006.Show();
                    break;
                //人員分析表
                case "crr007":
                    crr007 crr007 = new crr007();
                    crr007.Show();
                    break;
                //個人資料明細表
                case "crr008":
                    crr008 crr008 = new crr008();
                    crr008.Show();
                    break;
                //代碼清冊
                case "crr009":
                    crr009 crr009 = new crr009();
                    crr009.Show();
                    break;
                //年度員工特別休假給假標準對照表
                case "crr012":
                    crr012 crr012 = new crr012();
                    crr012.Show();
                    break;
                //籍貫分析表
                case "crr013":
                    crr013 crr013 = new crr013();
                    crr013.Show();
                    break;
                //年資分析表
                case "crr014":
                    crr014 crr014 = new crr014();
                    crr014.Show();
                    break;
                //教育程度分析表
                case "crr015":
                    crr015 crr015 = new crr015();
                    crr015.Show();
                    break;
                //離職人員表
                case "crr016":
                    crr016 crr016 = new crr016();
                    crr016.Show();
                    break;
                //年齡分析表
                case "crr018":
                    crr018 crr018 = new crr018();
                    crr018.Show();
                    break;
                //年度員工特別休假明細表
                case "crr019":
                    crr019 crr019 = new crr019();
                    crr019.Show();
                    break;
                //年度員工請假統計表
                case "crr020":
                    crr020 crr020 = new crr020();
                    crr020.Show();
                    break;
                //薪資基準表
                case "crr022":
                    crr022 crr022 = new crr022();
                    crr022.Show();
                    break;
                //薪資彙總表
                case "crr023":
                    crr023 crr023 = new crr023();
                    crr023.Show();
                    break;
                //薪資歸級表
                case "crr025":
                    crr025 crr025 = new crr025();
                    crr025.Show();
                    break;
                //津貼表
                case "crr026":
                    crr026 crr026 = new crr026();
                    crr026.Show();
                    break;                
                //薪資轉帳資料表
                case "crr028":
                    crr028 crr028 = new crr028();
                    crr028.Show();
                    break;
                //薪資袋
                case "crr030":
                    crr030 crr030 = new crr030();
                    crr030.Show();
                    break;

                //出勤報表(日報,月報,彙總)
                case "crr031":
                    crr031 crr031 = new crr031();
                    crr031.Show();
                    break;

                //出勤日報表
                //case "crr032":
                //    crr032 crr032 = new crr032();
                //    crr032.Show();
                //    break;

                //出勤月報表
                //case "crr033":
                //    crr033 crr033 = new crr033();
                //    crr033.Show();
                //    break;

                //出勤彙總表
                //case "crr034":
                //    crr034 crr034 = new crr034();
                //    crr034.Show();
                //    break;

                //勞動合同報表列印
                case "crr036":
                    crr036 crr036 = new crr036();
                    crr036.Show();
                    break;

                //工資表
                case "crr038":
                    crr038 crr038 = new crr038();
                    crr038.Show();
                    break;

                //個人所得申報表
                case "crr040":
                    crr040 crr040 = new crr040();
                    crr040.Show();
                    break;

                //員工投保明細表
                case "crr042":
                    crr042 crr042 = new crr042();
                    crr042.Show();
                    break;

                //解除終止勞動合同證明書
                case "crr044":
                    crr044 crr044 = new crr044();
                    crr044.Show();
                    break;

                //個人所得申報表(新稅法)
                case "crr045":
                    crr045 crr045 = new crr045();
                    crr045.Show();
                    break;

                case "prr030-S1":
                    ReportParameter dept38 = new ReportParameter("pr_dept");

                    for (int i = 0; i < sarray2.Length; i++)
                    {
                        dept38.Values.Add(sarray2[i]);
                    }
                    ReportParameter[] rparray41 = new ReportParameter[] { dept38 };

                    ReportView fm42 = new ReportView("/ERP/prr030-S1", rparray41);
                    fm42.Show();
                    break;

                //年終獎金設定作業
                case "pri100":
                    pri100 pri100 = new pri100();
                    pri100.Show();
                    break; 
               
                //年終獎金轉檔作業
                case "pri110":
                    pri110 pri110 = new pri110();
                    pri110.Show();
                    break;

                //年終獎金團體維護
                case "pri115":
                    pri115 pri115 = new pri115();
                    pri115.Show();
                    break;

                //年終獎金關帳作業
                case "pri130":
                    pri130 pri130 = new pri130();
                    pri130.Show();
                    break;

                //年終獎金報表
                case "qrr205":
                    qrr205 qrr205 = new qrr205();
                    qrr205.Show();
                    break;

            }
            return null;
        }

    }
}
