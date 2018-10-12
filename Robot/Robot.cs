using Robot.Interfaces;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Robot : IRobot
    {
        private readonly IMovement _movement;
        private bool _hasPlaced;

        public Robot(IMovement movement)
        {
            _movement = movement;
        }

        public void Place(Coordinate coordinate, Direction direction)
        {
            if (Table.HasValidCoordinate(coordinate))
            {
                _hasPlaced = true;
                _movement.CurrentCoordinate = coordinate;
                _movement.CurrentDirection = direction;
            }
        }

        public void Left()
        {
            if (CanExecuteCommand())
            {
                _movement.RotateLeft();
            }
        }

        public void Right()
        {
            if (CanExecuteCommand())
            {
                _movement.RotateRight();
            }
        }

        public void Move()
        {
            if (CanExecuteCommand())
            {
                _movement.Move();
            }
        }

        public string Report()
        {
            if (CanExecuteCommand())
            {
                return $"{_movement.CurrentCoordinate.X}, {_movement.CurrentCoordinate.Y}, {_movement.CurrentDirection.ToString().ToUpper()}";
            }

            return string.Empty;
        }

        private bool CanExecuteCommand()
        {
            return _hasPlaced && Table.HasValidCoordinate(_movement.CurrentCoordinate);
        }
    }
}
