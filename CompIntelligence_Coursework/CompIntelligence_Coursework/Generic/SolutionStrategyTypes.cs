using System.ComponentModel;

namespace CompIntelligence_Coursework.Helpers
{
    public enum SolutionStrategyTypes
    {
        [Description("End_Program")]
        DefaultStrategy,

        [Description("Random_Solution")]
        RandomSolutionStrategy,

        [Description("PSO_Solution")]
        PSOSolutionStrategy,

        [Description("EVO_Solution")]
        EVOSolutionStrategy,

        [Description("Generate_Test_Results")]
        GenerateTestResults,

        [Description("Generate_Random_Test_Results")]
        GenerateRandomTestResults
    }
}
