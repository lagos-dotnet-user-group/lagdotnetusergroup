using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace WebApplication.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public bool SendEmail(string email, string subject, string message)
        {
            throw new NotImplementedException();
        }

        public bool SendEmail(string email, string emailName, string subject, string message)
        {
            var body = new BodyBuilder();
            body.HtmlBody = message;
            var _message = new MimeMessage();
            _message.To.Add(new MailboxAddress(emailName, email));
            //TODO: change email to mail chimp
            _message.From.Add(new MailboxAddress("Lagos dotnet user group", "lagosdotnetusergroup@outlook.com"));
            _message.Subject = subject;
            _message.Body = body.ToMessageBody();
            // using (var client = new SmtpClient())
            // {
            //     client.LocalDomain = "";
            //     client.Connect("", 587, false);
            //     client.AuthenticationMechanisms.Remove("XOAUTH2"); // Note: since we don't have an OAuth2 token, disable
            //     client.Authenticate("", "");
            //     client.Send(_message);
            //     client.Disconnect(true);
            // }
            return true;
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
