using System;

namespace CompIntelligence_Coursework.Generic
{
    public static class GenericConstants
    {
        public static int NUMBER_OF_ITERATIONS { get; set; }

        public static int SIZE_OF_POPULATION { get; set; }

        public static void ResetValuesToDefault()
        {
            NUMBER_OF_ITERATIONS = 100;
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
