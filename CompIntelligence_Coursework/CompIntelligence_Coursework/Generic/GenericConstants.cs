﻿using System;

namespace CompIntelligence_Coursework.Generic
{
    public static class GenericConstants
    {
        // User set
        public static int NUMBER_OF_ITERATIONS { get; set; } = 50;

        public static int SIZE_OF_POPULATION { get; set; } = 100;
        public static int NUMBER_OF_TEST_RESULTS_TO_CREATE { get; set; } = 50;

        public static string RANDOM_SOLUTION { get; } = "Random_Solution";

        public static string EVO_SOLUTION { get; } = "EVO_Solution";

        public static string END_PROGRAM { get; } = "End_Program";
        public static string GENERATE_TEST_RESULTS { get; } = "Generate_Test_Results";

        // Non user set
        public static double UPPER_BOUND_FOR_RANDOM_QUANTITY { get; } = 10;

        public static double CHANCE_FOR_ORDER_TO_USE_STOCK_LENGTH { get; } = 0.3;

        public static void ResetValuesToDefault()
        {
            NUMBER_OF_ITERATIONS = 50;
            SIZE_OF_POPULATION = 100;
        }

        public static void DisplayConstants()
        {
            Console.WriteLine($"Number of iterations: {NUMBER_OF_ITERATIONS}");
            Console.WriteLine($"Size of population: {SIZE_OF_POPULATION}");

            Console.WriteLine(System.Environment.NewLine);
        }
    }
}
