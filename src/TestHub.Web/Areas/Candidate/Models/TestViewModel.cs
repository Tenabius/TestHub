using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Test))]
    public class TestViewModel
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<QuestionViewModel>? Questions { get; set; }
    }
}
