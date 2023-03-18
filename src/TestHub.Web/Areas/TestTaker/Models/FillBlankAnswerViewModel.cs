﻿namespace TestHub.Web.Areas.TestTaker.Models
{
    public class FillBlankAnswerViewModel : AnswerViewModel
    {
        public List<SubmittedBlankViewModel>? SubmittedBlanks { get; set; }

        public class SubmittedBlankViewModel
        {
            public int? Id { get; set; }
            public string? SubmittedAnswer { get; set; }
        }
    }
}
