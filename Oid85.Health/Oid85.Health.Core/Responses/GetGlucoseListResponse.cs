namespace Oid85.Health.Core.Responses
{
    /// <summary>
    /// История измерений глюкозы
    /// </summary>
    public class GetGlucoseListResponse
    {
        public List<GetGlucoseListDayItem> DayItems { get; set; }
    }

    public class GetGlucoseListDayItem
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Дата измерения
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Перед завтраком
        /// </summary>
        public double? BeforeMorningFood { get; set; }

        /// <summary>
        /// После завтрака
        /// </summary>
        public double? AfterMorningFood { get; set; }

        /// <summary>
        /// Перед тренировкой
        /// </summary>
        public double? BeforeTraining { get; set; }

        /// <summary>
        /// После тренировки
        /// </summary>
        public double? AfterTraining { get; set; }

        /// <summary>
        /// Перед ужином
        /// </summary>
        public double? BeforeEveningFood { get; set; }

        /// <summary>
        /// Перед сном
        /// </summary>
        public double? BeforeNight { get; set; }
    }
}
