using CompIntelligence_Coursework.Models;
using System;
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
        public Activity ProduceActivity(StockItem stockItem, double orderLength, double orderQuantity)
        {
            Random random = new Random();

            Activity activity = new Activity
            {
                StockItemUsed = stockItem
            };

            double lengthOfCurrentStockLeft = stockItem.StockLength;

            while (lengthOfCurrentStockLeft >= orderLength && activity.PositionsToCutAt.Count < orderQuantity)
            {
                lengthOfCurrentStockLeft -= orderLength;
                activity.PositionsToCutAt.Add(orderLength);

                if(random.Next(0, 4) >= 2)
                {
                    break;
                }
            }

            activity.Offcut = lengthOfCurrentStockLeft;

            return activity;
        }
    }
}
