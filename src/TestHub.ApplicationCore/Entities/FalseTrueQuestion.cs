namespace TestHub.ApplicationCore.Entities
{
    public sealed class FalseTrueQuestion : Question
    {
        public bool CorrectChoice { get; set; }

        #pragma warning disable CS8618
        public FalseTrueQuestion() { }
        #pragma warning restore CS8618


        public FalseTrueQuestion(Test test, string description, int maxPoints, bool correctChoice)
            : base(test, description, maxPoints)
        {
            CorrectChoice = correctChoice;
        }

        public override AnswerForm GetAnswerForm()
        {
            return new FalseTrueAnswerForm(this);
        }

        public override void Validate() { }
    }

    public sealed class FalseTrueAnswerForm : AnswerForm
    {
        public bool? SelectedChoice { get; set; }

        private readonly FalseTrueQuestion _question;

        #pragma warning disable CS8618
        public FalseTrueAnswerForm() { }
        #pragma warning restore CS8618

        public FalseTrueAnswerForm(FalseTrueQuestion question)
        {
            _question = question;
        }

        public override decimal Grade()
        {
            return (SelectedChoice.HasValue &&
                SelectedChoice == _question.CorrectChoice) ? _question.MaxPoints : 0;
        }
    }
}
