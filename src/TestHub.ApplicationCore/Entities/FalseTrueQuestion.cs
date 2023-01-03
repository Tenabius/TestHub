namespace TestHub.ApplicationCore.Entities
{
    public sealed class FalseTrueQuestion : Question
    {
        public bool? CorrectAnswer { get; set; }

        public override decimal GradeAnswer()
        {
            throw new NotImplementedException();
        }
    }
}
