using Oid85.Health.Core.Models;

namespace Oid85.Health.Application.Interfaces.Repositories
{
    /// <summary>
    /// Репозиторий глюкозы
    /// </summary>
    public interface IGlucoseRepository
    {
        /// <summary>
        /// Создать запись измерения
        /// </summary>        
        Task<Guid?> CreateGlucoseAsync(Glucose model);

        /// <summary>
        /// Редактировать запись измерения
        /// </summary>        
        Task<Guid?> EditGlucoseAsync(Glucose model);

        /// <summary>
        /// Получить измерение по идентификатору
        /// </summary>        
        Task<Glucose?> GetGlucoseByIdAsync(Guid id);

        /// <summary>
        /// Получить измерение по дате
        /// </summary>        
        Task<Glucose?> GetGlucoseByDateAsync(DateOnly date);

        /// <summary>
        /// Получить измерения за период
        /// </summary>
        Task<List<Glucose>?> GetGlucosesAsync(DateOnly from, DateOnly to);
    }
}
