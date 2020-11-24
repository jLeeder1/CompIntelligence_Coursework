using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.SolutionEvaluation
{
    public class SolutionValidation : ISolutionValidation
    {
        public bool IsValidSolution(Solution solution, IOrderItems pieceLengthToQuantityLookup, IStockItems stockLengthToCostLookup)
        {
            bool isValidLength = IsLengthOfSolutionValid(solution, pieceLengthToQuantityLookup);
            bool isOnlyValidCuts = IsSolutionOnlyFilledWithValidLengths(solution, stockLengthToCostLookup);

            if (isValidLength && isOnlyValidCuts)
            {
                return true;
            }

            return false;
        }

        /*
         * Checks to see that the length of the solution is less than the lengths of pieces if they were placed end to end
         */
        private bool IsLengthOfSolutionValid(Solution solution, IOrderItems orderItems)
        {
            double solutionLength = GetTotalLengthOfSolutionStockLengths(solution);
            double pieceLength = GetTotalOfPieceLengths(orderItems);

            if (solutionLength < pieceLength)
            {
                return false;
            }

            return true;
        }

        private bool IsSolutionOnlyFilledWithValidLengths(Solution solution, IStockItems stockItems)
        {
            foreach (StockItem solutionStockItem in solution.SolutionStockItems)
            {
                foreach (StockItem factoryStockItem in stockItems.StockItemList)
                {
                    if (solutionStockItem.StockLength == factoryStockItem.StockLength)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private double GetTotalLengthOfSolutionStockLengths(Solution solution)
        {
            double totalLength = 0.0;

            foreach (StockItem stockitem in solution.SolutionStockItems)
            {
                totalLength += stockitem.StockLength;
            }

            return totalLength;
        }

        private double GetTotalOfPieceLengths(IOrderItems orderItems)
        {
            double totalLength = 0.0;

            foreach (OrderItem orderItem in orderItems.OrderItemsList)
            {
                totalLength += orderItem.PieceLength * orderItem.QuantityOfPieceLength;
            }

            return totalLength;
        }
    }
}
