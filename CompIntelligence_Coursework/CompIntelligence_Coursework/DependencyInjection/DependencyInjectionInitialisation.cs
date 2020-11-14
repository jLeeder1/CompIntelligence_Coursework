using Autofac;
using CompIntelligence_Coursework.Menu;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;

namespace CompIntelligence_Coursework.DependencyInjection
{
    public class DependencyInjectionInitialisation
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<MainMenu>();
            builder.RegisterType<SolutionEvaluator>().As<ISolutionEvaluator>();
            builder.RegisterType<SolutionValidation>().As<ISolutionValidation>();

            return builder.Build();
        }
    }
}
