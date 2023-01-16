using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestHub.ApplicationCore.Entities;

namespace TestHub.Infrastructure.Data
{
    public class TestHubContext : DbContext
    {
        public TestHubContext(DbContextOptions<TestHubContext> options) 
            : base(options) { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<TestForm> TestForms { get; set; } //TODO Change to better name
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<FalseTrueQuestion>();
            builder.Entity<MatchingQuestion>();
            builder.Entity<MultipleChoiceQuestion>();
            builder.Entity<FillBlankQuestion>();
            builder.Entity<Question>().UseTptMappingStrategy();
            builder.Entity<Test>().HasOne(t => t.Author);
            builder.Entity<Test>().Navigation(t => t.Questions).AutoInclude();
            builder.Entity<FalseTrueQuestionForm>();
            builder.Entity<FillBlankQuestionForm>();
            builder.Entity<MatchingQuestionFrom>();
            builder.Entity<MultipleChoiceQuestionForm>();
            builder.Entity<QuestionForm>().UseTptMappingStrategy();
            builder.Entity<TestForm>().HasOne(t => t.Candidate);
        }

    }
}
