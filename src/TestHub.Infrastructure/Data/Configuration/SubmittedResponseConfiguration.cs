using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static TestHub.Core.Entities.MatchingCandidateAnswer;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class SubmittedResponseConfiguration : IEntityTypeConfiguration<SubmittedResponse>
    {
        public void Configure(EntityTypeBuilder<SubmittedResponse> builder)
        {
            builder.HasOne(x => x.Stem)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Response)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
