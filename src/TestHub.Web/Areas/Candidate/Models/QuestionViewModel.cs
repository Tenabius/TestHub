using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Question),
        IncludeAllDerived = true)]
    public abstract class QuestionViewModel
    {
        public string Kind { get; protected set; }
        public int? Id { get; set; }
        public string? Directions { get; set; }

        public QuestionViewModel()
        {
            Kind = GetType().Name;
        }
    }
}
