namespace TestHub.ApplicationCore.Entities
{
    public abstract class QuestionContent //TODO Move to web project and name QuestionViewModel?
    {
        public int QuestionId { get; }

        protected QuestionContent(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
