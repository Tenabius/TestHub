using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using TestHub.Infrastructure.EmailSender;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class ConfigureEmailSenderHelper : IApplicationConfiguration
    {
        public void ConfigureApplication(WebApplicationBuilder builder)
        {
            var emailConfig = new EmailConfig();
            var configuration = builder.Configuration;
            configuration.GetSection("Authentication:Mail").Bind(emailConfig);
            builder.Services.AddSingleton(emailConfig);
            builder.Services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
