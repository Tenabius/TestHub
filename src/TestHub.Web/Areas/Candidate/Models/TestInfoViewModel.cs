using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Test))]
    public class TestInfoViewModel
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? PassingScore { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public int AttemptAllowed { get; set; }
    }
}
