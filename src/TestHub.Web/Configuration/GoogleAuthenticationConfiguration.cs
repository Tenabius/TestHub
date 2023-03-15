using TestHub.Infrastructure.Services;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class GoogleAuthenticationConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            var keyVaultManager = new GoogleSecretManager(builder.Configuration);

            builder.Services.AddAuthentication().AddGoogle(googleOptions =>
            {
                googleOptions.ClientId = keyVaultManager.GetSecret("GoogleOAuth:ClientId");
                googleOptions.ClientSecret = keyVaultManager.GetSecret("GoogleOAuth:ClientSecret");
            });
        }
    }
}
