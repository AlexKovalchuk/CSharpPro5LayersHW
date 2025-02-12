using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _5Layers.Animals.Persistence.EFCore.AnimalsDb;

public static class AnimalsDbContextRegistration
{
    public static void RegisterAnimalsDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AnimalsDb");

        services.AddDbContext<AnimalsDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        AnimalsDbContext.AnimalsMigrationHistory,
                        AnimalsDbContext.AnimalsDbSchema);
                });
        });
    }
}