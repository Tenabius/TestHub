using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Web.BaseViewModels;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(MultipleChoiceQuestion))]
    public class MultipleChoiceQuestionViewModel : QuestionViewModel
    {
        public string? Stem { get; set; }
        public List<ChoiceViewModel>? Choices { get; set; }

        [AutoMap(typeof(MultipleChoiceQuestion.Choice))]
        public class ChoiceViewModel : BaseEntityViewModel
        {
            public string? Description { get; set; }
            public bool? IsSelected { get; set; } = false;
        }
    }
}
