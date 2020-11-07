using CompIntelligence_Coursework.FileReader;
using CompIntelligence_Coursework.Models;
using System;

namespace CompIntelligence_Coursework.Menu
{
    public class MainMenu
    {
        private PieceLengthToQuantityLookup pieceLengthToQuantityLookup;
        private StockLengthToCostLookup stockLengthToCostLookup;

        public MainMenu()
        {
            pieceLengthToQuantityLookup = new PieceLengthToQuantityLookup();
            stockLengthToCostLookup = new StockLengthToCostLookup();
        }

        public void DisplayMenu()
        {
            Console.WriteLine("Please choose from the choices below");
            Console.WriteLine("1. Not yet implemented");
            Console.WriteLine("2. Not yet implemented");

            CSVFileReader cSVFileReader = new CSVFileReader();
            cSVFileReader.ReadCSVFile(pieceLengthToQuantityLookup, stockLengthToCostLookup);

            int x = 0;
        }
    }
}
