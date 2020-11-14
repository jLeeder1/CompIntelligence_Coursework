using Autofac;
using CompIntelligence_Coursework.DependencyInjection;
using CompIntelligence_Coursework.Menu;

namespace CompIntelligence_Coursework
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjectionInitialisation dependencyInjection = new DependencyInjectionInitialisation();
            var container = dependencyInjection.BuildContainer();

            using(var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<MainMenu>().RunMenu();
            }
        }
    }
}
