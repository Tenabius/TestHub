using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.ApplicationCore.Interfaces;

namespace TestHub.ApplicationCore.Entities
{
    public sealed class FalseTrueQuestionForm : QuestionForm
    {
        public bool? SelectedChoice { get; private set; }

#pragma warning disable CS8618
        private FalseTrueQuestionForm() { }
#pragma warning restore 

        public FalseTrueQuestionForm(int questionId, bool? selectedChoice) :
            base(questionId)
        {
            SelectedChoice = selectedChoice;
        }
    }
}
