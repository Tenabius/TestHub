﻿using AutoMapper;
using TestHub.Core.Entities;
using TestHub.Core.Extensions;
using TestHub.Web.BaseViewModels;

namespace TestHub.Web.Areas.Candidate.Models
{
    [AutoMap(typeof(MatchingQuestion))]
    public class MatchingQuestionViewModel : QuestionViewModel
    {
        private List<StemViewModel> _stems = new();
        public List<StemViewModel> Stems
        {
            get { return _stems; }

            set
            {
                _stems = value;
                _stems.Shuffle();
            }
        }
        private List<ResponseViewModel> _responses = new();
        public List<ResponseViewModel> Responses
        {
            get { return _responses; }

            set
            {
                _responses = value;
                _responses.Shuffle();
            }
        }

        [AutoMap(typeof(MatchingQuestion.Stem))]
        public class StemViewModel : BaseEntityViewModel
        {
            public string? Content { get; set; }
            public ResponseViewModel? CorrectResponse { get; set; }
            public ResponseViewModel? SubmittedResponse { get; set; }
        }

        [AutoMap(typeof(MatchingQuestion.Response))]
        public class ResponseViewModel : BaseEntityViewModel
        {
            public string? Content { get; set; }
        }
    }
}
