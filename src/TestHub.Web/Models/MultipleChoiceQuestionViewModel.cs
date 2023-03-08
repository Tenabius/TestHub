using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestHub.Web.Models
{
    public class MultipleChoiceQuestionViewModel : QuestionViewModel
    {
        public string Directions { get; }
        public string Stem { get; }
        public List<(int Id, string Description)> Choices { get; }

        public MultipleChoiceQuestionViewModel(int questionId, string directions, string stem, List<(int, string)> choices)
            : base(questionId, nameof(MultipleChoiceQuestionViewModel))
        {
            Directions = directions;
            Stem = stem;
            Choices = choices;
        }
    }
}
