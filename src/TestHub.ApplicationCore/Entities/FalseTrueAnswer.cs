namespace TestHub.Core.Entities
{
    public sealed class FalseTrueAnswer : Answer
    {
        public bool? SubmittedChoice { get; private set; }

#pragma warning disable CS8618
        public FalseTrueAnswer() { }
#pragma warning restore 

        public FalseTrueAnswer(Question question, bool? submittedChoice) :
            base(question)
        {
            SubmittedChoice = submittedChoice;
        }
    }
}
