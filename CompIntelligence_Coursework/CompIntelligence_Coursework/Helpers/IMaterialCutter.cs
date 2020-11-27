using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Helpers
{
    public interface IMaterialCutter
    {
        Activity ProduceActivity(StockItem stockItem, double orderLength, double orderQuantity);
    }
}