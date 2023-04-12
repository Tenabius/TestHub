using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(FillBlankQuestion))]
    public class FillBlankQuestionViewModel : QuestionViewModel
    {
        public string? Context { get; set; }
    }
}
