using TestHub.Web.Interfaces;

namespace TestHub.Web.Services
{
    public class TestService
    {
        public TViewModel GetViewModel<TViewModel>() where TViewModel : IBaseViewModel
        {

        }
    }
}
