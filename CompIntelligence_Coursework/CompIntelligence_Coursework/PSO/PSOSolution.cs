using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.PSO
{
    public class PSOSolution : ISolutionFinderStrategy
    {
        private readonly IOrder pieceLengthToQuantityLookup;
        private readonly IStockList stockLengthToCostLookup;

        public PSOSolution(IOrder pieceLengthToQuantityLookup, IStockList stockLengthToCostLookup)
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
