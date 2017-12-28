using System;
using System.Configuration;
using System.Net.Mail;


namespace DevaxiloS.Infras.Email
{
    public static class EmailHelper
    {
        public static string GmailUserLogin = ConfigurationManager.AppSettings["GmailUserLogin"].ToString();
        public static string GmailPassword = ConfigurationManager.AppSettings["GmailPassword"].ToString();
        public static string SendMail(string toList, string from, string ccList, string subject, string body)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress(from);
                message.From = fromAddress;
                message.To.Add(toList);
                if (!string.IsNullOrEmpty(ccList)) message.CC.Add(ccList);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = body;

                // We use gmail as our smtp client
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(GmailUserLogin, GmailPassword);

                smtpClient.Send(message);
                msg = "Successful";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
