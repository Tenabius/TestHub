using static TestHub.Core.Entities.FillBlankQuestion;

namespace TestHub.Core.Entities
{
    public sealed class FillBlankCandidateAnswer : CandidateAnswer
    {
        public IReadOnlyList<SubmittedBlank> SubmittedBlanks => _submittedBlanks.AsReadOnly();
        private List<SubmittedBlank> _submittedBlanks;

#pragma warning disable CS8618
        private FillBlankCandidateAnswer() { }
#pragma warning restore 

        public FillBlankCandidateAnswer(Question question, IList<SubmittedBlank> submittedBlanks)
            : base(question)
        {
            _submittedBlanks = submittedBlanks.ToList();
        }

        public class SubmittedBlank : BaseEntity
        {
            public Blank Blank { get; private set; }
            public string SubmittedAnswer { get; private set; }

            public SubmittedBlank(Blank blank, string answer)
            {
                Blank = blank;
                SubmittedAnswer = answer;
            }

#pragma warning disable CS8618
            private SubmittedBlank() { }
#pragma warning restore 
        }
    }
}
