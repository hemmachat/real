using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    /// <summary>
    /// A robot class to control the movement
    /// </summary>
    public class Robot : IRobot
    {
        /// <summary>
        /// Movement of the robot
        /// </summary>
        private readonly IMovement _movement;

        /// <summary>
        /// A flag to check if the robot has been placed on the table
        /// </summary>
        private bool _hasPlaced;

        public Robot(IMovement movement)
        {
            _movement = movement;
        }

        /// <summary>
        /// Placing a robot on the table
        /// </summary>
        /// <param name="coordinate">Coordinate</param>
        /// <param name="direction">Facing direction</param>
        public void Place(Coordinate coordinate, Direction direction)
        {
            if (Table.HasValidCoordinate(coordinate))
            {
                _hasPlaced = true;
                _movement.CurrentCoordinate = coordinate;
                _movement.CurrentDirection = direction;
            }
        }

        /// <summary>
        /// Rotate left
        /// </summary>
        public void Left()
        {
            if (CanExecuteCommand())
            {
                _movement.RotateLeft();
            }
        }

        /// <summary>
        /// Rotate right
        /// </summary>
        public void Right()
        {
            if (CanExecuteCommand())
            {
                _movement.RotateRight();
            }
        }

        /// <summary>
        /// Move the robot
        /// </summary>
        public void Move()
        {
            if (CanExecuteCommand())
            {
                _movement.Move();
            }
        }

        /// <summary>
        /// Report the current coordinate and the facing direction
        /// </summary>
        /// <returns></returns>
        public string Report()
        {
            if (CanExecuteCommand())
            {
                return $"{_movement.CurrentCoordinate.X},{_movement.CurrentCoordinate.Y},{_movement.CurrentDirection.ToString().ToUpper()}";
            }

            return string.Empty;
        }

        /// <summary>
        /// Check if the robot has been placed on the table and has a valid coordinate hence the command can be executed
        /// </summary>
        /// <returns>True if the command can be executed</returns>
        private bool CanExecuteCommand()
        {
            return _hasPlaced && Table.HasValidCoordinate(_movement.CurrentCoordinate);
        }
    }
}
