using static TestHub.Core.Entities.MatchingQuestion;

namespace TestHub.Core.Entities
{
    public class MatchingAnswer : Answer
    {
        public IReadOnlyList<(Stem Stem, Response SubmittedResponse)> SubmittedAnswers => _submittedAnswers.AsReadOnly();
        private List<(Stem Stem, Response SubmittedResponse)> _submittedAnswers;

#pragma warning disable CS8618
        private MatchingAnswer() { }
#pragma warning restore 

        public MatchingAnswer(Question question, IList<(Stem Stem, Response SubmittedResponse)> submittedAnswers)
            : base(question)
        {
            _submittedAnswers = submittedAnswers.ToList();
        }
    }
}
