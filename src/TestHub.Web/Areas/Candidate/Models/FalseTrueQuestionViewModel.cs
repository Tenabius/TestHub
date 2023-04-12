using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(FalseTrueQuestion))]
    public class FalseTrueQuestionViewModel : QuestionViewModel
    {
        public string? Statment { get; set; }
    }
}
