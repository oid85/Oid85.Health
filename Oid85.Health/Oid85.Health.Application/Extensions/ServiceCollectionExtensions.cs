using Microsoft.Extensions.DependencyInjection;
using Oid85.Health.Application.Interfaces.Services;
using Oid85.Health.Application.Services;

namespace Oid85.Health.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationServices(
        this IServiceCollection services)
    {
        services.AddTransient<IPressureService, PressureService>();
        services.AddTransient<IGlucoseService, GlucoseService>();
    }
}