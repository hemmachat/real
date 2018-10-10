using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Table : ITable
    {
        Coordinate minCoordinate = new Coordinate(0, 0);
        Coordinate maxCoordinate = new Coordinate(4, 4);
        Coordinate currentCoordinate = new Coordinate(0, 0);

        public void Place(Coordinate coordinate)
        {
            currentCoordinate = coordinate;
        }

        public void IsInRange()
        {
            throw new NotImplementedException();
        }
    }
}
