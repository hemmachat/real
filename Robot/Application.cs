using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Application : IApplication
    {
        private readonly IRobot _robot;
        private readonly IUserInput _input;
        private readonly IUserOutput _output;

        public Application(IRobot robot, IUserInput input, IUserOutput output)
        {
            _robot = robot;
            _input = input;
            _output = output;
        }

        public void Run()
        {
            _robot.Place(new Models.Coordinate(0, 0), Models.Direction.North);
            _robot.Move();
            _output.ShowMessage(_robot.Report());

            Console.ReadLine();
        }
    }
}
