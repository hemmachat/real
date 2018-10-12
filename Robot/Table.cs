using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Table
    {
        const int MAX_Y = 4;
        const int MAX_X = 4;
        const int MIN_Y = 0;
        const int MIN_X = 0;

        public static bool HasValidCoordinate(Coordinate coordinate)
        {
            if (coordinate.X < MIN_X || coordinate.X > MAX_X || coordinate.Y < MIN_Y || coordinate.Y > MAX_Y)
            {
                return false;
            }

            return true;
        }

        public static bool CanMoveNorth(Coordinate coordinate)
        {
            return coordinate.Y != MAX_Y;
        }

        public static bool CanMoveWest(Coordinate coordinate)
        {
            return coordinate.X != MIN_X;
        }

        public static bool CanMoveSouth(Coordinate coordinate)
        {
            return coordinate.Y != MIN_Y;
        }

        public static bool CanMoveEast(Coordinate coordinate)
        {
            return coordinate.X != MAX_X;
        }
    }
}
