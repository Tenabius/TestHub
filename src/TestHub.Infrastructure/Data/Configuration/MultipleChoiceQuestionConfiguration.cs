using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class MultipleChoiceQuestionConfiguration : IEntityTypeConfiguration<MultipleChoiceQuestion>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceQuestion> builder)
        {
            builder.Navigation(q => q.Choices)
                .HasField("_choices")
                .AutoInclude();

            builder.HasMany(q => q.Choices)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
