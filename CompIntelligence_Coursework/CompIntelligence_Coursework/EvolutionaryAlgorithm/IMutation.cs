using CompIntelligence_Coursework.Models;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public interface IMutation
    {
        double SumOfCostOfMutatedIndividuals { get; set; }
        void MutateSolution(Solution solution);
    }
}