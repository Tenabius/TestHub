using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Core.Extensions;
using TestHub.Web.Areas.Candidate.Models;

namespace TestHub.Web.Areas.Candidate.Controllers
{

    [Area("Candidate")]
    [Route("[area]/[controller]")]
    public class TestsController : Controller
    {
        private readonly IRepository<Test> _testsRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public TestsController(IRepository<Test> testsRepository,
            IRepository<TestResult> resultRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _testsRepository = testsRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var tests = await _testsRepository.GetAsync((test) => true);

            var testsInfo = new List<TestInfoViewModel>();
            foreach (var test in tests)
            {
                testsInfo.Add(_mapper.Map<TestInfoViewModel>(test));
            }
            return View(testsInfo);
        }

        [HttpGet("Info/{id}")]
        public async Task<IActionResult> Info(string id)
        {
            var guid = id.FromShortGuid();
            var test = await _testsRepository.GetByIdAsync(guid);
            if (test == null)
            {
                return NotFound();
            }

            var testInfo = _mapper.Map<TestInfoViewModel>(test);
            return View(testInfo); 
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Test(string id)
        {
            var guid = id.FromShortGuid();
            var test = await _testsRepository.GetByIdAsync(guid);
            if (test == null)
            {
                return NotFound();
            }

            var testViewModel = _mapper.Map<TestViewModel>(test);
            return View(testViewModel);
        }
    }
}
