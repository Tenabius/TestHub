using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class FillBlankQuestionForm : QuestionForm
    {
        public List<(string Name, string Answer)> SubmittedAnswers { get; private set; }

#pragma warning disable CS8618
        private FillBlankQuestionForm() { }
#pragma warning restore 

        public FillBlankQuestionForm(int questionId, List<(string Name, string Answer)> submittedAnswers)
            : base(questionId)
        {
            SubmittedAnswers = submittedAnswers;
        }
    }
}
