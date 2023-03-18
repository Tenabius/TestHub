namespace TestHub.Web.Areas.TestTaker.Models
{
    public class AnswersSheetViewModel
    {
        public int? CandidateId { get; set; }
        public int? TestId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public List<AnswerViewModel>? SubmittedAnswers { get; set; }
    }
}
