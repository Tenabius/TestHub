using Microsoft.AspNetCore.Mvc;
using TestHub.ApplicationCore.Entities;
using TestHub.ApplicationCore.Interfaces;

namespace TestHub.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestRepository _repository;

        public TestController(ITestRepository repository) 
        {
            _repository = repository;
        }

        public IActionResult Index(int Id = 1)
        {
            return View(_repository.GetById(Id));
        }

        [HttpPost]
        public IActionResult Submit(TestForm answerSheet)
        {
            return View(answerSheet);
        }

    }
}
