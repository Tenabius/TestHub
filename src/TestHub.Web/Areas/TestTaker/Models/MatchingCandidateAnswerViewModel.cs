﻿namespace TestHub.Web.Areas.TestTaker.Models
{
    public class MatchingCandidateAnswerViewModel : CandidateAnswerViewModel
    {
        public List<SubmittedResponseViewModel>? SubmittedResponses { get; set; }

        public class SubmittedResponseViewModel
        {
            public int? StemId { get; set; }
            public int? ResponseId { get; set; }
        }
    }
}
