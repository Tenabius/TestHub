using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class MatchingQuestionConfiguration : IEntityTypeConfiguration<MatchingQuestion>
    {
        public void Configure(EntityTypeBuilder<MatchingQuestion> builder)
        {
            builder.Navigation(q => q.Stems)
                .HasField("_stems")
                .AutoInclude();

            builder.HasMany(q => q.Stems)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(q => q.Responses)
                .HasField("_responses")
                .AutoInclude();

            builder.HasMany(q => q.Responses)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
