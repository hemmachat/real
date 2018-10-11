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
        public Coordinate CurrentCoordinate { get; set; }

        public Direction CurrentDirection { get; set; }

        public Movement()
        {
            CurrentDirection = Direction.North;
            CurrentCoordinate = new Coordinate(0, 0);
        }

        public Movement(Coordinate coordinate, Direction direction)
        {
            CurrentDirection = direction;
            CurrentCoordinate = coordinate;
        }

        public Movement(Direction direction)
        {
            CurrentDirection = direction;
            CurrentCoordinate = new Coordinate(0, 0);
        }

        public void Move()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    if (CurrentCoordinate.Y != MAX_Y)
                    {
                        CurrentCoordinate.Y = CurrentCoordinate.Y + 1;
                    }
                    break;

                case Direction.West:
                    if (CurrentCoordinate.X != MIN_X)
                    {
                        CurrentCoordinate.X = CurrentCoordinate.X - 1;
                    }
                    break;

                case Direction.South:
                    if (CurrentCoordinate.Y != MIN_Y)
                    {
                        CurrentCoordinate.Y = CurrentCoordinate.Y - 1;
                    }
                    break;

                case Direction.East:
                    if (CurrentCoordinate.X != MAX_X)
                    {
                        CurrentCoordinate.X = CurrentCoordinate.X + 1;
                    }
                    break;

                default:
                    break;
            }
        }

        public void RotateLeft()
        {
            var newDirection = ShiftLeft(CurrentDirection);

            if (IsBitOverflow(newDirection))
            {
                CurrentDirection = Direction.East;
            }
            else
            {
                CurrentDirection = newDirection;
            }
        }

        public void RotateRight()
        {
            var newDirection = ShiftRight(CurrentDirection);

            if (IsBitOverflow(newDirection))
            {
                CurrentDirection = Direction.South;
            }
            else
            {
                CurrentDirection = newDirection;
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
