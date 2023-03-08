using TestHub.Core.Entities;
using TestHub.Web.Interfaces;
using TestHub.Web.Models;

namespace TestHub.Web.Configuration
{
    public static class PartialViewResolverConfig
    {
        public static void ConfigurePartialViewResolver(this WebApplication app)
        {
            var resolver = app.Services.GetRequiredService<IPartialViewResolver>();
            resolver.AddPartialView<FalseTrueQuestionViewModel>("_FalseTrueQuestion");
            resolver.AddPartialView<MultipleChoiceQuestionViewModel>("_MultipleChoiceQuestion");
        }
    }
}
