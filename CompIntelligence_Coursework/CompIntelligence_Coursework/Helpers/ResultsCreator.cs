using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.FileReader;
using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
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

        private List<Result> results;

        public ResultsCreator(IBestSolutionFinder bestSolutionFinder, ISolutionFinderStrategy randomSolution, ISolutionFinderStrategy evoSolution, ICSVFileWriter csvFileWriter)
        {
            this.bestSolutionFinder = bestSolutionFinder;
            this.randomSolution = randomSolution;
            this.evoSolution = evoSolution;
            this.csvFileWriter = csvFileWriter;
            results = new List<Result>();
        }

        public void ClearSolutions()
        {
            results.Clear();
        }

        Dictionary<int, Solution> ISolutionFinderStrategy.FindSolutions()
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

            // Generate EVO Elitism results
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = true;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Elitism_TEST_RESULTS);

            // Generate EVO Adaptive results
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = false;
            EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES = true;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Adaptive_TEST_RESULTS);

            // Generate EVO Elitism Adaptive results
            ClearSolutions();
            EvolutionaryAlgorithmConstants.IS_USING_ELITISM = true;
            GenerateOneSetOfResults(evoSolution, GenericConstants.EVO_Elitism_Adaptive_TEST_RESULTS);
        }

        private void GenerateOneSetOfResults(ISolutionFinderStrategy solutionFinderStrategy, string fileNamePrefix) 
        {
            ClearSolutions();
            results = GenerateListOfResults(solutionFinderStrategy);
            csvFileWriter.WriteResultsToFile(results, fileNamePrefix);
        }

        private List<Result> GenerateListOfResults(ISolutionFinderStrategy solutionFinderStrategy)
        {
            List<Result> localResults = new List<Result>();
            FailedSolutionsCounter.ResetCounters();
            for (int index = 0; index < GenericConstants.NUMBER_OF_TEST_RESULTS_TO_CREATE; index++)
            {
                solutionFinderStrategy.ClearSolutions();
                ExecutionTimer.StartTimer();
                FailedSolutionsCounter.ResetCounters();

                Dictionary<int, Solution> solutions = solutionFinderStrategy.FindSolutions();

                KeyValuePair<int, Solution> bestSolution = bestSolutionFinder.GetBestSolutionInGenerationFromDictionary(solutions);

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
