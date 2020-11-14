using CompIntelligence_Coursework.FileReader;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.PSO;
using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Menu
{
    public class MainMenu
    {
        private readonly IPieceLengthToQuantityLookup pieceLengthToQuantityLookup;
        private readonly IStockLengthToCostLookup stockLengthToCostLookup;
        private readonly ISolutionFinderStrategy solutionFinderStrategy;

        private Dictionary<int, double> solutions;

        public MainMenu(IPieceLengthToQuantityLookup pieceLengthToQuantityLookup, IStockLengthToCostLookup stockLengthToCostLookup)
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;

            solutions = new Dictionary<int, double>();
        }

        public void RunMenu()
        {
            DisplayMenu();
            ReadCSVFile();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Please choose from the choices below");
            Console.WriteLine("1. Not yet implemented");
            Console.WriteLine("2. Not yet implemented");
        }

        private void ReadCSVFile()
        {
            CSVFileReader cSVFileReader = new CSVFileReader();
            cSVFileReader.ReadCSVFile(pieceLengthToQuantityLookup, stockLengthToCostLookup);
        }

        private void RunPSOSolution()
        {
            ISolutionFinderStrategy psoSolution = new PSOSolution();
            solutions = 
        }
    }
}
