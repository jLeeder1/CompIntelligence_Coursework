using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public class StockItems : IStockItems
    {
        public List<StockItem> StockItemList { get; set; }

        public StockItems()
        {
            StockItemList = new List<StockItem>();
        }
    }
}
