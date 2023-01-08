namespace TestHub.ApplicationCore.Entities
{
    public sealed class MultipleChoiceQuestion : Question
    {
        public IReadOnlyCollection<Choice> Choices => _choices.AsReadOnly();
        public bool MultipleCorrectChoices { get; }
        public ScoringOptions ScoringOptions { get; }

        private readonly List<Choice> _choices = new();

        public MultipleChoiceQuestion(
            Test test,
            string description,
            int maxPoints,
            bool multipleCorrectChoices,
            ScoringOptions scoringOptions) :
                base (test, description, maxPoints)
        {
            MultipleCorrectChoices = multipleCorrectChoices;
            ScoringOptions = scoringOptions;
        }

        public override AnswerForm GetAnswerForm()
        {
            throw new Exception();
        }

        public void AddChoice(Choice choice)
        {
            if (MultipleCorrectChoices ||
                !choice.IsCorrect ||
                !_choices.Any(ch => ch.IsCorrect))
            {
                _choices.Add(choice);
            } else
            {
                throw new InvalidOperationException("Question, with property \"MuliplieCorrectChoice\" is false, can have only one correct choice");
            }
        }

        public bool DeleteChoice(Choice choice) => _choices.Remove(choice);

        public void UpdateChoice(Choice choice)
        {
            int updatedChoice = _choices.FindIndex(ch => ch.Id == choice.Id);
            //TODO Not completed
        }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public sealed class Choice : BaseEntity
        {
            public int QuestionId { get; }
            public string Description { get; }
            public int Points { get; }
            public bool IsCorrect { get; }

            public Choice(int questionId, string description, int points, bool isCorrect)
            {
                QuestionId = questionId;
                Description = description;
                Points = points;
                IsCorrect = isCorrect;
            }
        }

        public sealed class MultipleChoiceAnswer : AnswerForm
        {
            private readonly MultipleChoiceQuestion _question;

            public MultipleChoiceAnswer(MultipleChoiceQuestion question)
            {
                _question = question;
            }

            public override decimal Grade()
            {


                return 1;
            }
        }
    }
}
