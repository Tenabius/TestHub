namespace TestHub.Web.Areas.TestTaker.Models
{
    public class MatchingQuestionViewModel : QuestionViewModel
    {
        public List<StemViewModel>? Stems { get; }
        public List<ResponseViewModel>? Responses { get; }

        public class StemViewModel
        {
            public int? Id { get; set; }
            public string? Stem { get; set; }
        }

        public class ResponseViewModel
        {
            public int? Id { get; set; }
            public string? Response { get; set; }
        }
    }
}
