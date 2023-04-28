using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Web.BaseViewModels;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Test))]
    public class TestInfoViewModel : BaseEntityViewModel
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public int? PassingScore { get; set; }
        public string? Description { get; set; }
        public TimeSpan? Duration { get; set; }
        public int AttemptAllowed { get; set; }
    }
}
