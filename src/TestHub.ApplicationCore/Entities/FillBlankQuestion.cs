using Validation;

namespace TestHub.Core.Entities
{
    public sealed class FillBlankQuestion : Question
    {
        public static readonly string BlankTag = "<blank>";
        public string Context { get; private set; }
        public IReadOnlyList<Blank> Blanks => _blanks.AsReadOnly();
        private readonly List<Blank> _blanks = new();

#pragma warning disable CS8618
        private FillBlankQuestion() { }
#pragma warning restore 

        private FillBlankQuestion(string directions, string context, IList<Blank> blanks)
            : base(directions)
        {
            Context = context;
            _blanks = blanks.ToList();
        }

        public static FillBlankQuestion Create(string directions, string context, IList<Blank> blanks)
        {
            Requires.NotNullOrEmpty(directions, nameof(directions));
            Requires.NotNullOrEmpty(context, nameof(context));
            //TODO Check that all blanks have answers and no answers without a blank

            return new(directions, context, blanks);
        }

        public override bool EvaluateAnswer(CandidateAnswer submittedAnswer)
        {
            if (submittedAnswer is FillBlankCandidateAnswer answer)
            {
                return answer.SubmittedBlanks
                    .All(a => a.SubmittedAnswer == a.Blank.CorrectAnswer);
            }

            throw new InvalidCastException(nameof(submittedAnswer));
        }

        public sealed class Blank : BaseEntity
        {
            public string Name { get; private set; }
            public string CorrectAnswer { get; private set; }

#pragma warning disable CS8618
            private Blank() { }
#pragma warning restore 

            private Blank(string name, string correctAnswer)
            {
                Name = name;
                CorrectAnswer = correctAnswer;
            }

            public static Blank Create(string name, string correctAnswer)
            {
                Requires.NotNullOrEmpty(name, nameof(name));
                Requires.NotNullOrEmpty(correctAnswer, nameof(correctAnswer));

                return new(name,
                    correctAnswer.Trim().ToLower());
            }
        }
    }
}
