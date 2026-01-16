using Oid85.Health.Core.Requests;
using Oid85.Health.Core.Responses;

namespace Oid85.Health.Application.Interfaces.Services
{
    /// <summary>
    /// Сервис работы с измерениями глюкозы
    /// </summary>
    public interface IGlucoseService
    {
        /// <summary>
        /// Внесение измерения артериального глюкозы
        /// </summary>
        Task<SetGlucoseResponse?> SetGlucoseAsync(SetGlucoseRequest request);

        /// <summary>
        /// Получение списка измерений глюкозы
        /// </summary>
        Task<GetGlucoseListResponse?> GetGlucoseListAsync(GetGlucoseListRequest request);

        /// <summary>
        /// Получить количество измерений глюкозы за дату
        /// </summary>        
        Task<GetCountGlucoseResponse> GetCountGlucoseAsync(GetCountGlucoseRequest request);
    }
}
