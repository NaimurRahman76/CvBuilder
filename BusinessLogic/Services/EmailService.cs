using BusinessObject.Validation;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class EmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public void SendValidationCode(string recipientEmail, int validationCode)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.SenderEmail, _emailSettings.SenderName),
                Subject = "Validation Code",
                Body = $"Your Cv Maker Account validation code is: {validationCode.ToString()}",
                IsBodyHtml = false
            };

            mailMessage.To.Add(recipientEmail);

            using (var smtpClient = new SmtpClient(_emailSettings.SmtpServer, _emailSettings.Port))
            {
                smtpClient.Credentials = new NetworkCredential(_emailSettings.Username, _emailSettings.Password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mailMessage);
            }
        }
    }
}
