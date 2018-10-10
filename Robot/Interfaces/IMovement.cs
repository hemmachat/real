using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface IMovement
    {
        void RotateLeft();
        void RotateRight();
        Direction CurrentFacing();

    }
}
