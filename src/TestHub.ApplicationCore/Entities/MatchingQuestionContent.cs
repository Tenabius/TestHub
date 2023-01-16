using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.ApplicationCore.Entities
{
    public class MatchingQuestionContent : QuestionContent
    {
        public string Directions { get; }
        public List<(int Id, string Stem)> Stems { get; }
        public List<(int Id, string Response)> Responses { get; }

        public MatchingQuestionContent(int questionId, 
            string directions, 
            List<(int Id, string Stem)> stems,
            List<(int Id, string Response)> responses)
            : base(questionId)
        {
            Directions = directions;
            Stems = stems;
            Responses = responses;
        }
    }
}
