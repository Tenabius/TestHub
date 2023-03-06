using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.Web.ViewModels
{
    public class FalseTrueQuestionViewModel : QuestionViewModel
    {
        public string Directions { get; }
        public string Statment { get; }

        public FalseTrueQuestionViewModel(int questionId, string directions, string statment)
            : base(questionId, nameof(FalseTrueQuestionViewModel))
        {
            Directions = directions;
            Statment = statment;
        }
    }
}
