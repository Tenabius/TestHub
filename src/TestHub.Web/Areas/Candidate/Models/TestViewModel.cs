namespace TestHub.Web.Areas.TestTaker.Models
{
    public class TestViewModel
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<QuestionViewModel>? Questions { get; set; }
    }
}
