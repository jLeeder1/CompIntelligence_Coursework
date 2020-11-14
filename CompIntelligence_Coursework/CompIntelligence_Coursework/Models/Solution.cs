using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class Solution
    {
        // Stock length | quantity
        public Dictionary<double, double> LengthToQuantity { get; set; }

        public double SolutionCost { get; set; }

        public Solution()
        {
            LengthToQuantity = new Dictionary<double, double>();
        }
    }
}
