using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PlantC.CitoyensEntreprises.BLL.Services
{
    public class MailConfig
    {
        public string Host { get; set; }
        public string Mail { get; set; }
        public string Pwd { get; set; }
        public int Port { get; set; }
    }

    public class MailService
    {
        private MailConfig _config;
        private SmtpClient _smtpclient;

        public MailService(MailConfig config, SmtpClient smtpclient)
        {
            _config = config;
            _smtpclient = smtpclient;
        }

        public void SendEmail(string subject, string content, params string[] mails)
        {
            _smtpclient.Credentials = new NetworkCredential(_config.Mail, _config.Pwd);
            _smtpclient.Host = _config.Host;
            _smtpclient.Port = _config.Port;
            _smtpclient.EnableSsl = true;
            MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = content;
            message.IsBodyHtml = true;
            message.From = new MailAddress(_config.Mail);
            foreach(string mail in mails)
            {
                message.To.Add(mail);
            }
            try
            {
                _smtpclient.Send(message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                //ecrire dans un fichier de log 
                throw;
            }
        }
    }
}
