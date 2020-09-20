using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace tyr.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> AsEnumerable<T>(this T value)
        {
            yield return value;
        }

        public static void AddRange<T>(this ICollection<T> targetList, IEnumerable<T> listToAdd)
        {
            foreach (var listItem in listToAdd)
            {
                targetList.Add(listItem);
            }
        }

        [PublicAPI]
        [Pure]
        public static bool IsEmpty([NoEnumeration] this IEnumerable source)
        {
            if (source.IsNull())
            {
                return true;
            }

            return source is ICollection collection ? collection.Count == 0 : IsEnumerableEmpty(source);
        }

        private static bool IsEnumerableEmpty([NoEnumeration] IEnumerable enumerable)
        {
            var enumerator = enumerable.GetEnumerator();
            try
            {
                return !enumerator.MoveNext();
            }
            finally
            {
                if (enumerator is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }

        public static T LastOr<T>(this IEnumerable<T> sourceList, T defaultT) where T : class
        {
            return sourceList.LastOrDefault() ?? defaultT;
        }

        public static T LastOrNew<T>(this IEnumerable<T> sourceList) where T : class, new()
        {
            return sourceList.LastOr(new T());
        }
    }
}