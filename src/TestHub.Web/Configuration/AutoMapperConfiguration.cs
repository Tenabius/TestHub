using AutoMapper;
using Google.Api;
using TestHub.Core.Entities;
using TestHub.Web.Areas.TestTaker.Models;
using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public class AutoMapperConfiguration : IApplicationConfigurator
    {
        public void ApplyConfiguration(WebApplicationBuilder builder)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Test, TestInfoViewModel>();
            });

            IMapper mapper = config.CreateMapper();
            builder.Services.AddSingleton(mapper);
        }
    }
}
