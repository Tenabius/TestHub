using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EntityTypeBuilder<Test> builder)
        {
            builder.Navigation(q => q.Questions)
                .HasField("_questions")
                .AutoInclude();

            builder.HasMany(q => q.Questions)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Author)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
