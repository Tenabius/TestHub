using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public class MultipleChoiceCandidateAnswerViewModel : CandidateAnswerViewModel, IBaseViewModel
    {
        public List<SubmittedChoiceViewModel>? SubmittedChoice { get; set; }

        public class SubmittedChoiceViewModel
        {
            public int? Id { get; set; }
            public bool? IsSelected { get; set; }
        }
    }
}
