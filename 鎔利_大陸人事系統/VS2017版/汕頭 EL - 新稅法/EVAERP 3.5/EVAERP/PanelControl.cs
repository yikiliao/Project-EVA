using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using EVAERP.Forms;
using Microsoft.Reporting.WinForms;
using EVAERP.Models;

namespace EVAERP
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
                case "BM":            
                    panelname.Controls.Clear();
                    BM BMform = new BM();
                    BMform.FormBorderStyle = FormBorderStyle.None; 
                    BMform.TopLevel = false; 
                    panelname.Controls.Add(BMform);
                    BMform.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    BMform.Show();                    
                    break;
                case "BM1":
                    panelname.Controls.Clear();
                    BM1 bm_detel = new BM1();
                    bm_detel.FormBorderStyle = FormBorderStyle.None;//無邊框
                    bm_detel.TopLevel = false;//不是最頂層視窗
                    panelname.Controls.Add(bm_detel);//添加到Panel
                    bm_detel.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
                    bm_detel.Show();
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
                    pri008 PRpri008 = new pri008();
                    PRpri008.Show();
                    break;
                
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
                
                case "pri036":
                    pri036 PRpri036 = new pri036();
                    PRpri036.Show();
                    break;
                
                case "pri038":
                    pri038 PRpri038 = new pri038();
                    PRpri038.Show();
                    break;
                
                case "pri041":
                    pri041 PRpri041 = new pri041();
                    PRpri041.Show();
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

                case "pri100":
                    pri100 PRpri100 = new pri100();
                    PRpri100.Show();
                    break;                

                case "pri105":
                    pri105 PRpri105 = new pri105();
                    PRpri105.Show();
                    break;

                case "pri110":
                    pri110 PRpri110 = new pri110();
                    PRpri110.Show();
                    break;

                case "pri115":
                    pri115 PRpri115 = new pri115();
                    PRpri115.Show();
                    break;

                case "pri120":
                    pri120 PRpri120 = new pri120();
                    PRpri120.Show();
                    break;

                case "pri125":
                    pri125 PRpri125 = new pri125();
                    PRpri125.Show();
                    break;

                case "pri130":
                    pri130 PRpri130 = new pri130();
                    PRpri130.Show();
                    break;

                case "qrr200":
                    qrr200 PRqrr200 = new qrr200();
                    PRqrr200.Show();
                    break;

                case "qrr205":
                    qrr205 PRqrr205 = new qrr205();
                    PRqrr205.Show();
                    break;

                case "qrr210":
                    qrr210 PRqrr210 = new qrr210();
                    PRqrr210.Show();
                    break;

                case "qrr215":
                    qrr215 PRqrr215 = new qrr215();
                    PRqrr215.Show();
                    break;

                case "qrr220":
                    qrr220 PRqrr220 = new qrr220();
                    PRqrr220.Show();
                    break;

                case "qrr225":
                    qrr225 PRqrr225 = new qrr225();
                    PRqrr225.Show();
                    break;

                
                //系統整體設定 
                case "ssi901":
                    ssi901 FAssi901 = new ssi901();
                    FAssi901.Show();
                    break;
                case "ssi902":
                    ssi902 FAssi902 = new ssi902();
                    FAssi902.Show();
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

                //個人所得申報表
                case "crr045":
                    crr045 crr045 = new crr045();
                    crr045.Show();
                    break;

            }
            return null;
        }

    }
}
