﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using TestHub.Core.Entities;
using TestHub.Core.Interfaces;
using TestHub.Infrastructure;
using TestHub.Web.Areas.Candidate.Models;

namespace TestHub.Web.Areas.Candidate.Controllers
{

    [Area("Candidate")]
    public class TestController : Controller
    {
        private readonly IRepository<Test> _testsRepository;
        private readonly IRepository<TestResult> _testResultsRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;

        public TestController(IRepository<Test> testsRepository,
            IRepository<TestResult> resultRepository,
            IMapper mapper,
            UserManager<IdentityUser> userManager)
        {
            _testsRepository = testsRepository;
            _testResultsRepository = resultRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var test = await _testsRepository.GetByIdAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            var testInfo = _mapper.Map<TestInfoViewModel>(test);
            return View("TestInfo", testInfo); 
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> IndexPost(int id)
        {
            var test = await _testsRepository.GetByIdAsync(id);
            if (test == null)
            {
                return NotFound();
            }

            if (HttpContext.User.Identity is { } identity
                && identity.IsAuthenticated)
            {
                var candidate = await _userManager.GetUserAsync(HttpContext.User);
                var testResult = TestResult.Create(candidate!, test, DateTimeOffset.UtcNow);
                await _testResultsRepository.CreateAsync(testResult);
            }

            var testViewModel = _mapper.Map<TestViewModel>(test);
            return View(testViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromForm] List<CandidateAnswerViewModel> answers)
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
