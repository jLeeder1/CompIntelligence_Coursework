using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.solutionEveluation
{
    public interface ISolutionEvaluator
    {
        double GetCostOfSolution(List<CutRecipe> cutRecipes);
    }
}