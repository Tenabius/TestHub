using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class SessionConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            builder.Services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = builder.Configuration.GetValue<string>("ConnectionStrings:TestHubDb");
                options.SchemaName = "dbo";
                options.TableName = "Sessions";
            });

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}
