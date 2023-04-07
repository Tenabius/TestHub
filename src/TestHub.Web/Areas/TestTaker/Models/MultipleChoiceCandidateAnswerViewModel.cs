﻿namespace TestHub.Web.Areas.TestTaker.Models
{
    public class MultipleChoiceCandidateAnswerViewModel : CandidateAnswerViewModel
    {
        public List<SubmittedChoiceViewModel>? SubmittedChoice { get; set; }

        public class SubmittedChoiceViewModel
        {
            public int? Id { get; set; }
            public bool? IsSelected { get; set; }
        }
    }
}
