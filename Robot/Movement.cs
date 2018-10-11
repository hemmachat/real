using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Movement : IMovement
    {
        private Direction currentDirection;

        public Movement(Direction direction)
        {
            currentDirection = direction;
        }

        public void Move()
        {

        }

        public Direction CurrentFacing()
        {
            return currentDirection;
        }

        public void RotateLeft()
        {
            var newDirection = ShiftLeft(currentDirection);

            if (IsBitOverflow(newDirection))
            {
                currentDirection = Direction.East;
            }
            else
            {
                currentDirection = newDirection;
            }
        }

        public void RotateRight()
        {
            var newDirection = ShiftRight(currentDirection);

            if (IsBitOverflow(newDirection))
            {
                currentDirection = Direction.South;
            }
            else
            {
                currentDirection = newDirection;
            }
        }

        private bool IsBitOverflow(Direction direction)
        {
            return direction < Direction.East || direction > Direction.South;
        }

        private Direction ShiftLeft(Direction direction)
        {
            return (Direction)((int)direction << 1);
        }

        private Direction ShiftRight(Direction direction)
        {
            return (Direction)((int)direction >> 1);
        }
    }
}
