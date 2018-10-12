using Robot;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace RobotTest
{
    public class MovementMoveTest
    {
        // multiple moves and rotates
        [Fact]
        public void North_Multiple_Moves()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.North);
            m.Move();
            m.Move();
            m.RotateLeft();
            m.Move();
            m.Move();
            m.RotateLeft();
            m.RotateLeft();
            m.Move();
            m.Move();
            m.RotateRight();
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(2, 1));
        }

        [Fact]
        public void Example_A()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 1));
        }

        [Fact]
        public void Example_B()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.North);
            m.RotateLeft();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 0));
        }

        [Fact]
        public void Example_C()
        {
            var m = new Movement(new Coordinate(1, 2), Direction.East);
            m.Move();
            m.Move();
            m.RotateLeft();
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(3, 3));
        }

        // origin-bottom-left
        [Fact]
        public void Origin_North_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 1));
        }

        [Fact]
        public void Origin_East_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(1, 0));
        }

        [Fact]
        public void Origin_South_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 0));
        }

        [Fact]
        public void Origin_West_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 0));
        }

        // top-left
        [Fact]
        public void Top_Left_North_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 4));
        }

        [Fact]
        public void Top_Left_West_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 4));
        }

        [Fact]
        public void Top_Left_South_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 3));
        }

        [Fact]
        public void Top_Left_East_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(1, 4));
        }

        // top-right
        [Fact]
        public void Top_Right_North_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 4));
        }

        [Fact]
        public void Top_Right_West_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(3, 4));
        }

        [Fact]
        public void Top_Right_South_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 3));
        }

        [Fact]
        public void Top_Right_East_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 4));
        }

        // bottom-right
        [Fact]
        public void Bottom_Right_North_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 1));
        }

        [Fact]
        public void Bottom_Right_West_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(3, 0));
        }

        [Fact]
        public void Bottom_Right_South_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 0));
        }

        [Fact]
        public void Bottom_Right_East_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 0));
        }

        // center
        [Fact]
        public void Centre_North_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(2, 3));
        }

        [Fact]
        public void Centre_West_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(1, 2));
        }

        [Fact]
        public void Centre_South_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(2, 1));
        }

        [Fact]
        public void Centre_East_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(3, 2));
        }

        // top edge
        [Fact]
        public void Top_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(2, 4));
        }

        [Fact]
        public void Top_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(1, 4));
        }

        [Fact]
        public void Top_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(2, 3));
        }

        [Fact]
        public void Top_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(3, 4));
        }

        // left edge
        [Fact]
        public void Left_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 3));
        }

        [Fact]
        public void Left_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 2));
        }

        [Fact]
        public void Left_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(0, 1));
        }

        [Fact]
        public void Left_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(1, 2));
        }

        // bottom edge
        [Fact]
        public void Bottom_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(2, 1));
        }

        [Fact]
        public void Bottom_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(1, 0));
        }

        [Fact]
        public void Bottom_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(2, 0));
        }

        [Fact]
        public void Bottom_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(3, 0));
        }

        // right edge
        [Fact]
        public void Right_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 3));
        }

        [Fact]
        public void Right_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(3, 2));
        }

        [Fact]
        public void Right_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 1));
        }

        [Fact]
        public void Right_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentDirection);
            m.CurrentCoordinate.Should().BeEquivalentTo(new Coordinate(4, 2));
        }
    }
}
