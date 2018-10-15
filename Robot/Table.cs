using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    /// <summary>
    /// Table class
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Constants for valid positions on the table
        /// </summary>
        const int MAX_Y = 4;
        const int MAX_X = 4;
        const int MIN_Y = 0;
        const int MIN_X = 0;

        /// <summary>
        /// Check if the coordinates are valid on the table
        /// </summary>
        /// <param name="coordinate">Coordinate to check</param>
        /// <returns>True if the coordinates are valid</returns>
        public static bool HasValidCoordinate(Coordinate coordinate)
        {
            if (coordinate.X < MIN_X || coordinate.X > MAX_X || coordinate.Y < MIN_Y || coordinate.Y > MAX_Y)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Check if we can move move north from the coordinate
        /// </summary>
        /// <param name="coordinate">Coordinate to check</param>
        /// <returns>True if we can move north</returns>
        public static bool CanMoveNorth(Coordinate coordinate)
        {
            return coordinate.Y != MAX_Y;
        }

        /// <summary>
        /// Check if we can move move west from the coordinate
        /// </summary>
        /// <param name="coordinate">Coordinate to check</param>
        /// <returns>True if we can move west</returns>
        public static bool CanMoveWest(Coordinate coordinate)
        {
            return coordinate.X != MIN_X;
        }

        /// <summary>
        /// Check if we can move move south from the coordinate
        /// </summary>
        /// <param name="coordinate">Coordinate to check</param>
        /// <returns>True if we can move south</returns>
        public static bool CanMoveSouth(Coordinate coordinate)
        {
            return coordinate.Y != MIN_Y;
        }

        /// <summary>
        /// Check if we can move move south from the coordinate
        /// </summary>
        /// <param name="coordinate">Coordinate to check</param>
        /// <returns>True if we can move south</returns>
        public static bool CanMoveEast(Coordinate coordinate)
        {
            return coordinate.X != MAX_X;
        }
    }
}
