using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class FillBlankQuestionConfiguration : IEntityTypeConfiguration<FillBlankQuestion>
    {
        public void Configure(EntityTypeBuilder<FillBlankQuestion> builder)
        {
            builder.Navigation(q => q.Blanks)
                .HasField("_blanks")
                .AutoInclude();

            builder.HasMany(q => q.Blanks)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
