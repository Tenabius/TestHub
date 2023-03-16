using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class FalseTrueQuestionConfiguration : IEntityTypeConfiguration<FalseTrueQuestion>
    {
        public void Configure(EntityTypeBuilder<FalseTrueQuestion> builder)
        {
        }
    }
}
