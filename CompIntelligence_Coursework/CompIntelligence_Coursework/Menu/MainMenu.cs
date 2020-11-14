using CompIntelligence_Coursework.FileReader;
using CompIntelligence_Coursework.Helpers;
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
        private readonly ISolutionStrategyFactory solutionStrategyFactory;
        private ISolutionFinderStrategy solutionFinderStrategy;

        private Dictionary<int, Solution> solutions;

        public MainMenu(IPieceLengthToQuantityLookup pieceLengthToQuantityLookup, IStockLengthToCostLookup stockLengthToCostLookup, ISolutionStrategyFactory solutionStrategyFactory)
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
            this.solutionStrategyFactory = solutionStrategyFactory;

            solutions = new Dictionary<int, Solution>();
        }

        public void RunMenu()
        {
            DisplayMenu();
            ReadCSVFile();
            RunApplication();
        }

        private void DisplayMenu()
        {
            Console.WriteLine("Please choose from the choices below");
            Console.WriteLine("1. PSO solution");
            Console.WriteLine("2. Not yet implemented");
        }

        private void ReadCSVFile()
        {
            CSVFileReader cSVFileReader = new CSVFileReader();
            cSVFileReader.ReadCSVFile(pieceLengthToQuantityLookup, stockLengthToCostLookup);
        }

        private void RunApplication()
        {
            var strategyType = SolutionStrategyTypes.PSOSolutionStrategy; // Menu choice needs to affect this

            solutionFinderStrategy = solutionStrategyFactory.GetSolutionFinderStrategy(strategyType);
            solutions = solutionFinderStrategy.FindSolutions();
            //DataDisplay.DisplayData(solutions);
        }
    }
}
