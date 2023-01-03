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

        public abstract decimal GradeAnswer(object answer);
    }
}
