using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface ISolutionFinderStrategy
    {
        public Dictionary<int, Solution> FindSolutions(int numberOfRuns, PieceLengthToQuantityLookup pieceLengthToQuantityLookup, StockLengthToCostLookup stockLengthToCostLookup);
    }
}
