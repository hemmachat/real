using Robot;
using Robot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(2, 1), m.CurrentCoordinate());
        }

        [Fact]
        public void Example_A()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 1), m.CurrentCoordinate());
        }

        [Fact]
        public void Example_B()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.North);
            m.RotateLeft();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 0), m.CurrentCoordinate());
        }

        [Fact]
        public void Example_C()
        {
            var m = new Movement(new Coordinate(1, 2), Direction.East);
            m.Move();
            m.Move();
            m.RotateLeft();
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(3, 3), m.CurrentCoordinate());
        }

        // origin-bottom-left
        [Fact]
        public void Origin_North_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 1) , m.CurrentCoordinate());
        }

        [Fact]
        public void Origin_East_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(1, 0), m.CurrentCoordinate());
        }

        [Fact]
        public void Origin_South_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 0), m.CurrentCoordinate());
        }

        [Fact]
        public void Origin_West_Move()
        {
            var m = new Movement(new Coordinate(0, 0), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 0), m.CurrentCoordinate());
        }

        // top-left
        [Fact]
        public void Top_Left_North_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 4), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Left_West_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 4), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Left_South_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 3), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Left_East_Move()
        {
            var m = new Movement(new Coordinate(0, 4), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(1, 4), m.CurrentCoordinate());
        }

        // top-right
        [Fact]
        public void Top_Right_North_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 4), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Right_West_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(3, 4), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Right_South_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 3), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Right_East_Move()
        {
            var m = new Movement(new Coordinate(4, 4), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 4), m.CurrentCoordinate());
        }

        // bottom-right
        [Fact]
        public void Bottom_Right_North_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 1), m.CurrentCoordinate());
        }

        [Fact]
        public void Bottom_Right_West_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(3, 0), m.CurrentCoordinate());
        }

        [Fact]
        public void Bottom_Right_South_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 0), m.CurrentCoordinate());
        }

        [Fact]
        public void Bottom_Right_East_Move()
        {
            var m = new Movement(new Coordinate(4, 0), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 0), m.CurrentCoordinate());
        }

        // center
        [Fact]
        public void Centre_North_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(2, 3), m.CurrentCoordinate());
        }

        [Fact]
        public void Centre_West_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(1, 2), m.CurrentCoordinate());
        }

        [Fact]
        public void Centre_South_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(2, 1), m.CurrentCoordinate());
        }

        [Fact]
        public void Centre_East_Move()
        {
            var m = new Movement(new Coordinate(2, 2), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(3, 2), m.CurrentCoordinate());
        }

        // top edge
        [Fact]
        public void Top_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(2, 4), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(1, 4), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(2, 3), m.CurrentCoordinate());
        }

        [Fact]
        public void Top_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(2, 4), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(3, 4), m.CurrentCoordinate());
        }

        // left edge
        [Fact]
        public void Left_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 3), m.CurrentCoordinate());
        }

        [Fact]
        public void Left_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 2), m.CurrentCoordinate());
        }

        [Fact]
        public void Left_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(0, 1), m.CurrentCoordinate());
        }

        [Fact]
        public void Left_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(0, 2), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(1, 2), m.CurrentCoordinate());
        }

        // bottom edge
        [Fact]
        public void Bottom_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(2, 1), m.CurrentCoordinate());
        }

        [Fact]
        public void Bottom_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(1, 0), m.CurrentCoordinate());
        }

        [Fact]
        public void Bottom_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(2, 0), m.CurrentCoordinate());
        }

        [Fact]
        public void Bottom_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(2, 0), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(3, 0), m.CurrentCoordinate());
        }

        // right edge
        [Fact]
        public void Right_Edge_North_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.North);
            m.Move();

            Assert.Equal(Direction.North, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 3), m.CurrentCoordinate());
        }

        [Fact]
        public void Right_Edge_West_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.West);
            m.Move();

            Assert.Equal(Direction.West, m.CurrentFacing());
            Assert.Equal(new Coordinate(3, 2), m.CurrentCoordinate());
        }

        [Fact]
        public void Right_Edge_South_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.South);
            m.Move();

            Assert.Equal(Direction.South, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 1), m.CurrentCoordinate());
        }

        [Fact]
        public void Right_Edge_East_Move()
        {
            var m = new Movement(new Coordinate(4, 2), Direction.East);
            m.Move();

            Assert.Equal(Direction.East, m.CurrentFacing());
            Assert.Equal(new Coordinate(4, 2), m.CurrentCoordinate());
        }
    }
}
