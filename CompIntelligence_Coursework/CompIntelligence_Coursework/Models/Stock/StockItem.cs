using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Models
{
    public class StockItem
    {
        public double StockLength { get; }

        public double StockLengthCost { get; }

        public StockItem(double stockLength, double stockLengthCost)
        {
            StockLength = stockLength;
            StockLengthCost = stockLengthCost;
        }
    }
}
