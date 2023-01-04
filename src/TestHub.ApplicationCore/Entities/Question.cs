using TestHub.ApplicationCore.Interfaces;

namespace TestHub.ApplicationCore.Entities
{
    public abstract class Question : BaseEntity
    {
        public string Description { get; }
        public int MaxPoints { get; }
        public int TestId { get; }

        protected Question(string description, int maxPoints, int testId)
        {
            Description = description;
            MaxPoints = maxPoints;
            TestId = testId;
        }

        public abstract AnswerForm GetAnswerForm();

        public abstract IView GetView();

        public abstract void Validate();
    }
}
