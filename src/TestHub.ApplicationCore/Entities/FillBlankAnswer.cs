using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validation;
using static TestHub.Core.Entities.FillBlankQuestion;

namespace TestHub.Core.Entities
{
    public sealed class FillBlankAnswer : Answer
    {
        public List<(Blank Blank, string SubmittedAnswer)> SubmittedAnswers { get; private set; }

#pragma warning disable CS8618
        private FillBlankAnswer() { }
#pragma warning restore 

        public FillBlankAnswer(Question question, IList<(Blank Blank, string SubmittedAnswer)> submittedAnswers)
            : base(question)
        {
            SubmittedAnswers = submittedAnswers.ToList();
        }
    }
}
