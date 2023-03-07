using Validation;

namespace TestHub.Core.Entities
{
    public class AnswersSheet : BaseEntity
    {
        public User Candidate { get; private set; }
        public Test Test { get; private set; }
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset EndTime { get; private set; }
        public int Score => _submittedAnswers.Aggregate(0, (score, answer) => answer.IsCorrect() ? score++ : score);
        public bool IsPassed => Score >= Test.PassingScore && EndTime - StartTime <= Test.Duration;
        public IReadOnlyList<Answer> SubmittedAnswers => _submittedAnswers.AsReadOnly();
        private List<Answer> _submittedAnswers;

#pragma warning disable CS8618
        private AnswersSheet() { }
#pragma warning restore CS8618

        private AnswersSheet(User candidate, 
            Test test, 
            DateTimeOffset startTime, 
            DateTimeOffset endTime, 
            IList<Answer> submittedAnswers)
        {
            Candidate = candidate;
            Test = test;
            StartTime = startTime;
            EndTime = endTime;
            _submittedAnswers = submittedAnswers.ToList();
        }

        public static AnswersSheet Create(User candidate,
            Test test,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            IList<Answer> submittedAnswers)
        {
            Requires.NotNull(candidate, nameof(candidate));
            Requires.NotNull(test, nameof(test));
            Requires.NotNull(submittedAnswers, nameof(submittedAnswers));
            Verify.Operation(endTime > startTime,
                "The end time cannot be earlier than the start time");
            Verify.Operation(test.Questions.Count == submittedAnswers.Count,
                "The number of questions is not equal to the number of answers");

            return new(candidate, test, startTime, endTime, submittedAnswers);
        }

    }
}
