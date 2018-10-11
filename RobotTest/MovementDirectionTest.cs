using Robot;
using Robot.Models;
using System;
using Xunit;

namespace RobotTest
{
    public class MovementDirectionTest
    {
        // North
        [Fact]
        public void North_Left_West()
        {
            var m = new Movement(Direction.North);
            m.RotateLeft();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void North_Left_Right_North()
        {
            var m = new Movement(Direction.North);
            m.RotateLeft();
            m.RotateRight();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void North_Left_Left_South()
        {
            var m = new Movement(Direction.North);
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void North_Left_Left_Left_East()
        {
            var m = new Movement(Direction.North);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void North_Left_Left_Left_Left_North()
        {
            var m = new Movement(Direction.North);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void North_Right_East()
        {
            var m = new Movement(Direction.North);
            m.RotateRight();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void North_Right_Left_North()
        {
            var m = new Movement(Direction.North);
            m.RotateRight();
            m.RotateLeft();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void North_Right_Right_South()
        {
            var m = new Movement(Direction.North);
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void North_Right_Right_Right_West()
        {
            var m = new Movement(Direction.North);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void North_Right_Right_Right_Right_North()
        {
            var m = new Movement(Direction.North);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        // West
        [Fact]
        public void West_Left_South()
        {
            var m = new Movement(Direction.West);
            m.RotateLeft();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void West_Left_Right_West()
        {
            var m = new Movement(Direction.West);
            m.RotateLeft();
            m.RotateRight();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void West_Left_Left_East()
        {
            var m = new Movement(Direction.West);
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void West_Left_Left_Left_North()
        {
            var m = new Movement(Direction.West);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void West_Left_Left_Left_Left_West()
        {
            var m = new Movement(Direction.West);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void West_Right_North()
        {
            var m = new Movement(Direction.West);
            m.RotateRight();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void West_Right_Left_West()
        {
            var m = new Movement(Direction.West);
            m.RotateRight();
            m.RotateLeft();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void West_Right_Right_East()
        {
            var m = new Movement(Direction.West);
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void West_Right_Right_Right_South()
        {
            var m = new Movement(Direction.West);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void West_Right_Right_Right_Right_West()
        {
            var m = new Movement(Direction.West);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        // East
        [Fact]
        public void East_Left_North()
        {
            var m = new Movement(Direction.East);
            m.RotateLeft();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void East_Left_Right_East()
        {
            var m = new Movement(Direction.East);
            m.RotateLeft();
            m.RotateRight();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void East_Left_Left_West()
        {
            var m = new Movement(Direction.East);
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void East_Left_Left_Left_South()
        {
            var m = new Movement(Direction.East);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void East_Left_Left_Left_Left_East()
        {
            var m = new Movement(Direction.East);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void East_Right_South()
        {
            var m = new Movement(Direction.East);
            m.RotateRight();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void East_Right_Left_East()
        {
            var m = new Movement(Direction.East);
            m.RotateRight();
            m.RotateLeft();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void East_Right_Right_West()
        {
            var m = new Movement(Direction.East);
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void East_Right_Right_Right_North()
        {
            var m = new Movement(Direction.East);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void East_Right_Right_Right_Right_East()
        {
            var m = new Movement(Direction.East);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        // South
        [Fact]
        public void South_Left_East()
        {
            var m = new Movement(Direction.South);
            m.RotateLeft();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void South_Left_Right_South()
        {
            var m = new Movement(Direction.South);
            m.RotateLeft();
            m.RotateRight();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void South_Left_Left_North()
        {
            var m = new Movement(Direction.South);
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void South_Left_Left_Left_West()
        {
            var m = new Movement(Direction.South);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void South_Left_Left_Left_Left_South()
        {
            var m = new Movement(Direction.South);
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();
            m.RotateLeft();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void South_Right_West()
        {
            var m = new Movement(Direction.South);
            m.RotateRight();

            Assert.Equal(Direction.West, m.CurrentFacing());
        }

        [Fact]
        public void South_Right_Left_South()
        {
            var m = new Movement(Direction.South);
            m.RotateRight();
            m.RotateLeft();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }

        [Fact]
        public void South_Right_Right_North()
        {
            var m = new Movement(Direction.South);
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.North, m.CurrentFacing());
        }

        [Fact]
        public void South_Right_Right_Right_East()
        {
            var m = new Movement(Direction.South);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.East, m.CurrentFacing());
        }

        [Fact]
        public void South_Right_Right_Right_Right_South()
        {
            var m = new Movement(Direction.South);
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();
            m.RotateRight();

            Assert.Equal(Direction.South, m.CurrentFacing());
        }
    }
}
