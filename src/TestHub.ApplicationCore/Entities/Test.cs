using System.Diagnostics.CodeAnalysis;
using Validation;

namespace TestHub.ApplicationCore.Entities
{
    public class Test : BaseEntity
    {
        public User Author { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal PassingPercent { get; private set; }
        public TimeSpan TimeTesting { get; private set; }
        public int AttemptAllowed { get; private set; }
        public IReadOnlyCollection<Question> Questions => _questions.AsReadOnly();

        private readonly List<Question> _questions = new();

        #pragma warning disable CS8618
        private Test() { }
        #pragma warning restore CS8618

        public Test(User author, 
            string name,
            string desription,
            decimal passingPercent, 
            TimeSpan timeTesting, 
            int attemptAllowed)
        {
            Author = author;
            SetName(name);
            SetDescription(desription);
            SetPassingPercent(passingPercent);
            SetTimeTesting(timeTesting);
            SetAttemptAllowed(attemptAllowed);
        }

        [MemberNotNull(nameof(Name))]
        public void SetName(string name)
        {
            Requires.NotNullOrEmpty(name, nameof(Name));
            Name = name;
        }

        [MemberNotNull(nameof(Description))]
        public void SetDescription(string description)
        {
            Requires.NotNull(description, nameof(description));
            Description = description;
        }

        [MemberNotNull(nameof(PassingPercent))]
        public void SetPassingPercent(decimal passingPercent)
        {
            Requires.Range(passingPercent < 0 && passingPercent > 1, 
                nameof(passingPercent),
                $"{nameof(PassingPercent)} must be greater than 0 and smaller than 1.0");
            PassingPercent = passingPercent;
        }

        [MemberNotNull(nameof(TimeTesting))]
        private void SetTimeTesting(TimeSpan timeTesting)
        {
            Requires.Range(timeTesting.Minutes > 1,
                nameof(timeTesting),
                $"{nameof(timeTesting)} must be greater than 1 minute");
            TimeTesting = timeTesting;
        }

        [MemberNotNull(nameof(AttemptAllowed))]
        private void SetAttemptAllowed(int attemptAllowed)
        {
            Requires.Range(attemptAllowed > 1,
                nameof(attemptAllowed),
                $"{nameof(attemptAllowed)} must be equal or greater than 1");
            AttemptAllowed = attemptAllowed;
        }

        public List<AnswerForm> GetAnswerForms()
        {
            var answerForms = new List<AnswerForm>();
            foreach (var question in Questions)
            {
                answerForms.Add(question.GetAnswerForm());
            }

            return answerForms;
        }

        public void AddQuestion(Question question)
        {
            question.Validate();
            _questions.Add(question);
        }
    }
}