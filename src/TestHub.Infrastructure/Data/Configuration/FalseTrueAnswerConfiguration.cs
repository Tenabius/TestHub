using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data.Configuration
{
    public class FalseTrueAnswerConfiguration : IEntityTypeConfiguration<FalseTrueAnswer>
    {
        public void Configure(EntityTypeBuilder<FalseTrueAnswer> builder)
        {
        }
    }
}
