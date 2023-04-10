using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static TestHub.Core.Entities.MultipleChoiceCandidateAnswer;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class SubmittedChoiceConfiguration : IEntityTypeConfiguration<SubmittedChoice>
    {
        public void Configure(EntityTypeBuilder<SubmittedChoice> builder)
        {
            builder.HasOne(x => x.Choice)
                 .WithMany()
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
