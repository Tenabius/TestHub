namespace TestHub.ApplicationCore.Entities
{
    public sealed class FillBlankQuestion : Question
    {
        public string Context { get; }
        public IReadOnlyCollection<Blank> Blanks => _blanks.AsReadOnly();
        private readonly List<Blank> _blanks = new();

#pragma warning disable CS8618
        private FillBlankQuestion() { }
#pragma warning restore 

        public FillBlankQuestion(Test test, string directions, int maxPoints, string context, ICollection<Blank> blanks)
            : base(test, directions, maxPoints)
        {
            Context = context;
            _blanks = blanks.ToList();
        }

        public override QuestionContent GetContent()
        {
            return new FillBlankQuestionContent(Id, Directions, Context);
        }

        public override decimal Grade(QuestionForm candidateForm)
        {
            if (candidateForm is FillBlankQuestionForm form)
            {
                return form.Answers.All(a => _blanks.Find(b => b.InnerId == a.InnerId)?.Answer == a.Answer.Trim().ToLower())
                    ? MaxPoints : 0;
            }
            throw new InvalidCastException(nameof(candidateForm));
        }

        public sealed class Blank : BaseEntity
        {
            public FillBlankQuestion FillBlankQuestion { get; }
            public string InnerId { get; set; }
            public string Answer { get; set; }

#pragma warning disable CS8618
            private Blank() { }
#pragma warning restore 

            public Blank(FillBlankQuestion fillBlankQuestion, string innerId, string answer)
            {
                FillBlankQuestion = fillBlankQuestion;
                InnerId = innerId;
                Answer = answer.Trim().ToLower();
            }
        }
    }
}
