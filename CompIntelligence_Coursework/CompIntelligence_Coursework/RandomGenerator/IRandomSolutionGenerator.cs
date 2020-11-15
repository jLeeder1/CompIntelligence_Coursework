using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.RandomGenerator
{
    public interface IRandomSolutionGenerator
    {
        Solution GenerateRandomSolution();

        List<Solution> GeneratePopulationOfRandomSolutions(int sizeOfPopulation);
    }
}