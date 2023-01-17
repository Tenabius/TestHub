﻿namespace TestHub.ApplicationCore.Entities
{
    public sealed class MatchingQuestion : Question
    {
        public List<Stem> Stems { get; private set; }
        public List<Response> Responses { get; private set; }

#pragma warning disable CS8618
        private MatchingQuestion() { }
#pragma warning restore 

        public MatchingQuestion(Test test, string directions, int maxPoints, List<Stem> stems, List<Response> responses)
            : base(test, directions, maxPoints)
        {
            Stems = stems;
            Responses = responses;
        }

        public override QuestionContent GetContent()
        {
            return new MatchingQuestionContent(Id,
                Directions,
                Stems.ConvertAll(stem => (stem.Id, stem.Content)),
                Responses.ConvertAll(response => (response.Id, response.Content)));
        }

        public override decimal Grade(QuestionForm submittedForm)
        {
            if (submittedForm is MatchingQuestionFrom form)
            {
                return Stems.All(stem => 
                form.SubmittedAnswers.Find(a => a.StemId == stem.Id).ResponseId == stem.CorrectResponse.Id)
                    ? MaxPoints : 0;
                //TODO If not found and Response's ID can be 0, will return true, what is a problem
            }
            throw new InvalidCastException(nameof(submittedForm));
        }



        public sealed class Stem : BaseEntity
        {
            public string Content { get; private set; }
            public Response CorrectResponse { get; private set; }
            public MatchingQuestion MatchingQuestion { get; private set; }

#pragma warning disable CS8618
            private Stem() { }
#pragma warning restore 

            public Stem(string content, Response correctResponse, MatchingQuestion matchingQuestion)
            {
                Content = content;
                CorrectResponse = correctResponse;
                MatchingQuestion = matchingQuestion;
            }
        }



        public sealed class Response : BaseEntity
        {
            public string Content { get; private set; }
            public MatchingQuestion MatchingQuestion { get; private set; }

#pragma warning disable CS8618
            private Response() { }
#pragma warning restore 

            public Response(string content, MatchingQuestion matchingQuestion)
            {
                Content = content;
                MatchingQuestion = matchingQuestion;
            }
        }
    }
}
