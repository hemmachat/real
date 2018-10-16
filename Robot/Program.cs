using Autofac;
using Robot.Interfaces;
using System;

namespace Robot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var container = ConfigureContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IRobotController>();
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
            builder.RegisterType<CommandParser>().As<ICommandParser>();
            builder.RegisterType<ConsoleInput>().As<IUserInput>();
            builder.RegisterType<ConsoleOutput>().As<IUserOutput>();
            builder.RegisterType<Movement>().As<IMovement>();
            builder.RegisterType<Robot>().As<IRobot>();
            builder.RegisterType<RobotController>().As<IRobotController>();

            return builder.Build();
        }
    }
}
