using Validation;

namespace TestHub.Core.Entities
{
    public sealed class MatchingQuestion : Question
    {
        private readonly List<Stem> _stems;
        public IReadOnlyList<Stem> Stems => _stems.AsReadOnly();
        private readonly List<Response> _responses;
        public IReadOnlyList<Response> Responses => _responses.AsReadOnly();

#pragma warning disable CS8618
        private MatchingQuestion() { }
#pragma warning restore 

        private MatchingQuestion(string directions, IList<Stem> stems, IList<Response> responses)
            : base(directions)
        {
            _stems = stems.ToList();
            _responses = responses.ToList();
        }

        public static MatchingQuestion Create(string directions, IList<Stem> stems, IList<Response> responses)
        {
            Requires.NotNullOrEmpty(directions, nameof(directions));
            Requires.Range(stems.Count >= 2, nameof(stems), "Matching quest must have two or greater number of stems");

            return new(directions, stems, responses);
        }

        public override bool EvaluateAnswer(CandidateAnswer submittedAnswer)
        {
            if (submittedAnswer is MatchingCandidateAnswer answer)
            {
                return answer.SubmittedResponses.All(a => a.Stem.CorrectResponse == a.Response);
            }

            throw new InvalidCastException(nameof(submittedAnswer));
        }

        public sealed class Stem : BaseEntity
        {
            public string Content { get; private set; }
            public Response CorrectResponse { get; private set; }

#pragma warning disable CS8618
            private Stem() { }
#pragma warning restore 

            private Stem(string content, Response correctResponse)
            {
                Content = content;
                CorrectResponse = correctResponse;
            }

            public static Stem Create(string content, Response correctResponse)
            {
                Requires.NotNullOrEmpty(content, nameof(content));
                Requires.NotNull(correctResponse, nameof(correctResponse));

                return new(content, correctResponse);
            }
        }

        public sealed class Response : BaseEntity
        {
            public string Content { get; private set; }

#pragma warning disable CS8618
            private Response() { }
#pragma warning restore 

            private Response(string content)
            {
                Content = content;
            }

            public static Response Create(string content)
            {
                Requires.NotNullOrEmpty(content, nameof(content));

                return new Response(content);
            }
        }
    }
}
