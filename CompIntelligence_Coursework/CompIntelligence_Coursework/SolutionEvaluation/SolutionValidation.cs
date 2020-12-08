using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.SolutionEvaluation
{
    public class SolutionValidation : ISolutionValidation
    {
        private readonly IOrder order;
        private readonly IStockList stockList;

        public SolutionValidation(IOrder order, IStockList stockList)
        {
            this.order = order;
            this.stockList = stockList;
        }

        public bool IsValidSolution(Solution solution)
        {
            bool isValidLength = IsLengthOfSolutionValid(solution);
            bool isOnlyValidCuts = IsSolutionOnlyFilledWithValidLengths(solution);
            bool isOrderFulfilled = IsOrderFulfilled(solution);

            if (isValidLength && isOnlyValidCuts && isOrderFulfilled)
            {
                return true;
            }

            return false;
        }

        /*
         * Checks to see that the length of the solution is less than the lengths of pieces if they were placed end to end
         */
        private bool IsLengthOfSolutionValid(Solution solution)
        {
            double solutionLength = GetTotalLengthOfSolutionStockUsed(solution);
            double pieceLength = GetTotalOfPieceLengths();

            if (solutionLength < pieceLength)
            {
                return false;
            }

            return true;
        }

        private bool IsSolutionOnlyFilledWithValidLengths(Solution solution)
        {
            List<double> stockItemLengths = new List<double>();

            foreach(StockItem stockItem in stockList.StockItemList)
            {
                stockItemLengths.Add(stockItem.StockLength);
            }

            foreach(Activity activity in solution.Activities)
            {
                if (!stockItemLengths.Contains(activity.StockItemUsed.StockLength))
                {
                    return false;
                }
            }

            return true;
        }

        private double GetTotalLengthOfSolutionStockUsed(Solution solution)
        {
            double totalLength = 0.0;

            foreach (Activity activity in solution.Activities)
            {
                totalLength += activity.StockItemUsed.StockLength;
            }

            return totalLength;
        }

        private double GetTotalOfPieceLengths()
        {
            double totalLength = 0.0;

            foreach (KeyValuePair<double, double> entry in order.OrderItems)
            {
                totalLength += entry.Key * entry.Value;
            }

            return totalLength;
        }

        /*
         * Creates a Dictionaty of the order lengths and quantities
         * then decrements quantities from this as they are cut from the solutions activities
         */
        private bool IsOrderFulfilled(Solution solution)
        {
            Dictionary<double, double> orderDictionaryCopy = new Dictionary<double, double>(order.OrderItems);

            foreach(Activity activity in solution.Activities)
            {
                foreach(double cutPiece in activity.PositionsToCutAt)
                {
                    orderDictionaryCopy[cutPiece]--;
                }
            }

            foreach (KeyValuePair<double, double> entry in orderDictionaryCopy)
            {
                if(entry.Value > 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
