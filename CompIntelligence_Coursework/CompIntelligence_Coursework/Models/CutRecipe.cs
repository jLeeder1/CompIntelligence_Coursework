using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Models
{
    /*
     * Holds the data for where cuts should be made along a paricular stock item
     */
    public class CutRecipe
    {
        public StockItem OriginalStockItemUsed { get; set; }

        public List<double> PositionsToCutAt { get; set; }
    }
}
