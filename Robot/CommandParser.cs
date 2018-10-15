using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Robot
{
    public class CommandParser : ICommandParser
    {
        private const string PLACE = "place";
        private const string MOVE = "move";
        private const string LEFT = "left";
        private const string RIGHT = "right";
        private const string REPORT = "report";

        public (RobotCommandType, Coordinate, Direction) Parse(string line)
        {
            line = line.Trim().ToLower();

            switch (line)
            {
                case var testLine when testLine.StartsWith(PLACE) && testLine.Length > PLACE.Length:
                    return PlaceCommand(line);

                case var testLine when testLine.Equals(MOVE):
                    return (RobotCommandType.Move, null, Direction.North);

                case var testLine when testLine.Equals(LEFT):
                    return (RobotCommandType.Left, null, Direction.North);

                case var testLine when testLine.Equals(RIGHT):
                    return (RobotCommandType.Right, null, Direction.North);

                case var testLine when testLine.Equals(REPORT):
                    return (RobotCommandType.Report, null, Direction.North);

                default:
                    return (RobotCommandType.Invalid, null, Direction.North);
            }
        }

        private (RobotCommandType, Coordinate, Direction) PlaceCommand(string line)
        {
            var parameters = line.Substring(PLACE.Length + 1).Trim().Split(',');

            if (parameters.Length != 3)
            {
                return InvalidCommand();
            }

            if (!HasValidCoordinate(parameters[0].Trim(), parameters[1].Trim(), out Coordinate coordinate))
            {
                return InvalidCommand();
            }

            if (!HasValidDirection(parameters[2].Trim(), out Direction direction))
            {
                return InvalidCommand();
            }

            return (RobotCommandType.Place, coordinate, direction);
        }

        private (RobotCommandType, Coordinate, Direction) InvalidCommand()
        {
            return (RobotCommandType.Invalid, null, Direction.North);
        }

        private bool HasValidCoordinate(string param1, string param2, out Coordinate coordinate)
        {
            int x = 0;
            int y = 0;
            coordinate = null;

            if (!int.TryParse(param1, out x) || !int.TryParse(param2, out y))
            {
                return false;
            }

            coordinate = new Coordinate(x, y);

            return true;
        }

        private bool HasValidDirection(string value, out Direction direction)
        {
            direction = Direction.North;

            foreach (var di in Enum.GetValues(typeof(Direction)))
            {
                if (((Direction)di).ToString().ToLower().Equals(value))
                {
                    direction = (Direction)di;

                    return true;
                }
            }

            return false;
        }
    }
}
