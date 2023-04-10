using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class CandidateAnswerConfiguration : IEntityTypeConfiguration<CandidateAnswer>
    {
        public void Configure(EntityTypeBuilder<CandidateAnswer> builder)
        {
            builder.UseTptMappingStrategy();
            builder.HasOne(x => x.Question)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
