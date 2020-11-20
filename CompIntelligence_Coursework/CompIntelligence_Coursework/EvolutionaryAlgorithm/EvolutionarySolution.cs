using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class EvolutionarySolution : ISolutionFinderStrategy
    {
        private readonly IOrderItems pieceLengthToQuantityLookup;
        private readonly IStockItems stockLengthToCostLookup;
        private readonly IRandomSolutionGenerator randomSolutionGenerator;

        // Populations
        private List<Solution> parentPopulation;
        private List<Solution> offspringPopulation;

        public EvolutionarySolution(IOrderItems pieceLengthToQuantityLookup, IStockItems stockLengthToCostLookup, IRandomSolutionGenerator randomSolutionGenerator)
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
            this.randomSolutionGenerator = randomSolutionGenerator;

            parentPopulation = new List<Solution>();
            offspringPopulation = new List<Solution>();
        }

        public Dictionary<int, Solution> FindSolutions()
        {
            parentPopulation = randomSolutionGenerator.GeneratePopulationOfRandomSolutions(GenericConstants.SIZE_OF_POPULATION);

            return null;
        }

        public void ClearSolutions()
        {
            throw new NotImplementedException();
        }
    }
}
