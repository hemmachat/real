using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public struct Coordinate
    {
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
