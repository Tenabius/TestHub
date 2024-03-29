﻿using System.Text.RegularExpressions;
using Validation;

namespace TestHub.Core.Entities
{
    public sealed class FillBlankQuestion : Question
    {
        public static readonly Regex BlankTag = new("({blank_\\d+})");
        public string Context { get; private set; }
        public IReadOnlyList<Blank> Blanks => _blanks.AsReadOnly();
        private readonly List<Blank> _blanks = new();

#pragma warning disable CS8618
        private FillBlankQuestion() { }
#pragma warning restore 

        private FillBlankQuestion(string directions, string context, IList<Blank> blanks)
            : base(directions)
        {
            Context = context;
            _blanks = blanks.ToList();
        }

        public static FillBlankQuestion Create(string directions, string context, IList<Blank> blanks)
        {
            Requires.NotNullOrEmpty(directions, nameof(directions));
            Requires.NotNullOrEmpty(context, nameof(context));
            Verify.Operation(blanks.Select(x => x.InnerId).All(new HashSet<int>().Add),
                $"{nameof(Blank.InnerId)} of all blanks must be unique.");
            //TODO Check that all blanks present in context

            return new(directions, context, blanks);
        }

        public override bool EvaluateAnswer(CandidateAnswer submittedAnswer)
        {
            if (submittedAnswer is FillBlankCandidateAnswer answer)
            {
                return answer.SubmittedBlanks
                    .All(a => a.SubmittedAnswer == a.Blank.CorrectAnswer);
            }

            throw new InvalidCastException(nameof(submittedAnswer));
        }

        public sealed class Blank : BaseEntity
        {
            public int InnerId { get; private set; }
            public string CorrectAnswer { get; private set; }

#pragma warning disable CS8618
            private Blank() { }
#pragma warning restore 

            private Blank(int innerId, string correctAnswer)
            {
                InnerId = innerId;
                CorrectAnswer = correctAnswer;
            }

            public static Blank Create(int innerId, string correctAnswer)
            {
                Requires.NotNullOrEmpty(correctAnswer, nameof(correctAnswer));

                return new(innerId, correctAnswer.Trim().ToLower());
            }
        }
    }
}
