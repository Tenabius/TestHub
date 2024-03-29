﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data
{
    public static class TestHubContextSeed
    {
        public static async Task SeedAsync(TestHubContext context)
        {
            if (!await context.Tests.AnyAsync())
            {
                await context.Tests.AddAsync(GetTest());
                await context.SaveChangesAsync();
            }
        }

        private static Test GetTest()
        {
            List<Question> questions = new()
            {
                MultipleChoiceQuestion.Create(
                    directions: "Choose correct answer(s)",
                    stem: "Known for its intelligence, which dog breed has been" +
                    " found capable of understanding more than a thousand words?",
                    isMultipleAnswers: false,
                    choices: new List<MultipleChoiceQuestion.Choice>(){
                        MultipleChoiceQuestion.Choice.Create("Cocker Spaniel", false),
                        MultipleChoiceQuestion.Choice.Create("French Bulldog", false),
                        MultipleChoiceQuestion.Choice.Create("Dachshund", false),
                        MultipleChoiceQuestion.Choice.Create("Border Collie", true)
                    }),

                FalseTrueQuestion.Create(
                    directions: "Choose TRUE or FALSE",
                    statement: "The blue whale is the biggest animal to have ever lived.",
                    correctChoice: true),

                GetMatchingQuestion(),

                FillBlankQuestion.Create(
                    directions: "Fill in a blank with the correct word or phrase",
                    context: "Cow gives us {blank_1}.",
                    blanks: new List<FillBlankQuestion.Blank>()
                    {
                        FillBlankQuestion.Blank.Create(1, "milk")
                    })
             };

            return Test.Create(
                author: new IdentityUser(),
                title: "Animals",
                passingScore: 3,
                duration: TimeSpan.FromMinutes(3),
                description: "This is a test for basic animal knowledge.",
                attemptAllowed: 1,
                questions: questions);
        }

        private static MatchingQuestion GetMatchingQuestion()
        {
            var responses = new List<MatchingQuestion.Response>();
            var stems = new List<MatchingQuestion.Stem>();

            var fishResponse = MatchingQuestion.Response.Create("swim");
            var fishStem = MatchingQuestion.Stem.Create("a fish", fishResponse);
            responses.Add(fishResponse);
            stems.Add(fishStem);

            var dogResponse = MatchingQuestion.Response.Create("walk");
            var dogStem = MatchingQuestion.Stem.Create("a dog", dogResponse);
            responses.Add(dogResponse);
            stems.Add(dogStem);

            var eagleResponse = MatchingQuestion.Response.Create("fly");
            var eagleStem = MatchingQuestion.Stem.Create("an eagle", eagleResponse);
            responses.Add(eagleResponse);
            stems.Add(eagleStem);

            return MatchingQuestion.Create(
                directions: "Match the animals with their abilities.",
                stems: stems,
                responses: responses);
        }
    }
}
