using Microsoft.AspNetCore.Identity;
using Validation;

namespace TestHub.Core.Entities
{
    public class TestResult : BaseEntity
    {
        public IdentityUser? Candidate { get; private set; }
        public Test Test { get; private set; }
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset EndTime { get; private set; }
        public int Score => _candidateAnswers.Aggregate(0, (score, answer) => answer.IsCorrect() ? ++score : score);
        public bool IsPassed => Score >= Test.PassingScore 
            && EndTime - StartTime <= Test.Duration;
        public IReadOnlyList<CandidateAnswer> CandidateAnswers => _candidateAnswers.AsReadOnly();
        private readonly List<CandidateAnswer> _candidateAnswers;

#pragma warning disable CS8618
        private TestResult() { }
#pragma warning restore CS8618

        private TestResult(IdentityUser? candidate, 
            Test test, 
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            IEnumerable<CandidateAnswer> candidateAnswers)
        {
            Candidate = candidate;
            Test = test;
            StartTime = startTime;
            EndTime = endTime;
            _candidateAnswers = candidateAnswers.ToList();
        }

        public static TestResult Create(IdentityUser? candidate,
            Test test,
            DateTimeOffset startTime,
            DateTimeOffset endTime,
            IEnumerable<CandidateAnswer> candidateAnswers)
        {
            Requires.NotNull(test, nameof(test));

            bool isValidAnswers = test.Questions.All(q => candidateAnswers.Any(a => a.Question.Id == q.Id))
                && candidateAnswers.All(a => test.Questions.Any(q => a.Question.Id == q.Id));
            if (!isValidAnswers)
            {
                throw new InvalidOperationException("Answers not valid.");
            }

            return new(candidate, test, startTime, endTime, candidateAnswers);
        }
    }
}
