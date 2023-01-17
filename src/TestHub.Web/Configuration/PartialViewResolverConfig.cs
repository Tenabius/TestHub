using TestHub.ApplicationCore.Entities;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public static class PartialViewResolverConfig
    {
        public static void ConfigurePartialViewResolver(this WebApplication app)
        {
            var resolver = app.Services.GetRequiredService<IPartialViewResolver>();
            resolver.AddPartialView<FalseTrueQuestionContent>("_FalseTrueQuestion");
        }
    }
}
