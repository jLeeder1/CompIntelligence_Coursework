using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class Mutation : IMutation
    {
        public double SumOfCostOfMutatedIndividuals { get; set; }

        private readonly ISolutionValidation solutionValidation;
        private readonly ISolutionEvaluator solutionEvaluator;

        public Mutation(ISolutionValidation solutionValidation, ISolutionEvaluator solutionEvaluator)
        {
            this.solutionValidation = solutionValidation;
            this.solutionEvaluator = solutionEvaluator;
        }

        public void MutateSolution(Solution solution)
        {
            Random random = new Random();

            if(random.NextDouble() < EvolutionaryAlgorithmConstants.MUTATION_CHANCE)
            {
                return;
            }

            List<Activity> copyOfActivities = new List<Activity>(solution.Activities);

            Mutate(solution);

            if (solutionValidation.IsValidSolution(solution))
            {
                double mutatedSolutionCost = solutionEvaluator.GetCostOfSolution(solution);
                solution.SolutionCost = mutatedSolutionCost;
                SumOfCostOfMutatedIndividuals += mutatedSolutionCost;
                return;
            }

            solution.Activities.Clear();
            solution.Activities.AddRange(copyOfActivities);
        }

        private void Mutate(Solution solution)
        {
            List<Activity> activitiesWithOffcuts = GetActivitiesWithOffcuts(solution);

            if(activitiesWithOffcuts.Count == 0) { return; }

            Random random = new Random();
            Activity activityToMutate = activitiesWithOffcuts.ElementAt(random.Next(0, activitiesWithOffcuts.Count - 1));
            
            foreach (Activity activity in solution.Activities)
            {
                if (activity.Equals(activityToMutate))
                {
                    continue;
                }

                int elementToMove = random.Next(0, activityToMutate.PositionsToCutAt.Count);
                double cutToMove = activityToMutate.PositionsToCutAt.ElementAt(elementToMove);

                if(cutToMove <= activity.Offcut)
                {
                    activity.PositionsToCutAt.Add(cutToMove);
                    activity.Offcut -= cutToMove;
                    activityToMutate.PositionsToCutAt.RemoveAt(elementToMove);
                    activityToMutate.Offcut += cutToMove;
                    break;
                }
            }

            //solution.Activities.RemoveAll(activity => activity.PositionsToCutAt.Count == 0);
        }

        private List<Activity> GetActivitiesWithOffcuts(Solution solution)
        {
            List<Activity> activitiesWithOffcuts = new List<Activity>();
            solution.Activities.RemoveAll(activity => activity.PositionsToCutAt.Count == 0); // This is duplicated in the method above, doesn't seem to remove all of the gaps when it is above?

            foreach (Activity activity in solution.Activities)
            {
                if (activity.Offcut > 0 && activity.PositionsToCutAt.Count > 0)
                {
                    activitiesWithOffcuts.Add(activity);
                }
            }

            return activitiesWithOffcuts;
        }
    }
}