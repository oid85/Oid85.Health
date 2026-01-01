using Oid85.Health.Core.Models.Base;

namespace Oid85.Health.Core.Models
{
    /// <summary>
    /// Артериальное давление
    /// </summary>
    public class Pressure : BaseModel
    {
        /// <summary>
        /// Дата и время измерения
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Дата и время измерения
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
