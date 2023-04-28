using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Web.BaseViewModels;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Test))]
    public class TestViewModel : BaseEntityViewModel
    {
        public string? Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<QuestionViewModel>? Questions { get; set; }
    }
}
