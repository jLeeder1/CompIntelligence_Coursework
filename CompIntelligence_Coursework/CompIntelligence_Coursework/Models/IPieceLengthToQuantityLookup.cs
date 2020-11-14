using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface IPieceLengthToQuantityLookup
    {
        Dictionary<double, double> LengthToQuantity { get; set; }
    }
}