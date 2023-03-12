using TestHub.Web.Interfaces;

namespace TestHub.Web.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureApplication(this WebApplicationBuilder builder)
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(t => t.GetInterfaces().Contains(typeof(IApplicationConfiguration)) && t.IsClass);

            foreach (var type in types)
            {
                type.GetMethod(nameof(IApplicationConfiguration.ConfigureApplication))?
                    .Invoke(Activator.CreateInstance(type), new[] { builder });
            }
        }
    }
}