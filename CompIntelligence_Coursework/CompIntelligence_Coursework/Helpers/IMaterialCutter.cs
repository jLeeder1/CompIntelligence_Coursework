using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Helpers
{
    public interface IMaterialCutter
    {
        List<CutRecipe> CutMaterial(StockItem stockItem, OrderItem orderItem, double quantityToCut);
    }
}