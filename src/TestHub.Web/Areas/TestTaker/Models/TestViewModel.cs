using TestHub.Web.Interfaces;

namespace TestHub.Web.Areas.TestTaker.Models
{
    public class TestViewModel : IBaseViewModel
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<QuestionViewModel>? Questions { get; set; }
    }
}
