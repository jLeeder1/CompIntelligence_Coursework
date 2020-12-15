using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.solutionEveluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class EvolutionarySolution : ISolutionFinderStrategy
    {
        private readonly IRandomSolutionGenerator randomSolutionGenerator;
        private readonly IParentSelection parentSelection;
        private readonly IRecombination recombination;
        private readonly IBestSolutionFinder bestSolutionFinder;
        private readonly IMutation mutation;
        private readonly ISolutionEvaluator solutionEvaluator;
        private readonly IAdptiveChanceAdjuster adptiveChanceAdjuster;

        // Solutions
        private Dictionary<int, Solution> solutions;

        // Populations
        private List<Solution> parentPopulation;
        private List<Solution> offspringPopulation;

        public EvolutionarySolution(
            IRandomSolutionGenerator randomSolutionGenerator,
            IParentSelection parentSelection,
            IRecombination recombination,
            IBestSolutionFinder bestSolutionFinder,
            IMutation mutation,
            ISolutionEvaluator solutionEvaluator,
            IAdptiveChanceAdjuster adptiveChanceAdjuster
            )
        {
            this.randomSolutionGenerator = randomSolutionGenerator;
            this.parentSelection = parentSelection;
            this.recombination = recombination;
            this.bestSolutionFinder = bestSolutionFinder;
            this.mutation = mutation;
            this.solutionEvaluator = solutionEvaluator;
            this.adptiveChanceAdjuster = adptiveChanceAdjuster;

            solutions = new Dictionary<int, Solution>();

            parentPopulation = new List<Solution>();
            offspringPopulation = new List<Solution>();
        }

        public Dictionary<int, Solution> FindSolutions(List<Solution> initialPopulation = null)
        {
            parentPopulation.Clear();

            if(initialPopulation == null)
            {
                parentPopulation = randomSolutionGenerator.GeneratePopulationOfRandomSolutions(GenericConstants.SIZE_OF_POPULATION);
            }
            else
            {
                parentPopulation.AddRange(initialPopulation);
            }
            
            for(int generationNum = 0; generationNum < GenericConstants.NUMBER_OF_ITERATIONS; generationNum++)
            {
                Random random = new Random();
                List<Solution> potentialParentPool = parentSelection.GetParentPopulation(parentPopulation);

                // Generate an offspring population through recombination
                while (offspringPopulation.Count < parentPopulation.Count)
                {
                    Solution parentOne = potentialParentPool.ElementAt(random.Next(0, potentialParentPool.Count - 1));
                    Solution parentTwo = potentialParentPool.ElementAt(random.Next(0, potentialParentPool.Count - 1));

                    offspringPopulation.AddRange(recombination.RecombineParents(parentOne, parentTwo));
                    //offspringPopulation.Add(parentOne);
                    //offspringPopulation.Add(parentTwo);
                }

                // For each offspring run mutation 
                foreach(Solution offspring in offspringPopulation)
                {
                    mutation.MutateSolution(offspring);
                }

                // Find best solution in the generation and repeat
                solutions.Add(generationNum, bestSolutionFinder.GetBestSolutionInGeneration(offspringPopulation));

                if (EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES)
                {
                    adptiveChanceAdjuster.AdjustMutationRecombinationChances(recombination.SumOfCostOfRecombinedIndividuals, mutation.SumOfCostOfMutatedIndividuals);
                    ResetSumValues();
                }

                ResetPopulations();
            }

            return solutions;
        }

        public void ClearSolutions()
        {
            solutions.Clear();
        }

        private void ResetPopulations()
        {
            parentPopulation.Clear();
            parentPopulation.AddRange(offspringPopulation);
            offspringPopulation.Clear();
        }

        private void ResetSumValues()
        {
            recombination.SumOfCostOfRecombinedIndividuals = 0;
            mutation.SumOfCostOfMutatedIndividuals = 0;
        }
    }
}
