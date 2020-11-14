using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.PSO;

namespace CompIntelligence_Coursework.Helpers
{
    public class SolutionStrategyFactory : ISolutionStrategyFactory
    {
        private readonly IPieceLengthToQuantityLookup pieceLengthToQuantityLookup;
        private readonly IStockLengthToCostLookup stockLengthToCostLookup;

        public SolutionStrategyFactory(IPieceLengthToQuantityLookup pieceLengthToQuantityLookup, IStockLengthToCostLookup stockLengthToCostLookup)
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
        }

        public ISolutionFinderStrategy GetSolutionFinderStrategy(SolutionStrategyTypes solutionStrategyTypes)
        {
            ISolutionFinderStrategy solutionFinderStrategy = null;
            switch (solutionStrategyTypes)
            {
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
