using System;

namespace CompIntelligence_Coursework.Generic
{
    public static class GenericConstants
    {
        public static int NUMBER_OF_ITERATIONS { get; set; } = 50;
        public static int SIZE_OF_POPULATION { get; set; } = 100;
        public static int NUMBER_OF_TEST_RESULTS_TO_CREATE { get; set; } = 50;
        public static string RANDOM_SOLUTION { get; } = "Random_Solution";
        public static string EVO_SOLUTION { get; } = "EVO_Solution";
        public static string END_PROGRAM { get; } = "End_Program";
        public static string GENERATE_TEST_RESULTS { get; } = "Generate_Test_Results";
        public static string GENERATE_RANDOM_TEST_RESULTS { get; } = "Generate_Random_Test_Results";
        public static bool IS_USING_RANDOM_SOLUTION { get; set; } = false;

        // File names
        public static string RANDOM_TEST_RESULTS{ get; } = "Random_Results";
        public static string EVO_Default_TEST_RESULTS{ get; } = "EVO_Default_Results";
        public static string EVO_Default_TEST_RESULTS_WITH_RANKED_SELECTION{ get; } = "EVO_Default_Results_Ranked_Selection";
        public static string EVO_Elitism_TEST_RESULTS{ get; } = "EVO_Elitism_Results";
        public static string EVO_Elitism_TEST_RESULTS_RANKED{ get; } = "EVO_Elitism_Results_Ranked_Selection";
        public static string EVO_Adaptive_TEST_RESULTS{ get; } = "EVO_Adaptive_Results";
        public static string EVO_Adaptive_TEST_RESULTS_RANKED{ get; } = "EVO_Adaptive_Results_Ranked_Selection";
        public static string EVO_Elitism_Adaptive_TEST_RESULTS{ get; } = "EVO_Elitism_Adaptive_Results";
        public static string EVO_Elitism_Adaptive_TEST_RESULTS_RANKED{ get; } = "EVO_Elitism_Adaptive_Results_Ranked";


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
