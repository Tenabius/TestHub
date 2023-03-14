using Microsoft.AspNetCore.Identity.UI.Services;
using MailKit.Net.Smtp;
using MimeKit;
using TestHub.Infrastructure.Interfaces;

namespace TestHub.Infrastructure.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _settings;

        public EmailSender(SmtpSettings settings, IKeyVaultManager keyVaultManager)
        {
            _settings = settings;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Gmail", _settings.Mailbox));
            message.To.Add(new MailboxAddress("User", email));
            message.Subject = subject;
            
            BodyBuilder builder = new BodyBuilder();
            builder.HtmlBody = htmlMessage;
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_settings.Server, _settings.Port!.Value, false);
                await client.AuthenticateAsync(_settings.User, _settings.Password);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}
