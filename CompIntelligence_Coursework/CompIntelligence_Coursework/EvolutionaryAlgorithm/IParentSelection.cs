using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.RandomGenerator
{
    public interface IParentSelection
    {
        List<Solution> GetParentPopulation(List<Solution> currentParentPopulation);
    }
}