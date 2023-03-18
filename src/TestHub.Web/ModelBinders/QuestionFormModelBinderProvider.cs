using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestHub.Web.Areas.TestTaker.Models;

namespace TestHub.Web.ModelBinders
{
    public class QuestionFormModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(AnswerViewModel))
            {
                return null;
            }

            var subclasses = new[] { 
                typeof(FalseTrueAnswerViewModel), 
                typeof(FillBlankAnswerViewModel),
                typeof(MatchingAnswerViewModel),
                typeof(MultipleChoiceAnswerViewModel)
            };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new QuestionFormModelBinder(binders);
        }
    }
}
