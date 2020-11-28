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
        private readonly ISolutionEvaluator solutionEvaluator;
        private readonly ISolutionValidation solutionValidation;

        public Mutation(ISolutionEvaluator solutionEvaluator, ISolutionValidation solutionValidation)
        {
            this.solutionEvaluator = solutionEvaluator;
            this.solutionValidation = solutionValidation;
        }

        public void MutateSolution(Solution solution)
        {
            Random random = new Random();

            if(random.NextDouble() < EvolutionaryAlgorithmConstants.MUTATION_CHANCE)
            {
                return;
            }

            Mutate(solution);
        }

        private void Mutate(Solution solution)
        {
            List<Activity> activitiesWithOffcuts = GetActivitiesWithOffcuts(solution);

            if(activitiesWithOffcuts.Count == 0) { return; }

            Random random = new Random();
            Activity activityToMutate = activitiesWithOffcuts.ElementAt(random.Next(0, activitiesWithOffcuts.Count - 1));

            if(activityToMutate.Offcut > activityToMutate.StockItemUsed.StockLength)
            {
                int x = 0;
            }

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

            solution.Activities.RemoveAll(activity => activity.Offcut > 0 && activity.PositionsToCutAt.Count == 0);
        }

        private List<Activity> GetActivitiesWithOffcuts(Solution solution)
        {
            List<Activity> activitiesWithOffcuts = new List<Activity>();

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

/*
            foreach (Activity ac in solution.Activities)
            {
                if (ac.Offcut > 0 && ac.PositionsToCutAt.Count == 0)
                {
                    if (Object.ReferenceEquals(ac, activityToMutate))
                    {
                        Console.WriteLine("Test");
                    }
                    Console.WriteLine("Test");
                }
            }
            */