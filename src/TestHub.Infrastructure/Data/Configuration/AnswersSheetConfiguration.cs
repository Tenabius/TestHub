using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class AnswersSheetConfiguration : IEntityTypeConfiguration<TestResult>
    {
        public void Configure(EntityTypeBuilder<TestResult> builder)
        {
            builder.Navigation(x => x.CandidateAnswers)
                .HasField("_submittedAnswers")
                .AutoInclude();

            builder.HasMany(x => x.CandidateAnswers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Candidate)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
