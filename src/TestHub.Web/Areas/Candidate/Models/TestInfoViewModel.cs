namespace TestHub.Web.Areas.TestTaker.Models
{
    public class TestInfoViewModel
    {
        public string? Title { get; set; }
        public int? PassingScore { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
