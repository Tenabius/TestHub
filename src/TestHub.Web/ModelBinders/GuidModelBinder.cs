using Microsoft.AspNetCore.Mvc.ModelBinding;
using TestHub.Core.Extensions;

namespace TestHub.Web.ModelBinders
{
    public class GuidModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(Guid))
            {
                return Task.CompletedTask;
            }

            var modelName = bindingContext.ModelName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            var shortGuid = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(shortGuid))
            {
                return Task.CompletedTask;
            }

            var guid = shortGuid.FromShortGuid();
            bindingContext.Result = ModelBindingResult.Success(guid);
            return Task.CompletedTask;
        }
    }
}
