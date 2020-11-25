using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Helpers
{
    public interface IBestSolutionFinder
    {
        Solution GetBestSolutionInGeneration(List<Solution> solutions);
    }
}