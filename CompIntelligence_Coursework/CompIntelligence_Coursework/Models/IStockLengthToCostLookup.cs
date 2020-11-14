using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface IStockLengthToCostLookup
    {
        Dictionary<double, double> LengthToCost { get; set; }
    }
}