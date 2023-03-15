using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestHub.Infrastructure.Data;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class IdentityAuthenticationConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
                .AddIdentityCookies();

            builder.Services.AddIdentityCore<IdentityUser>(options =>
            {
                options.Stores.MaxLengthForKeys = 128;
                options.SignIn.RequireConfirmedAccount = true;
            })
                .AddDefaultTokenProviders()
                .AddSignInManager()
                .AddEntityFrameworkStores<TestHubContext>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Identity/Account/Login";
            });
        }
    }
}
