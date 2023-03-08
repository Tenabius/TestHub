using TestHub.Web.Models;

namespace TestHub.Web.Interfaces
{
    public interface ITestPassingService
    {
        TestBlankViewModel GetTestBlank(int testId);
        void SubmitTestBlank(TestBlankViewModel testBlankViewModel);
    }
}
