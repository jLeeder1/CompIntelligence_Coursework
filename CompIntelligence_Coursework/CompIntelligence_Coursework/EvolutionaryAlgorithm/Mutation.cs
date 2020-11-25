using CompIntelligence_Coursework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public class Mutation
    {
        
        public Solution MutateSolution(Solution solution)
        {
            Random random = new Random();

            if (random.NextDouble() < EvolutionaryAlgorithmConstants.MUTATION_CHANCE)
            {
                return solution;
            }

            return null;
        }

        /**
         * Seeks to look into the solutions offcuts and find one large enough that will accomodate another stock piece cut to remove a stock a stock piece from being used
         */
        private Solution SquashMutate(Solution solution, Random random)
        {
            int elementBeginIteratingAt = random.Next(0, solution.CutRecipes.Count - 1);
            bool isMutated = false;

            while(isMutated == false)
            {
                CutRecipe currentCutRecipe = solution.CutRecipes.ElementAt(elementBeginIteratingAt);

                if(currentCutRecipe.OffCut == 0)
                {
                    continue;
                }

                double currentCutRecipeOffCut = currentCutRecipe.OffCut;

                for(int index = 0; index <= solution.CutRecipes.Count - 1; index++)
                {
                    CutRecipe potentialCutRecipeToChange = solution.CutRecipes.ElementAt(index);
                    if (potentialCutRecipeToChange.OffCut == 0)
                    {
                        continue;
                    }

                    if(currentCutRecipeOffCut >= potentialCutRecipeToChange.OriginalStockItemUsed.StockLength - potentialCutRecipeToChange.PositionsToCutAt.Last())
                    {

                    }
                }

            }
            return null;
        }
    }
}
