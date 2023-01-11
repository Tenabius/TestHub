using TestHub.Web.ViewModels;

namespace TestHub.Web.Interfaces
{
    public interface ITestPassingService
    {
        TestBlankViewModel GetTestBlank(int testId);
        void SubmitTestBlank(TestBlankViewModel testBlankViewModel);
    }
}
