using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.FileReader;
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
        private readonly IAdptiveChanceAdjuster adptiveChanceAdjuster;
        private readonly ICSVFileWriter csvFileWriter;

        public SolutionStrategyFactory(
            IRandomSolutionGenerator randomSolutionGenerator,
            IParentSelection parentSelection,
            IRecombination recombination,
            IBestSolutionFinder bestSolutionFinder,
            IMutation mutation,
            ISolutionEvaluator solutionEvaluator,
            IAdptiveChanceAdjuster adptiveChanceAdjuster,
            ICSVFileWriter csvFileWriter
            )
        {
            this.randomSolutionGenerator = randomSolutionGenerator;
            this.parentSelection = parentSelection;
            this.recombination = recombination;
            this.bestSolutionFinder = bestSolutionFinder;
            this.mutation = mutation;
            this.solutionEvaluator = solutionEvaluator;
            this.adptiveChanceAdjuster = adptiveChanceAdjuster;
            this.csvFileWriter = csvFileWriter;
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
                    solutionFinderStrategy = new EvolutionarySolution(randomSolutionGenerator, parentSelection, recombination, bestSolutionFinder, mutation, solutionEvaluator, adptiveChanceAdjuster);
                    break;
                case SolutionStrategyTypes.GenerateTestResults:
                    solutionFinderStrategy = new ResultsCreator(bestSolutionFinder, new EvolutionarySolution(randomSolutionGenerator, parentSelection, recombination, bestSolutionFinder, mutation, solutionEvaluator, adptiveChanceAdjuster), csvFileWriter);
                    break;
                default:
                    solutionFinderStrategy = new RandomSolution(randomSolutionGenerator);
                    break;
            }

            return solutionFinderStrategy;
        }
    }
}
