namespace tyr.Core.Extensions
{
    public static class FloatExtensions
    {
        public static bool IsInRange(this float value, float minValue, float maxValue)
        {
            return value >= minValue && value <= maxValue;
        }
    }
}