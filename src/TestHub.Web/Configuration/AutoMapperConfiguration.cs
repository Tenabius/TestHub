using AutoMapper;
using System.Reflection;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class AutoMapperConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            IMapper mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
        }
    }
}
