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
        private Coordinate _currentCoordinate;

        public Direction CurrentDirection { get; set; }

        public Movement()
        {
            CurrentDirection = Direction.North;
            _currentCoordinate = new Coordinate(0, 0);
        }

        public Movement(Coordinate coordinate, Direction direction)
        {
            CurrentDirection = direction;
            _currentCoordinate = coordinate;
        }

        public Movement(Direction direction)
        {
            CurrentDirection = direction;
            _currentCoordinate = new Coordinate(0, 0);
        }

        public void Move()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    if (_currentCoordinate.Y != MAX_Y)
                    {
                        _currentCoordinate.Y = _currentCoordinate.Y + 1;
                    }
                    break;

                case Direction.West:
                    if (_currentCoordinate.X != MIN_X)
                    {
                        _currentCoordinate.X = _currentCoordinate.X - 1;
                    }
                    break;

                case Direction.South:
                    if (_currentCoordinate.Y != MIN_Y)
                    {
                        _currentCoordinate.Y = _currentCoordinate.Y - 1;
                    }
                    break;

                case Direction.East:
                    if (_currentCoordinate.X != MAX_X)
                    {
                        _currentCoordinate.X = _currentCoordinate.X + 1;
                    }
                    break;

                default:
                    break;
            }
        }

        public Direction CurrentFacing()
        {
            return CurrentDirection;
        }

        public Coordinate CurrentCoordinate()
        {
            return _currentCoordinate;
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
