namespace Oid85.Health.Core.Requests
{
    /// <summary>
    /// Редактирование измерения глюкозы
    /// </summary>
    public class SetGlucoseRequest
    {
        /// <summary>
        /// Дата
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Тип измерения
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Значение
        /// </summary>
        public double? Value { get; set; }
    }
}
