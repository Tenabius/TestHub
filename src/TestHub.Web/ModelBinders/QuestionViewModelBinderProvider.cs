using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestHub.Web.Areas.Candidate.Models;

namespace TestHub.Web.ModelBinders
{
    public class QuestionViewModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(QuestionViewModel))
            {
                return null;
            }

            var subclasses = new[] { 
                typeof(FalseTrueQuestionViewModel), 
                typeof(FillBlankQuestionViewModel),
                typeof(MatchingQuestionViewModel),
                typeof(MultipleChoiceQuestionViewModel)
            };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new QuestionViewModelBinder(binders);
        }
    }
}
