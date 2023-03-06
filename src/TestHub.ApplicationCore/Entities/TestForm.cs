namespace TestHub.Core.Entities
{
    public class TestForm : BaseEntity
    {
        public User Candidate { get; private set; }
        public Test Test { get; private set; }
        public DateTimeOffset StartTestingTime { get; private set; }
        public DateTimeOffset? EndTestingTime { get; private set; }
        public List<Answer> CandidateAnswers { get; private set; }

        #pragma warning disable CS8618
        private TestForm() { }
        #pragma warning restore CS8618

        public TestForm(User candidate, Test test, DateTimeOffset currentTime)
        {
            Candidate = candidate;
            Test = test;
            StartTestingTime = currentTime.UtcDateTime;
            CandidateAnswers = new();
        }

        public void Complete(DateTimeOffset currentTime)
        {
            EndTestingTime = currentTime.UtcDateTime;
        }
    }
}
