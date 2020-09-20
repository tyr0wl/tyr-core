namespace tyr.Core.Extensions
{
    public static class CharExtensions
    {
        public static bool IsDecimalSign(this char source)
        {
            return source == '+' || source == '-';
        }
    }
}