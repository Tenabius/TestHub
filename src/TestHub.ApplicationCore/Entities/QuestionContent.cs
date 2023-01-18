namespace TestHub.ApplicationCore.Entities
{
    public abstract class QuestionContent //TODO Move to web project and name QuestionViewModel?
    {
        public string Kind { get; }
        public int QuestionId { get; }

        protected QuestionContent(int questionId, string kind)
        {
            QuestionId = questionId;
            Kind = kind;    
        }
    }
}
