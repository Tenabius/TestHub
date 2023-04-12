using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Question),
        IncludeAllDerived = true)]
    public abstract class QuestionViewModel
    {
        public string? Kind { get; set; }
        public int? QuestionId { get; set; }
        public string? Directions { get; set; }
    }
}
