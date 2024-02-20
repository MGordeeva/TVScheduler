namespace TVScheduler.Business.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime TrimMilliseconds(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Kind);
        }
    }
}
