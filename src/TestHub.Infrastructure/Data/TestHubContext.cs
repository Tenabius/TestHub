using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data
{
    public class TestHubContext : DbContext
    {
        public TestHubContext(DbContextOptions<TestHubContext> options) 
            : base(options) { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<AnswersSheet> TestForms { get; set; } //TODO Change to better name
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //builder.Entity<FalseTrueQuestion>();
            //builder.Entity<MatchingQuestion>();
            //builder.Entity<MultipleChoiceQuestion>().Navigation(q => q.Choices).AutoInclude();
            //builder.Entity<FillBlankQuestion>();
            //builder.Entity<Question>().UseTptMappingStrategy();
            //builder.Entity<Test>().HasOne(t => t.Author).WithMany().OnDelete(DeleteBehavior.NoAction);
            //builder.Entity<Test>().Navigation(t => t.Questions).AutoInclude();
            //builder.Entity<FalseTrueAnswer>();

            //var converter1 = new ValueConverter<List<(string Name, string Answer)>, string>(
            //    blanks => string.Join("\\;", blanks.ConvertAll(blank => blank.Name + "\\," + blank.Answer)),
            //    blanks => blanks
            //        .Split("\\;", StringSplitOptions.None).ToList()
            //        .ConvertAll(x => x.Split("\\,", 2, StringSplitOptions.None).ToList())
            //        .ConvertAll(x => new Tuple<string, string>(x.First(), x.Last()).ToValueTuple())
            //    );
            //builder.Entity<FillBlankAnswer>().Property(f => f.SubmittedAnswers).HasConversion(converter1);

            //var converter2 = new ValueConverter<List<(int StemId, int ResponseId)>, string>(
            //    blanks => string.Join("\\;", blanks.ConvertAll(blank => blank.StemId + "\\," + blank.ResponseId)),
            //    blanks => blanks
            //        .Split("\\;", StringSplitOptions.None).ToList()
            //        .ConvertAll(x => x.Split("\\,", 2, StringSplitOptions.None).ToList())
            //        .ConvertAll(x => new Tuple<int, int>(int.Parse(x.First()), int.Parse(x.Last())).ToValueTuple())
            //    );
            //builder.Entity<MatchingAnswer>().Property(f => f.SubmittedAnswers).HasConversion(converter2);

            //var converter3 = new ValueConverter<List<int>, string>(ids => string.Join(";", ids),
            //    ids => ids.Split(new[] { ';' }).Select(id => int.Parse(id)).ToList());
            ////builder.Entity<MultipleChoiceAnswer>().Property(f => f.SelectedChoicesId).HasConversion(converter3);


            //builder.Entity<Answer>().UseTptMappingStrategy();
            //builder.Entity<AnswersSheet>().HasOne(f => f.Candidate).WithMany().OnDelete(DeleteBehavior.NoAction);
            //builder.Entity<AnswersSheet>().HasOne(f => f.Test).WithMany().OnDelete(DeleteBehavior.NoAction);

            //builder.Entity<MatchingQuestion.Stem>().HasOne(s => s.CorrectResponse).WithMany().OnDelete(DeleteBehavior.NoAction);
        }

    }
}
