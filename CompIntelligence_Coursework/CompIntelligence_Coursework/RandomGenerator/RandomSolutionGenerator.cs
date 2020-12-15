using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompIntelligence_Coursework.RandomGenerator
{
    public class RandomSolutionGenerator : IRandomSolutionGenerator
    {
        private readonly IOrder order;
        private readonly IStockList stockList;
        private readonly ISolutionEvaluator solutionEvaluator;
        private readonly ISolutionValidation solutionValidation;
        private readonly IMaterialCutter materialCutter;

        public RandomSolutionGenerator(
            IOrder order,
            IStockList stockList,
            ISolutionEvaluator solutionEvaluator,
            ISolutionValidation solutionValidation,
            IMaterialCutter materialCutter
            )
        {
            this.order = order;
            this.stockList = stockList;
            this.solutionEvaluator = solutionEvaluator;
            this.solutionValidation = solutionValidation;
            this.materialCutter = materialCutter;
        }

        public Solution GenerateRandomSolution()
        {
            bool isValidSolutionFound = false;
            Solution solution;
            Random random = new Random();

            do
            {
                
                solution = new Solution();
                Dictionary<double, double> copyOfOrder = new Dictionary<double, double>(order.OrderItems);

                // not loving the use of goto but oh well
                KeepIterating:
                foreach (KeyValuePair<double, double> orderItem in order.OrderItems)
                {
                    if (copyOfOrder[orderItem.Key] <= 0)
                    {
                        continue;
                    }

                    StockItem stockItem = stockList.StockItemList.ElementAt(random.Next(0, stockList.StockItemList.Count));

                    double chance = random.NextDouble();

                    Activity activity = materialCutter.ProduceActivity(stockItem, orderItem.Key, orderItem.Value);
                    copyOfOrder[orderItem.Key] -= activity.PositionsToCutAt.Count;

                    var randomOrderItem = order.OrderItems.ElementAt(random.Next(0, order.OrderItems.Count));

                    if (copyOfOrder[randomOrderItem.Key] > 0 && activity.Offcut >= randomOrderItem.Key)
                    {
                        activity.PositionsToCutAt.Add(randomOrderItem.Key);
                        activity.Offcut -= randomOrderItem.Key;
                        copyOfOrder[randomOrderItem.Key]--;
                    }

                    solution.Activities.Add(activity);
                }

                foreach (KeyValuePair<double, double> checkCopyOfOrder in copyOfOrder)
                {
                    if(checkCopyOfOrder.Value > 0)
                    {
                        goto KeepIterating;
                    }
                }

                if (solutionValidation.IsValidSolution(solution))
                {
                    solution.SolutionCost = solutionEvaluator.GetCostOfSolution(solution);
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
