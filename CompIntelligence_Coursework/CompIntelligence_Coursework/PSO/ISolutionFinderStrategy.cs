using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.PSO
{
    public interface ISolutionFinderStrategy
    {
        Dictionary<int, Solution> FindSolution();
    }
}