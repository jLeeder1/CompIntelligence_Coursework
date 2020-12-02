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
                foreach (Result result in results)
                    outputFile.WriteLine($"{result.GenerationResultFoundIn},{result.SolutionCost}");
            }
        }
    }
}
