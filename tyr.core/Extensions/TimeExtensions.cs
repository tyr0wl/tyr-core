using System;

namespace tyr.Core.Extensions
{
    public static class TimeExtensions
    {
        public static TimeSpan Seconds(this int number)
        {
            return TimeSpan.FromSeconds(number);
        }

        public static TimeSpan Minutes(this int number)
        {
            return TimeSpan.FromMinutes(number);
        }

        public static TimeSpan Seconds(this double number)
        {
            return TimeSpan.FromSeconds(number);
        }

        public static TimeSpan Minutes(this double number)
        {
            return TimeSpan.FromMinutes(number);
        }

        public static bool IsNegative(this TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds < 0;
        }

        public static bool IsPositive(this TimeSpan timeSpan)
        {
            return timeSpan.TotalMilliseconds > 0;
        }
    }
}