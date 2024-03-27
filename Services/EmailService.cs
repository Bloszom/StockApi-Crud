using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using morningclassonapi.DTO.Email;
using morningclassonapi.Helper;
using morningclassonapi.Interfaces;
using Org.BouncyCastle.Asn1.Ocsp;

namespace morningclassonapi.Services
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _config;


        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDTO mail)
        {

            string body = PopulateRegisterEmail(mail.UserName, mail.Otp);

            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config["EmailSettings:EmailUserName"]));
            email.To.Add(MailboxAddress.Parse(mail.To));
            email.Subject = mail.Subject;
            // email.Body = new TextPart(TextFormat.Html) { Text = mail.Body };

            var builder = new BodyBuilder();

            builder.HtmlBody = body;

            using var smtp = new SmtpClient();

            smtp.Connect(_config["EmailSettings:EmailHost"], int.Parse(_config["EmailSettings:EmailPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["EmailSettings:EmailUserName"], _config["EmailSettings:EmailPassword"]);

            smtp.Send(email);
            smtp.Disconnect(true);

        }

        private string PopulateRegisterEmail(string userName, string otp)
        {
            string body = string.Empty;

            //verbatim= @, normal=//
            string filepath = Directory.GetCurrentDirectory() + @"\Template\RegistrationTemplate.html\";
            using (StreamReader reader = new StreamReader(filepath))
            {
                body = reader.ReadToEnd(filepath);
            }

            body = body.Replace("{UserName}", UserName);
            body = body.Replace("{Otp}", Otp);

            return body;
        }

    }

}
