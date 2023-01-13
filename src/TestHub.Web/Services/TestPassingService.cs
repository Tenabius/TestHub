using TestHub.ApplicationCore.Entities;
using TestHub.ApplicationCore.Interfaces;
using TestHub.Web.Interfaces;
using TestHub.Web.ViewModels;

namespace TestHub.Web.Services
{
    public class TestPassingService : ITestPassingService
    {
        private readonly ITestRepository _repository;
        private Test _test;

        public TestPassingService(ITestRepository repository)
        {
            _repository = repository;
        }

        public TestBlankViewModel GetTestBlank(int testId)
        {
            return MapTestToTestBlank(_repository.GetById(testId));
        }

        public void SubmitTestBlank(TestBlankViewModel testBlankViewModel)
        {
            throw new NotImplementedException();
        }

        private TestBlankViewModel MapTestToTestBlank(Test test)
        {
            TestBlankViewModel blank = new()
            {
                AuthorId = test.Author.Id,
                AuthorName = test.Author.Name,
                Name = test.Theme,
                Description = test.Description,
                Id = test.Id,
                Duration = test.Duration
            };



            return blank;
        }
    }
}
