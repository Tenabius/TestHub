namespace TestHub.Core.Entities
{
    public abstract class Question : BaseEntity
    {
        public string Directions { get; private set; }

#pragma warning disable CS8618
        protected Question() { }
#pragma warning restore 

        protected Question(string directions)
        {
            Directions = directions;
        }

        public abstract bool EvaluateAnswer(CandidateAnswer answer);
    }
}
