using Microsoft.AspNetCore.Identity;
using Validation;

namespace TestHub.Core.Entities
{
    public class Test : BaseEntity
    {
        public IdentityUser Author { get; private set; }
        public string Title { get; private set; }
        public int PassingScore { get; private set; }
        public TimeSpan Duration { get; private set; }
        public DateTimeOffset CreationTime { get; private set; }
        public string Description { get; private set; }
        public int AttemptAllowed { get; private set; }
        public IReadOnlyList<Question> Questions => _questions.AsReadOnly();

        private readonly List<Question> _questions;

        #pragma warning disable CS8618
        private Test() { }
        #pragma warning restore CS8618

        private Test(IdentityUser author,
            string title,
            int passingScore,
            TimeSpan duration,
            int attemptAllowed,
            IList<Question> questions)
        {
            Author = author;
            Title = title;
            PassingScore = passingScore;
            Duration = duration;
            AttemptAllowed = attemptAllowed;
            _questions = questions.ToList();
            CreationTime = DateTimeOffset.Now;
        }

        public static Test Create(IdentityUser author, 
            string title, 
            int passingScore, 
            TimeSpan duration,
            int attemptAllowed, 
            IList<Question> questions)
        {
            Requires.NotNull(author, nameof(author));
            Requires.NotNull(questions, nameof(questions));
            Requires.Range(questions.Count >= 1, nameof(questions));
            Requires.NotNullOrEmpty(title, nameof(title));
            Requires.Range(duration > TimeSpan.FromMinutes(3), nameof(duration));
            Requires.Range(passingScore > 0 && passingScore < questions.Count, nameof(passingScore));
            Requires.Range(attemptAllowed >= 1, nameof(attemptAllowed));

            return new(author, title, passingScore, duration, attemptAllowed, questions);
        }
    }
}