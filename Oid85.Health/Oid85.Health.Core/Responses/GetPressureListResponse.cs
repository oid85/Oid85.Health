namespace Oid85.Health.Core.Responses
{
    /// <summary>
    /// История измерений артериального давления
    /// </summary>
    public class GetPressureListResponse
    {
        public List<GetPressureListDayItem> DayItems { get; set; }
    }

    public class GetPressureListDayItem
    {
        public DateOnly Date { get; set; }

        public List<GetPressureListIntraDayItem> IntraDayItems { get; set; }
    }

    public class GetPressureListIntraDayItem
    {
        public TimeOnly Time { get; set; }
        public int? Sys { get; set; }
        public int? Dia { get; set; }
        public int? Pulse { get; set; }
    }
}
