using System.Diagnostics.CodeAnalysis;
using Validation;

namespace TestHub.Core.Entities
{
    public sealed class FalseTrueQuestion : Question
    {
        public string Statment { get; private set; }
        public bool CorrectChoice { get; private set; }

#pragma warning disable CS8618
        private FalseTrueQuestion() { }
#pragma warning restore 

        private FalseTrueQuestion(string directions, string statment, bool correctChoice)
            : base(directions)
        {
            Statment = statment;
            CorrectChoice = correctChoice;
        }

        public static FalseTrueQuestion Create(string directions, string statment, bool correctChoice)
        {
            Requires.NotNullOrEmpty(statment, nameof(statment));
            Requires.NotNullOrEmpty(directions, nameof(directions));

            return new(directions, statment, correctChoice);
        }

        public override bool EvaluateAnswer(Answer submittedAnswer)
        {
            if (submittedAnswer is FalseTrueAnswer answer)
            {
                return answer.SelectedChoice.HasValue
                    && answer.SelectedChoice == CorrectChoice;
            }

            throw new InvalidCastException(nameof(submittedAnswer));
        }
    }
}
