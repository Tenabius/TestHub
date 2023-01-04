using TestHub.ApplicationCore.Interfaces;

namespace TestHub.ApplicationCore.Entities
{
    public sealed class FalseTrueQuestion : Question
    {
        public bool? CorrectChoice { get; set; }

        public FalseTrueQuestion(string description, int maxPoints, int testId)
            : base(description, maxPoints, testId)
        {
        }

        public override AnswerForm GetAnswerForm()
        {
            return new FalseTrueAnswerForm(this);
        }

        public override IView GetView()
        {
            throw new NotImplementedException();
        }

        public override void Validate()
        {
            //TODO Change exception
            if (CorrectChoice is null) throw new Exception();
        }
    }

    public sealed class FalseTrueAnswerForm : AnswerForm
    {
        public bool? SelectedChoice { get; set; }

        private readonly FalseTrueQuestion _question;

        public FalseTrueAnswerForm(FalseTrueQuestion question)
        {
            _question = question;
        }

        public override int Grade()
        {
            return (SelectedChoice is not null &&
                SelectedChoice == _question.CorrectChoice) ? _question.MaxPoints : 0;
        }
    }
}
