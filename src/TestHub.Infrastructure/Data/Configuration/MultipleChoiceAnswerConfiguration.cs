using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class MultipleChoiceAnswerConfiguration : IEntityTypeConfiguration<MultipleChoiceAnswer>
    {
        public void Configure(EntityTypeBuilder<MultipleChoiceAnswer> builder)
        {
            builder.Navigation(q => q.SubmittedChoices)
                .HasField("_submittedChoices")
                .AutoInclude();

            builder.HasMany(q => q.SubmittedChoices)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
