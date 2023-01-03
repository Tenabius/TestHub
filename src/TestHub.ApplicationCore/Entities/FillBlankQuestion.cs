namespace TestHub.ApplicationCore.Entities
{
    public sealed class FillBlankQuestion : Question
    {
        public List<Blank> Banks { get; } = new();

        public List<Answer> Answers { get; } = new();

        public ScoringOptions? ScoringOptions { get; set; }

        public override decimal GradeAnswer()
        {
            throw new NotImplementedException();
        }

        public sealed class Blank
        {
            public string? Id { get; set; }

            public Answer? CorrectAnswer { get; set; }

            public FillBlankQuestion? FillBlankQuestion { get; set; }
        }

        public sealed class Answer
        {
            public string? Id { get; set; }

            public string? Description { get; set; }

            public FillBlankQuestion? FillBlankQuestion { get; set; }
        }
    }
}
