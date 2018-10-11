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

        public Robot(IMovement movement)
        {
            _movement = movement;
        }

        public void Place(Coordinate coordinate, Direction direction)
        {
            
        }

        public void Left()
        {
            _movement.RotateLeft();
        }

        public void Right()
        {
            _movement.RotateRight();
        }

        public void Move()
        {
            _movement.Move();
        }

        public void Report()
        {
            throw new NotImplementedException();
        }
    }
}
