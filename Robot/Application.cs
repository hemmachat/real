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
        private readonly ICommandParser _commandParser;

        public Application(IRobot robot, IUserInput input, IUserOutput output, ICommandParser commandParser)
        {
            _robot = robot;
            _input = input;
            _output = output;
            _commandParser = commandParser;
        }

        public void Run()
        {
            var line = _input.ReadLine();

            while (line != Environment.NewLine)
            {
                var command = _commandParser.Parse(line);

                switch (command.Item1)
                {
                    case Models.RobotCommandType.Place:
                        _robot.Place(new Models.Coordinate(0, 0), Models.Direction.North);
                        break;

                    case Models.RobotCommandType.Move:
                        _robot.Move();
                        break;

                    case Models.RobotCommandType.Left:
                        _robot.Left();
                        break;

                    case Models.RobotCommandType.Right:
                        _robot.Right();
                        break;

                    case Models.RobotCommandType.Report:
                        _output.ShowMessage(_robot.Report());
                        break;

                    default:
                        _output.ShowMessage("Bad command or filename.");
                        break;
                }
            }

            Console.ReadLine();
        }
    }
}
