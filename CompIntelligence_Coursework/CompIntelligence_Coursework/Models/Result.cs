﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Models
{
    public class Result : Solution
    {
        public int GenerationResultFoundIn { get; set; }
        public TimeSpan TimeTakenToFindResult { get; set; }
        public int FailedMutationCount { get; set; }
        public int FailedRecombinationCount { get; set; }
        public double AverageCostOfGeneration { get; set; }
    }
}
