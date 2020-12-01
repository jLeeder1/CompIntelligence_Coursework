using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class EvolutionaryAlgorithmConstants
    {
        public static int TOURNAMENT_SIZE { get; set; } = 10;
        public static int NUMBER_OF_INVIDIDUALS_PICKED_PER_TOURNAMENT { get; set; } = 10;
        public static bool IS_USING_ELITISM { get; set; } = false;
        public static double RECOMBINATION_CHANCE { get; set; } = 0.6;
        public static double MUTATION_CHANCE { get; set; } = 0.01;
        public static double RECOMBINATION_CHANCE_ADJUST_VALUE { get; set; } = 0.05;
        public static double MUTATION_CHANCE_ADJUST_VALUE { get; set; } = 0.0025;
        public static bool IS_USING_ADAPTIVE_CROSSOVER_CHANCES { get; set; } = true;
    }
}
