using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Movement : IMovement
    {
        private Direction currentDirection;

        public Movement()
        {
            currentDirection = Direction.North;
        }

        public Direction CurrentFacing()
        {
            return currentDirection;
        }

        public void RotateLeft()
        {
            int newDirection = (int)currentDirection << 1;

            if (IsBitOverflow(newDirection))
            {
                currentDirection = Direction.East;
            }
            else
            {
                AssignNewDirection((Direction)newDirection);
            }
        }

        public void RotateRight()
        {
            int newDirection = (int)currentDirection >> 1;

            if (IsBitOverflow(newDirection))
            {
                currentDirection = Direction.South;
            }
            else
            {
                AssignNewDirection((Direction)newDirection);
            }
        }

        private bool IsBitOverflow(int value)
        {
            return value == 0;
        }

        private void AssignNewDirection(Direction newDirection)
        {
            currentDirection = newDirection;
        }
    }
}
