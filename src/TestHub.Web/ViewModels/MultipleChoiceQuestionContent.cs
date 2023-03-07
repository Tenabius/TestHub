using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.Core.Entities
{
    public class MultipleChoiceQuestionContent : QuestionContent
    {
        public string Directions { get; }
        public string Stem { get; }
        public List<(int Id, string Description)> Choices { get; }

        public MultipleChoiceQuestionContent(int questionId, string directions, string stem, List<(int, string)> choices)
            : base(questionId, nameof(MultipleChoiceAnswer))
        {
            Directions = directions;
            Stem = stem;
            Choices = choices;
        }
    }
}
