using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class PieceLengthToQuantityLookup
    {
        // Piece length | Quantity
        public Dictionary<double, double> LengthToCost { get; set; }

        public PieceLengthToQuantityLookup()
        {
            LengthToCost = new Dictionary<double, double>();
        }
    }
}
