using Oid85.Health.Infrastructure.Entities.Base;

namespace Oid85.Health.Infrastructure.Entities
{
    /// <summary>
    /// Артериальное давление
    /// </summary>
    public class PressureEntity : BaseEntity
    {
        /// <summary>
        /// Дата измерения
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Время измерения
        /// </summary>
        public TimeOnly Time { get; set; }

        /// <summary>
        /// Систолическое
        /// </summary>
        public int Sys { get; set; }

        /// <summary>
        /// Диастолическое
        /// </summary>
        public int Dia { get; set; }

        /// <summary>
        /// Пульс
        /// </summary>
        public int? Pulse { get; set; }
    }
}
