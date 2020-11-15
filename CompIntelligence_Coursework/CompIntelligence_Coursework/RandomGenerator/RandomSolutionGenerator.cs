using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.RandomGenerator
{
    public class RandomSolutionGenerator : IRandomSolutionGenerator
    {
        private readonly IPieceLengthToQuantityLookup pieceLengthToQuantityLookup;
        private readonly IStockLengthToCostLookup stockLengthToCostLookup;
        private readonly ISolutionEvaluator solutionEvaluator;
        private readonly ISolutionValidation solutionValidation;

        public RandomSolutionGenerator(
            IPieceLengthToQuantityLookup pieceLengthToQuantityLookup,
            IStockLengthToCostLookup stockLengthToCostLookup,
            ISolutionEvaluator solutionEvaluator,
            ISolutionValidation solutionValidation
            )
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
            this.solutionEvaluator = solutionEvaluator;
            this.solutionValidation = solutionValidation;
        }

        public Solution GenerateRandomSolution()
        {
            bool isValidSolutionFound = false;
            Random random = new Random();
            Solution solution;

            do
            {
                solution = new Solution();

                foreach (KeyValuePair<double, double> stockList in stockLengthToCostLookup.LengthToCost)
                {
                    solution.LengthToQuantity[stockList.Key] = Math.Round(random.NextDouble() * GenericConstants.UPPER_BOUND_FOR_RANDOM_QUANTITY);
                }

                if (solutionValidation.IsValidSolution(solution, pieceLengthToQuantityLookup, stockLengthToCostLookup))
                {
                    solution.SolutionCost = solutionEvaluator.GetCostOfSolution(solution, stockLengthToCostLookup);
                    isValidSolutionFound = true;
                }

            } while (isValidSolutionFound == false);

            return solution;
        }

        public List<Solution> GeneratePopulationOfRandomSolutions(int sizeOfPopulation)
        {
            List<Solution> population = new List<Solution>();

            while (population.Count < sizeOfPopulation)
            {
                population.Add(GenerateRandomSolution());
            }

            return population;
        }
    }
}
