using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class FalseTrueQuestionContent : QuestionContent
    {
        public string Directions { get; }
        public string Statment { get; }

        public FalseTrueQuestionContent(int questionId, string directions, string statment)
            : base(questionId, nameof(FalseTrueQuestionForm))
        {
            Directions = directions;
            Statment = statment;
        }
    }
}
