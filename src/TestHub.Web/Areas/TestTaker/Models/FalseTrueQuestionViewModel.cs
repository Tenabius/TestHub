using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public class FalseTrueQuestionViewModel : QuestionViewModel, IBaseViewModel
    {
        public string? Statment { get; set; }
    }
}
