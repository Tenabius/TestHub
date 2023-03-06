namespace TestHub.Core.Entities
{
    public class MatchingQuestionContent : QuestionContent
    {
        public string Directions { get; }
        public List<(int Id, string Stem)> Stems { get; }
        public List<(int Id, string Response)> Responses { get; }

        public MatchingQuestionContent(int questionId,
            string directions,
            List<(int Id, string Stem)> stems,
            List<(int Id, string Response)> responses)
            : base(questionId, nameof(MatchingAnswer))
        {
            Directions = directions;
            Stems = stems;
            Responses = responses;
        }
    }
}
