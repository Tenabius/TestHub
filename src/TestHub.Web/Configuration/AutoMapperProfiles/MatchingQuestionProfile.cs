using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Web.Areas.Candidate.Models;

namespace TestHub.Web.Configuration.AutoMapperProfiles
{
    public class MatchingQuestionProfile : Profile
    {
        public MatchingQuestionProfile() 
        {
            CreateMap<MatchingQuestion.Response, MatchingQuestionViewModel.ResponseViewModel>();
            CreateMap<MatchingQuestion.Stem, MatchingQuestionViewModel.StemViewModel>();
            CreateMap<MatchingQuestion, MatchingQuestionViewModel>();

        }
    }
}
