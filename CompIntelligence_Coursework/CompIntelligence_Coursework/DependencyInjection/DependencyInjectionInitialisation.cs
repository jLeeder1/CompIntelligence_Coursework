using Autofac;
using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Menu;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;

namespace CompIntelligence_Coursework.DependencyInjection
{
    public class DependencyInjectionInitialisation
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Helpers
            builder.RegisterType<SolutionStrategyFactory>().As<ISolutionStrategyFactory>();

            // Menu
            builder.RegisterType<MainMenu>();

            // Models
            // Setup to use the same object each time not a new object
            IPieceLengthToQuantityLookup pieceLengthToQuantityLookup = new PieceLengthToQuantityLookup();
            IStockLengthToCostLookup stockLengthToCostLookup = new StockLengthToCostLookup();

            builder.RegisterInstance(pieceLengthToQuantityLookup).As<IPieceLengthToQuantityLookup>();
            builder.RegisterInstance(stockLengthToCostLookup).As<IStockLengthToCostLookup>();

            // PSO

            // Solution evaluation
            builder.RegisterType<SolutionEvaluator>().As<ISolutionEvaluator>();
            builder.RegisterType<SolutionValidation>().As<ISolutionValidation>();

            return builder.Build();
        }
    }
}
