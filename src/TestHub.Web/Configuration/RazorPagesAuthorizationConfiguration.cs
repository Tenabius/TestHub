using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class RazorPagesAuthorizationConfiguration : IApplicationConfiguration
    {
        public void ConfigureApplication(WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            });
        }
    }
}
