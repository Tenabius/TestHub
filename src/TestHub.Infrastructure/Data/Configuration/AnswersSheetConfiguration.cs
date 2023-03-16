using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class AnswersSheetConfiguration : IEntityTypeConfiguration<AnswersSheet>
    {
        public void Configure(EntityTypeBuilder<AnswersSheet> builder)
        {
            builder.Navigation(x => x.SubmittedAnswers)
                .HasField("_submittedAnswers")
                .AutoInclude();

            builder.HasMany(x => x.SubmittedAnswers)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Candidate)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
