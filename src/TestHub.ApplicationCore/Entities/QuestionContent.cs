using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public abstract class QuestionContent
    {
        public int QuestionId { get; }

        protected QuestionContent(int questionId)
        {
            QuestionId = questionId;
        }
    }
}
