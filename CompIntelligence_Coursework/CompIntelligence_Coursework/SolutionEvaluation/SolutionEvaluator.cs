using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.solutionEveluation
{
    public class SolutionEvaluator : ISolutionEvaluator
    {
        public double GetCostOfSolution(Solution solution)
        {
            double totalCost = 0.0;

            foreach(Activity activity in solution.Activities)
            {
                totalCost += activity.StockItemUsed.StockLengthCost;
            }

            return totalCost;
        }
    }
}
