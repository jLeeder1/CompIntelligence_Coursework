using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public interface IRecombination
    {
        List<Solution> RecombineParents(Solution parentOne, Solution parentTwo);
    }
}