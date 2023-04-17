using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(FillBlankQuestion))]
    public class FillBlankQuestionViewModel : QuestionViewModel
    {
        public string? Context { get; set; }
        public List<BlankViewModel>? Blanks { get; set; }

        [AutoMap(typeof(FillBlankQuestion.Blank))]
        public class BlankViewModel
        {
            public int? InnerId { get; set; }
            public string? SubmittedAnswer { get; set; }
            public string? CorrectAnswer { get; set; }
        }
    }
}
