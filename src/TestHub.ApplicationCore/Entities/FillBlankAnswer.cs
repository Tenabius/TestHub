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
        public IReadOnlyList<(Blank Blank, string SubmittedAnswer)> SubmittedAnswers => _submittedAnswers.AsReadOnly();
        private List<(Blank Blank, string SubmittedAnswer)> _submittedAnswers;

#pragma warning disable CS8618
        private FillBlankAnswer() { }
#pragma warning restore 

        public FillBlankAnswer(Question question, IList<(Blank Blank, string SubmittedAnswer)> submittedAnswers)
            : base(question)
        {
            _submittedAnswers = submittedAnswers.ToList();
        }
    }
}
