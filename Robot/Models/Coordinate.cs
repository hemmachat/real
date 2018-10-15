using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Models
{
    public class Coordinate
    {
        /// <summary>
        /// Coordinate
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
