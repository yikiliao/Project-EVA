using EVAERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace EVAERP
{
    class mailto
    {
        /// <summary>
        /// 郵件自動發信
        /// </summary>
        /// <param name="ProgramId">程式代碼</param>
        /// <param name="Dept">廠部代碼</param>
        /// <param name="Senduser">寄件人ERP帳號</param>
        /// <param name="Body">信件內容</param>
        public static void SendMail(string ProgramId, string Dept, string Senduser, string Body)
        {
            bool b =  true; 
            try
            {                
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("mail.chiffon");//郵件伺服器
                mail.From = new MailAddress(sst901.GetMail(Senduser).Mail);//寄件人
                foreach (var a in (sst903.GetMail(ProgramId, Dept).ToList()))
                {
                    mail.To.Add(a.Mail);//收件人
                    if(b)
                    {
                        mail.Subject = a.Subject ;//主旨 
                        b = false;
                    }
                }                
                //mail.CC.Add(pt11@evaglory.com.tw);//副本
                //mail.Attachments.Add(new Attachment(@"C:\Users\俊佑\Desktop\新文字文件.txt"));//夾檔            
                mail.Body = System.String.Format(Body);//本文內容
                SmtpServer.Send(mail);//寄信                 
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        public static void SendMailHtml(string ProgramId, string Dept, string Senduser, string Body)
        {
            bool b = true;
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.Default;
                SmtpClient SmtpServer = new SmtpClient("mail.chiffon");//郵件伺服器
                mail.From = new MailAddress(sst901.GetMail(Senduser).Mail);//寄件人
                foreach (var a in (sst903.GetMail(ProgramId, Dept).ToList()))
                {
                    mail.To.Add(a.Mail);//收件人
                    if (b)
                    {
                        mail.Subject = string.Format("{0} {1}", sst011.Get().Dept_name, a.Subject);//主旨 
                        b = false;
                    }
                }
                //mail.CC.Add(pt11@evaglory.com.tw);//副本
                //mail.Attachments.Add(new Attachment(@"C:\Users\俊佑\Desktop\新文字文件.txt"));//夾檔            
                mail.Body = System.String.Format(Body);//本文內容
                SmtpServer.Send(mail);//寄信                 
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        

    }
}
