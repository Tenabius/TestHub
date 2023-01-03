namespace TestHub.ApplicationCore.Entities
{
    public class Test
    {
        public string? Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public List<Question> Questions { get; } = new();

        public int PassingScore { get; set; }

        public string? AuthorId { get; set; }

        public TimeSpan? TimeTesting { get; set; }

        public int? AttemptAllowed { get; set; }


    }
}