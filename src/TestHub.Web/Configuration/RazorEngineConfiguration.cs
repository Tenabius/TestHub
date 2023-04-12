using Microsoft.AspNetCore.Mvc.Razor;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class RazorEngineConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            builder.Services.Configure<RazorViewEngineOptions>(o =>
            {
                o.ViewLocationFormats.Add("~/Shared/{0}" + RazorViewEngine.ViewExtension);
            });
        }
    }
}
