using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static TestHub.Core.Entities.FillBlankCandidateAnswer;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class SubmittedBlankConfiguration : IEntityTypeConfiguration<SubmittedBlank>
    {
        public void Configure(EntityTypeBuilder<SubmittedBlank> builder)
        {
            builder.HasOne(x => x.Blank)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
