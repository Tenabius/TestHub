using TestHub.Web.Areas.Candidate.Models;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public static class PartialViewResolverConfiguration
    {
        public static void ConfigurePartialViewResolver(this WebApplication app)
        {
            var resolver = app.Services.GetRequiredService<IPartialViewResolver>();
            resolver.AddPartialView<FalseTrueQuestionViewModel>("_FalseTrueQuestion");
            resolver.AddPartialView<MultipleChoiceQuestionViewModel>("_MultipleChoiceQuestion");
            resolver.AddPartialView<FillBlankQuestionViewModel>("_FillBlankQuestion");
            resolver.AddPartialView<MatchingQuestionViewModel>("_MatchingQuestion");
        }
    }
}
