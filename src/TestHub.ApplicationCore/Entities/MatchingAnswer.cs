using static TestHub.Core.Entities.MatchingQuestion;

namespace TestHub.Core.Entities
{
    public class MatchingAnswer : Answer
    {
        public List<(Stem Stem, Response SubmittedResponse)> SubmittedAnswers { get; private set; }

#pragma warning disable CS8618
        private MatchingAnswer() { }
#pragma warning restore 

        public MatchingAnswer(Question question, IList<(Stem Stem, Response SubmittedResponse)> submittedAnswers)
            : base(question)
        {
            SubmittedAnswers = submittedAnswers.ToList();
        }
    }
}
