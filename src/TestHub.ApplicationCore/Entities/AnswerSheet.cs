using System.Linq;

namespace TestHub.ApplicationCore.Entities
{
    public class AnswerSheet : BaseEntity
    {
        public User Candidate { get; }
        public Test Test { get; }
        public decimal? ResultingScore { get; private set; }
        public TestStatus Status { get; private set; }
        public DateTimeOffset StartTestingTime { get; }
        public DateTimeOffset? EndTestingTime { get; private set; }
        public List<AnswerForm> Answers { get; }

        #pragma warning disable CS8618
        private AnswerSheet() { }
        #pragma warning restore CS8618

        public AnswerSheet(User candidate, Test test, DateTimeOffset currentTime)
        {
            Candidate = candidate;
            Test = test;
            StartTestingTime = currentTime.UtcDateTime;
            Answers = Test.GetAnswerForms();
        }

        public void Complete(DateTimeOffset currentTime)
        {
            EndTestingTime = currentTime.UtcDateTime;
        }

        public void Grade()
        {
            ResultingScore = Answers.Sum(a => a.Grade());
            if (ResultingScore / 100 > Test.PassingPercent)
            {
                Status = TestStatus.Passed;
            } else
            {
                Status = TestStatus.Failed;
            }
        }
    }

    public enum TestStatus
    {
        Passed,
        Failed,
        Evaluation
    }
}
