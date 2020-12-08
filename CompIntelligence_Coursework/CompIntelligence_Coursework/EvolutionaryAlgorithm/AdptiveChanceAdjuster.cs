using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class AdptiveChanceAdjuster : IAdptiveChanceAdjuster
    {
        public void AdjustMutationRecombinationChances(double recombinationSum, double mutationSum)
        {
            if (recombinationSum > mutationSum)
            {
                EvolutionaryAlgorithmConstants.RECOMBINATION_CHANCE += EvolutionaryAlgorithmConstants.RECOMBINATION_CHANCE_ADJUST_VALUE;
                EvolutionaryAlgorithmConstants.MUTATION_CHANCE -= EvolutionaryAlgorithmConstants.MUTATION_CHANCE_ADJUST_VALUE;
                return;
            }

            EvolutionaryAlgorithmConstants.RECOMBINATION_CHANCE -= EvolutionaryAlgorithmConstants.RECOMBINATION_CHANCE_ADJUST_VALUE;
            EvolutionaryAlgorithmConstants.MUTATION_CHANCE += EvolutionaryAlgorithmConstants.MUTATION_CHANCE_ADJUST_VALUE;

        }
    }
}
