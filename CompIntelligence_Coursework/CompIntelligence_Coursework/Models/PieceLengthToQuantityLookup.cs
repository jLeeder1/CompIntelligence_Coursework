﻿using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class PieceLengthToQuantityLookup
    {
        // Piece length | Quantity
        public Dictionary<double, double> LengthToQuantity { get; set; }

        public PieceLengthToQuantityLookup()
        {
            LengthToQuantity = new Dictionary<double, double>();
        }
    }
}
