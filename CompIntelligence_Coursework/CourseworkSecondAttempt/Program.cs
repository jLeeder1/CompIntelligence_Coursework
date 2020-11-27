using System;

namespace CourseworkSecondAttempt
{
    class Program
    {
        static void Main(string[] args)
        {
            DependencyInjectionInitialisation dependencyInjection = new DependencyInjectionInitialisation();
            var container = dependencyInjection.BuildContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                scope.Resolve<MainMenu>().RunMenu();
            }
        }
    }
}
