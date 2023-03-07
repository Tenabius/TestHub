using System.Diagnostics.CodeAnalysis;
using Validation;

namespace TestHub.Core.Entities
{
    public sealed class MultipleChoiceQuestion : Question
    {
        public string Stem { get; private set; }
        public IReadOnlyList<Choice> Choices => _choices.AsReadOnly();
        public bool IsMultipleAnswers { get; private set; }

        private readonly List<Choice> _choices;

#pragma warning disable CS8618
        private MultipleChoiceQuestion() { }
#pragma warning restore 

        private MultipleChoiceQuestion(string directions, string stem, IList<Choice> choices, bool isMultipleAnswers)
            : base (directions)
        {
            Stem = stem;
            _choices = choices.ToList();
            IsMultipleAnswers = isMultipleAnswers;
        }

        public static MultipleChoiceQuestion Create(string directions, string stem, IList<Choice> choices, bool isMultipleAnswers)
        {
            Requires.NotNullOrEmpty(directions, nameof(directions));
            Requires.NotNullOrEmpty(stem, nameof(stem));

            if (!isMultipleAnswers 
                && choices.Aggregate(0, (acc, choice) => choice.IsCorrect ? acc++ : acc) > 1)
            {
                throw new ArgumentException("Question with one correct choice can't have multiple choices with are correct.");
            }

            return new(directions, stem, choices, isMultipleAnswers);
        }

        public override bool EvaluateAnswer(Answer submittedAnswer)
        {
            if (submittedAnswer is MultipleChoiceAnswer answer)
            {
                return answer.SubmittedAnswers.All(a => a.Choice.IsCorrect == a.IsSelected);
            }
            throw new InvalidCastException(nameof(submittedAnswer));
        }

        public sealed class Choice : BaseEntity
        {
            public string Description { get; private set; }
            public bool IsCorrect { get; private set; }

#pragma warning disable CS8618
            private Choice() { }
#pragma warning restore 

            private Choice(string description, bool isCorrect)
            {
                Description = description;
                IsCorrect = isCorrect;
            }

            public static Choice Create(string description, bool isCorrect)
            {
                Requires.NotNullOrEmpty(description, nameof(description));

                return new(description, isCorrect);
            }
        }
    }
}
