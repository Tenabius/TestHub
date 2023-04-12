using AutoMapper;
using TestHub.Core.Entities;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(MultipleChoiceQuestion))]
    public class MultipleChoiceQuestionViewModel : QuestionViewModel
    {
        public string? Stem { get; set; }
        public List<ChoiceViewModel>? Choices { get; set; }

        [AutoMap(typeof(MultipleChoiceQuestion.Choice))]
        public class ChoiceViewModel
        {
            public int? Id { get; set; }
            public string? Description { get; set; }
        }
    }
}
