using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public class MultipleChoiceQuestionViewModel : QuestionViewModel, IBaseViewModel
    {
        public string? Stem { get; }
        public List<ChoiceViewModel>? Choices { get; }

        public class ChoiceViewModel
        {
            public int? Id { get; set; }
            public string? Description { get; set; }
        }
    }
}
