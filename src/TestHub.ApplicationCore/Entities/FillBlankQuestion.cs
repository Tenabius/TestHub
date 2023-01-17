namespace TestHub.ApplicationCore.Entities
{
    public sealed class FillBlankQuestion : Question
    {
        public string Context { get; private set; }
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

        public override decimal Grade(QuestionForm submittedForm)
        {
            if (submittedForm is FillBlankQuestionForm form)
            {
                return form.SubmittedAnswers.All(a => _blanks.Find(b => b.Name == a.Name)?.Answer == a.Answer.Trim().ToLower())
                    ? MaxPoints : 0;
            }
            throw new InvalidCastException(nameof(submittedForm));
        }

        public sealed class Blank : BaseEntity
        {
            public FillBlankQuestion FillBlankQuestion { get; private set; }
            public string Name { get; private set; }
            public string Answer { get; private set; }

#pragma warning disable CS8618
            private Blank() { }
#pragma warning restore 

            public Blank(FillBlankQuestion fillBlankQuestion, string innerId, string answer)
            {
                FillBlankQuestion = fillBlankQuestion;
                Name = innerId;
                Answer = answer.Trim().ToLower();
            }
        }
    }
}
