using Oid85.Health.Infrastructure.Entities.Base;

namespace Oid85.Health.Infrastructure.Entities
{
    /// <summary>
    /// Глюкоза
    /// </summary>
    public class GlucoseEntity : BaseEntity
    {
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
