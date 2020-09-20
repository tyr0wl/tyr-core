using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using tyr.Core.Extensions;

namespace tyr.Core
{
    public static class Requires
    {
        [DebuggerStepThrough]
        [PublicAPI]
        [NotNull]
        [ContractAnnotation("value:null => halt")]
        [AssertionMethod]
        public static T IsNotNull<T>([NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
                                     T value, [InvokerParameterName] string parameterName) where T : class
        {
            if (value == null)
            {
                Throw.ArgumentShouldNotBeNull(parameterName);
            }

            return value;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [NotNull]
        [AssertionMethod]
        public static IEnumerable<T> HasNoNullElements<T>([AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
                                                          IEnumerable<T> values, [InvokerParameterName] string parameterName) where T : class
        {
            var enumerable = values as T[] ?? values.ToArray();
            if (enumerable.Any(item => item == null))
            {
                Throw.ParameterShouldNotContainNullElements(parameterName);
            }

            return enumerable;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [NotNull]
        [AssertionMethod]
        public static T[] HasNoNullElements<T>([AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
                                               T[] values, [InvokerParameterName] string parameterName) where T : class
        {
            if (values == null || values.Any(item => item == null))
            {
                Throw.ParameterShouldNotContainNullElements(parameterName);
            }

            return values;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [NotNull]
        [ContractAnnotation("source:null => halt")]
        [AssertionMethod]
        public static T? IsNotNull<T>([AssertionCondition(AssertionConditionType.IS_NOT_NULL)] [NoEnumeration]
                                      T? source, [InvokerParameterName] string parameterName) where T : struct
        {
            if (!source.HasValue)
            {
                Throw.ArgumentShouldNotBeNull(parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [NotNull]
        [ContractAnnotation("source:null => halt")]
        [AssertionMethod]
        public static string IsNotNullOrEmpty([AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
                                              string source, [InvokerParameterName] string parameterName)
        {
            if (source.IsNullOrEmpty())
            {
                Throw.ArgumentShouldNotBeEmpty(parameterName);
            }

            return source;
        }

        public static IEnumerable IsNotNullOrEmpty([NoEnumeration] [AssertionCondition(AssertionConditionType.IS_NOT_NULL)]
                                                   IEnumerable source, [InvokerParameterName] string parameterName)
        {
            if (source.IsNull())
            {
                Throw.ArgumentShouldNotBeNull(parameterName);
            }

            if (source.IsEmpty())
            {
                Throw.ArgumentShouldNotBeEmpty(parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static DateTime IsInRange(DateTime source, DateTime minValue, DateTime maxValue, [InvokerParameterName] string parameterName)
        {
            if (!source.IsInRange(minValue, maxValue))
            {
                Throw.ArgumentShouldBeBetween(source, minValue, maxValue, parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static int IsInRange(int source, int minValue, int maxValue, [InvokerParameterName] string parameterName)
        {
            if (!source.IsInRange(minValue, maxValue))
            {
                Throw.ArgumentShouldBeBetween(source, minValue, maxValue, parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static int IsGreaterThan(int source, int value, [InvokerParameterName] string parameterName)
        {
            if (source <= value)
            {
                Throw.ArgumentShouldBeGreaterThen(source, value, parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static int IsGreaterOrEqualThan(int source, int value, [InvokerParameterName] string parameterName)
        {
            if (source < value)
            {
                Throw.ArgumentShouldBeGreaterOrEqualThen(source, value, parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static int IsSmallerThan(int source, int value, [InvokerParameterName] string parameterName)
        {
            if (source >= value)
            {
                Throw.ArgumentShouldBeSmallerThen(source, value, parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static int IsSmallerOrEqualThan(int source, int value, [InvokerParameterName] string parameterName)
        {
            if (source > value)
            {
                Throw.ArgumentShouldBeSmallerOrEqualThen(source, value, parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static IEnumerable IsNotEmpty([NoEnumeration] IEnumerable source, [InvokerParameterName] string parameterName)
        {
            if (source.IsNull())
            {
                Throw.ArgumentShouldNotBeNull(parameterName);
            }

            if (source.IsEmpty())
            {
                Throw.ArgumentShouldNotBeEmpty(parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static T HasValue<T>(T source, [InvokerParameterName] string parameterName) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(source, default))
            {
                Throw.ArgumentShouldNotBeDefault(parameterName);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static T IsTrue<T>(T source, [AssertionCondition(AssertionConditionType.IS_TRUE)]
                                  bool condition, [InvokerParameterName] string parameterName, string errorMessage)
        {
            if (!condition)
            {
                Throw.ArgumentOutOfRangeException(source, parameterName, errorMessage);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static T IsFalse<T>(T source, [AssertionCondition(AssertionConditionType.IS_FALSE)]
                                   bool condition, [InvokerParameterName] string parameterName, string errorMessage)
        {
            if (condition)
            {
                Throw.ArgumentOutOfRangeException(source, parameterName, errorMessage);
            }

            return source;
        }

        [DebuggerStepThrough]
        [PublicAPI]
        [AssertionMethod]
        public static DateTime IsBefore(DateTime source, DateTime end, [InvokerParameterName] string parameterName)
        {
            if (source.Ticks >= end.Ticks)
            {
                Throw.ArgumentShouldBeBefore(source, end, parameterName);
            }

            return source;
        }
    }
}