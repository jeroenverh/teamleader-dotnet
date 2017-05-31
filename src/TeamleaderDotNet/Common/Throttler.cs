using System;
using System.Threading.Tasks;

namespace TeamleaderDotNet.Common
{
    public static class Throttler
    {
        private static DateTime s_timeOfFirstCall;
        private static int s_currentNumberOfCalls;
        
        // according to the teamleader documentation only 5 request per 25 seconds are allowed
        private const int MaxNumberOfCalls = 5;
        private static readonly TimeSpan s_throttlingDuration = TimeSpan.FromSeconds(25);

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
                Task.Delay(TimeSpan.FromSeconds(1000));
            }
            s_timeOfFirstCall = DateTime.Now;
            s_currentNumberOfCalls = 1;
            return task.Invoke();
        }
    }
}
