using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.Infrastructure.EmailSender
{
    public static class ConfigureEmailSenderHelper
    {
        public static WebApplicationBuilder ConfigureEmailSender(this WebApplicationBuilder builder)
        {
            var emailConfig = new EmailConfig();
            var configuration = builder.Configuration;
            configuration.GetSection("Authentication:Mail").Bind(emailConfig);
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            return builder;
        }
    }
}
