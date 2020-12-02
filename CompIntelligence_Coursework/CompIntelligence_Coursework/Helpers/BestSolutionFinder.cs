using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompIntelligence_Coursework.Helpers
{
    public class BestSolutionFinder : IBestSolutionFinder
    {
        public Solution GetBestSolutionInGeneration(List<Solution> solutions)
        {
            Solution bestSolution = solutions.First();
            double bestCost = solutions.First().SolutionCost;

            foreach (Solution solution in solutions)
            {
                if (solution.SolutionCost < bestCost)
                {
                    bestCost = solution.SolutionCost;
                    bestSolution = solution;
                }
            }

            return bestSolution;
        }

        public KeyValuePair<int, Solution> GetBestSolutionInGenerationFromDictionary(Dictionary<int, Solution> solutions)
        {
            Solution bestSolution = solutions[0];
            int foundInGeneraton = 0;
            foreach (KeyValuePair<int, Solution> entry in solutions)
            {
                if (entry.Value.SolutionCost < bestSolution.SolutionCost)
                {
                    bestSolution = entry.Value;
                    foundInGeneraton = entry.Key;
                }
            }

            return new KeyValuePair<int, Solution>(foundInGeneraton, bestSolution);
        }
    }
}
