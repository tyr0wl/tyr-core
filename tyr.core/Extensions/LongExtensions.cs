using System;

namespace tyr.Core.Extensions
{
    public static class LongExtensions
    {
        public static long Absolute(this long value)
        {
            return Math.Abs(value);
        }
    }
}