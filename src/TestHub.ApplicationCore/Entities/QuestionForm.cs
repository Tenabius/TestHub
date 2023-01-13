using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public abstract class QuestionForm : BaseEntity
    {
        public int QuestionId { get; }

        protected QuestionForm() { }

        protected QuestionForm(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
