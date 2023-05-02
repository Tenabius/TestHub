using TestHub.Core.Entities;
using TestHub.Web.Areas.Candidate.Models;

namespace TestHub.Web.Services
{
    public static class MapService
    {
        public static IEnumerable<CandidateAnswer> Map(IEnumerable<QuestionViewModel> submittedAnswers,
            Test test) 
        {
            var answers = new List<CandidateAnswer>();

            foreach (var submittedAnswer in submittedAnswers)
            {
                if (submittedAnswer is FalseTrueQuestionViewModel falseTrueQuestion)
                {
                    answers.Add(new FalseTrueCandidateAnswer(test.Questions.First((q) => q.Id == falseTrueQuestion.Id), falseTrueQuestion.SelectedChoice ?? false));
                }

                if (submittedAnswer is FillBlankQuestionViewModel fillBlankQuestion)
                {
                    var question = test.Questions.First((q) => q.Id == fillBlankQuestion.Id) as FillBlankQuestion;
                    var blanks = new List<FillBlankCandidateAnswer.SubmittedBlank>();
                    foreach (var blankViewModel in fillBlankQuestion.Blanks!)
                    {
                        blanks.Add(new FillBlankCandidateAnswer.SubmittedBlank(
                            question!.Blanks.First(b => b.Id == blankViewModel.Id),
                            blankViewModel.SubmittedAnswer!));
                    }
                    answers.Add(new FillBlankCandidateAnswer(question!, blanks));
                }

                if (submittedAnswer is MatchingQuestionViewModel matchingQuestion)
                {
                    var question = test.Questions.First((q) => q.Id == matchingQuestion.Id) as MatchingQuestion;
                    var submittedResponses = new List<MatchingCandidateAnswer.SubmittedResponse>();
                    foreach (var stemViewModel in matchingQuestion.Stems)
                    {
                        var stem = question!.Stems.First(s => s.Id == stemViewModel.Id);
                        if (stemViewModel.SubmittedResponse!.Id == null)
                        {
                            submittedResponses.Add(new MatchingCandidateAnswer.SubmittedResponse(stem, null));
                        } else
                        {
                            submittedResponses.Add(new MatchingCandidateAnswer.SubmittedResponse(stem,
                                question!.Responses.First(r => r.Id == stemViewModel.SubmittedResponse.Id)));
                        }
                    }
                    answers.Add(new MatchingCandidateAnswer(question!, submittedResponses));
                }

                if (submittedAnswer is MultipleChoiceQuestionViewModel multipleChoiceQuestion)
                {
                    var question = test.Questions.First((q) => q.Id == multipleChoiceQuestion.Id) as MultipleChoiceQuestion;
                    var submittedChoices = new List<MultipleChoiceCandidateAnswer.SubmittedChoice>();
                    foreach (var choiceViewModel in multipleChoiceQuestion.Choices!)
                    {
                        var choice = question!.Choices.First(s => s.Id == choiceViewModel.Id);
                        submittedChoices.Add(new MultipleChoiceCandidateAnswer.SubmittedChoice(choice, choiceViewModel.IsSelected));
                    }
                    answers.Add(new MultipleChoiceCandidateAnswer(question!, submittedChoices));
                }
            }

            return answers;
        }
    }
}
