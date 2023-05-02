using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using TestHub.Core.Entities;
using TestHub.Core.Extensions;
using TestHub.Core.Interfaces;
using TestHub.Web.Areas.Candidate.Models;
using TestHub.Web.Services;

namespace TestHub.Web.Areas.Candidate.Controllers
{

    [Area("Candidate")]
    [Route("[area]/[controller]")]
    public class ResultsController : Controller
    {
        private readonly IRepository<Test> _testsRepository;
        private readonly IRepository<TestResult> _testResultsRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public ResultsController(IRepository<Test> testsRepository,
            IRepository<TestResult> testResultRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _testsRepository = testsRepository;
            _testResultsRepository = testResultRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Result(string id)
        {
            var guid = id.FromShortGuid();
            var testResult = await _testResultsRepository.GetByIdAsync(guid);
            if (testResult == null)
            {
                return NotFound();
            }

            var testResultViewModel = _mapper.Map<TestResultViewModel>(testResult);
            return View(testResultViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Guid id,
            [FromForm] string startTime,
            [FromForm] List<QuestionViewModel> submittedAnswers)
        {
            var test = await _testsRepository.GetByIdAsync(id);

            if (test == null)
            {
                return BadRequest();
            }


            TestResult createResult(IdentityUser? user) =>
                TestResult.Create(user,
                test,
                EncryptService.DecryptDateTimeOffset(startTime),
                DateTimeOffset.UtcNow,
                MapService.Map(submittedAnswers, test)
                );

            TestResult testResult;
            if (HttpContext.User.Identity is { } identity
                && identity.IsAuthenticated)
            {
                var candidate = await _userManager.GetUserAsync(HttpContext.User);
                testResult = createResult(candidate);
            }
            else
            {
                testResult = createResult(null);
            }

            await _testResultsRepository.CreateAsync(testResult);

            string? location = Url.Action("Result", new { id = testResult.Id.ShortGuid() });
            Response.Headers.Add(HeaderNames.Location, location);
            return StatusCode(StatusCodes.Status303SeeOther);
        }
    }
}
