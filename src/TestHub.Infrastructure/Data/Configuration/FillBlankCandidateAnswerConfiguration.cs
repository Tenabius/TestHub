using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class FillBlankCandidateAnswerConfiguration : IEntityTypeConfiguration<FillBlankCandidateAnswer>
    {
        public void Configure(EntityTypeBuilder<FillBlankCandidateAnswer> builder)
        {
            builder.Navigation(x => x.SubmittedBlanks)
                .HasField("_submittedBlanks")
                .AutoInclude();

            builder.HasMany(x => x.SubmittedBlanks)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
