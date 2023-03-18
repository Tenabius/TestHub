﻿using TestHub.Web.Areas.TestTaker.Models;
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
        }
    }
}
