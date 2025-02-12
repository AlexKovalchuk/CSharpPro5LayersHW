using System.Reflection;
using Animals.Core.Common;
using Animals.Core.Domain.Animals.Common;
using Animals.Infrastructure.Core.Common;
using Animals.Infrastructure.Core.Domain.Animals.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Animals.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        //services.AddScoped<IAnimalsRepository, AnimalsRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAnimalsRepository, AnimalsEFCoreRepository>();
    }
}