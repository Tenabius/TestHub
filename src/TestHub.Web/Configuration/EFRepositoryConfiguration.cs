using Microsoft.EntityFrameworkCore;
using TestHub.Core.Interfaces;
using TestHub.Infrastructure;
using TestHub.Infrastructure.Data;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class EFRepositoryConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<TestHubContext>(options =>
            options.UseSqlServer(builder.Configuration.GetValue<string>("ConnectionStrings:TestHubDb")));

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            }

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
        }
    }
}