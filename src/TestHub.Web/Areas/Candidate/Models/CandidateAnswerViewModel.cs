using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(Question),
        IncludeAllDerived = true)]
    public abstract class CandidateAnswerViewModel
    {
        public int? QuestionId { get; set; }
    }
}
