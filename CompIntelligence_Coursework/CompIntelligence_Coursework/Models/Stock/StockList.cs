using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    /**
     * Represents what stock a factory has that can be used to cut to fulfill orders
     */
    public class StockList : IStockList
    {
        public List<StockItem> StockItemList { get; set; }

        public StockList()
        {
            StockItemList = new List<StockItem>();
        }
    }
}
