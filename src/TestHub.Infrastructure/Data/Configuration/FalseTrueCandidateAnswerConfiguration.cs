using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class FalseTrueCandidateAnswerConfiguration : IEntityTypeConfiguration<FalseTrueCandidateAnswer>
    {
        public void Configure(EntityTypeBuilder<FalseTrueCandidateAnswer> builder)
        {
        }
    }
}
