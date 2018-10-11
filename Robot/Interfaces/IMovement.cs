using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface IMovement
    {
        Coordinate CurrentCoordinate { get; set; }
        Direction CurrentDirection { get; set; }
        void RotateLeft();
        void RotateRight();
        void Move();
    }
}
