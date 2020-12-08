namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public interface IAdptiveChanceAdjuster
    {
        void AdjustMutationRecombinationChances(double recombinationSum, double mutationSum);
    }
}