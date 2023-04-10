using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class MatchingCandidateAnswerConfiguration : IEntityTypeConfiguration<MatchingCandidateAnswer>
    {
        public void Configure(EntityTypeBuilder<MatchingCandidateAnswer> builder)
        {
            builder.Navigation(x => x.SubmittedResponses)
                .HasField("_submittedResponses")
                .AutoInclude();

            builder.HasMany(x => x.SubmittedResponses)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
