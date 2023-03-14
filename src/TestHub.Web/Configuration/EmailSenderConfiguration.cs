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
    public class ConfigureEmailSenderHelper : IApplicationConfigurator
    {
        public void ConfigureApplication(WebApplicationBuilder builder)
        {
            var smtpSettings = new SmtpSettings();
            var configuration = builder.Configuration;
            configuration.GetSection("SmptSettings").Bind(smtpSettings);
            builder.Services.AddSingleton(smtpSettings);
            builder.Services.AddScoped<IEmailSender, EmailSender>();
        }
    }
}
