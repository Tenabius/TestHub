namespace TestHub.ApplicationCore.Entities
{
    public sealed class MatchingQuestion : Question
    {
        public List<Stem> Stems { get; } = new();

        public List<Response> Responses { get; } = new();

        public ScoringOptions? ScoringOptions { get; set; }

        public override decimal GradeAnswer()
        {
            throw new NotImplementedException();
        }

        public sealed class Stem
        {
            public string? Id { get; set; }

            public string? Description { get; set; }

            public Response? CorrectResponse { get; set; }

            public MatchingQuestion? MatchingQuestion { get; set; }
        }

        public sealed class Response
        {
            public string? Id { get; set; }

            public string? Description { get; set; }

            public MatchingQuestion? MatchingQuestion { get; set; }
        }
    }
}
