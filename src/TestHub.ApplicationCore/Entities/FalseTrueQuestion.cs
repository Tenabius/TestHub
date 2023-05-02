using Validation;

namespace TestHub.Core.Entities
{
    public sealed class FalseTrueQuestion : Question
    {
        public string Statement { get; private set; }
        public bool CorrectChoice { get; private set; }

#pragma warning disable CS8618
        private FalseTrueQuestion() { }
#pragma warning restore 

        private FalseTrueQuestion(string directions, string statement, bool correctChoice)
            : base(directions)
        {
            Statement = statement;
            CorrectChoice = correctChoice;
        }

        public static FalseTrueQuestion Create(string directions, string statement, bool correctChoice)
        {
            Requires.NotNullOrEmpty(statement, nameof(statement));
            Requires.NotNullOrEmpty(directions, nameof(directions));

            return new(directions, statement, correctChoice);
        }

        public override bool EvaluateAnswer(CandidateAnswer submittedAnswer)
        {
            if (submittedAnswer is FalseTrueCandidateAnswer answer)
            {
                return answer.SubmittedChoice == CorrectChoice;
            }

            throw new InvalidCastException(nameof(submittedAnswer));
        }
    }
}
