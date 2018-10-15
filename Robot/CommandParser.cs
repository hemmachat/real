using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Robot
{
    /// <summary>
    /// A class to parse input string into different command types
    /// </summary>
    public class CommandParser : ICommandParser
    {
        /// <summary>
        /// Constants for different types of command string
        /// </summary>
        private const string PLACE = "place";
        private const string MOVE = "move";
        private const string LEFT = "left";
        private const string RIGHT = "right";
        private const string REPORT = "report";
        private const char SEPARATOR = ',';
        private const int VALID_NUMBER_OF_PARAMS = 3;
        private const int X_COORDINATE_ARRAY_POSITION = 0;
        private const int Y_COORDINATE_ARRAY_POSITION = 1;
        private const int DIRECTION_ARRAY_POSITION = 2;
        private const int PARAMETERS_POSITION = 1;

        /// <summary>
        /// Parse command string
        /// </summary>
        /// <param name="line">Input string</param>
        /// <returns>Command type</returns>
        public (RobotCommandType, Coordinate, Direction) Parse(string line)
        {
            line = line.Trim().ToLower();

            switch (line)
            {
                case var testLine when testLine.StartsWith(PLACE) && testLine.Length > PLACE.Length:
                    return ExtractPlaceCommand(line);

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

        /// <summary>
        /// Extract parameters for 'PLACE' command
        /// </summary>
        /// <param name="line">String command</param>
        /// <returns>PLACE command type, coordinate, direction</returns>
        private (RobotCommandType, Coordinate, Direction) ExtractPlaceCommand(string line)
        {
            int parametersStartIndex = PLACE.Length + PARAMETERS_POSITION;
            var parameters = line.Substring(parametersStartIndex).Trim().Split(SEPARATOR);

            if (parameters.Length != VALID_NUMBER_OF_PARAMS)
            {
                return InvalidCommand();
            }

            if (!HasValidCoordinate(parameters[X_COORDINATE_ARRAY_POSITION].Trim(), parameters[Y_COORDINATE_ARRAY_POSITION].Trim(), out Coordinate coordinate))
            {
                return InvalidCommand();
            }

            if (!HasValidDirection(parameters[DIRECTION_ARRAY_POSITION].Trim(), out Direction direction))
            {
                return InvalidCommand();
            }

            return (RobotCommandType.Place, coordinate, direction);
        }

        /// <summary>
        /// Show invalid command
        /// </summary>
        /// <returns>Invalid command type</returns>
        private (RobotCommandType, Coordinate, Direction) InvalidCommand()
        {
            return (RobotCommandType.Invalid, null, Direction.North);
        }

        /// <summary>
        /// Check if the input command has a valid coordinates for x and y
        /// </summary>
        /// <param name="param1">X coordinate</param>
        /// <param name="param2">Y coordinate</param>
        /// <param name="coordinate">Output of the valid coordinates</param>
        /// <returns>True if coordinates are valid</returns>
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

        /// <summary>
        /// Check if the input command has a valid direction
        /// </summary>
        /// <param name="value">String value of direction</param>
        /// <param name="direction">Output of the valid direction</param>
        /// <returns>True if the direction is valid</returns>
        private bool HasValidDirection(string value, out Direction direction)
        {
            direction = Direction.North;

            foreach (var di in Enum.GetValues(typeof(Direction)))
            {
                var d = ((Direction)di).ToString().ToLower();

                if (d.Equals(value))
                {
                    direction = (Direction)di;

                    return true;
                }
            }

            return false;
        }
    }
}
