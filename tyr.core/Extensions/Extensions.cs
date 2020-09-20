using System;
using System.Linq.Expressions;

namespace tyr.Core.Extensions
{
    public static class Extensions
    {
        [PublicAPI]
        [Pure]
        [ContractAnnotation("null => true")]
        public static bool IsNull<T>([NoEnumeration] this T source) where T : class
        {
            return source == null;
        }

        public static string GetMemberName<T>(this Expression<Func<T, string>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            return memberExpression?.Member.Name;
        }
    }
}