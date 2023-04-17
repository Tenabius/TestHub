using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestHub.Core.Entities;

namespace TestHub.Infrastructure.Data
{
    public class TestHubContext : IdentityDbContext
    {
        public TestHubContext(DbContextOptions<TestHubContext> options)
            : base(options) { }

        public DbSet<Test> Tests { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
