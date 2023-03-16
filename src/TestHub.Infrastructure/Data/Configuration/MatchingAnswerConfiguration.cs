using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class MatchingAnswerConfiguration : IEntityTypeConfiguration<MatchingAnswer>
    {
        public void Configure(EntityTypeBuilder<MatchingAnswer> builder)
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
