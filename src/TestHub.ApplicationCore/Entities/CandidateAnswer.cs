namespace TestHub.Core.Entities
{
    public abstract class CandidateAnswer : BaseEntity
    {
        public Question Question { get; private set; }

#pragma warning disable CS8618
        protected CandidateAnswer() { }
#pragma warning restore 

        protected CandidateAnswer(Question question)
        {
            Question = question;
        }

        public bool IsCorrect()
        {
            return Question.EvaluateAnswer(this);
        }
    }
}
