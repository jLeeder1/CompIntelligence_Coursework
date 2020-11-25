using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    public interface IStockList
    {
        public List<StockItem> StockItemList { get; set; }
    }
}