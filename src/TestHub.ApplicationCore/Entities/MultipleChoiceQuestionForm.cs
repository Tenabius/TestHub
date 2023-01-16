namespace TestHub.ApplicationCore.Entities
{
    public class MultipleChoiceQuestionForm : QuestionForm
    {
        public List<int> SelectedChoicesId { get; private set; }

#pragma warning disable CS8618
        private MultipleChoiceQuestionForm() { }
#pragma warning restore 

        public MultipleChoiceQuestionForm(int questionId, List<int> selectedChoicesId)
            : base(questionId)
        {
            SelectedChoicesId = selectedChoicesId;
        }
    }
}
