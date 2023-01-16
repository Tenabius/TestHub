using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class FillBlankQuestionForm : QuestionForm
    {
        public List<(string InnerId, string Answer)> Answers { get; private set; }

#pragma warning disable CS8618
        private FillBlankQuestionForm() { }
#pragma warning restore 

        public FillBlankQuestionForm(int questionId, List<(string InnerId, string Answer)> blanks)
            : base(questionId)
        {
            Answers = blanks;
        }
    }
}
