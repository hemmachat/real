using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Robot.Models;

namespace Robot
{
    public class RobotController : IRobotController
    {
        private readonly IRobot _robot;
        private readonly IUserInput _input;
        private readonly IUserOutput _output;
        private readonly ICommandParser _commandParser;

        public RobotController(IRobot robot, IUserInput input, IUserOutput output, ICommandParser commandParser)
        {
            _robot = robot;
            _input = input;
            _output = output;
            _commandParser = commandParser;
        }

        /// <summary>
        /// Main application
        /// </summary>
        public void Run()
        {
            var line = _input.ReadLine();

            // type 'q' or empty line to quit
            while (line != null && line != "q" && line != "")
            {
                var command = _commandParser.Parse(line);

                switch (command.Item1)
                {
                    case RobotCommandType.Place:
                        _robot.Place(command.Item2, command.Item3);
                        break;

                    case RobotCommandType.Move:
                        _robot.Move();
                        break;

                    case RobotCommandType.Left:
                        _robot.Left();
                        break;

                    case RobotCommandType.Right:
                        _robot.Right();
                        break;

                    case RobotCommandType.Report:
                        _output.ShowMessage(_robot.Report());
                        break;

                    default:
                        _output.ShowMessage("Bad command or filename.");
                        break;
                }

                line = _input.ReadLine();
            }
        }
    }
}
