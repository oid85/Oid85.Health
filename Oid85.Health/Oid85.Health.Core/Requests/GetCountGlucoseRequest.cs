namespace Oid85.Health.Core.Requests
{
    /// <summary>
    /// Получить измерения глюкозы
    /// </summary>
    public class GetCountGlucoseRequest
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }
    }
}
