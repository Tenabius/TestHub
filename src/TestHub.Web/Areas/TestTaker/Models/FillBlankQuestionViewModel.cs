using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public class FillBlankQuestionViewModel : QuestionViewModel, IBaseViewModel
    {
        public string? Context { get; }
    }
}
