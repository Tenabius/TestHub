using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestHub.Web.Areas.Candidate.Models;

namespace TestHub.Web.ModelBinders
{
    public class AnswerViewModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(CandidateAnswerViewModel))
            {
                return null;
            }

            var subclasses = new[] { 
                typeof(FalseTrueCandidateAnswerViewModel), 
                typeof(FillBlankCandidateAnswerViewModel),
                typeof(MatchingCandidateAnswerViewModel),
                typeof(MultipleChoiceCandidateAnswerViewModel)
            };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new AnswerViewModelBinder(binders);
        }
    }
}
