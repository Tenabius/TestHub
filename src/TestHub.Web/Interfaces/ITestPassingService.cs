using TestHub.Web.Areas.TestTaker.Models;

namespace TestHub.Web.Interfaces
{
    public interface ITestPassingService
    {
        TestViewModel GetTestBlank(int testId);
        void SubmitTestBlank(TestViewModel testBlankViewModel);
    }
}
