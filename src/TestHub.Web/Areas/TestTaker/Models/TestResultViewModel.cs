namespace TestHub.Web.Areas.TestTaker.Models
{
    public class TestResultViewModel
    {
        public int? CandidateId { get; set; }
        public int? TestId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public List<CandidateAnswerViewModel>? SubmittedAnswers { get; set; }
    }
}
