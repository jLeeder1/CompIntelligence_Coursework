using CompIntelligence_Coursework.Models;

namespace CompIntelligence_Coursework.Helpers
{
    public interface ISolutionStrategyFactory
    {
        ISolutionFinderStrategy GetSolutionFinderStrategy(SolutionStrategyTypes solutionStrategyTypes);
    }
}