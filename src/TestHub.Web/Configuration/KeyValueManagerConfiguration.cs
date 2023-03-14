﻿using TestHub.Web.Interfaces;
using TestHub.Web.Services;

namespace TestHub.Web.Configuration
{
    public class KeyValueManagerConfiguration : IApplicationConfigurator
    {
        public void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IKeyVaultManager, GoogleSecretManager>();
        }
    }
}
