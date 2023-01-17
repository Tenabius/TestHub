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
#pragma warning restore 

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

        public override decimal Grade(QuestionForm submittedForm)
        {
            if (submittedForm is FalseTrueQuestionForm form)
            {
                return form.SelectedChoice.HasValue
                    && form.SelectedChoice == CorrectChoice ? MaxPoints : 0;
            }
            throw new InvalidCastException(nameof(submittedForm));
        }

        public override QuestionContent GetContent()
        {
            return new FalseTrueQuestionContent(Id, Directions, Statment);
        }
    }
}
