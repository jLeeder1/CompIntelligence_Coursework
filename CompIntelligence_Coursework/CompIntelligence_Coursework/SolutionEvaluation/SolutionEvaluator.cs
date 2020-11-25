using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.solutionEveluation
{
    public class SolutionEvaluator : ISolutionEvaluator
    {
        public double GetCostOfSolution(List<CutRecipe> cutRecipes)
        {
            double totalCost = 0.0;

            foreach(CutRecipe cutRecipe in cutRecipes)
            {
                totalCost += cutRecipe.OriginalStockItemUsed.StockLengthCost;
            }

            return totalCost;
        }
    }
}
