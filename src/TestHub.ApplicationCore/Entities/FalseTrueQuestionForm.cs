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

        private FalseTrueQuestionForm() { }

        public FalseTrueQuestionForm(int questionId, bool? selectedChoice) :
            base(questionId)
        {
            SelectedChoice = selectedChoice;
        }

        public void SetSelectedChoice(bool selectedChoice)
        {
            SelectedChoice = selectedChoice;
        }
    }
}
