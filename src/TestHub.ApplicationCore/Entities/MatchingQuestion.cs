﻿using Validation;

namespace TestHub.Core.Entities
{
    public sealed class MatchingQuestion : Question
    {
        public List<Stem> Stems { get; private set; }
        public List<Response> Responses { get; private set; }

#pragma warning disable CS8618
        private MatchingQuestion() { }
#pragma warning restore 

        private MatchingQuestion(string directions, IList<Stem> stems, IList<Response> responses)
            : base(directions)
        {
            Stems = stems.ToList();
            Responses = responses.ToList();
        }

        public static MatchingQuestion Create(string directions, IList<Stem> stems, IList<Response> responses)
        {
            Requires.NotNullOrEmpty(directions, nameof(directions));

            return new(directions, stems, responses);
        }

        public override bool EvaluateAnswer(Answer submittedAnswer)
        {
            if (submittedAnswer is MatchingAnswer answer)
            {
                return answer.SubmittedAnswers.All(a => a.Stem.CorrectResponse == a.SubmittedResponse);
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
