﻿using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Web.BaseViewModels;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(TestResult))]
    public class TestResultViewModel : BaseEntityViewModel
    {
        public Guid? CandidateId { get; set; }
        public Guid? TestId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public List<QuestionViewModel>? SubmittedAnswers { get; set; }
    }
}
