using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.SolutionEvaluation
{
    public class SolutionValidation : ISolutionValidation
    {
        public bool IsValidSolution(Solution solution, IOrder order, IStockList stockList)
        {
            bool isValidLength = IsLengthOfSolutionValid(solution, order);
            bool isOnlyValidCuts = IsSolutionOnlyFilledWithValidLengths(solution, stockList);

            if (isValidLength && isOnlyValidCuts)
            {
                return true;
            }

            return false;
        }

        /*
         * Checks to see that the length of the solution is less than the lengths of pieces if they were placed end to end
         */
        private bool IsLengthOfSolutionValid(Solution solution, IOrder order)
        {
            double solutionLength = GetTotalLengthOfSolutionStockUsed(solution);
            double pieceLength = GetTotalOfPieceLengths(order);

            if (solutionLength < pieceLength)
            {
                return false;
            }

            return true;
        }

        private bool IsSolutionOnlyFilledWithValidLengths(Solution solution, IStockList stockItems)
        {
            List<double> stockItemLengths = new List<double>();

            foreach(StockItem stockItem in stockItems.StockItemList)
            {
                stockItemLengths.Add(stockItem.StockLength);
            }

            foreach(CutRecipe cutRecipe in solution.CutRecipes)
            {
                if (!stockItemLengths.Contains(cutRecipe.OriginalStockItemUsed.StockLength))
                {
                    return false;
                }
            }

            return true;
        }

        private double GetTotalLengthOfSolutionStockUsed(Solution solution)
        {
            double totalLength = 0.0;

            foreach (CutRecipe cutRecipe in solution.CutRecipes)
            {
                totalLength += cutRecipe.OriginalStockItemUsed.StockLength;
            }

            return totalLength;
        }

        private double GetTotalOfPieceLengths(IOrder order)
        {
            double totalLength = 0.0;

            foreach (OrderItem orderItem in order.OrderItemsList)
            {
                totalLength += orderItem.PieceLength * orderItem.QuantityOfPieceLength;
            }

            return totalLength;
        }
    }
}
