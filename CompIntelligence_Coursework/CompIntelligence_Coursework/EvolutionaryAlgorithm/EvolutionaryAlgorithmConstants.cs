using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class EvolutionaryAlgorithmConstants
    {
        public static int TOURNAMENT_SIZE { get; set; } = 10;
        public static bool IS_USING_ELITISM { get; set; } = false;
        public static double RECOMBINATION_CHANCE
        {
            get => recombinationChance;
            set
            {
                if (value > recombinationChanceLowerLimit && value < recombinationChanceUpperLimit)
                {
                    recombinationChance = value;
                }
            }
        }

        public static double MUTATION_CHANCE {
            get => mutationChance;
            set
            {
                if (value > mutationChanceLowerLimit && value < mutationChanceUpperLimit)
                {
                    mutationChance = value;
                }
            }
        }
        public static double RECOMBINATION_CHANCE_ADJUST_VALUE { get; set; } = 0.05;
        public static double MUTATION_CHANCE_ADJUST_VALUE { get; set; } = 0.0025;
        public static bool IS_USING_ADAPTIVE_CROSSOVER_CHANCES { get; set; } = false;

        private static double recombinationChance = 0.6;
        private static double recombinationChanceLowerLimit = 0.1;
        private static double recombinationChanceUpperLimit = 0.8;

        private static double mutationChance = 0.01;
        private static double mutationChanceLowerLimit = 0.001;
        private static double mutationChanceUpperLimit = 0.5;
    }
}
