using System.Diagnostics.CodeAnalysis;
using Validation;

namespace TestHub.ApplicationCore.Entities
{
    public sealed class FalseTrueQuestion : Question
    {
        public bool CorrectChoice { get; private set; }
        public string Statment { get; private set; }

        #pragma warning disable CS8618
        private FalseTrueQuestion() { }
        #pragma warning restore CS8618

        public FalseTrueQuestion(Test test, string directions, int maxPoints, string statment, bool correctChoice)
            : base(test, directions, maxPoints)
        {
            SetCorrectChoice(correctChoice);
            SetStatment(statment);
        }

        [MemberNotNull(nameof(CorrectChoice))]
        public void SetCorrectChoice(bool correctChoice)
        {
            CorrectChoice = correctChoice;
        }

        [MemberNotNull(nameof(Statment))]
        public void SetStatment(string statment)
        {
            Requires.NotNullOrEmpty(statment, nameof(statment));
            Statment = statment;
        }

        public override decimal Grade(QuestionForm candidateAnswer)
        {
            if (candidateAnswer is FalseTrueQuestionForm answer)
            {
                return answer.SelectedChoice.HasValue
                    && answer.SelectedChoice == CorrectChoice ? MaxPoints : 0;
            }
            throw new InvalidCastException(nameof(candidateAnswer));
        }

        public override QuestionContent GetContent()
        {
            return new FalseTrueQuestionContent(Id, Directions, Statment);
        }
    }
}
