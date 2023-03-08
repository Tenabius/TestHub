using Microsoft.AspNetCore.Mvc;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;

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
            return View();
            //return View(_repository.GetById(Id)?.GetQuestionsContents());
        }

        [HttpPost]
        public IActionResult Submit([FromForm] List<Answer> questionForms)
        {
            var questions = _repository.GetById(1)?.Questions;
            int result = 0;
            //foreach (var questionForm in questionForms)
            //{
            //    result += questions?.First(q => q.Id == questionForm.QuestionId)?.EvaluateAnswer(questionForm) > 0 ? 1 : 0;
            //}

            return View("Result", result);
        }

    }
}
