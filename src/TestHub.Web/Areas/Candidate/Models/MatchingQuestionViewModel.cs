using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Web.Extensions;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(MatchingQuestion))]
    public class MatchingQuestionViewModel : QuestionViewModel
    {
        private List<StemViewModel> _stems = new();
        public List<StemViewModel> Stems
        {
            get { return _stems; }

            set
            {
                _stems = value;
                _stems.Shuffle();
            }
        }
        private List<ResponseViewModel> _responses = new();
        public List<ResponseViewModel> Responses
        {
            get { return _responses; }

            set
            {
                _responses = value;
                _responses.Shuffle();
            }
        }

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
