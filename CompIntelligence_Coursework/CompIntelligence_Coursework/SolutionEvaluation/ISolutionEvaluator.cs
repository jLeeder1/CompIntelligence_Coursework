using CompIntelligence_Coursework.Models;

namespace CompIntelligence_Coursework.solutionEveluation
{
    public interface ISolutionEvaluator
    {
        double GetCostOfSolution(Solution solution, IStockItems stockLengthToCostLookup);
    }
}