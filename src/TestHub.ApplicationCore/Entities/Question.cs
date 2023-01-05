using TestHub.ApplicationCore.Interfaces;

namespace TestHub.ApplicationCore.Entities
{
    public abstract class Question : BaseEntity
    {
        public string Description { get; private set; }
        public int MaxPoints { get; private set; }
        public Test Test { get; }

        protected Question(string description, int maxPoints, Test test)
        {
            Description = description;
            MaxPoints = maxPoints > 0 ? maxPoints : throw new Exception();
            Test = test;
        }

        public void UpdateDescription(string description)
        {
            if (description != string.Empty)
            {
                Description = description;
            } else
            {
                throw new InvalidOperationException("Description is empty.");
            }
        }

        public void UpdateMaxPoints(int maxPoints)
        {
            if (maxPoints > 0)
            {
                MaxPoints = maxPoints;
            } else
            {
                //TODO Change exception
                throw new InvalidOperationException();
            }
            
        }

        public abstract AnswerForm GetAnswerForm();

        public abstract void Validate();
    }
}
