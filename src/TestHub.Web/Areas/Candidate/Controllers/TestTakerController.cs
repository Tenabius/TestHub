using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Infrastructure;
using TestHub.Web.Areas.TestTaker.Models;

namespace TestHub.Web.Controllers
{
    public class TestTakerController : Controller
    {
        private readonly IRepository<Test> _testsRepository;
        private readonly IRepository<TestResult> _testResultsRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public TestTakerController(IRepository<Test> testsRepository,
            IRepository<TestResult> resultRepository,
            UserManager<IdentityUser> userManager)
        {
            _testsRepository = testsRepository;
            _testResultsRepository = resultRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int id, bool startTest = false)
        {
            var test = await _testsRepository.GetByIdAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            if (!startTest)
            {
                return View("TestInfo"); //TODO pass testInfo object
            }

            if (HttpContext.User.Identity is { } identity
                && identity.IsAuthenticated)
            {
                var candidate = await _userManager.GetUserAsync(HttpContext.User);
                var testResult = TestResult.Create(candidate!, test, DateTimeOffset.UtcNow);
                await _testResultsRepository.CreateAsync(testResult);
            }

            return View(test);
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromForm] List<CandidateAnswerViewModel> answers, [FromForm] int? testAttepmtId)
        {
            //var questions = _testsRepository.GetById(1)?.Questions;
            int result = 0;
            //foreach (var questionForm in questionForms)
            //{
            //    result += questions?.First(q => q.Id == questionForm.QuestionId)?.EvaluateAnswer(questionForm) > 0 ? 1 : 0;
            //}

            return View("Result", result);
        }

    }
}
