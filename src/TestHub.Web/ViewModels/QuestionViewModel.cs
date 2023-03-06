namespace TestHub.Web.ViewModels
{
    public abstract class QuestionViewModel //TODO Move to web project and name QuestionViewModel?
    {
        public string Kind { get; }
        public int QuestionId { get; }

        protected QuestionViewModel(int questionId, string kind)
        {
            QuestionId = questionId;
            Kind = kind;    
        }
    }
}
