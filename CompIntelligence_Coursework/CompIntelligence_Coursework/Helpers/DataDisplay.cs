using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Helpers
{
    public static class DataDisplay
    {
        public static void DisplayData(Dictionary<int, Solution> solutions)
        {
            if(solutions == null || solutions.Count == 0)
            {
                Console.WriteLine("No solutions to show");
                return;
            }

            int bestIteration = 0;
            double bestSolutionCost = double.MaxValue;
            string bestLengthToQuantity = string.Empty;

            foreach (KeyValuePair<int, Solution> entry in solutions)
            {
                string fullSolution = FormatSolutionForPrintingToConsole(entry.Value);
                Console.WriteLine($"{System.Environment.NewLine}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Iteration: {entry.Key}{System.Environment.NewLine}Best solution in iteration: {fullSolution}");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"Cost: {entry.Value.SolutionCost}");
                Console.WriteLine("--------------------------------------------------");

                if (entry.Value.SolutionCost < bestSolutionCost)
                {
                    bestIteration = entry.Key;
                    bestSolutionCost = entry.Value.SolutionCost;
                    bestLengthToQuantity = fullSolution;
                }
            }

            Console.WriteLine($"{System.Environment.NewLine}BEST SOLUTION FOUND IN ITERATION: {bestIteration} WITH COST: {bestSolutionCost}{System.Environment.NewLine}BEST SOLUTION: {bestLengthToQuantity}");
        }

        private static string FormatSolutionForPrintingToConsole(Solution solution)
        {
            string formattedString = string.Empty;

            foreach (Activity activity in solution.Activities)
            {
                formattedString += ($"{System.Environment.NewLine}Stock length used: {activity.StockItemUsed.StockLength} | Offcut: {activity.Offcut} | {FormatCutsForPrintingToConsole(activity.PositionsToCutAt)}");
            }

            return formattedString;
        }

        private static string FormatCutsForPrintingToConsole(List<double> positionsToCutAt)
        {
            string formattedString = "Cuts: [";

            for (int index = 0; index <= positionsToCutAt.Count - 1; index++)
            {
                formattedString += ($" {positionsToCutAt[index]}");
                if(positionsToCutAt[index] != 0 && index != positionsToCutAt.Count - 1)
                {
                    formattedString += " -";
                }
            }

            formattedString += " ]";

            return formattedString;
        }
    }
}
