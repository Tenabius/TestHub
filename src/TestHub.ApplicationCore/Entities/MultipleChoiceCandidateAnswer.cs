﻿using static TestHub.Core.Entities.MultipleChoiceQuestion;

namespace TestHub.Core.Entities
{
    public class MultipleChoiceCandidateAnswer : CandidateAnswer
    {
        public IReadOnlyList<SubmittedChoice> SubmittedChoices => _submittedChoices.AsReadOnly();
        private readonly List<SubmittedChoice> _submittedChoices;

#pragma warning disable CS8618
        public MultipleChoiceCandidateAnswer() { }
#pragma warning restore 

        public MultipleChoiceCandidateAnswer(Question question, IList<SubmittedChoice> submittedChoices)
            : base(question)
        {
            _submittedChoices = submittedChoices.ToList();
        }

        public class SubmittedChoice : BaseEntity
        {
            public Choice Choice { get; private set; }
            public bool IsSelected { get; private set; }

            public SubmittedChoice(Choice choice, bool isSelected)
            {
                Choice = choice;
                IsSelected = isSelected;
            }

#pragma warning disable CS8618
            public SubmittedChoice() { }
#pragma warning restore   

        }
    }
}
