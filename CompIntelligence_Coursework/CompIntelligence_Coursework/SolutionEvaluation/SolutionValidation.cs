using CompIntelligence_Coursework.Models;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.SolutionEvaluation
{
    public class SolutionValidation : ISolutionValidation
    {
        public bool IsValidSolution(Solution solution, IPieceLengthToQuantityLookup pieceLengthToQuantityLookup, IStockLengthToCostLookup stockLengthToCostLookup)
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
        private bool IsLengthOfSolutionValid(Solution solution, IPieceLengthToQuantityLookup pieceLengthToQuantityLookup)
        {
            double solutionLength = GetTotalLengthOfSolutionStockLengths(solution);
            double pieceLength = GetTotalOfPieceLengths(pieceLengthToQuantityLookup);

            if (solutionLength < pieceLength)
            {
                return false;
            }

            return true;
        }

        private bool IsSolutionOnlyFilledWithValidLengths(Solution solution, IStockLengthToCostLookup stockLengthToCostLookup)
        {
            foreach (KeyValuePair<double, double> currentSolution in solution.LengthToQuantity)
            {
                if (!stockLengthToCostLookup.LengthToCost.ContainsKey(currentSolution.Key))
                {
                    return false;
                }
            }

            return true;
        }

        private double GetTotalLengthOfSolutionStockLengths(Solution solution)
        {
            double totalLength = 0.0;

            foreach (KeyValuePair<double, double> currentSolution in solution.LengthToQuantity)
            {
                totalLength += currentSolution.Key * currentSolution.Value;
            }

            return totalLength;
        }

        private double GetTotalOfPieceLengths(IPieceLengthToQuantityLookup pieceLengthToQuantityLookup)
        {
            double totalLength = 0.0;

            foreach (KeyValuePair<double, double> currentSolution in pieceLengthToQuantityLookup.LengthToQuantity)
            {
                totalLength += currentSolution.Key * currentSolution.Value;
            }

            return totalLength;
        }
    }
}
