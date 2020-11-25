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
                string fullSolution = FormatSolutionForPrintingToConsole(entry.Value);
                Console.WriteLine($"{System.Environment.NewLine}{System.Environment.NewLine}");
                Console.WriteLine($"Iteration: {entry.Key}{System.Environment.NewLine}Best solution in iteration: {fullSolution}{System.Environment.NewLine}");
                Console.WriteLine($"Cost: {entry.Value.SolutionCost}");

                if (entry.Value.SolutionCost < bestSolutionCost)
                {
                    bestIteration = entry.Key;
                    bestSolutionCost = entry.Value.SolutionCost;
                    bestLengthToQuantity = fullSolution;
                }
            }

            Console.WriteLine($"{System.Environment.NewLine}Best solution found in iteration: {bestIteration} with cost: {bestSolutionCost}{System.Environment.NewLine}Best solution: {bestLengthToQuantity}");
        }

        private static string FormatSolutionForPrintingToConsole(Solution solution)
        {
            string formattedString = string.Empty;

            foreach (CutRecipe cutRecipe in solution.CutRecipes)
            {
                formattedString += ($"{System.Environment.NewLine}Stock length used: {cutRecipe.OriginalStockItemUsed.StockLength}, Cuts at: {FormatCutsForPrintingToConsole(cutRecipe)}");
            }

            return formattedString;
        }

        private static string FormatCutsForPrintingToConsole(CutRecipe cutRecipe)
        {
            string formattedString = "Cuts at: [";

            for (int index = cutRecipe.PositionsToCutAt.Count - 1; index >= 0; index--)
            {
                formattedString += ($" {cutRecipe.PositionsToCutAt[index]}");
            }

            formattedString += " ]";

            return formattedString;
        }
    }
}
