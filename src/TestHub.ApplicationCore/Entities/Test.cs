using System.Reflection;
namespace TestHub.ApplicationCore.Entities
{
    public class Test : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Question> Questions { get; } = new();
        public int PassingScore { get; set; }
        public User Author { get; set; }
        public TimeSpan? TimeTesting { get; set; }
        public int? AttemptAllowed { get; set; }

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
            Questions.Add(question);
        }

        public void Validate()
        {
            var properties = GetType().GetProperties(BindingFlags.DeclaredOnly
                | BindingFlags.Instance
                | BindingFlags.Public);

            List<string> nullProperties = new();

            foreach(PropertyInfo property in properties)
            {
                if (GetType().GetProperty(property.Name).GetValue(this) is null)
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