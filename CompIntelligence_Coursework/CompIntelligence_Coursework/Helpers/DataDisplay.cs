using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Helpers
{
    public static class DataDisplay
    {
        public static void DisplayData(Dictionary<int, Solution> solutions)
        {
            int bestIteration = 0;
            double bestSolutionCost = double.MaxValue;
            string bestLengthToQuantity = string.Empty;

            foreach (KeyValuePair<int, Solution> entry in solutions)
            {
                string lengthToQuantity = FormatSolutionForPrintingToConsole(entry.Value);
                Console.WriteLine($"{System.Environment.NewLine}Iteration: {entry.Key}, Best solution in iteration: {lengthToQuantity}Cost: {entry.Value.SolutionCost}");
                Console.WriteLine($"Cost: {entry.Value.SolutionCost}");

                if (entry.Value.SolutionCost < bestSolutionCost)
                {
                    bestIteration = entry.Key;
                    bestSolutionCost = entry.Value.SolutionCost;
                    bestLengthToQuantity = lengthToQuantity;
                }
            }

            Console.WriteLine($"{System.Environment.NewLine}Best solution found in iteration: {bestIteration} with cost: {bestSolutionCost}{System.Environment.NewLine}Best solution: {bestLengthToQuantity}");
        }

        private static string FormatSolutionForPrintingToConsole(Solution solution)
        {
            string formattedString = string.Empty;

            foreach (KeyValuePair<double, double> entry in solution.LengthToQuantity)
            {
                formattedString += ($"{System.Environment.NewLine}Length: {entry.Key}, Quantity: {entry.Value}");
            }

            return formattedString;
        }
    }
}
