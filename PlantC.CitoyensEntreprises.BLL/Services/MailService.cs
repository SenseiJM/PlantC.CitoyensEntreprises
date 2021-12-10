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
        private SmtpClient _client;

        public MailService(MailConfig config, SmtpClient smtpclient)
        {
            _config = config;
            _client = smtpclient;
        }

        public void SendEmail(string subject, string content, params string[] mails)
        {
            _client.Credentials = new NetworkCredential(_config.Mail, _config.Pwd);
            _client.Host = _config.Host;
            _client.Port = _config.Port;
            _client.EnableSsl = true;
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
                _client.Send(message);
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
