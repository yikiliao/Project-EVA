using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HRMmail_New.Models;
using System.Net.Mail;
using System.Windows.Forms;

namespace HRMmail_New
{
    class mailto
    {
        public static void SendMail(string ProgramId, string Dept, string Body,string Active)
        {
            if (hrmmail.GetMail(ProgramId, Dept, Active).ToList().Count == 0) return;
            bool b = true;
            try
            {
                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.BodyEncoding = Encoding.UTF8;               //mail.BodyEncoding = Encoding.Defult;//編碼 (一些特殊字體會變問號)               
                mail.Priority = MailPriority.High;//優先權

                foreach (var item in LogoAttr.LogoArr(Dept))
                {
                    string strFilePath = @"C:\CompLogo\" + item.img;
                    Attachment attachment = new Attachment(strFilePath)
                    {
                        Name = System.IO.Path.GetFileName(strFilePath),
                        NameEncoding = Encoding.UTF8,
                        TransferEncoding = System.Net.Mime.TransferEncoding.Base64
                    };
                    // 設定該附件為一個內嵌附件(Inline Attachment)
                    attachment.ContentDisposition.Inline = true;
                    attachment.ContentDisposition.DispositionType = System.Net.Mime.DispositionTypeNames.Inline;
                    mail.Attachments.Add(attachment);
                }
                //-----------

                Body += "<hr/>";
                Body += "<table border=0>";
                Body += "<tr>";
                foreach (var a in LogoAttr.LogoArr(Dept))
                {
                    Body += string.Format("<td><a href={0} title={1}> <img src={2} width='93' height='59' alt={3} border='0' /></td>", a.href, a.title, a.img, a.alt);
                }
                Body += "</tr>";
                Body += "</table>";
                //-----------------

                //SmtpClient SmtpServer = new SmtpClient("mail.chiffon");//郵件伺服器
                SmtpClient SmtpServer = new SmtpClient("192.168.66.27");//郵件伺服器
                mail.From = new MailAddress("root@evaglory.com.tw");//寄件人
                foreach (var a in (hrmmail.GetMail(ProgramId, Dept, Active).ToList()))
                {   
                    mail.To.Add(a.Mail);//收件人
                    if (b)
                    {
                        mail.Subject = a.Subject;//主旨 
                        b = false;
                    }
                }
                //mail.CC.Add(pt11@evaglory.com.tw);//副本
                //mail.Attachments.Add(new Attachment(@"C:\Users\俊佑\Desktop\新文字文件.txt"));//夾檔            
                mail.Body = Body;//本文內容

                SmtpServer.Send(mail);//寄信                 
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        
    }
}
