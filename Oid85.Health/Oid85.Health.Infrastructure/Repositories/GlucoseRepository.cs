using Microsoft.EntityFrameworkCore;
using Oid85.Health.Application.Interfaces.Repositories;
using Oid85.Health.Core.Models;
using Oid85.Health.Infrastructure.Entities;

namespace Oid85.Health.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class GlucoseRepository(
        IDbContextFactory<HealthContext> contextFactory) 
        : IGlucoseRepository
    {
        /// <inheritdoc/>
        public async Task<Guid?> CreateGlucoseAsync(Glucose model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = new GlucoseEntity
            {
                Id = Guid.NewGuid(),
                Date = model.Date,
                BeforeMorningFood = model.BeforeMorningFood,
                AfterMorningFood = model.AfterMorningFood,
                BeforeTraining = model.BeforeTraining,
                AfterTraining = model.AfterTraining,
                BeforeEveningFood = model.BeforeEveningFood,
                BeforeNight = model.BeforeNight
            };

            await context.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<Guid?> EditGlucoseAsync(Glucose model)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            await context.GlucoseEntities
                .Where(x => x.Id == model.Id)
                .ExecuteUpdateAsync(x => x
                        .SetProperty(entity => entity.BeforeMorningFood, model.BeforeMorningFood)
                        .SetProperty(entity => entity.AfterMorningFood, model.AfterMorningFood)
                        .SetProperty(entity => entity.BeforeTraining, model.BeforeTraining)
                        .SetProperty(entity => entity.AfterTraining, model.AfterTraining)
                        .SetProperty(entity => entity.BeforeEveningFood, model.BeforeEveningFood)
                        .SetProperty(entity => entity.BeforeNight, model.BeforeNight));

            await context.SaveChangesAsync();

            return model.Id;
        }

        /// <inheritdoc/>
        public async Task<Glucose?> GetGlucoseByIdAsync(Guid id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.GlucoseEntities.FirstOrDefaultAsync(x => x.Id == id);

            if (entity is null)
                return null;

            var model = new Glucose
            {
                Id = entity.Id,
                Date = entity.Date,
                BeforeMorningFood = entity.BeforeMorningFood,
                AfterMorningFood = entity.AfterMorningFood,
                BeforeTraining = entity.BeforeTraining,
                AfterTraining = entity.AfterTraining,
                BeforeEveningFood = entity.BeforeEveningFood,
                BeforeNight = entity.BeforeNight
            };

            return model;
        }

        /// <inheritdoc/>
        public async Task<Glucose?> GetGlucoseByDateAsync(DateOnly date)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entity = await context.GlucoseEntities.FirstOrDefaultAsync(x => x.Date == date);

            if (entity is null)
                return null;

            var model = new Glucose
            {
                Id = entity.Id,
                Date = entity.Date,
                BeforeMorningFood = entity.BeforeMorningFood,
                AfterMorningFood = entity.AfterMorningFood,
                BeforeTraining = entity.BeforeTraining,
                AfterTraining = entity.AfterTraining,
                BeforeEveningFood = entity.BeforeEveningFood,
                BeforeNight = entity.BeforeNight
            };

            return model;
        }

        /// <inheritdoc/>
        public async Task<List<Glucose>?> GetGlucosesAsync(DateOnly from, DateOnly to)
        {
            await using var context = await contextFactory.CreateDbContextAsync();

            var entities = context.GlucoseEntities
                .Where(x => x.Date >= from)
                .Where(x => x.Date <= to)
                .AsQueryable();

            if (entities is null)
                return null;

            var filteredEntities = await entities.AsNoTracking().ToListAsync();

            if (filteredEntities is null)
                return null;

            var result = entities
                .Select(x => new Glucose
                {
                    Id = x.Id,
                    Date = x.Date,
                    BeforeMorningFood = x.BeforeMorningFood,
                    AfterMorningFood = x.AfterMorningFood,
                    BeforeTraining = x.BeforeTraining,
                    AfterTraining = x.AfterTraining,
                    BeforeEveningFood = x.BeforeEveningFood,
                    BeforeNight = x.BeforeNight
                })
                .OrderByDescending(x => x.Date)
                .ToList();

            return result;
        }
    }
}
