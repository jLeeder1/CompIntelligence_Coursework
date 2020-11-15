using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.solutionEveluation
{
    public class SolutionEvaluator : ISolutionEvaluator
    {
        public double GetCostOfSolution(Solution solution, IStockLengthToCostLookup stockLengthToCostLookup)
        {
            double totalCost = 0.0;

            foreach (KeyValuePair<double, double> currentSolution in solution.LengthToQuantity)
            {
                totalCost += GetCostOfOneStockLengthBasedOnQuantity(stockLengthToCostLookup, currentSolution.Key, currentSolution.Value);
            }

            return totalCost;
        }

        private double GetCostOfOneStockLengthBasedOnQuantity(IStockLengthToCostLookup stockLengthToCostLookup, double stockLenth, double quantityOfStock)
        {
            double costOfOneLength = stockLengthToCostLookup.LengthToCost[stockLenth];
            return costOfOneLength * quantityOfStock;
        }
    }
}
