namespace TestHub.Core.Entities
{
    public abstract class Answer : BaseEntity
    {
        public Question Question { get; private set; }

#pragma warning disable CS8618
        protected Answer() { }
#pragma warning restore 

        protected Answer(Question question)
        {
            Question = question;
        }

        public virtual bool IsCorrect()
        {
            return Question.EvaluateAnswer(this);
        }
    }
}
