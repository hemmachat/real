using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface ICommandParser
    {
        (RobotCommandType, Coordinate, Direction) Parse(string line);
    }
}
