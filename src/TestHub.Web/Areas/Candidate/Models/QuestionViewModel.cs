using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Web.BaseViewModels;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Question),
        IncludeAllDerived = true)]
    public abstract class QuestionViewModel : BaseEntityViewModel
    {
        public string Kind { get; protected set; }
        public string? Directions { get; set; }

        public QuestionViewModel()
        {
            Kind = GetType().Name;
        }
    }
}
