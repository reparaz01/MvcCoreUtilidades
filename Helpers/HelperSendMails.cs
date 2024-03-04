using System.Net.Mail;
using System.Net;

namespace MvcCoreUtilidades.Helpers
{
    public class HelperSendMails
    {
        private readonly IConfiguration configuration;

        public HelperSendMails(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void EnviarCorreo(string para, string asunto, string mensaje)
        {
            MailMessage mail = new MailMessage();

            string user = this.configuration.GetValue<string>("MailSettings:Credentials:User");

            mail.From = new MailAddress(user);
            mail.To.Add(para);
            mail.Subject = asunto;
            mail.Body = mensaje;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.Normal;

            string password = this.configuration.GetValue<string>("MailSettings:Credentials:Password");
            string hostName = this.configuration.GetValue<string>("MailSettings:ServerSmtp:Host");
            int port = this.configuration.GetValue<int>("MailSettings:ServerSmtp:Port");
            bool enableSSL = this.configuration.GetValue<bool>("MailSettings:ServerSmtp:EnableSsl");
            bool defaultCredentials = this.configuration.GetValue<bool>("MailSettings:ServerSmtp:DefaultCredentials");

            SmtpClient smtpClient = new SmtpClient();

            smtpClient.Host = hostName;
            smtpClient.Port = port;
            smtpClient.EnableSsl = enableSSL;
            smtpClient.UseDefaultCredentials = defaultCredentials;

            NetworkCredential credentials = new NetworkCredential(user, password);
            smtpClient.Credentials = credentials;

            smtpClient.Send(mail);
        }
    }
}