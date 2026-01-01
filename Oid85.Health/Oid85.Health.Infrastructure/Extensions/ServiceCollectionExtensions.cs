using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oid85.Health.Application.Interfaces.Repositories;
using Oid85.Health.Common.KnownConstants;
using Oid85.Health.Infrastructure.Repositories;

namespace Oid85.Health.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {    
        services.AddDbContextPool<HealthContext>((serviceProvider, options) =>
        {  
            options.UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresHealthConnectionString)!);
        });

        services.AddPooledDbContextFactory<HealthContext>(options =>
            options
                .UseNpgsql(configuration.GetValue<string>(KnownSettingsKeys.PostgresHealthConnectionString)!)
                .EnableServiceProviderCaching(false), poolSize: 32);

        services.AddTransient<IPressureRepository, PressureRepository>();
        services.AddTransient<IGlucoseRepository, GlucoseRepository>();
    }

    public static async Task ApplyMigrations(this IHost host)
    {
        var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();
        await using var scope = scopeFactory.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<HealthContext>();
        await context.Database.MigrateAsync();
    }
}