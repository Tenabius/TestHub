﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class MultipleChoiceQuestionContent : QuestionContent
    {
        public string Directions { get; }
        public string Stem { get; }
        public List<(int Id, string Description)> Choices { get; }

        public MultipleChoiceQuestionContent(int questionId, string directions, string stem, List<(int, string)> choices)
            : base(questionId)
        {
            Directions = directions;
            Stem = stem;
            Choices = choices;
        }
    }
}