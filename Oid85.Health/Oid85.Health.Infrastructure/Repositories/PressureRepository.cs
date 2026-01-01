using Microsoft.EntityFrameworkCore;
using Oid85.Health.Application.Interfaces.Repositories;
using Oid85.Health.Core.Models;
using Oid85.Health.Infrastructure.Entities;

namespace Oid85.Health.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class PressureRepository(
        IDbContextFactory<HealthContext> contextFactory) 
        : IPressureRepository
    {
        /// <inheritdoc/>
        public async Task<Guid?> CreatePressureAsync(Pressure model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = new PressureEntity
            {
                Id = Guid.NewGuid(),
                Date = model.Date,
                Time = model.Time,
                Sys = model.Sys,
                Dia = model.Dia,
                Pulse = model.Pulse
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<List<Pressure>?> GetPressuresAsync(DateOnly from, DateOnly to)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.PressureEntities
                .Where(x => x.Date >= from)
                .Where(x => x.Date <= to)
                .AsQueryable();

            if (entities is null)
                return null;

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            if (filteredEntities is null)
                return null;

            var result = entities
                .Select(x => new Pressure
                {
                    Id = x.Id,
                    Date = x.Date,
                    Time = x.Time,
                    Sys = x.Sys,
                    Dia = x.Dia,
                    Pulse = x.Pulse
                })
                .ToList();

            return result;
        }
    }
}
