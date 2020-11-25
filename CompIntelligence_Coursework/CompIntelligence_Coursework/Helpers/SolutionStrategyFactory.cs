using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.PSO;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.RandomSolutions;

namespace CompIntelligence_Coursework.Helpers
{
    public class SolutionStrategyFactory : ISolutionStrategyFactory
    {
        private readonly IOrder pieceLengthToQuantityLookup;
        private readonly IStockList stockLengthToCostLookup;
        private readonly IRandomSolutionGenerator randomSolutionGenerator;

        public SolutionStrategyFactory(
            IOrder pieceLengthToQuantityLookup, 
            IStockList stockLengthToCostLookup, 
            IRandomSolutionGenerator randomSolutionGenerator
            )
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
            this.randomSolutionGenerator = randomSolutionGenerator;
        }

        public ISolutionFinderStrategy GetSolutionFinderStrategy(SolutionStrategyTypes solutionStrategyTypes)
        {
            ISolutionFinderStrategy solutionFinderStrategy;
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
