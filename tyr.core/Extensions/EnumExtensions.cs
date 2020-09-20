using System;
using System.Linq;

namespace tyr.Core.Extensions
{
    public static class EnumExtensions
    {
        public static TExpected GetAttributeValue<T, TExpected>(this Enum enumeration, Func<T, TExpected> expression)
            where T : Attribute
        {
            var attribute = GetAttributeOfType<T>(enumeration);
            return attribute != null ? expression(attribute) : default;
        }

        /// <summary>
        ///     Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumeration">The enumeration value</param>
        /// <returns>The attribute of type T that exists on the enumeration value</returns>
        public static T GetAttributeOfType<T>(this Enum enumeration) where T : Attribute
        {
            var type = enumeration.GetType();
            var memberInfoArray = type.GetMember(enumeration.ToString());
            var attributes = memberInfoArray[0].GetCustomAttributes(typeof(T), false);

            return attributes.Cast<T>().SingleOrDefault();
        }

        public static T Parse<T>(this Enum enumerator, int value)
        {
            return (T) Enum.Parse(typeof(T), value.ToString());
        }
    }
}