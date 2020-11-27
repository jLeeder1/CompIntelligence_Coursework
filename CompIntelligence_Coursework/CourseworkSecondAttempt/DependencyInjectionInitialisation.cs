using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseworkSecondAttempt
{
    class DependencyInjectionInitialisation
    {
        public IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // Menu
            builder.RegisterType<MainMenu>();

            return builder.Build();
        }
    }
}
