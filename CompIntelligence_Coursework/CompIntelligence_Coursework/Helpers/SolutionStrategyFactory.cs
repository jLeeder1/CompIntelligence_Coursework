using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.RandomSolutions;
using CompIntelligence_Coursework.solutionEveluation;

namespace CompIntelligence_Coursework.Helpers
{
    public class SolutionStrategyFactory : ISolutionStrategyFactory
    {
        private readonly IRandomSolutionGenerator randomSolutionGenerator;
        private readonly IParentSelection parentSelection;
        private readonly IRecombination recombination;
        private readonly IBestSolutionFinder bestSolutionFinder;
        private readonly IMutation mutation;
        private readonly ISolutionEvaluator solutionEvaluator;

        public SolutionStrategyFactory(
            IRandomSolutionGenerator randomSolutionGenerator,
            IParentSelection parentSelection,
            IRecombination recombination,
            IBestSolutionFinder bestSolutionFinder,
            IMutation mutation,
            ISolutionEvaluator solutionEvaluator
            )
        {
            this.randomSolutionGenerator = randomSolutionGenerator;
            this.parentSelection = parentSelection;
            this.recombination = recombination;
            this.bestSolutionFinder = bestSolutionFinder;
            this.mutation = mutation;
            this.solutionEvaluator = solutionEvaluator;
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
                    solutionFinderStrategy = new EvolutionarySolution(randomSolutionGenerator, parentSelection, recombination, bestSolutionFinder, mutation, solutionEvaluator);
                    break;
                default:
                    solutionFinderStrategy = new RandomSolution(randomSolutionGenerator);
                    break;
            }

            return solutionFinderStrategy;
        }
    }
}
