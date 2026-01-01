using Microsoft.EntityFrameworkCore;
using Oid85.Health.Common.KnownConstants;
using Oid85.Health.Infrastructure.Entities;
using Oid85.Health.Infrastructure.Schemas;

namespace Oid85.Health.Infrastructure;

public class HealthContext(DbContextOptions<HealthContext> options) : DbContext(options)
{
    public DbSet<PressureEntity> PressureEntities { get; set; }
    public DbSet<GlucoseEntity> GlucoseEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .HasDefaultSchema(KnownDatabaseSchemas.Default)
            .ApplyConfigurationsFromAssembly(
                typeof(HealthContext).Assembly,
                type => type
                    .GetInterface(typeof(IHealthSchema).ToString()) != null)
            .UseIdentityAlwaysColumns();
    }    
}