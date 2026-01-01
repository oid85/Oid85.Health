namespace Oid85.Health.Core.Responses
{
    /// <summary>
    /// Ответ на запрос создания записи измерения артериального давления
    /// </summary>
    public class CreatePressureResponse
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
    }
}
