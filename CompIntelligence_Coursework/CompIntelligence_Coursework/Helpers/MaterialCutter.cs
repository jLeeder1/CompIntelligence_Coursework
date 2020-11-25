using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompIntelligence_Coursework.Helpers
{
    public class MaterialCutter
    {
        /*
         * Cuts pieces but removing the piece length from the given stock item
         * once the length left from cutting is lower than the piece length that remianing length is added to the offcuts
         * and a new stock length is used to cut the remaining quantity of pieces
         */
        public List<CutRecipe> CutMaterial(StockItem stockItem, OrderItem orderItem, double quantityToCut)
        {
            List<CutRecipe> cutRecipes = new List<CutRecipe>();

            while(quantityToCut > 0)
            {
                CutRecipe cutRecipe = new CutRecipe();
                double lengthOfCurrentStockLeft = stockItem.StockLength;

                while(lengthOfCurrentStockLeft >= orderItem.PieceLength)
                {
                    lengthOfCurrentStockLeft -= orderItem.PieceLength;
                    cutRecipe.PositionsToCutAt.Add(lengthOfCurrentStockLeft);
                }

                cutRecipe.OffCuts.Add(lengthOfCurrentStockLeft);
                cutRecipes.Add(cutRecipe);
                quantityToCut--;
            }

            return cutRecipes;
        }
    }
}
