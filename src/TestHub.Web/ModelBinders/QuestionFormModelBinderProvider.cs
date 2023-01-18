using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestHub.ApplicationCore.Entities;

namespace TestHub.Web.ModelBinders
{
    public class QuestionFormModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(QuestionForm))
            {
                return null;
            }

            var subclasses = new[] { typeof(FalseTrueQuestionForm), typeof(MultipleChoiceQuestionForm), };

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
