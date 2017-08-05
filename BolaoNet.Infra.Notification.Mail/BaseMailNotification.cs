using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Notification.Mail
{
    public class BaseMailNotification
    {
        #region Variables

        private static DateTime _lastEmailSent = DateTime.MinValue;
        private static object lockObject = new object();

        #endregion

        #region Properties

        protected string CurrentUserName { get; set; }

        #endregion

        #region Constructors/Destructors

        public BaseMailNotification(string currentUserName)
        {
            this.CurrentUserName = currentUserName;
        }

        #endregion

        #region Methods

        protected string GetFolderTemplates()
        {
            string temp = System.Configuration.ConfigurationManager.AppSettings["TemplatesHtml"];
            if (string.IsNullOrEmpty(temp))
                return "";
            else
                return temp;
        }
        protected void SendMailFromAppSettingsConfig(string title, string body, bool htmlType, string[] targets, params string[] attachmentFiles)
        {
            string temp = null;
            temp = System.Configuration.ConfigurationManager.AppSettings["MailEnableSSL"];
            if (string.IsNullOrEmpty(temp))
                temp = "false";
            bool enableSsl = bool.Parse(temp);

            string smtpServer = System.Configuration.ConfigurationManager.AppSettings["MailSmtp"];

            temp = System.Configuration.ConfigurationManager.AppSettings["MailPort"];
            if (string.IsNullOrEmpty(temp))
                temp = "0";
            int port = int.Parse(temp);

            string from = System.Configuration.ConfigurationManager.AppSettings["MailFrom"];

            string password = System.Configuration.ConfigurationManager.AppSettings["MailPassword"];

            temp = System.Configuration.ConfigurationManager.AppSettings["WaitTime"];
            int waitTime = int.Parse(temp);

            SendMail(waitTime, enableSsl, smtpServer, port, from, password, title, body, htmlType, targets, attachmentFiles);

        }
        protected void SendMail(int waitTime, bool enableSsl, string smtpServer, int port, string from, string password, string title, string body, bool htmlType, string[] targets, params string[] attachmentFiles)
        {
            SmtpClient client = null;

            if (port != 0)
            {
                client = new SmtpClient(smtpServer, port);
            }
            else
            {
                client = new SmtpClient(smtpServer);
            }
            client.EnableSsl = enableSsl;

            if (!string.IsNullOrEmpty(password))
            {
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(from, password);
                client.Credentials = credentials;
                //client.UseDefaultCredentials = false;
            }

            MailAddress fromMail = new MailAddress(from);

            //Only allow sending by 1 thread at a time
            //This will throttle how many messages can be sent within
            //a certain amount of time by setting a static variable which
            //holds the time the last email was sent.
            lock (lockObject)
            {
                while (_lastEmailSent.AddMilliseconds(waitTime) > DateTime.Now)
                {
                    System.Threading.Thread.Sleep(waitTime);
                }

                _lastEmailSent = DateTime.Now;

                //for (int i = 0; i < targets.Length; i++)
                //{
                    //MailAddress to = new MailAddress(targets[i]);   
                    MailAddress to = new MailAddress(targets[0]);    

                    // Specify the message content.
                    using (MailMessage message = new MailMessage(fromMail, to))
                    {
                        for (int i = 1; i < targets.Length; i++ )
                        {
                            message.CC.Add(new MailAddress(targets[i]));
                        }

                        if (attachmentFiles != null && attachmentFiles.Length > 0)
                        {
                            for (int c = 0; c < attachmentFiles.Length; c++)
                                message.Attachments.Add(new Attachment(attachmentFiles[c]));
                        }

                        message.Subject = title;
                        message.Body = body;
                        message.IsBodyHtml = htmlType; 

                        client.Send(message);
                    }

                //}
            }//end lock

        }

        #endregion       
    }
}
