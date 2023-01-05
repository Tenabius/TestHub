using System.Diagnostics.CodeAnalysis;
using System.Xml.Linq;
using TestHub.ApplicationCore.Interfaces;

namespace TestHub.ApplicationCore.Entities
{
    public abstract class Question : BaseEntity
    {
        public string Description { get; private set; }
        public int MaxPoints { get; private set; }
        public Test Test { get; }

        protected Question(Test test, string description, int maxPoints)
        {
            SetDescription(description);
            SetMaxPoints(maxPoints);
            Test = test;
        }

        [MemberNotNull(nameof(Description))]
        public void SetDescription(string description)
        {
            if (description != string.Empty)
            {
                Description = description;
            } else
            {
                throw new ArgumentException(nameof(Description));
            }
        }

        [MemberNotNull(nameof(MaxPoints))]
        public void SetMaxPoints(int maxPoints)
        {
            if (maxPoints > 0)
            {
                MaxPoints = maxPoints;
            } else
            {
                throw new ArgumentOutOfRangeException(nameof(maxPoints));
            }
            
        }

        public abstract AnswerForm GetAnswerForm();

        public abstract void Validate();
    }
}
