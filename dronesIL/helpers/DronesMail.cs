using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace dronesIL.helpers
{
    public class DronesMail
    {
        private string smtpServer
        {
            get
            {
                return "smtp.gmail.com";
            }
        }
        private string smtpPassword
        {
            get
            {
                return "yKcgw}*TkB**H&nk";
            }
        }
        private string smtpUser
        {
            get
            {
                return "dronesIlSite@gmail.com";
            }
        }
        private string from { get; set; }
        private string to { get; set; }
        private string caption { get; set; }
        private Attachment attachment { get; set; }
        public DronesMail(string from,string to,string caption="", Attachment attchment=null)
        {
            this.from = from;
            this.to = to;
            this.caption = caption;
            if (attachment != null)
            {
                this.attachment = attchment;
            }
        }
        public bool sendMail(string body)
        {
            SmtpClient smtp = new SmtpClient(this.smtpServer, 587)
            {
                Credentials = new NetworkCredential(this.smtpUser, this.smtpPassword),
                EnableSsl=true
            };
            MailMessage mssg = new MailMessage(this.from, this.to)
            {
                Body = body,
                BodyEncoding = System.Text.Encoding.UTF8,
                IsBodyHtml = false,
                Subject = this.caption,
                SubjectEncoding = System.Text.Encoding.UTF8
            };
            if (this.attachment != null)
            {
                mssg.Attachments.Add(this.attachment);
                
            }
            try
            {
                smtp.Send(mssg);
                mssg.Dispose();
            }
            catch(Exception e)
            {
                string m = e.Message;
            }
            return true;

        }
    }
}
