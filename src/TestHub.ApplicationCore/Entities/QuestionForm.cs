using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public abstract class QuestionForm : BaseEntity
    {
        public int QuestionId { get; private set; }

#pragma warning disable CS8618
        protected QuestionForm() { }
#pragma warning restore 

        protected QuestionForm(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
