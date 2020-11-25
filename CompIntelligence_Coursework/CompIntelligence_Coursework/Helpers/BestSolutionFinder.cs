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
    }
}
