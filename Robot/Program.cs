using Autofac;
using Robot.Interfaces;
using System;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();
                app.Run();
            }
        }

        /// <summary>
        /// Configure all necessary classes for the application
        /// </summary>
        /// <returns></returns>
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Application>().As<IApplication>();

            return builder.Build();
        }
    }
}
