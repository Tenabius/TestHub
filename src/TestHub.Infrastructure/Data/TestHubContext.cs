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
        public DbSet<AnswerSheet> AnswerSheets { get; set; }
        public DbSet<AnswerForm> Answers { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Test>().HasOne(t => t.Author);
            builder.Entity<Test>().Navigation(t => t.Questions).AutoInclude();
            builder.Entity<Question>().UseTptMappingStrategy();
            builder.Entity<AnswerForm>().UseTptMappingStrategy();
            builder.Entity<FalseTrueQuestion>();
            builder.Entity<FalseTrueAnswerForm>();
        }

    }
}
