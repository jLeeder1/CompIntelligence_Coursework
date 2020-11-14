﻿using CompIntelligence_Coursework.Models;

namespace CompIntelligence_Coursework.SolutionEvaluation
{
    public interface ISolutionValidation
    {
        bool IsValidSolution(Solution solution, PieceLengthToQuantityLookup pieceLengthToQuantityLookup, StockLengthToCostLookup stockLengthToCostLookup);
    }
}