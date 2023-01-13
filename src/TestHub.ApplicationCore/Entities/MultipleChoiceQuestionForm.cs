namespace TestHub.ApplicationCore.Entities
{
    public class MultipleChoiceQuestionForm : QuestionForm
    {
        public List<int>? SelectedChoicesId { get; private set; }

        public MultipleChoiceQuestionForm(int questionId, List<int>? selectedChoicesId)
            : base(questionId)
        {
            SelectedChoicesId = selectedChoicesId;
        }

        public void SetSelectedChoicesId(List<int> selectedChoicesId)
        {
            SelectedChoicesId = selectedChoicesId;
        }
    }
}
