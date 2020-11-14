using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CompIntelligence_Coursework.FileReader
{
    public class CSVFileReader
    {
        public void ReadCSVFile(IPieceLengthToQuantityLookup pieceLengthToQuantityLookup, IStockLengthToCostLookup stockLengthToCostLookup)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "CompIntelligence_Coursework.Resources.Problem1.csv";

            try
            {
                using Stream stream = assembly.GetManifestResourceStream(resourceName);
                using StreamReader reader = new StreamReader(stream);
                while (!reader.EndOfStream)
                {
                    string[] currentLine = reader.ReadLine().Split(",");

                    if (IsStockLengths(currentLine))
                    {
                        string[] currentLinePlusOne = reader.ReadLine().Split(",");
                        stockLengthToCostLookup.LengthToCost = ConstructLengthCostLookup(currentLine, currentLinePlusOne);
                    }

                    if (IsPieceLengths(currentLine))
                    {
                        string[] currentLinePlusOne = reader.ReadLine().Split(",");
                        pieceLengthToQuantityLookup.LengthToQuantity = ConstructLengthQuantityLookup(currentLine, currentLinePlusOne);
                    }
                }
                
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read");
                Console.WriteLine(e.Message);
            }
        }

        private bool IsStockLengths(string[] one)
        {
            if(one[0].ToLower().Equals("stock lengths"))
            {
                return true;
            }

            return false;
        }

        private bool IsPieceLengths(string[] one)
        {
            if (one[0].ToLower().Equals("piece lengths"))
            {
                return true;
            }

            return false;
        }

        private bool IsViableToParse(string stringToParse)
        {
            double x = 0;
            if (stringToParse != String.Empty && double.TryParse(stringToParse, out x))
            {
                return true;
            }

            return false;
        }

        /*
         * This logic is duplicated but at time of writing I wasn't sure what data types each lookup would use
         * So leaving for now for easy switching and experimenting
         */
        private Dictionary<double, double> ConstructLengthCostLookup(string[] currentLine, string[] currentLinePlusOne)
        {
            Dictionary<double, double> newLookup = new Dictionary<double, double>();

            for(int index = 0; index <= currentLine.Length - 1; index++)
            {
                if(!IsViableToParse(currentLine[index]) || !IsViableToParse(currentLinePlusOne[index]))
                {
                    continue;
                }

                double currentLineDouble = double.Parse(currentLine[index]);
                double currentLinePlusOneDouble = double.Parse(currentLinePlusOne[index]);
                
                newLookup.Add(currentLineDouble, currentLinePlusOneDouble);
            }

            return newLookup;
        }

        private Dictionary<double, double> ConstructLengthQuantityLookup(string[] currentLine, string[] currentLinePlusOne)
        {
            Dictionary<double, double> newLookup = new Dictionary<double, double>();

            for (int index = 0; index <= currentLine.Length - 1; index++)
            {
                if (!IsViableToParse(currentLine[index]) || !IsViableToParse(currentLinePlusOne[index]))
                {
                    continue;
                }

                double currentLineDouble = double.Parse(currentLine[index]);
                double currentLinePlusOneDouble = double.Parse(currentLinePlusOne[index]);

                newLookup.Add(currentLineDouble, currentLinePlusOneDouble);
            }

            return newLookup;
        }
    }
}
