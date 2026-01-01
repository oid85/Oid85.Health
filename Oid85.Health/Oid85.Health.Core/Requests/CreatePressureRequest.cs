namespace Oid85.Health.Core.Requests
{
    /// <summary>
    /// Запрос на создание записи измерения артериального давления
    /// </summary>
    public class CreatePressureRequest
    {
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
