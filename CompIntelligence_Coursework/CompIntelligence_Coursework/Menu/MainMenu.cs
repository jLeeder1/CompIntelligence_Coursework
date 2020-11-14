using CompIntelligence_Coursework.FileReader;
using CompIntelligence_Coursework.Models;
using System;

namespace CompIntelligence_Coursework.Menu
{
    public class MainMenu
    {
        private readonly PieceLengthToQuantityLookup pieceLengthToQuantityLookup;
        private readonly StockLengthToCostLookup stockLengthToCostLookup;

        public MainMenu()
        {
            pieceLengthToQuantityLookup = new PieceLengthToQuantityLookup();
            stockLengthToCostLookup = new StockLengthToCostLookup();
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
    }
}
