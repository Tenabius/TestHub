using Microsoft.AspNetCore.Mvc;
using TestHub.ApplicationCore.Entities;
using TestHub.ApplicationCore.Interfaces;

namespace TestHub.Web.Controllers
{
    public class TestController : Controller
    {
        private readonly IRepository<Test> _repository;

        public TestController(IRepository<Test> repository)
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
