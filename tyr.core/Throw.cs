using System;
using tyr.Core.Extensions;
using tyr.Core.Properties;

namespace tyr.Core
{
    internal static class Throw
    {
        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldNotBeNull(string parameterName)
        {
            throw new ArgumentNullException(parameterName);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldNotBeEmpty(string parameterName)
        {
            throw new ArgumentException(parameterName, Resources.ParameterShouldNotBeNullOrEmpty.With(parameterName));
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldBeBetween<T>(T value, T minValue, T maxValue, string parameterName)
        {
            var exceptionMessage = Resources.ParameterShouldBeBetween.With(parameterName, minValue.Stringify(),
                                                                           maxValue.Stringify(), value);
            throw new ArgumentOutOfRangeException(parameterName, value, exceptionMessage);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentOutOfRangeException<T>(T value, string parameterName, string errorMessage)
        {
            throw new ArgumentOutOfRangeException(parameterName, value, errorMessage);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldBeGreaterThen(int value, int otherValue, string parameterName)
        {
            var exceptionMessage = Resources.ParameterShouldBeGreaterThen.With(parameterName, otherValue, value);
            throw new ArgumentOutOfRangeException(parameterName, value, exceptionMessage);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldBeGreaterOrEqualThen(int value, int otherValue, string parameterName)
        {
            var exceptionMessage = Resources.ParameterShouldBeGreaterThen.With(parameterName, otherValue, value);
            throw new ArgumentOutOfRangeException(parameterName, value, exceptionMessage);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldBeSmallerThen(int value, int otherValue, string parameterName)
        {
            var exceptionMessage = Resources.ParameterShouldBeSmallerThen.With(parameterName, otherValue, value);
            throw new ArgumentOutOfRangeException(parameterName, value, exceptionMessage);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldBeSmallerOrEqualThen(int value, int otherValue, string parameterName)
        {
            var exceptionMessage = Resources.ParameterShouldBeSmallerOrEqualThen.With(parameterName, otherValue, value);
            throw new ArgumentOutOfRangeException(parameterName, value, exceptionMessage);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldBeBefore(DateTime value, DateTime otherValue, string parameterName)
        {
            var exceptionMessage = Resources.DateTimeParameterShouldBeSmallerThen.With(parameterName, otherValue, value);
            throw new ArgumentOutOfRangeException(parameterName, value, exceptionMessage);
        }

        [ContractAnnotation("=> halt")]
        public static void ArgumentShouldNotBeDefault(string parameterName)
        {
            throw new ArgumentException(parameterName, Resources.ParameterShouldNotBeDefault.With(parameterName));
        }

        [ContractAnnotation("=> halt")]
        public static void ParameterShouldNotContainNullElements(string parameterName)
        {
            throw new ArgumentException(parameterName, Resources.ParameterShouldNotContainNullElements.With(parameterName));
        }
    }
}