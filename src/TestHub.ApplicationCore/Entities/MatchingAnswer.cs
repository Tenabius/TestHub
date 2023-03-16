using static TestHub.Core.Entities.MatchingQuestion;

namespace TestHub.Core.Entities
{
    public class MatchingAnswer : Answer
    {
        public IReadOnlyList<SubmittedResponse> SubmittedResponses => _submittedResponses.AsReadOnly();
        private List<SubmittedResponse> _submittedResponses;

#pragma warning disable CS8618
        private MatchingAnswer() { }
#pragma warning restore 

        public MatchingAnswer(Question question, IList<SubmittedResponse> submittedResponses)
            : base(question)
        {
            _submittedResponses = submittedResponses.ToList();
        }


        public class SubmittedResponse : BaseEntity
        {
            public Stem Stem { get; private set;}
            public Response? Response { get; private set; }

            public SubmittedResponse(Stem stem, Response? response)
            {
                Stem = stem;
                Response = response;
            }

#pragma warning disable CS8618
            private SubmittedResponse() { }
#pragma warning restore 

        }
    }
}
