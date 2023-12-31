﻿using System.Net.Mail;
using System.Net;

namespace Shopping.UI.EmailServices
{
    public class MailHelper
    {
        public static bool SendEmail(string body, string to, string subject, bool isHtml = true)
        {
            return SendEmail(body, new List<string> { to }, subject, isHtml);
        }

        public static bool SendEmail(string body, List<string> to, string subject, bool isHtml = true)
        {
            bool result = false;

            try
            {
                var message = new MailMessage();
                message.From = new MailAddress("deneme@gmail.com");

                to.ForEach(x =>
                {
                    message.To.Add(new MailAddress(x));
                });
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;

                using (var smtp = new SmtpClient("smtp-mail.outlook.com", 587))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential("deneme@gmail.com", "deneme");

                    smtp.Send(message);
                    result = true;
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
