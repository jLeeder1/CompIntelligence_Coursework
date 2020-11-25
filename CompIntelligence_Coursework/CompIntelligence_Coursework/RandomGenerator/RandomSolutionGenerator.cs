using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            List<OrderItem> ordersFulfilled = new List<OrderItem>();

            do
            {
                Random random = new Random();
                solution = new Solution();
                ordersFulfilled.Clear();

                
               

                foreach (OrderItem orderItem in order.OrderItemsList)
                {
                    if (ordersFulfilled.Contains(orderItem))
                    {
                        continue;
                    }

                    StockItem stockItem = stockList.StockItemList.ElementAt(random.Next(0, stockList.StockItemList.Count));

                    double chance = random.NextDouble();

                    solution.CutRecipes.AddRange(materialCutter.CutMaterial(stockItem, orderItem, orderItem.QuantityOfPieceLength));
                    ordersFulfilled.Add(orderItem);
                }

                if (solutionValidation.IsValidSolution(solution, order, stockList))
                {
                    solution.SolutionCost = solutionEvaluator.GetCostOfSolution(solution.CutRecipes);
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
