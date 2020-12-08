using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public interface IRecombination
    {
        double SumOfCostOfRecombinedIndividuals { get; set; }
        List<Solution> RecombineParents(Solution parentOne, Solution parentTwo);
    }
}