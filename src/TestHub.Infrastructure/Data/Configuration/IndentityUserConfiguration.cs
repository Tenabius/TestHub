using Laraue.EfCoreTriggers.Common.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestHub.Infrastructure.Data.Configuration
{
    internal class IndentityUserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            builder
                .AfterDelete(trigger => trigger
                    .Action(action => action
                        .ExecuteRawSql($"delete from TestResults where CandidateId=@OldId",
                            user => user.Id)));
        }
    }
}
