using Microsoft.AspNetCore.Identity.UI.Services;
using TestHub.Infrastructure.EmailSender;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class EmailSenderConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            var smtpSettings = new SmtpSettings();
            var configuration = builder.Configuration;
            configuration.GetSection("SmptSettings").Bind(smtpSettings);
            builder.Services.AddSingleton(smtpSettings);
            builder.Services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
