using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Helpers
{
    public class MaterialCutter : IMaterialCutter
    {
        /*
         * Cuts pieces but removing the piece length from the given stock item
         * once the length left from cutting is lower than the piece length that remianing length is added to the offcuts
         * and a new stock length is used to cut the remaining quantity of pieces
         */
        public List<CutRecipe> CutMaterial(StockItem stockItem, OrderItem orderItem)
        {
            List<CutRecipe> cutRecipes = new List<CutRecipe>();

            CutRecipe cutRecipe = new CutRecipe
            {
                OriginalStockItemUsed = stockItem,
                OriginalOrderItem = orderItem
            };

            double lengthOfCurrentStockLeft = stockItem.StockLength;

            lengthOfCurrentStockLeft -= orderItem.PieceLength;
            cutRecipe.PositionsToCutAt.Add(lengthOfCurrentStockLeft);

            if(lengthOfCurrentStockLeft != 0)
            {
                cutRecipe.OffCut = lengthOfCurrentStockLeft;
            }
                
            cutRecipes.Add(cutRecipe);

            return cutRecipes;
        }
    }
}
