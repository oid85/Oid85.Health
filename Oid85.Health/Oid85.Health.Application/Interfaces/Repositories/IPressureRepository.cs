using Oid85.Health.Core.Models;

namespace Oid85.Health.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий артериального давления
    /// </summary>
    public interface IPressureRepository
    {
        /// <summary>
        /// Создать запись измерения
        /// </summary>        
        Task<Guid?> CreatePressureAsync(Pressure model);

        /// <summary>
        /// Получить измерения за период
        /// </summary>
        Task<List<Pressure>?> GetPressuresAsync(DateOnly from, DateOnly to);
    }
}
