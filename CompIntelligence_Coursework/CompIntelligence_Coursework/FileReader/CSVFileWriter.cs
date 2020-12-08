using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CompIntelligence_Coursework.FileReader
{
    public class CSVFileWriter : ICSVFileWriter
    {
        public void WriteResultsToFile(List<Result> results)
        {
            // Set a variable to the Documents path.
            string docPath =
              Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Write the string array to a new file named "WriteLines.txt".
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "TestResults.txt")))
            {
                outputFile.WriteLine($"Is using adaptive crossover,{EvolutionaryAlgorithmConstants.IS_USING_ADAPTIVE_CROSSOVER_CHANCES}");
                outputFile.WriteLine($"Number of generations,{GenericConstants.NUMBER_OF_ITERATIONS}");
                outputFile.WriteLine($"Number of iterations in generation,{GenericConstants.NUMBER_OF_ITERATIONS}");
                outputFile.WriteLine($"Tournament size,{EvolutionaryAlgorithmConstants.TOURNAMENT_SIZE}");
                outputFile.WriteLine($"Number of tests,{GenericConstants.NUMBER_OF_TEST_RESULTS_TO_CREATE}");
                outputFile.WriteLine("Generation cost found in" + ","+ "Best cost value");
                foreach (Result result in results)
                    outputFile.WriteLine($"{result.GenerationResultFoundIn},{result.SolutionCost}");
            }
        }
    }
}
