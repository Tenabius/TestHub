using System.Diagnostics.CodeAnalysis;
using Validation;
using System.Xml.Linq;
using TestHub.ApplicationCore.Interfaces;

namespace TestHub.ApplicationCore.Entities
{
    public abstract class Question : BaseEntity
    {
        public string Directions { get; private set; }
        public int MaxPoints { get; private set; }
        public Test Test { get; }

        #pragma warning disable CS8618
        protected Question() { }
        #pragma warning restore CS8618

        protected Question(Test test, string directions, int maxPoints)
        {
            SetDirections(directions);
            SetMaxPoints(maxPoints);
            Test = test;
        }

        [MemberNotNull(nameof(Directions))]
        public void SetDirections(string directions)
        {
            Requires.NotNullOrEmpty(directions, nameof(directions));
            Directions = directions;
        }

        [MemberNotNull(nameof(MaxPoints))]
        public void SetMaxPoints(int maxPoints)
        {
            Requires.Range(maxPoints > 0,
                nameof(maxPoints),
                $"{nameof(maxPoints)} must be greater than 0");
            MaxPoints = maxPoints;
        }

        public abstract decimal Grade(QuestionForm candidateAnswer);

        public abstract QuestionContent GetContent();
    }
}
