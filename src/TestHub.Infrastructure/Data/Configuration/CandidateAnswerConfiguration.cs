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
        }
    }
}
