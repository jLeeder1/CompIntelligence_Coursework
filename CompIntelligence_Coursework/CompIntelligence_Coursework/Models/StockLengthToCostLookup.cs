﻿using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class StockLengthToCostLookup : IStockLengthToCostLookup
    {
        // Stock length | Cost
        public Dictionary<double, double> LengthToCost { get; set; }

        public StockLengthToCostLookup()
        {
            LengthToCost = new Dictionary<double, double>();
        }
    }
}
