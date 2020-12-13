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
        private readonly ISolutionFinderStrategy evoSolution;
        private readonly ICSVFileWriter csvFileWriter;

        private List<Result> results;

        public ResultsCreator(IBestSolutionFinder bestSolutionFinder, ISolutionFinderStrategy evoSolution, ICSVFileWriter csvFileWriter)
        {
            this.bestSolutionFinder = bestSolutionFinder;
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
            ClearSolutions();
            results = GenerateListOfResults();
            csvFileWriter.WriteResultsToFile(results);
            return null;
        }

        private List<Result> GenerateListOfResults()
        {
            List<Result> localResults = new List<Result>();
            FailedSolutionsCounter.ResetCounters();
            for (int index = 0; index < GenericConstants.NUMBER_OF_TEST_RESULTS_TO_CREATE; index++)
            {
                evoSolution.ClearSolutions();
                ExecutionTimer.StartTimer();
                FailedSolutionsCounter.ResetCounters();

                Dictionary<int, Solution> solutions = evoSolution.FindSolutions();

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
