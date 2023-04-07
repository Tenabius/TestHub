using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public class FalseTrueCandidateAnswerViewModel : CandidateAnswerViewModel, IBaseViewModel
    {
        public bool? SelectedChoice { get; set; }
    }
}
