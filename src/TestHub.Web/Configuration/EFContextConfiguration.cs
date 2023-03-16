using Microsoft.EntityFrameworkCore;
using TestHub.Infrastructure.Data;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class EFContextConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TestHubContext>(options =>
            options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:TestHubDb")));

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            }
        }
    }
}