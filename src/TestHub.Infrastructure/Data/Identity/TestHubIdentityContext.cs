using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TestHub.Infrastructure.Data.Identity
{
    public class TestHubIdentityContext : IdentityDbContext
    {
        public TestHubIdentityContext(DbContextOptions<TestHubIdentityContext> options)
            : base(options) { }

    }
}
