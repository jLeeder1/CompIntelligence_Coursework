using System;
using System.Collections.Generic;

namespace CompIntelligence_Coursework.Models
{
    /*
     * Holds a solution for an order including
     * - A list of CutRecipes detailing where to make cuts along what sotck item
     * - List of offcuts that can be used instead of cutting longer pieces
     * - The total cost of the soution calculated from the quantity of each stock item used
     */
    public class Solution
    {
        public List<CutRecipe> CutRecipes { get; set; }

        public double SolutionCost { get; set; }

        public Solution()
        {
            CutRecipes = new List<CutRecipe>();
        }
    }
}
