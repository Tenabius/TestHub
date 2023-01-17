namespace TestHub.Web.Interfaces
{
    public interface IPartialViewResolver
    {
        void AddPartialView<T>(string partialViewName);
        void AddPartialView(Type type, string partialViewName);
        string GetPartialViewName(Type type);
    }
}
