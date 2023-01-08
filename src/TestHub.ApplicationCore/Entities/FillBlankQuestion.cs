namespace TestHub.ApplicationCore.Entities
{
    public sealed class FillBlankQuestion : Question
    {
        public List<Blank> Banks { get; } = new();

        public List<Answer> Answers { get; } = new();

        public ScoringOptions? ScoringOptions { get; set; }

        public FillBlankQuestion(Test test, string description, int maxPoints)
            : base(test, description, maxPoints)
        {
        }

        public override AnswerForm GetAnswerForm()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
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
