using Microsoft.EntityFrameworkCore;
using TestHub.ApplicationCore.Models;

namespace TestHub.Infrastructure
{
    public class TestHubContext : DbContext
    {
        DbSet<Test> Tests { get; set; }
    }
}