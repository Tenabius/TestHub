using static TestHub.Core.Entities.MultipleChoiceQuestion;

namespace TestHub.Core.Entities
{
    public class MultipleChoiceAnswer : Answer
    {
        public IReadOnlyList<SubmittedChoice> SubmittedAnswers => _submittedAnswers.AsReadOnly();
        private List<SubmittedChoice> _submittedAnswers { get; set; }

#pragma warning disable CS8618
        public MultipleChoiceAnswer() { }
#pragma warning restore 

        public MultipleChoiceAnswer(Question question, IList<SubmittedChoice> submittedAnswers)
            : base(question)
        {
            _submittedAnswers = submittedAnswers.ToList();
        }

        public class SubmittedChoice
        {
            public Choice Choice { get; private set; }
            public bool IsSelected { get; private set; }

            public SubmittedChoice(Choice choice, bool isSelected)
            {
                Choice = choice;
                IsSelected = isSelected;
            }

#pragma warning disable CS8618
            public SubmittedChoice() { }
#pragma warning restore   

        }
    }
}
