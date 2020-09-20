using System;
using System.Diagnostics;
using tyr.Core.Extensions;

namespace tyr.Core.Utilities
{
    public static class ExceptionMonster
    {
        public static bool EatTheException(Action action, string actionDescription)
        {
            return EatTheException(action, actionDescription, out _);
        }

        public static bool EatTheException<TExceptionType>(Action action, string actionDescription)
            where TExceptionType : Exception
        {
            return EatTheException(action, actionDescription, out TExceptionType _);
        }

        public static bool EatTheException(Action action, string actionDescription, out Exception ex)
        {
            return EatTheException<Exception>(action, actionDescription, out ex);
        }

        public static bool EatTheException<TExceptionType>(Action action, string actionDescription, out TExceptionType ex)
            where TExceptionType : Exception
        {
            EatTheException(() =>
            {
                action();
                return (object) null;
            }, actionDescription, out var success, out ex);
            return success;
        }

        public static T EatTheException<T>(Func<T> action, string actionDescription)
        {
            return EatTheException(action, actionDescription, out _, out _);
        }

        public static T EatTheException<T>(Func<T> action, string actionDescription, out bool success, out Exception ex)
        {
            return EatTheException<T, Exception>(action, actionDescription, out success, out ex);
        }

        public static TReturnType EatTheException<TReturnType, TExceptionType>(Func<TReturnType> action, string actionDescription, out bool success, out TExceptionType ex)
            where TExceptionType : Exception
        {
            ex = null;
            try
            {
                var result = action();
                success = true;
                return result;
            }
            catch (TExceptionType exception)
            {
                ex = exception;
                Trace.WriteLine("Error occurred while {0}: {1} ".With(actionDescription, ex));
            }

            success = false;
            return default;
        }
    }
}