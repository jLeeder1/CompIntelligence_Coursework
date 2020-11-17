using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using System.Collections.Generic;

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

        public Dictionary<int, Solution> FindSolutions()
        {
            for (int index = 0; index < GenericConstants.NUMBER_OF_ITERATIONS; index++)
            {
                Solution solution = randomSolutionGenerator.GenerateRandomSolution();

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
