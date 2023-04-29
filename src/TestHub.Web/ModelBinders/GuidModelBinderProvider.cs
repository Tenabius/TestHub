using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using TestHub.Web.Areas.Candidate.Models;

namespace TestHub.Web.ModelBinders
{
    public class GuidModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Guid))
            {
                return new GuidModelBinder();
            }

            return null;
        }
    }
}
