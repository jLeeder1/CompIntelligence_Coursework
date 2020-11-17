using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.RandomSolution
{
    public class RandomSolution : ISolutionFinderStrategy
    {
        private readonly IPieceLengthToQuantityLookup pieceLengthToQuantityLookup;
        private readonly IStockLengthToCostLookup stockLengthToCostLookup;
        private readonly IRandomSolutionGenerator randomSolutionGenerator;

        private Dictionary<int, Solution> solutions;

        public RandomSolution(
            IPieceLengthToQuantityLookup pieceLengthToQuantityLookup, 
            IStockLengthToCostLookup stockLengthToCostLookup, 
            IRandomSolutionGenerator randomSolutionGenerator
        )
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
            this.randomSolutionGenerator = randomSolutionGenerator;

            solutions = new Dictionary<int, Solution>();
        }

        public Dictionary<int, Solution> FindSolutions()
        {
            for(int index = 0; index < GenericConstants.NUMBER_OF_ITERATIONS; index++)
            {
                Solution solution = randomSolutionGenerator.GenerateRandomSolution();
            }

            return solutions;
        }

        public void ClearSolutions()
        {
            solutions.Clear();
        }
    }
}
