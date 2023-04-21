using AutoMapper;
using AutoMapper.Configuration.Annotations;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(MatchingQuestion))]
    public class MatchingQuestionViewModel : QuestionViewModel
    {
        public List<StemViewModel> Stems { get; set; } = new();
        public List<ResponseViewModel> Responses { get; set; } = new();

        [AutoMap(typeof(MatchingQuestion.Stem))]
        public class StemViewModel
        {
            public int? Id { get; set; }
            public string? Content { get; set; }
            public ResponseViewModel? CorrectResponse { get; set; }
            public ResponseViewModel? SubmittedResponse { get; set; }
        }

        [AutoMap(typeof(MatchingQuestion.Response))]
        public class ResponseViewModel
        {
            public int? Id { get; set; }
            public string? Content { get; set; }
        }
    }
}
