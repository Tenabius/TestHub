using System.Reflection;
namespace TestHub.ApplicationCore.Entities
{
    public class Test : BaseEntity
    {
        public User Author { get; }
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public int? PassingScore { get; private set; }
        public TimeSpan? TimeTesting { get; private set; }
        public int? AttemptAllowed { get; private set; }
        public IReadOnlyCollection<Question> Questions => _questions.AsReadOnly();

        private readonly List<Question> _questions = new();

        public Test(User author)
        {
            Author = author;
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