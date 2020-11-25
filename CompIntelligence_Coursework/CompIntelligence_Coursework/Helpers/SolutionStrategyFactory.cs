using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.PSO;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.RandomSolutions;

namespace CompIntelligence_Coursework.Helpers
{
    public class SolutionStrategyFactory : ISolutionStrategyFactory
    {
        private readonly IOrder order;
        private readonly IStockList stockList;
        private readonly IRandomSolutionGenerator randomSolutionGenerator;
        private readonly IParentSelection parentSelection;
        private readonly IRecombination recombination;
        private readonly IBestSolutionFinder bestSolutionFinder;

        public SolutionStrategyFactory(
            IOrder order,
            IStockList stockList,
            IRandomSolutionGenerator randomSolutionGenerator,
            IParentSelection parentSelection,
            IRecombination recombination,
            IBestSolutionFinder bestSolutionFinder
            )
        {
            this.order = order;
            this.stockList = stockList;
            this.randomSolutionGenerator = randomSolutionGenerator;
            this.parentSelection = parentSelection;
            this.recombination = recombination;
            this.bestSolutionFinder = bestSolutionFinder;
        }

        public ISolutionFinderStrategy GetSolutionFinderStrategy(SolutionStrategyTypes solutionStrategyTypes)
        {
            ISolutionFinderStrategy solutionFinderStrategy;
            switch (solutionStrategyTypes)
            {
                case SolutionStrategyTypes.RandomSolutionStrategy:
                    solutionFinderStrategy = new RandomSolution(randomSolutionGenerator);
                    break;
                case SolutionStrategyTypes.EVOSolutionStrategy:
                    solutionFinderStrategy = new EvolutionarySolution(order, stockList, randomSolutionGenerator, parentSelection, recombination, bestSolutionFinder);
                    break;
                default:
                    solutionFinderStrategy = new PSOSolution(order, stockList);
                    break;
            }

            return solutionFinderStrategy;
        }
    }
}
