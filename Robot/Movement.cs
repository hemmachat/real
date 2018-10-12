using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Movement : IMovement
    {
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
                    if (Table.CanMoveNorth(CurrentCoordinate))
                    {
                        CurrentCoordinate.Y = CurrentCoordinate.Y + 1;
                    }
                    break;

                case Direction.West:
                    if (Table.CanMoveWest(CurrentCoordinate))
                    {
                        CurrentCoordinate.X = CurrentCoordinate.X - 1;
                    }
                    break;

                case Direction.South:
                    if (Table.CanMoveSouth(CurrentCoordinate))
                    {
                        CurrentCoordinate.Y = CurrentCoordinate.Y - 1;
                    }
                    break;

                case Direction.East:
                    if (Table.CanMoveEast(CurrentCoordinate))
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
            ChangeDirection(ShiftLeft(CurrentDirection));
        }

        public void RotateRight()
        {
            ChangeDirection(ShiftRight(CurrentDirection), false);
        }

        private void ChangeDirection(Direction direction, bool isLeft = true)
        {
            if (IsBitOverflow(direction))
            {
                if (isLeft)
                {
                    CurrentDirection = Direction.East;
                }
                else
                {
                    CurrentDirection = Direction.South;
                }
            }
            else
            {
                CurrentDirection = direction;
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
