using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface IRobot
    {
        void Move();
        void Place(Coordinate coordinate, Direction direction);
        void Report();
        void Left();
        void Right();

    }
}
