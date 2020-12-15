using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.FileReader;
using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.RandomSolutions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Helpers
{
    public class ResultsCreator : ISolutionFinderStrategy
    {
        private readonly IBestSolutionFinder bestSolutionFinder;
        private readonly ISolutionFinderStrategy randomSolution;
        private readonly ISolutionFinderStrategy evoSolution;
        private readonly ICSVFileWriter csvFileWriter;
        private readonly IRandomSolutionGenerator randomSolutionGenerator;

        private List<Result> results;
        private readonly List<Solution> initialPopulation;

        public ResultsCreator(IBestSolutionFinder bestSolutionFinder, ISolutionFinderStrategy randomSolution, ISolutionFinderStrategy evoSolution, ICSVFileWriter csvFileWriter, IRandomSolutionGenerator randomSolutionGenerator)
        {
            this.bestSolutionFinder = bestSolutionFinder;
            this.randomSolution = randomSolution;
            this.evoSolution = evoSolution;
            this.csvFileWriter = csvFileWriter;
            this.randomSolutionGenerator = randomSolutionGenerator;
            results = new List<Result>();
            if (GenericConstants.IS_USING_SAME_INITIALPOPULATION)
            {
                initialPopulation = new List<Solution>();
            }
        }

        public void ClearSolutions()
        {
            results.Clear();
        }

        Dictionary<int, Solution> ISolutionFinderStrategy.FindSolutions(List<Solution> initialPopulation = null)
        {
            GenerateSuiteOfResult();
            return null;
        }

        private void GenerateSuiteOfResult()
        {
            // Generate random results
            ClearSolutions();
            GenericConstants.IS_USING_RANDOM_SOLUTION = true;
            GenerateOneSetOfResults(randomSolution, GenericConstants.RANDOM_TEST_RESULTS);
            GenericConstants.IS_USING_RANDOM_SOLUTION = false;

            // Generate EVO default results
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = false;
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = false;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Default_TEST_RESULTS);

            // Generate EVO default results with ranked parent selection
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = false;
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = false;
            EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT = true;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Default_TEST_RESULTS_WITH_RANKED_SELECTION);

            // Generate EVO Elitism results non ranked
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = true;
            EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT = false;
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = false;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Elitism_TEST_RESULTS);

            // Generate EVO Elitism results ranked
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = true;
            EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT = true;
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = false;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Elitism_TEST_RESULTS_RANKED);

            // Generate EVO Adaptive results non ranked
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = false;
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = true;
            EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT = false;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Adaptive_TEST_RESULTS);

            // Generate EVO Adaptive results ranked
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = false;
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = true;
            EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT = true;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Adaptive_TEST_RESULTS_RANKED);

            // Generate EVO Elitism Adaptive results non ranked
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = true;
            EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT = false;
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = true;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Elitism_Adaptive_TEST_RESULTS);

            // Generate EVO Elitism Adaptive results ranked
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = true;
            EvolutionaryAlgorithmConstants.IS_USING_RANKED_TOURNAMENT = true;
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = true;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Elitism_Adaptive_TEST_RESULTS_RANKED);
        }

        private void GenerateOneSetOfResults(ISolutionFinderStrategy solutionFinderStrategy, string fileNamePrefix) 
        {
            ClearSolutions();
            if (fileNamePrefix == GenericConstants.RANDOM_TEST_RESULTS)
            {
                results = GenerateListOfResultsForRandom(solutionFinderStrategy);
            }
            else
            {
                results = GenerateListOfResults(solutionFinderStrategy, initialPopulation);
            }
            csvFileWriter.WriteResultsToFile(results, fileNamePrefix);
        }

        private List<Result> GenerateListOfResults(ISolutionFinderStrategy solutionFinderStrategy, List<Solution> initialPopulation)
        {
            List<Result> localResults = new List<Result>();
            FailedSolutionsCounter.ResetCounters();
            for (int index = 0; index < GenericConstants.NUMBER_OF_TEST_RESULTS_TO_CREATE; index++)
            {
                solutionFinderStrategy.ClearSolutions();
                ExecutionTimer.StartTimer();
                FailedSolutionsCounter.ResetCounters();

                Dictionary<int, Solution> solutions = solutionFinderStrategy.FindSolutions(initialPopulation);
                double averageCost = CalculateAverageCostInGeneration(solutions);

                KeyValuePair<int, Solution> bestSolution = bestSolutionFinder.GetBestSolutionInGenerationFromDictionary(solutions);

                localResults.Add(new Result() 
                {
                    GenerationResultFoundIn = bestSolution.Key,
                    SolutionCost = bestSolution.Value.SolutionCost,
                    TimeTakenToFindResult = ExecutionTimer.GetExecutionTime(),
                    FailedRecombinationCount = FailedSolutionsCounter.FailedRecombinationCounter,
                    AverageCostOfGeneration = averageCost
                });
            }

            return localResults;
        }

        private double CalculateAverageCostInGeneration(Dictionary<int, Solution> solutions)
        {
            double sumOfCosts = 0;

            foreach(KeyValuePair<int, Solution> entry in solutions)
            {
                sumOfCosts += entry.Value.SolutionCost;
            }

            double average = sumOfCosts / solutions.Count;
            return average;
        }

        private List<Result> GenerateListOfResultsForRandom(ISolutionFinderStrategy solutionFinderStrategy)
        {
            List<Result> localResults = new List<Result>();
            FailedSolutionsCounter.ResetCounters();
            Dictionary<int, Solution> solutions = new Dictionary<int, Solution>();

            for (int index = 0; index < GenericConstants.NUMBER_OF_TEST_RESULTS_TO_CREATE; index++)
            {
                solutionFinderStrategy.ClearSolutions();
                ExecutionTimer.StartTimer();
                FailedSolutionsCounter.ResetCounters();

                Solution solution = randomSolutionGenerator.GenerateRandomSolution();
                solutions.Add(index, solution);
                initialPopulation.Add(solution);

                //KeyValuePair<int, Solution> bestSolution = bestSolutionFinder.GetBestSolutionInGenerationFromDictionary(solutions);
                KeyValuePair<int, Solution> bestSolution = new KeyValuePair<int, Solution>(index, solution);

                localResults.Add(new Result()
                {
                    GenerationResultFoundIn = bestSolution.Key,
                    SolutionCost = bestSolution.Value.SolutionCost,
                    TimeTakenToFindResult = ExecutionTimer.GetExecutionTime(),
                    FailedRecombinationCount = FailedSolutionsCounter.FailedRecombinationCounter
                });
            }

            return localResults;
        }
    }
}
