namespace TestHub.Core.Entities
{
    public sealed class FalseTrueCandidateAnswer : CandidateAnswer
    {
        public bool? SubmittedChoice { get; private set; }

#pragma warning disable CS8618
        public FalseTrueCandidateAnswer() { }
#pragma warning restore 

        public FalseTrueCandidateAnswer(Question question, bool? submittedChoice) :
            base(question)
        {
            SubmittedChoice = submittedChoice;
        }
    }
}
