using Microsoft.Extensions.DependencyInjection;
using Rackbook.Application.Behaviors;
using Rackbook.Infrastructure;

namespace Rackbook.Application
{
    public static class DependencyApplicationService
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddInfrastructureService();
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(DependencyApplicationService).Assembly);
                config.AddOpenBehavior(typeof(UnitofWorkBehavior<,>)); 
            });
        }
    }
}
