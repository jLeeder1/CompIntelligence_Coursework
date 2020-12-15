using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompIntelligence_Coursework.RandomSolutions
{
    class RandomSolution : ISolutionFinderStrategy
    {
        private readonly IRandomSolutionGenerator randomSolutionGenerator;

        private Dictionary<int, Solution> solutions;


        public RandomSolution(IRandomSolutionGenerator randomSolutionGenerator)
        {
            this.randomSolutionGenerator = randomSolutionGenerator;

            solutions = new Dictionary<int, Solution>();
        }

        public Dictionary<int, Solution> FindSolutions(List<Solution> initialPopulation = null)
        {
            int numIterations = GenericConstants.NUMBER_OF_ITERATIONS;

            if(initialPopulation != null)
            {
                numIterations = initialPopulation.Count;
            }
            
            for (int index = 0; index < numIterations; index++)
            {
                Solution solution;

                if(initialPopulation != null)
                {
                    solution = initialPopulation.ElementAt(index);
                }
                else
                {
                    solution = randomSolutionGenerator.GenerateRandomSolution();
                }
                

                solutions.Add(index, solution);
            }

            return solutions;
        }

        public void ClearSolutions()
        {
            solutions.Clear();
        }
    }
}
