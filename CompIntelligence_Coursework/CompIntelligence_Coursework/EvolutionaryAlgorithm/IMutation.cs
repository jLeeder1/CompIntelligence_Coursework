using CompIntelligence_Coursework.Models;

namespace CompIntelligence_Coursework.EvolutionaryAlgorithm
{
    public interface IMutation
    {
        void MutateSolution(Solution solution);
    }
}