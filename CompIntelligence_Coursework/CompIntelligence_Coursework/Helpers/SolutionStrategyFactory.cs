﻿using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.PSO;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.RandomSolutions;

namespace CompIntelligence_Coursework.Helpers
{
    public class SolutionStrategyFactory : ISolutionStrategyFactory
    {
        private readonly IPieceLengthToQuantityLookup pieceLengthToQuantityLookup;
        private readonly IStockLengthToCostLookup stockLengthToCostLookup;
        private readonly IRandomSolutionGenerator randomSolutionGenerator;

        public SolutionStrategyFactory(
            IPieceLengthToQuantityLookup pieceLengthToQuantityLookup, 
            IStockLengthToCostLookup stockLengthToCostLookup, 
            IRandomSolutionGenerator randomSolutionGenerator
            )
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
            this.randomSolutionGenerator = randomSolutionGenerator;
        }

        public ISolutionFinderStrategy GetSolutionFinderStrategy(SolutionStrategyTypes solutionStrategyTypes)
        {
            ISolutionFinderStrategy solutionFinderStrategy = null;
            switch (solutionStrategyTypes)
            {
                case SolutionStrategyTypes.RandomSolutionStrategy:
                    solutionFinderStrategy = new RandomSolution(randomSolutionGenerator);
                    break;
                case SolutionStrategyTypes.PSOSolutionStrategy:
                    solutionFinderStrategy = new PSOSolution(pieceLengthToQuantityLookup, stockLengthToCostLookup);
                    break;
                default:
                    solutionFinderStrategy = new PSOSolution(pieceLengthToQuantityLookup, stockLengthToCostLookup);
                    break;
            }

            return solutionFinderStrategy;
        }
    }
}
