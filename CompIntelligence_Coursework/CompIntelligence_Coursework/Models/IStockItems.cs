using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface IStockItems
    {
        public List<StockItem> StockItemList { get; set; }
    }
}