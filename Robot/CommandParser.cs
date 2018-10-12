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

        public (RobotCommandType, string[]) Parse(string line)
        {
            line = line.Trim().ToLower();

            if (line.StartsWith(PLACE))
            {
                var parameters = line.Substring(PLACE.Length + 1).Trim().Split(',');

                if (parameters.Length != 3)
                {
                    return (RobotCommandType.Invalid, null);
                }

                Coordinate coordinate;

                if (!HasValidCoordinate(parameters[0], parameters[1], out coordinate))
                {
                    return (RobotCommandType.Invalid, null);
                }

                if (!HasValidDirection(parameters[2]))
                {
                    return (RobotCommandType.Invalid, null);
                }

                return (RobotCommandType.Place, new string[] { "P" } );
            }
            else if (line.Equals("move"))
            {
                return (RobotCommandType.Move, null);
            }
            else if (line.Equals("left"))
            {
                return (RobotCommandType.Left, null);
            }
            else if (line.Equals("right"))
            {
                return (RobotCommandType.Right, null);
            }
            else if (line.Equals("report"))
            {
                return (RobotCommandType.Report, null);
            }

            return (RobotCommandType.Invalid, null);
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

        private bool HasValidDirection(string value)
        {
            foreach (var direction in Enum.GetValues(typeof(Direction)))
            {
                var d = (string)direction;

                if (d.Equals(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
