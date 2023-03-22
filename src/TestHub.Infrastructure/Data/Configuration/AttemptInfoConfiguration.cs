using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestHub.Infrastructure.Data.Configuration
{
    internal class AttemptInfoConfiguration : IEntityTypeConfiguration<TestAttemptInfo>
    {
        public void Configure(EntityTypeBuilder<TestAttemptInfo> builder)
        {
            builder.HasNoKey();
            builder.HasOne(a => a.Candidate)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Test)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
