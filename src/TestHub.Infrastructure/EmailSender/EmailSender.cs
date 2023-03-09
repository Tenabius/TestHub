using Microsoft.AspNetCore.Identity.UI.Services;
using MailKit.Net.Smtp;
using MimeKit;

namespace TestHub.Infrastructure.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _config;

        public EmailSender(EmailConfig config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sender", _config.User));
            message.To.Add(new MailboxAddress("Receiver", email));
            message.Subject = subject;
            
            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_config.Server, _config.Port!.Value, false);
                await client.AuthenticateAsync(_config.User, _config.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
