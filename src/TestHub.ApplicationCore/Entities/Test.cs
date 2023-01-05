using System.Diagnostics.CodeAnalysis;
using Validation;
using System.Reflection;
namespace TestHub.ApplicationCore.Entities
{
    public class Test : BaseEntity
    {
        public User Author { get; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal PassingScore { get; private set; }
        public TimeSpan TimeTesting { get; private set; }
        public int AttemptAllowed { get; private set; }
        public IReadOnlyCollection<Question> Questions => _questions.AsReadOnly();

        private readonly List<Question> _questions = new();

        public Test(User author, string name, decimal passingScore, TimeSpan timeTesting, int attemptAllowed)
        {
            Author = author;
            SetName(name);
            SetPassingScore(passingScore);
        }

        [MemberNotNull(nameof(Name))]
        public void SetName(string name)
        {
            Requires.NotNullOrEmpty(name, nameof(Name));
            Name = name;
        }

        [MemberNotNull(nameof(PassingScore))]
        public void SetPassingScore(decimal passingScore)
        {
            //TODO check for passing score
            Requires.Range(passingScore < 0, nameof(passingScore), $"{nameof(PassingScore)} must be greater than 0");
            PassingScore = passingScore;
        }

        public void SetDescription(string description)
        {
            Requires.NotNull(description, nameof(description));
            Description = description;
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

        public void Validate()
        {
            var properties = GetType().GetProperties(BindingFlags.DeclaredOnly
                | BindingFlags.Instance
                | BindingFlags.Public);

            List<string> nullProperties = new();

            foreach(PropertyInfo property in properties)
            {
                if (GetType().GetProperty(property.Name)?.GetValue(this) is null)
                {
                    nullProperties.Add(property.Name);
                }
            }
            
            if (nullProperties.Count > 0)
            {
                throw new Exception($"Property(-ies) {String.Join(", ", nullProperties)} is null.");
            }
        }

    }
}