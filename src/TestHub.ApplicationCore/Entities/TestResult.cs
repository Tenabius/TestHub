using Microsoft.AspNetCore.Identity;
using Validation;

namespace TestHub.Core.Entities
{
    public class TestResult : BaseEntity
    {
        public IdentityUser Candidate { get; private set; }
        public Test Test { get; private set; }
        public DateTimeOffset StartTime { get; private set; }
        public DateTimeOffset? EndTime { get; set; }
        public int? Score => _candidateAnswers?.Aggregate(0, (score, answer) => answer.IsCorrect() ? score++ : score);
        public bool? IsPassed => Score >= Test.PassingScore 
            && EndTime - StartTime <= Test.Duration;
        public IReadOnlyList<Answer>? CandidateAnswers => _candidateAnswers?.AsReadOnly();
        private List<Answer>? _candidateAnswers;

#pragma warning disable CS8618
        private TestResult() { }
#pragma warning restore CS8618

        private TestResult(IdentityUser candidate, 
            Test test, 
            DateTimeOffset startTime)
        {
            Candidate = candidate;
            Test = test;
            StartTime = startTime;
        }

        public static TestResult Create(IdentityUser candidate,
            Test test,
            DateTimeOffset startTime)
        {
            Requires.NotNull(candidate, nameof(candidate));
            Requires.NotNull(test, nameof(test));
            return new(candidate, test, startTime);
        }

        public void SubmitCandidateAnswers(DateTimeOffset endTime, IEnumerable<Answer> candidateAnswers)
        {
            bool isAnswersForThisTest = Test.Questions.All(q => candidateAnswers.Any(a => a.Question.Id == q.Id))
                && candidateAnswers.All(a => Test.Questions.Any(q => a.Question.Id == q.Id));

            if (!isAnswersForThisTest)
            {
                throw new InvalidOperationException("The answers not for this test!");
            }

            _candidateAnswers = candidateAnswers.ToList();
        }

    }
}
