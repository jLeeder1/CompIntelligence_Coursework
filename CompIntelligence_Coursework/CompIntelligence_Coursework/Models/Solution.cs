using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class Solution
    {
        public List<StockItem> SolutionStockItems { get; set; }

        public List<double> OffcutLengths { get; set; }

        public double SolutionCost { get; set; }

        public Solution()
        {
            SolutionStockItems = new List<StockItem>();
            OffcutLengths = new List<double>();
        }
    }
}
