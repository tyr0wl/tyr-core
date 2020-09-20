using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace tyr.Core.Threading
{
    public static class Async
    {
        public static Task Invoke(Action action)
        {
            return Task.Factory.StartNew(action, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default)
                       .ContinueWith(task =>
                       {
                           task.Exception?.Handle(ex =>
                           {
                               Trace.WriteLine("Exception occurred in async operation: " + ex);
                               return true;
                           });
                       }, TaskContinuationOptions.OnlyOnFaulted);
        }

        public static void Invoke(Action action, Action onComplete)
        {
            Invoke(action).ContinueWith(task => onComplete());
        }
    }
}