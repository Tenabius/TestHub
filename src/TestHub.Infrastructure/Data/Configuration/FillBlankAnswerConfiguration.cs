using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class FillBlankAnswerConfiguration : IEntityTypeConfiguration<FillBlankAnswer>
    {
        public void Configure(EntityTypeBuilder<FillBlankAnswer> builder)
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
