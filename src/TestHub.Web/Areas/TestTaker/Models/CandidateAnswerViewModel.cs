using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public abstract class CandidateAnswerViewModel : IBaseViewModel
    {
        public int? QuestionId { get; set; }
    }
}
