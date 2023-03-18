using Validation;

namespace TestHub.Core.Entities
{
    public sealed class MatchingQuestion : Question
    {
        private readonly List<Stem> _stems;
        public IReadOnlyList<Stem> Stems => _stems.AsReadOnly();

#pragma warning disable CS8618
        private MatchingQuestion() { }
#pragma warning restore 

        private MatchingQuestion(string directions, IList<Stem> stems)
            : base(directions)
        {
            _stems = stems.ToList();
        }

        public static MatchingQuestion Create(string directions, IList<Stem> stems)
        {
            Requires.NotNullOrEmpty(directions, nameof(directions));
            Requires.Range(stems.Count >= 2, nameof(stems), "Matching quest must have two or greater number of stems");

            return new(directions, stems);
        }

        public override bool EvaluateAnswer(Answer submittedAnswer)
        {
            if (submittedAnswer is MatchingAnswer answer)
            {
                return answer.SubmittedResponses.All(a => a.Stem.Response == a.Response);
            }

            throw new InvalidCastException(nameof(submittedAnswer));
        }

        public sealed class Stem : BaseEntity
        {
            public string Content { get; private set; }
            public Response Response { get; private set; }

#pragma warning disable CS8618
            private Stem() { }
#pragma warning restore 

            private Stem(string content, Response response)
            {
                Content = content;
                Response = response;
            }

            public static Stem Create(string content, Response response)
            {
                Requires.NotNullOrEmpty(content, nameof(content));
                Requires.NotNull(response, nameof(response));

                return new(content, response);
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
