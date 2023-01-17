﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class FillBlankQuestionContent : QuestionContent
    {
        public string Directions { get; }
        public string Context { get; }

        public FillBlankQuestionContent(int questionId, string directions, string context)
            : base(questionId)
        {
            Directions = directions;
            Context = context;
        }
    }
}