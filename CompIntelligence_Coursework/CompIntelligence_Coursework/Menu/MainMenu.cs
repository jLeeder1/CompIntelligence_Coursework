using CompIntelligence_Coursework.FileReader;
using CompIntelligence_Coursework.Generic;
using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.PSO;
using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Menu
{
    public class MainMenu
    {
        private readonly IOrder pieceLengthToQuantityLookup;
        private readonly IStockList stockLengthToCostLookup;
        private readonly ISolutionStrategyFactory solutionStrategyFactory;
        private ISolutionFinderStrategy solutionFinderStrategy;

        private Dictionary<int, Solution> solutions;

        public MainMenu(IOrder pieceLengthToQuantityLookup, IStockList stockLengthToCostLookup, ISolutionStrategyFactory solutionStrategyFactory)
        {
            this.pieceLengthToQuantityLookup = pieceLengthToQuantityLookup;
            this.stockLengthToCostLookup = stockLengthToCostLookup;
            this.solutionStrategyFactory = solutionStrategyFactory;

            solutions = new Dictionary<int, Solution>();
        }

        public void RunMenu()
        {
            ReadCSVFile();

            bool isRunning = true;

            while (isRunning)
            {
                DisplayMenu();
                SolutionStrategyTypes menuChoice = GetMenuChoice();

                if(menuChoice == SolutionStrategyTypes.DefaultStrategy)
                {
                    break;
                }
                RunApplication(menuChoice);
            }
            
        }

        private void DisplayMenu()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Please choose from the choices below");
            Console.WriteLine("1. Random Solution");
            Console.WriteLine("2. EVO Solution");
            Console.WriteLine("3. Not yet implemented");
            Console.WriteLine("4. End Program");
        }

        private void ReadCSVFile()
        {
            CSVFileReader cSVFileReader = new CSVFileReader();
            cSVFileReader.ReadCSVFile(pieceLengthToQuantityLookup, stockLengthToCostLookup);
        }

        private void RunApplication(SolutionStrategyTypes solutionStrategy)
        {
            solutionFinderStrategy = solutionStrategyFactory.GetSolutionFinderStrategy(solutionStrategy);
            solutionFinderStrategy.ClearSolutions();
            solutions = solutionFinderStrategy.FindSolutions();
            DataDisplay.DisplayData(solutions);
        }

        private SolutionStrategyTypes GetMenuChoice()
        {
            string solutionToUse = string.Empty;

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.D1:
                    solutionToUse = GenericConstants.RANDOM_SOLUTION;
                    break;
                case ConsoleKey.D2:
                    solutionToUse = GenericConstants.EVO_SOLUTION;
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Not yet implemented");
                    break;
                case ConsoleKey.D4:
                    solutionToUse = GenericConstants.END_PROGRAM;
                    break;
                default:
                    solutionToUse = GenericConstants.RANDOM_SOLUTION;
                    break;
            }

            return SolutionStrategyTypeHelper.GetValueFromDescription<SolutionStrategyTypes>(solutionToUse);
        }
    }
}
