namespace TestHub.ApplicationCore.Entities
{
    public class AnswersSheet : BaseEntity
    {
        public User Candidate { get; }
        public Test Test { get; }
        public decimal? ResultingScore { get; }
        public DateTimeOffset StartTestingTime { get; }
        public DateTimeOffset? EndTestingTime { get; }
        public List<AnswerForm> Answers { get; }

        public AnswersSheet(User candidate, Test test, DateTimeOffset currentTime)
        {
            Candidate = candidate;
            Test = test;
            StartTestingTime = currentTime.UtcDateTime;
            Answers = Test.GetAnswerForms();
        }

        public void Complete()
        {
            if (!Answers.All(a => a.IsValid()))
            {
                throw new Exception("Not all question is ");
            }
        }
    }
}
