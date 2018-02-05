using System;
using System.Threading.Tasks;

namespace TeamleaderDotNet.Common
{
    public static class Throttler
    {
        private static DateTime s_timeOfFirstCall;
        private static int s_currentNumberOfCalls;
        
        private const int MaxNumberOfCalls = 25;
        private static readonly TimeSpan s_throttlingDuration = TimeSpan.FromSeconds(5);

        public static T ExecuteTask<T>(Func<T> task)
        {
            var endOfPeriod = s_timeOfFirstCall.Add(s_throttlingDuration);
            while (endOfPeriod >= DateTime.Now)
            {
                if (s_currentNumberOfCalls < MaxNumberOfCalls)
                {
                    s_currentNumberOfCalls++;
                    var result = task.Invoke();
                    return result;
                }
                Task.Delay(TimeSpan.FromSeconds(5));
            }
            s_timeOfFirstCall = DateTime.Now;
            s_currentNumberOfCalls = 1;
            return task.Invoke();
        }
    }
}
