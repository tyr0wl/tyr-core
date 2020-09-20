using System;

namespace tyr.Core.Extensions
{
    public static class CoalesceExtensions
    {
        public static TResult Coalesce<T, TResult>(this T obj, Func<T, TResult> func)
        {
            return Coalesce(obj, func, default);
        }

        public static TResult Coalesce<T, TResult>(this T obj, Func<T, TResult> func, TResult defaultValue)
        {
            return obj == null ? defaultValue : func(obj);
        }

        public static TResult Coalesce<T1, T2, TResult>(this T1 obj, Func<T1, T2> func1, Func<T2, TResult> func2, TResult defaultValue)
        {
            if (obj == null)
            {
                return defaultValue;
            }

            var obj2 = func1(obj);
            if (obj2 == null)
            {
                return defaultValue;
            }

            return func2(obj2);
        }

        public static TResult Coalesce<T1, T2, T3, TResult>(this T1 obj, Func<T1, T2> func1, Func<T2, T3> func2, Func<T3, TResult> func3, TResult defaultValue)
        {
            if (obj == null)
            {
                return defaultValue;
            }

            var obj2 = func1(obj);
            if (obj2 == null)
            {
                return defaultValue;
            }

            var obj3 = func2(obj2);
            if (obj3 == null)
            {
                return defaultValue;
            }

            return func3(obj3);
        }

        public static TResult Coalesce<T1, T2, T3, T4, TResult>(this T1 obj, Func<T1, T2> func1, Func<T2, T3> func2, Func<T3, T4> func3, Func<T4, TResult> func4, TResult defaultValue)
        {
            if (obj == null)
            {
                return defaultValue;
            }

            var obj2 = func1(obj);
            if (obj2 == null)
            {
                return defaultValue;
            }

            var obj3 = func2(obj2);
            if (obj3 == null)
            {
                return defaultValue;
            }

            var obj4 = func3(obj3);
            if (obj4 == null)
            {
                return defaultValue;
            }

            return func4(obj4);
        }
    }
}