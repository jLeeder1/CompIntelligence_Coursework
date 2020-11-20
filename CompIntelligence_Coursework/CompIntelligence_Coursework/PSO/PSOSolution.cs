using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.PSO
{
    public class PSOSolution : ISolutionFinderStrategy
    {
        private readonly IOrderItems pieceLengthToQuantityLookup;
        private readonly IStockItems stockLengthToCostLookup;

        public PSOSolution(IOrderItems pieceLengthToQuantityLookup, IStockItems stockLengthToCostLookup)
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
        }

        public Dictionary<int, Solution> FindSolutions()
        {
            Console.WriteLine("PSO running");
            return null;
        }

        public void ClearSolutions()
        {
            throw new NotImplementedException();
        }
    }
}
