using System.Diagnostics.CodeAnalysis;
using Validation;

namespace TestHub.ApplicationCore.Entities
{
    public sealed class MultipleChoiceQuestion : Question
    {
        public string Stem { get; private set; }
        public IReadOnlyCollection<Choice> Choices => _choices.AsReadOnly();
        public bool IsMultipleAnswers { get; private set; }

        private readonly List<Choice> _choices = new();

#pragma warning disable CS8618
        private MultipleChoiceQuestion() { }
#pragma warning restore 

        public MultipleChoiceQuestion(
            Test test,
            string directions,
            int maxPoints,
            string stem,
            bool isMultipleAnswers)
            : base (test, directions, maxPoints)
        {
            SetStem(stem);
            IsMultipleAnswers = isMultipleAnswers;
        }

        public void AddChoice(Choice choice)
        {
            if (IsMultipleAnswers
                || !choice.IsCorrect
                || !_choices.Any(ch => ch.IsCorrect))
            {
                _choices.Add(choice);
            } else
            {
                throw new InvalidOperationException("Question, with property \"IsMultipleAnswers\" is false, can have only one correct choice");
            }
        }

        public bool DeleteChoice(Choice choice) => _choices.Remove(choice);

        public void UpdateChoice(Choice choice)
        {
            int updatedChoice = _choices.FindIndex(ch => ch.Id == choice.Id);
            if (updatedChoice != -1)
            {
                _choices[updatedChoice] = choice;
            }
            throw new InvalidOperationException("Choice not found");
        }

        [MemberNotNull(nameof(Stem))]
        public void SetStem(string stem)
        {
            Requires.NotNullOrEmpty(stem, nameof(stem));
            Stem = stem;
        }

        public void SetIsMultipliAnswers(bool isMultipliAnswers)
        {
            IsMultipleAnswers = isMultipliAnswers;
        }

        public override QuestionContent GetContent()
        {
            return new MultipleChoiceQuestionContent(Id, Directions, Stem, _choices.ConvertAll(ch => (ch.Id, ch.Description)));
        }

        public override decimal Grade(QuestionForm submittedForm)
        {
            if (submittedForm is MultipleChoiceQuestionForm form)
            {
                if (form.SelectedChoicesId is null
                    || (!IsMultipleAnswers && form.SelectedChoicesId.Count > 1))
                {
                    return 0;
                } else
                {
                    return _choices.Where(ch => ch.IsCorrect).All(ch => form.SelectedChoicesId.Contains(ch.Id))
                        && _choices.Where(ch => !ch.IsCorrect).All(ch => !form.SelectedChoicesId.Contains(ch.Id))
                        ? MaxPoints : 0;
                }
            }
            throw new InvalidCastException(nameof(submittedForm));
        }

        public sealed class Choice : BaseEntity
        {
            public MultipleChoiceQuestion Question { get; private set; }
            public string Description { get; private set; }
            public bool IsCorrect { get; private set; }

#pragma warning disable CS8618
            private Choice() { }
#pragma warning restore 

            public Choice(MultipleChoiceQuestion question, string description, bool isCorrect)
            {
                Question = question;
                Description = description;
                IsCorrect = isCorrect;
            }
        }
    }
}
