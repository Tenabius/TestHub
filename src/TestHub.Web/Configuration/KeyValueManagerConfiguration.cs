using TestHub.Web.Interfaces;
using TestHub.Infrastructure.Interfaces;
using TestHub.Infrastructure.Services;

namespace TestHub.Web.Configuration
{
    public class KeyValueManagerConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IKeyVaultManager, GoogleSecretManager>();
        }
    }
}
