using System;
using System.Diagnostics;

namespace CompIntelligence_Coursework.Helpers
{
    public static class ExecutionTimer
    {
        private static readonly Stopwatch stopwatch = new Stopwatch();

        public static void StartTimer()
        {
            stopwatch.Restart();
            stopwatch.Start();
        }

        public static TimeSpan GetExecutionTime()
        {
            stopwatch.Stop();
            return stopwatch.Elapsed;
        }
    }
}
