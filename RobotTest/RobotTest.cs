using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Moq;
using Robot.Interfaces;
using Robot;

namespace RobotTest
{
    public class RobotTest
    {
        private readonly Mock<IMovement> _mock;
        private readonly IRobot _robot;

        public RobotTest()
        {
            var factory = new MockRepository(MockBehavior.Loose);
            _mock = factory.Create<IMovement>();
            _robot = new Robot.Robot(_mock.Object);
        }

        [Fact]
        public void Example_A()
        {
            _mock.SetupGet(_ => _.CurrentCoordinate).Returns(new Robot.Models.Coordinate(0, 1));
            _mock.SetupGet(_ => _.CurrentDirection).Returns(Robot.Models.Direction.North);

            _robot.Place(new Robot.Models.Coordinate(0, 0), Robot.Models.Direction.North);
            _robot.Move();

            _robot.Report().Should().BeEquivalentTo("0, 1, NORTH");
        }

        [Fact]
        public void Example_B()
        {
            _mock.SetupGet(_ => _.CurrentCoordinate).Returns(new Robot.Models.Coordinate(0, 0));
            _mock.SetupGet(_ => _.CurrentDirection).Returns(Robot.Models.Direction.West);

            _robot.Place(new Robot.Models.Coordinate(0, 0), Robot.Models.Direction.North);
            _robot.Left();

            _robot.Report().Should().BeEquivalentTo("0, 0, WEST");
        }

        [Fact]
        public void Example_C()
        {
            _mock.SetupGet(_ => _.CurrentCoordinate).Returns(new Robot.Models.Coordinate(3, 3));
            _mock.SetupGet(_ => _.CurrentDirection).Returns(Robot.Models.Direction.North);

            _robot.Place(new Robot.Models.Coordinate(1, 2), Robot.Models.Direction.East);
            _robot.Move();
            _robot.Move();
            _robot.Left();
            _robot.Move();

            _robot.Report().Should().BeEquivalentTo("3, 3, NORTH");
        }
    }
}
