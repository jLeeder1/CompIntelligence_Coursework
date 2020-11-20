using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CompIntelligence_Coursework.FileReader
{
    public class CSVFileReader
    {
        public void ReadCSVFile(IOrderItems orderItems, IStockItems stockItems)
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
                        stockItems.StockItemList = ConstructStockItems(currentLine, currentLinePlusOne);
                    }

                    if (IsPieceLengths(currentLine))
                    {
                        string[] currentLinePlusOne = reader.ReadLine().Split(",");
                        orderItems.OrderItemsList = ConstructOrderItems(currentLine, currentLinePlusOne);
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

       

        private List<StockItem> ConstructStockItems(string[] currentLine, string[] currentLinePlusOne)
        {
            List<StockItem> newStockItemList = new List<StockItem>();

            for (int index = 0; index <= currentLine.Length - 1; index++)
            {
                if (!IsViableToParse(currentLine[index]) || !IsViableToParse(currentLinePlusOne[index]))
                {
                    continue;
                }

                double currentLineDouble = double.Parse(currentLine[index]);
                double currentLinePlusOneDouble = double.Parse(currentLinePlusOne[index]);

                newStockItemList.Add(new StockItem(currentLineDouble, currentLinePlusOneDouble));
            }

            return newStockItemList;
        }

        private List<OrderItem> ConstructOrderItems(string[] currentLine, string[] currentLinePlusOne)
        {
            List<OrderItem> newOrderItemList = new List<OrderItem>();

            for (int index = 0; index <= currentLine.Length - 1; index++)
            {
                if (!IsViableToParse(currentLine[index]) || !IsViableToParse(currentLinePlusOne[index]))
                {
                    continue;
                }

                double currentLineDouble = double.Parse(currentLine[index]);
                double currentLinePlusOneDouble = double.Parse(currentLinePlusOne[index]);

                newOrderItemList.Add(new OrderItem(currentLineDouble) { QuantityOfPieceLength = currentLinePlusOneDouble });
            }

            return newOrderItemList;
        }
    }
}
