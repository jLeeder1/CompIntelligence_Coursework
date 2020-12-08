using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.FileReader
{
    public interface ICSVFileWriter
    {
        void WriteResultsToFile(List<Result> results);
    }
}