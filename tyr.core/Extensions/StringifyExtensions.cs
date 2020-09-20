using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tyr.Core.Extensions
{
    internal static class StringifyExtensions
    {
        private static string Stringify<T>(this T value, bool stringWithQuotes, Func<T, string> stringifierFunc)
        {
            var quotes = stringWithQuotes ? "'" : string.Empty;

            if (value == null)
            {
                return "null";
            }

            if (value is string || value is char)
            {
                return $"{quotes}{value}{quotes}";
            }

            return stringifierFunc(value);
        }

        private static string JoinStringifiedCollection(string[] stringifiedCollection, bool encapsulateWithBrackets)
        {
            var brackets = GetBrackets(encapsulateWithBrackets);
            return $"{brackets[0]}{string.Join(",", stringifiedCollection)}{brackets[1]}";
        }

        private static string[] GetBrackets(bool encapsulateWithBrackets)
        {
            var openBrackets = encapsulateWithBrackets ? "{{" : string.Empty;
            var closeBrackets = encapsulateWithBrackets ? "}}" : string.Empty;
            return new[] { openBrackets, closeBrackets };
        }

        public static string Stringify<T>(this T value)
        {
            return value is string || !(value is IEnumerable collection) ? Stringify(value, o => o.ToString()) : Stringify(collection);
        }

        public static string Stringify<T>(this T value, Func<T, string> stringifierFunc)
        {
            return Stringify(value, true, stringifierFunc);
        }

        public static string Stringify(this IEnumerable collection)
        {
            return Stringify(collection, element => element.ToString());
        }

        public static string Stringify(this IEnumerable collection, Func<object, string> stringifierFunc)
        {
            var stringifiedCollection = collection.Cast<object>().Select(e => Stringify(e, stringifierFunc)).ToArray();

            return JoinStringifiedCollection(stringifiedCollection, true);
        }

        public static string Stringify<T>(this IEnumerable<T> collection)
        {
            return Stringify(collection, (T element) => element.ToString());
        }

        public static string Stringify<T>(this IEnumerable<T> collection, Func<T, string> stringifierFunc)
        {
            var stringifiedCollection = collection.Select(e => Stringify(e, stringifierFunc)).ToArray();

            return JoinStringifiedCollection(stringifiedCollection, true);
        }
    }
}