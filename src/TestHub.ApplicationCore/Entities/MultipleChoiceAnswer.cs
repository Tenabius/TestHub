using static TestHub.Core.Entities.MultipleChoiceQuestion;

namespace TestHub.Core.Entities
{
    public class MultipleChoiceAnswer : Answer
    {
        public IReadOnlyList<(Choice Choice, bool IsSelected)> SubmittedAnswers => _submittedAnswers.AsReadOnly();
        private List<(Choice Choice, bool IsSelected)> _submittedAnswers { get; set; }

#pragma warning disable CS8618
        public MultipleChoiceAnswer() { }
#pragma warning restore 

        public MultipleChoiceAnswer(Question question, IList<(Choice Choice, bool IsSelected)> submittedAnswers)
            : base(question)
        {
            _submittedAnswers = submittedAnswers.ToList();
        }
    }
}
