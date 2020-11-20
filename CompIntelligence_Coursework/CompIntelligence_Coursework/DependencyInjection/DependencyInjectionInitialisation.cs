using Autofac;
using CompIntelligence_Coursework.EvolutionaryAlgorithm;
using CompIntelligence_Coursework.Helpers;
using CompIntelligence_Coursework.Menu;
using CompIntelligence_Coursework.Models;
using CompIntelligence_Coursework.RandomGenerator;
using CompIntelligence_Coursework.SolutionEvaluation;
using CompIntelligence_Coursework.solutionEveluation;
using System.Linq;
using System.Reflection;

namespace CompIntelligence_Coursework.DependencyInjection
{
    public class DependencyInjectionInitialisation
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Evolutionary Algorithms
            builder.RegisterType<ParentSelection>().As<IParentSelection>();

            // Helpers
            builder.RegisterType<SolutionStrategyFactory>().As<ISolutionStrategyFactory>();


            // Menu
            builder.RegisterType<MainMenu>();


            // Models
            // Setup to use the same object each time not a new object
            IOrderItems pieceLengthToQuantityLookup = new OrderItems();
            IStockItems stockLengthToCostLookup = new StockItems();

            builder.RegisterInstance(pieceLengthToQuantityLookup).As<IOrderItems>();
            builder.RegisterInstance(stockLengthToCostLookup).As<IStockItems>();

            // PSO

            // Random solution generation
            builder.RegisterType<RandomSolutionGenerator>().As<IRandomSolutionGenerator>();

            // Solution evaluation
            builder.RegisterType<SolutionEvaluator>().As<ISolutionEvaluator>();
            builder.RegisterType<SolutionValidation>().As<ISolutionValidation>();

            /* This is a icer way of doing the above without having to add every mapping explicitly BUT if no interface exists for a class then it breaks
             * Optins are to look more into logic or to use this only on folders where there is a guarenteed interface to implementation mapping
             * Classes like constants could be pulled out into their own folder? Same for factory
             * Leaving for now as this is not a prioirity in this coursework
             * If this does get used in the future note that you need the usings: linq and reflection
             * 
            builder.RegisterAssemblyTypes(Assembly.Load(nameof(CompIntelligence_Coursework)))
                .Where(t => t.Namespace.Contains(nameof(SolutionEvaluation)))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));
            */

            return builder.Build();
        }
    }
}


