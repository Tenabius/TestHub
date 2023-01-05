namespace TestHub.ApplicationCore.Entities
{
    public sealed class FalseTrueQuestion : Question
    {
        public bool CorrectChoice { get; private set; }

        public FalseTrueQuestion(string description, int maxPoints, Test test, bool correctChoice)
            : base(description, maxPoints, test)
        {
            CorrectChoice = correctChoice;
        }

        public void UpdateCorrectChoice(bool correctChoice)
        {
            CorrectChoice = correctChoice;
        }

        public override AnswerForm GetAnswerForm()
        {
            return new FalseTrueAnswerForm(this);
        }

        public override void Validate()
        {
            return;
        }
    }

    public sealed class FalseTrueAnswerForm : AnswerForm
    {
        public bool? SelectedChoice { get; private set; }

        private readonly FalseTrueQuestion _question;

        public FalseTrueAnswerForm(FalseTrueQuestion question)
        {
            _question = question;
        }

        public void SelectChoice(bool selectedChoice)
        {
            SelectedChoice = selectedChoice;
        }

        public override int Grade()
        {
            return (SelectedChoice.HasValue &&
                SelectedChoice == _question.CorrectChoice) ? _question.MaxPoints : 0;
        }
    }
}
