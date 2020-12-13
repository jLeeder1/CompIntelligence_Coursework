using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Helpers
{
    public static class FailedSolutionsCounter
    {
        public static int FailedRecombinationCounter { get; set; }

        public static void ResetCounters()
        {
            FailedRecombinationCounter = 0;
        }
    }
}
