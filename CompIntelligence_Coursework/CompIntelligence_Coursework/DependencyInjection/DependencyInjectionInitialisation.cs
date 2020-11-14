using Autofac;
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
            // Setup to use the same object each time not a new object
            IPieceLengthToQuantityLookup pieceLengthToQuantityLookup = new PieceLengthToQuantityLookup();
            IStockLengthToCostLookup stockLengthToCostLookup = new StockLengthToCostLookup();

            var builder = new ContainerBuilder();

            builder.RegisterType<MainMenu>();
            builder.RegisterType<SolutionEvaluator>().As<ISolutionEvaluator>();
            builder.RegisterType<SolutionValidation>().As<ISolutionValidation>();

            builder.RegisterInstance(pieceLengthToQuantityLookup).As<IPieceLengthToQuantityLookup>();
            builder.RegisterInstance(stockLengthToCostLookup).As<IStockLengthToCostLookup>();

            return builder.Build();
        }
    }
}
