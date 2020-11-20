using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class Solution
    {
        // Stock StockLength | quantity
        public Dictionary<double, double> LengthToQuantity { get; set; }

        public List<double> OffcutLengths { get; set; }

        public double SolutionCost { get; set; }

        public Solution()
        {
            LengthToQuantity = new Dictionary<double, double>();
            OffcutLengths = new List<double>();
        }
    }
}
