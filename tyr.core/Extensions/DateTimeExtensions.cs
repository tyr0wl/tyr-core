using System;
using System.Collections.Generic;
using System.Globalization;

namespace tyr.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsInRange(this DateTime value, DateTime minValue, DateTime maxValue)
        {
            return value >= minValue && value <= maxValue;
        }

        public static bool IsNotInRange(this DateTime value, DateTime minValue, DateTime maxValue)
        {
            return !IsInRange(value, minValue, maxValue);
        }

        public static DateTime ResetMonths(this DateTime value)
        {
            return value.AddMonths(-value.Month + 1);
        }

        public static DateTime ResetMonthDays(this DateTime value)
        {
            return value.AddDays(-value.Day + 1);
        }

        public static DateTime ResetDayOfYear(this DateTime value)
        {
            return value.AddDays(-value.DayOfYear + 1);
        }

        public static DateTime WithMonthSetTo(this DateTime value, int month)
        {
            return new DateTime(value.Year, month, value.Day);
        }

        public static DateTime WithHourSetTo(this DateTime value, int hour)
        {
            return value.AddHours(-value.Hour + hour);
        }

        public static DateTime WithMinutesSetTo(this DateTime value, int minute)
        {
            return value.AddMinutes(-value.Minute + minute);
        }

        public static DateTime WithSecondsSetTo(this DateTime value, int seconds)
        {
            return value.AddSeconds(-value.Second + seconds);
        }

        public static DateTime AddWeeks(this DateTime dateTime, int weeks)
        {
            return dateTime.AddDays(weeks * 7);
        }

        public static int WeekOfYear(this DateTime date)
        {
            var day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)),
                                                                     CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule,
                                                                     CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek);
        }

        public static int WeekOfYear(this DateTime date, DayOfWeek weekStart)
        {
            var day = (int) CultureInfo.CurrentCulture.Calendar.GetDayOfWeek(date);
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date.AddDays(4 - (day == 0 ? 7 : day)),
                                                                     CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, weekStart);
        }

        public static int DaysInMonth(this DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(date.Year, date.Month);
        }

        public static DateTime ResetDaysInMonth(this DateTime date)
        {
            return date.AddDays(-date.Day + 1);
        }

        public static int DaysInYear(this DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetDaysInYear(date.Year);
        }

        public static DateTime GetFirstWeekDayInMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            date = date.ResetMonthDays();
            while (date.DayOfWeek != dayOfWeek)
            {
                date = date.AddDays(1);
            }

            return date;
        }

        public static int DaysInMonth(this DateTime date, int month)
        {
            return CultureInfo.CurrentCulture.Calendar.GetDaysInMonth(date.Year, month);
        }

        public static DateTime FirstDateOfWeek(this DateTime dateTime, int weekOfYear)
        {
            var date = new DateTime(dateTime.Year, 1, 1);
            var daysOffset = DayOfWeek.Thursday - date.DayOfWeek;

            var firstThursday = date.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            var firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1)
            {
                weekNum -= 1;
            }

            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }

        public static bool GreaterThan(this DateTime dateTime, DateTime dateToCompare)
        {
            return dateTime > dateToCompare;
        }

        public static bool LessThan(this DateTime dateTime, DateTime dateToCompare)
        {
            return dateTime < dateToCompare;
        }

        public static bool GreaterThanOrEqual(this DateTime dateTime, DateTime dateToCompare)
        {
            return dateTime >= dateToCompare;
        }

        public static IEnumerable<DateTime> GetDateTimesInMonthOf(this DateTime dateTime, DayOfWeek dayOfWeek)
        {
            var startMonth = dateTime.Month;
            var dateTime2 = dateTime.ResetDaysInMonth();
            var result = new List<DateTime>();

            while (dateTime2.DayOfWeek != dayOfWeek)
            {
                dateTime2 = dateTime2.AddDays(1);
            }

            result.Add(dateTime2);

            while (dateTime2.Month == startMonth)
            {
                dateTime2 = dateTime2.AddDays(7);
                if (dateTime2.Month == startMonth)
                {
                    result.Add(dateTime2);
                }
            }

            return result;
        }

        public static DateTime ResetMilliseconds(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute,
                                dateTime.Second, dateTime.Kind);
        }

        public static string ToUtcIso8601String(this DateTime? utcDateTime)
        {
            if (!utcDateTime.HasValue)
            {
                return null;
            }

            var dateTime = utcDateTime.Value;
            return ToUtcIso8601String(dateTime);
        }

        public static string ToUtcIso8601String(this DateTime utcDateTime)
        {
            return "{0}{1}{2}T{3}{4}{5}Z".With(utcDateTime.Year.ToString("0000"), utcDateTime.Month.ToString("00"),
                                               utcDateTime.Day.ToString("00"), utcDateTime.Hour.ToString("00"), utcDateTime.Minute.ToString("00"),
                                               utcDateTime.Second.ToString("00"));
        }
    }
}