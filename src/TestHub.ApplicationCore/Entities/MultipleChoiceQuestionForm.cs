namespace TestHub.Core.Entities
{
    public class MultipleChoiceQuestionForm : Answer
    {
        public List<int> SelectedChoicesId { get; set; }

#pragma warning disable CS8618
        public MultipleChoiceQuestionForm() { }
#pragma warning restore 

        public MultipleChoiceQuestionForm(int questionId, List<int> selectedChoicesId)
            : base(questionId)
        {
            SelectedChoicesId = selectedChoicesId;
        }
    }
}
