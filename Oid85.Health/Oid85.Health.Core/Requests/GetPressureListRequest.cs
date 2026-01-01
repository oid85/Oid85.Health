namespace Oid85.Health.Core.Requests
{
    /// <summary>
    /// История измерений артериального давления
    /// </summary>
    public class GetPressureListRequest
    {
        /// <summary>
        /// Дата начала
        /// </summary>
        public DateOnly From { get; set; }

        /// <summary>
        /// Дата конца
        /// </summary>
        public DateOnly To { get; set; }
    }
}
