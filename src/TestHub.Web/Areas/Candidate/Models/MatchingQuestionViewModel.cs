using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(MatchingQuestion))]
    public class MatchingQuestionViewModel : QuestionViewModel
    {
        public List<StemViewModel>? Stems { get; set; }
        public List<ResponseViewModel>? Responses { get; set; }

        [AutoMap(typeof(MatchingQuestion.Stem))]
        public class StemViewModel
        {
            public int? Id { get; set; }
            public string? Stem { get; set; }
        }

        [AutoMap(typeof(MatchingQuestion.Response))]
        public class ResponseViewModel
        {
            public int? Id { get; set; }
            public string? Response { get; set; }
        }
    }
}
