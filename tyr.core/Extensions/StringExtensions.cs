using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tyr.Core.Extensions
{
    public static class StringExtensions
    {
        [PublicAPI]
        [NotNull]
        [Pure]
        [ContractAnnotation("null => notnull")]
        public static string EmptyIfNull([CanBeNull] this string text)
        {
            return text ?? string.Empty;
        }
        [PublicAPI]
        [Pure]
        [ContractAnnotation("notnull => null")]
        public static string NullIfEmpty([CanBeNull] this string text)
        {
            return string.IsNullOrWhiteSpace(text) ? null : text;
        }

        [PublicAPI]
        [Pure]
        [ContractAnnotation("null => true")]
        public static bool IsNullOrWhiteSpace([CanBeNull] this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        [PublicAPI]
        [Pure]
        [ContractAnnotation("null => true", true)]
        public static bool IsNullOrEmpty([CanBeNull] this string text)
        {
            return string.IsNullOrEmpty(text);
        }

        [PublicAPI]
        [Pure]
        [ContractAnnotation("notnull => true", true)]
        public static bool IsNotNullOrEmpty([CanBeNull] this string source)
        {
            return !IsNullOrEmpty(source);
        }

        public static int ToInt(this string source)
        {
            return Convert.ToInt32(source);
        }

        public static bool StartsWithDecimalSign([CanBeNull] this string source)
        {
            return source != null && source.FirstOrDefault().IsDecimalSign();
        }

        public static bool Contains(this string source, IEnumerable<string> values)
        {
            return values.Any(source.Contains);
        }

        [PublicAPI]
        [NotNull]
        [StringFormatMethod("stringObject")]
        [Pure]
        public static string With(this string stringFormat, params object[] parameter)
        {
            return string.Format(stringFormat, parameter);
        }

        [PublicAPI]
        [Pure]
        [NotNull]
        [ContractAnnotation("separator:null => halt")]
        public static string[] Split([NotNull] this string source, [NotNull] string separator)
        {
            return Split(source, separator, StringSplitOptions.None);
        }

        [PublicAPI]
        [Pure]
        [NotNull]
        [ContractAnnotation("separator:null => halt")]
        public static string[] Split([NotNull] this string source, [NotNull] string separator, StringSplitOptions stringSplitOptions)
        {
            Requires.IsNotNull(source, nameof(source));
            return source.Split(new[] { separator }, stringSplitOptions);
        }

        [PublicAPI]
        [Pure]
        public static string ReplaceAt([NotNull] this string source, int position, int length, string replacement)
        {
            Requires.IsNotNull(source, nameof(source));
            var builder = new StringBuilder(source);
            builder.Remove(position, length);
            builder.Insert(position, replacement);
            return builder.ToString();
        }

        [PublicAPI]
        [Pure]
        public static StringBuilder ReplaceAt([NotNull] this StringBuilder source, int position, int length, string replacement)
        {
            Requires.IsNotNull(source, nameof(source));
            source.Remove(position, length);
            source.Insert(position, replacement);
            return source;
        }

        [PublicAPI]
        [Pure]
        public static bool Contains(this string source, string value, StringComparison comparison)
        {
            return false;
        }
    }
}