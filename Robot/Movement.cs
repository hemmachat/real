using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Movement : IMovement
    {
        const int MAX_Y = 4;
        const int MAX_X = 4;
        const int MIN_Y = 0;
        const int MIN_X = 0;

        private Direction currentDirection;
        private Coordinate currentCoordinate;

        public Movement()
        {
            currentDirection = Direction.North;
            currentCoordinate = new Coordinate(0, 0);
        }

        public Movement(Coordinate coordinate, Direction direction)
        {
            currentDirection = direction;
            currentCoordinate = coordinate;
        }

        public Movement(Direction direction)
        {
            currentDirection = direction;
            currentCoordinate = new Coordinate(0, 0);
        }

        public void Move()
        {
            switch (currentDirection)
            {
                case Direction.North:
                    if (currentCoordinate.Y != MAX_Y)
                    {
                        currentCoordinate.Y = currentCoordinate.Y + 1;
                    }
                    break;

                case Direction.West:
                    if (currentCoordinate.X != MIN_X)
                    {
                        currentCoordinate.X = currentCoordinate.X - 1;
                    }
                    break;

                case Direction.South:
                    if (currentCoordinate.Y != MIN_Y)
                    {
                        currentCoordinate.Y = currentCoordinate.Y - 1;
                    }
                    break;

                case Direction.East:
                    if (currentCoordinate.X != MAX_X)
                    {
                        currentCoordinate.X = currentCoordinate.X + 1;
                    }
                    break;

                default:
                    break;
            }
        }

        public Direction CurrentFacing()
        {
            return currentDirection;
        }

        public Coordinate CurrentCoordinate()
        {
            return currentCoordinate;
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
