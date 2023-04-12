using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(TestResult))]
    public class TestResultViewModel
    {
        public int? CandidateId { get; set; }
        public int? TestId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public List<CandidateAnswerViewModel>? SubmittedAnswers { get; set; }
    }
}
