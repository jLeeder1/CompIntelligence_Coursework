﻿using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface ISolutionFinderStrategy
    {
        public Dictionary<int, Solution> FindSolutions();

        public void ClearSolutions();
    }
}
