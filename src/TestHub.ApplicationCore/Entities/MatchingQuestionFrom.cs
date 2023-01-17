﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class MatchingQuestionFrom : QuestionForm
    {
        public List<(int StemId, int ResponseId)> SubmittedAnswers { get; private set; }

#pragma warning disable CS8618
        private MatchingQuestionFrom() { }
#pragma warning restore 

        public MatchingQuestionFrom(int questionId, List<(int StemId, int ResponseId)> submittedAnswers)
            : base(questionId)
        {
            SubmittedAnswers = submittedAnswers;
        }
    }
}