using TestHub.Web.Interfaces;

namespace TestHub.Web.Services
{
    public class PartialViewResolver : IPartialViewResolver //TODO divide in two interfaces for adding and for getting
    {
        private readonly Dictionary<Type, string> _partialViewNames = new();

        public void AddPartialView<T>(string partialViewName)
        {
            AddPartialView(typeof(T), partialViewName);
        }

        public void AddPartialView(Type type, string partialViewName)
        {
            _partialViewNames.Add(type, partialViewName);
        }

        public string GetPartialViewName(Type type)
        {
            return _partialViewNames[type];
        }
    }
}
