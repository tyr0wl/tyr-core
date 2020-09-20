using System;

namespace tyr.Core.Extensions
{
    public static class IntegerExtensions
    {
        public static int Absolute(this int value)
        {
            return Math.Abs(value);
        }

        public static bool IsPositive(this int value)
        {
            return value >= 0;
        }

        public static bool IsNegative(this int value)
        {
            return value < 0;
        }

        public static bool IsGreaterOrEqual(this int value, int valueToCompare)
        {
            return value >= valueToCompare;
        }

        public static bool IsSmallerOrEqual(this int value, int valueToCompare)
        {
            return value <= valueToCompare;
        }

        public static bool IsInRange(this int value, int minValue, int maxValue)
        {
            return value >= minValue && value <= maxValue;
        }
    }
}