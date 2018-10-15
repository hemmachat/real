using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    /// <summary>
    /// Movement class to move or rotate the robot
    /// </summary>
    public class Movement : IMovement
    {
        /// <summary>
        /// One step to move at a time
        /// </summary>
        private const int ONE_STEP = 1;

        /// <summary>
        /// Current coordinate
        /// </summary>
        public Coordinate CurrentCoordinate { get; set; }

        /// <summary>
        /// Current facing direction
        /// </summary>
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

        /// <summary>
        /// Make a move by one step
        /// </summary>
        public void Move()
        {
            switch (CurrentDirection)
            {
                case Direction.North:
                    if (Table.CanMoveNorth(CurrentCoordinate))
                    {
                        CurrentCoordinate.Y = CurrentCoordinate.Y + ONE_STEP;
                    }
                    break;

                case Direction.West:
                    if (Table.CanMoveWest(CurrentCoordinate))
                    {
                        CurrentCoordinate.X = CurrentCoordinate.X - ONE_STEP;
                    }
                    break;

                case Direction.South:
                    if (Table.CanMoveSouth(CurrentCoordinate))
                    {
                        CurrentCoordinate.Y = CurrentCoordinate.Y - ONE_STEP;
                    }
                    break;

                case Direction.East:
                    if (Table.CanMoveEast(CurrentCoordinate))
                    {
                        CurrentCoordinate.X = CurrentCoordinate.X + ONE_STEP;
                    }
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Rotate left
        /// </summary>
        public void RotateLeft()
        {
            ChangeDirection(ShiftLeft(CurrentDirection));
        }

        /// <summary>
        /// Rotate right
        /// </summary>
        public void RotateRight()
        {
            ChangeDirection(ShiftRight(CurrentDirection), false);
        }

        /// <summary>
        /// Change the direction
        /// </summary>
        /// <param name="direction">Direction to rotate</param>
        /// <param name="turningLeft">If turning left</param>
        private void ChangeDirection(Direction direction, bool turningLeft = true)
        {
            if (IsBitOverflow(direction))
            {
                if (turningLeft)
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

        /// <summary>
        /// Check if the direction will overflow the bit operation
        /// </summary>
        /// <param name="direction">Direction to check</param>
        /// <returns>True if the direction will be overflow</returns>
        private bool IsBitOverflow(Direction direction)
        {
            return direction < Direction.East || direction > Direction.South;
        }

        /// <summary>
        /// Make the direction's bit shift to left
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>A new direction</returns>
        private Direction ShiftLeft(Direction direction)
        {
            return (Direction)((int)direction << 1);
        }

        /// <summary>
        /// Make the direction's bit shift to right
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>A new direction</returns>
        private Direction ShiftRight(Direction direction)
        {
            return (Direction)((int)direction >> 1);
        }
    }
}
