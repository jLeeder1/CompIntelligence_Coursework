using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class Recombination : IRecombination
    {
        private readonly IOrder order;
        private readonly IStockList stockList;
        private readonly ISolutionEvaluator solutionEvaluator;
        private readonly ISolutionValidation solutionValidation;

        public Recombination(IOrder order, IStockList stockList, ISolutionEvaluator solutionEvaluator, ISolutionValidation solutionValidation)
        {
            this.order = order;
            this.stockList = stockList;
            this.solutionEvaluator = solutionEvaluator;
            this.solutionValidation = solutionValidation;
        }

        public List<Solution> RecombineParents(Solution parentOne, Solution parentTwo)
        {
            List<Solution> offspring = new List<Solution>();
            /*
            offspring.AddRange(RecombineParentsToFormOneChild(parentOne, parentTwo));
            offspring.AddRange(RecombineParentsToFormOneChild(parentTwo, parentOne));
            

            offspring.AddRange(RecombineParentsToFormOneChildUsingShuffling(parentOne, parentTwo));
            offspring.AddRange(RecombineParentsToFormOneChildUsingShuffling(parentTwo, parentOne));
            return offspring;
            */

            return null;
        }
        /*
        private List<Solution> RecombineParentsToFormOneChild(Solution parentOne, Solution parentTwo)
        {
            Random random = new Random();
            int parentOneElementAmountBoundary = random.Next(0, parentOne.Activities.Count - 1);

            List<CutRecipe> newCutRecipes = new List<CutRecipe>();

            for (int index = 0; index <= parentOneElementAmountBoundary; index++)
            {
                newCutRecipes.Add(parentOne.Activities.ElementAt(index));
            }

            for (int index = parentOneElementAmountBoundary + 1; index <= parentTwo.Activities.Count - 1; index++)
            {
                newCutRecipes.Add(parentTwo.Activities.ElementAt(index));
            }

            Solution offspring = new Solution
            {
                Activities = newCutRecipes,
                SolutionCost = solutionEvaluator.GetCostOfSolution(newCutRecipes)
            };

            if (!solutionValidation.IsValidSolution(offspring, order, stockList) && UseElitism(parentOne, parentTwo, offspring))
            {
                return new List<Solution>
                {
                    parentOne,
                    parentTwo
                };
            }

            return new List<Solution> { offspring };
        }

        // Much better than other method
        private List<Solution> RecombineParentsToFormOneChildUsingShuffling(Solution parentOne, Solution parentTwo)
        {
            List<CutRecipe> newCutRecipes = new List<CutRecipe>();

            for (int index = 0; index < parentOne.Activities.Count - 1; index += 2)
            {
                newCutRecipes.Add(parentOne.Activities.ElementAt(index));
            }

            for (int index = 1; index <parentTwo.Activities.Count - 1; index += 2)
            {
                newCutRecipes.Add(parentTwo.Activities.ElementAt(index));
            }

            Solution offspring = new Solution
            {
                Activities = newCutRecipes,
                SolutionCost = solutionEvaluator.GetCostOfSolution(newCutRecipes)
            };

            if (!solutionValidation.IsValidSolution(offspring, order, stockList))
            {
                return new List<Solution>
                {
                    parentOne,
                    parentTwo
                };
            }

            return new List<Solution> { offspring };
        }

        // Doesn't really work
        private bool UseElitism(Solution parentOne, Solution parentTwo, Solution offspring)
        {
            if(EvolutionaryAlgorithmConstants.IS_USING_ELITISM == true && offspring.SolutionCost < parentOne.SolutionCost || offspring.SolutionCost < parentTwo.SolutionCost)
            {
                return true;
            }

            return false;
        }
        */
    }
}
