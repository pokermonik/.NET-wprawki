using WebApplication1.Interfaces;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectService(this
        IServiceCollection services)
        {
            services.AddTransient<IRepository, SearchEntryRepository>();
            services.AddTransient<ILeapYearInterface, LeapYearService>();
            return services;
        }
    }
}
