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
        public double SumOfCostOfRecombinedIndividuals { get; set; }

        private readonly ISolutionEvaluator solutionEvaluator;
        private readonly ISolutionValidation solutionValidation;

        public Recombination(ISolutionEvaluator solutionEvaluator, ISolutionValidation solutionValidation)
        {
            this.solutionEvaluator = solutionEvaluator;
            this.solutionValidation = solutionValidation;
        }

        public List<Solution> RecombineParents(Solution parentOne, Solution parentTwo)
        {
            Random random = new Random();

            if (random.NextDouble() < EvolutionaryAlgorithmConstants.RECOMBINATION_CHANCE)
            {
                return new List<Solution>
                {
                    parentOne,
                    parentTwo
                };
            }

            return new List<Solution>
            {
                RecombineParentsToFormOneChild(parentOne, parentTwo),
                RecombineParentsToFormOneChild(parentTwo, parentOne)
            };
        }
       
        private Solution RecombineParentsToFormOneChild(Solution parentOne, Solution parentTwo)
        {
            int numberOfActivitiesParentOne = parentOne.Activities.Count;
            int numberOfActivitiesParentTwo = parentTwo.Activities.Count;

            int iteationLimit = Math.Min(numberOfActivitiesParentOne, numberOfActivitiesParentTwo);

            Solution offspring = new Solution();
            Random random = new Random();

            for (int index = 0; index < iteationLimit; index++)
            {
                // Take from parent one
                if(random.NextDouble() > 0.5)
                {
                    offspring.Activities.Add(parentOne.Activities.ElementAt(index));
                }
                // Take from parent two
                else
                {
                    offspring.Activities.Add(parentOne.Activities.ElementAt(index));
                }
            }

            if (solutionValidation.IsValidSolution(offspring))
            {
                double recombinedSolutionCost = solutionEvaluator.GetCostOfSolution(offspring);
                offspring.SolutionCost = recombinedSolutionCost;
                SumOfCostOfRecombinedIndividuals += recombinedSolutionCost;
                return offspring;
            }

            if(random.NextDouble() > 0.5)
            {
                return parentOne;
            }

            return parentTwo;
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
    }
}
