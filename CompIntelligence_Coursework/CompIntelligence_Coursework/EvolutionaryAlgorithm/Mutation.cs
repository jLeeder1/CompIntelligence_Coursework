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
        private readonly IStockList stockList;

        public Mutation(ISolutionValidation solutionValidation, ISolutionEvaluator solutionEvaluator, IStockList stockList)
        {
            this.solutionValidation = solutionValidation;
            this.solutionEvaluator = solutionEvaluator;
            this.stockList = stockList;
        }

        public void MutateSolution(Solution solution)
        {
            Random random = new Random();

            if(random.NextDouble() < EvolutionaryAlgorithmConstants.MUTATION_CHANCE)
            {
                return;
            }

            
            if (IsGoingToAddActivityOrMoveCut() == true)
            {
                Mutate(solution);
            }
            else
            {
                MutateByAddingActivity(solution);
            }
            
            //solution.Activities.RemoveAll(activity => activity.PositionsToCutAt.Count == 0);
            //MutateByAddingActivity(solution);
            solution.Activities.RemoveAll(activity => activity.PositionsToCutAt.Count == 0);
            
            
            double mutatedSolutionCost = solutionEvaluator.GetCostOfSolution(solution);
            solution.SolutionCost = mutatedSolutionCost;
            SumOfCostOfMutatedIndividuals += mutatedSolutionCost;
        }

        // Mutates by removing a cut and adding to another existing activity
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

        // Mutates by removing cut and adding it to a new activity
        private void MutateByAddingActivity(Solution solution)
        {
            Random random = new Random();
            Activity activityToMutate = solution.Activities.ElementAt(random.Next(solution.Activities.Count));

            if(activityToMutate.PositionsToCutAt.Count == 0)
            {
                return;
            }

            double cutToRemove = activityToMutate.PositionsToCutAt.ElementAt(random.Next(activityToMutate.PositionsToCutAt.Count));
            activityToMutate.PositionsToCutAt.Remove(cutToRemove);
            
            if(activityToMutate.PositionsToCutAt.Count == 0)
            {
                solution.Activities.Remove(activityToMutate);
            }
            else
            {
                activityToMutate.Offcut += cutToRemove;
            }

            List<StockItem> viableStockItems = GenerateListOfViableStockItems(cutToRemove);
            StockItem stockItemToUse = viableStockItems.ElementAt(random.Next(0, viableStockItems.Count));

            solution.Activities.Add(new Activity
            {
                StockItemUsed = stockItemToUse,
                PositionsToCutAt = new List<double>()
                {
                    cutToRemove
                },
                Offcut = stockItemToUse.StockLength - cutToRemove
            });
        }

        private List<StockItem> GenerateListOfViableStockItems(double cutToRemove)
        {
            List<StockItem> viableStockItems = new List<StockItem>();

            foreach(StockItem stockItem in stockList.StockItemList)
            {
                if(stockItem.StockLength >= cutToRemove)
                {
                    viableStockItems.Add(stockItem);
                }
            }

            return viableStockItems;
        }

        private bool IsGoingToAddActivityOrMoveCut()
        {
            Random random = new Random();
            if(random.NextDouble() < 0.5)
            {
                return true;
            }

            return false;
        }
    }
}