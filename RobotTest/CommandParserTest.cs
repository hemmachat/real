using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Robot;
using Robot.Models;

namespace RobotTest
{
    public class CommandParserTest
    {
        [Fact]
        public void Place_Origin_North()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE 0,0,NORTH");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Place);
            actual.Item2.Should().BeEquivalentTo(new Coordinate(0, 0));
            actual.Item3.Should().BeEquivalentTo(Direction.North);
        }

        [Fact]
        public void Place_Origin_North_Lowercase()
        {
            var c = new CommandParser();

            var actual = c.Parse("place 0,0,north");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Place);
            actual.Item2.Should().BeEquivalentTo(new Coordinate(0, 0));
            actual.Item3.Should().BeEquivalentTo(Direction.North);
        }

        [Fact]
        public void Place_Origin_North_Lowercase_Spaces()
        {
            var c = new CommandParser();

            var actual = c.Parse(" place  0 , 0 , north ");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Place);
            actual.Item2.Should().BeEquivalentTo(new Coordinate(0, 0));
            actual.Item3.Should().BeEquivalentTo(Direction.North);
        }

        [Fact]
        public void Place_Top_Left_South()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE 0,4,SOUTH");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Place);
            actual.Item2.Should().BeEquivalentTo(new Coordinate(0, 4));
            actual.Item3.Should().BeEquivalentTo(Direction.South);
        }

        [Fact]
        public void Place_Out_Of_Bound_Coordinate_East()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE -1,-1,EAST");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Place);
            actual.Item2.Should().BeEquivalentTo(new Coordinate(-1, -1));
            actual.Item3.Should().BeEquivalentTo(Direction.East);
        }

        [Fact]
        public void Place_Invalid_Incomplete()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE ");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Place()
        {
            var c = new CommandParser();

            var actual = c.Parse("PACE -1,-1,EAST");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Parameters()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE -1,-1,EAST,NORTH");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Coordinate_X()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE A,-1,EAST");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Coordinate_Y()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE 0,A,EAST");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Coordinate_X_Y()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE A,A,EAST");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Overflow_Coordinate_X()
        {
            var c = new CommandParser();
            Int64 overflow = (Int64)int.MaxValue + 1;

            var actual = c.Parse($"PLACE {overflow},0,EAST");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Overflow_Coordinate_Y()
        {
            var c = new CommandParser();
            Int64 overflow = (Int64)int.MaxValue + 1;

            var actual = c.Parse($"PLACE 0, {overflow},EAST");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Direction_East()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE 0,0,EASTER");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Direction_North()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE 0,0,NORTHERN");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Place_Invalid_Direction_Number()
        {
            var c = new CommandParser();

            var actual = c.Parse("PLACE 0,0,1");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Move_Valid()
        {
            var c = new CommandParser();

            var actual = c.Parse("MOVE");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Move);
        }

        [Fact]
        public void Move_Valid_Space()
        {
            var c = new CommandParser();

            var actual = c.Parse(" MOVE ");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Move);
        }

        [Fact]
        public void Move_Valid_Lowercase()
        {
            var c = new CommandParser();

            var actual = c.Parse("move");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Move);
        }

        [Fact]
        public void Move_Invalid_Mover()
        {
            var c = new CommandParser();

            var actual = c.Parse("MOVER");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Move_Invalid_Move_One()
        {
            var c = new CommandParser();

            var actual = c.Parse("MOVE1");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Left_Valid()
        {
            var c = new CommandParser();

            var actual = c.Parse("LEFT");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Left);
        }

        [Fact]
        public void Left_Valid_Spaces()
        {
            var c = new CommandParser();

            var actual = c.Parse(" LEFT ");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Left);
        }

        [Fact]
        public void Left_Valid_Lowercase()
        {
            var c = new CommandParser();

            var actual = c.Parse("left");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Left);
        }

        [Fact]
        public void Left_Invalid_Lefty()
        {
            var c = new CommandParser();

            var actual = c.Parse("LEFTY");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Left_Invalid_Left_One()
        {
            var c = new CommandParser();

            var actual = c.Parse("LEFT1");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Right_Valid()
        {
            var c = new CommandParser();

            var actual = c.Parse("RIGHT");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Right);
        }

        [Fact]
        public void Right_Valid_Spaces()
        {
            var c = new CommandParser();

            var actual = c.Parse(" RIGHT ");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Right);
        }

        [Fact]
        public void Right_Valid_Lowercase()
        {
            var c = new CommandParser();

            var actual = c.Parse("right");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Right);
        }

        [Fact]
        public void Right_Invalid_Righty()
        {
            var c = new CommandParser();

            var actual = c.Parse("RIGHTY");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Right_Invalid_Right_One()
        {
            var c = new CommandParser();

            var actual = c.Parse("RIGHT1");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Report_Valid()
        {
            var c = new CommandParser();

            var actual = c.Parse("REPORT");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Report);
        }

        [Fact]
        public void Report_Valid_Spaces()
        {
            var c = new CommandParser();

            var actual = c.Parse(" REPORT ");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Report);
        }

        [Fact]
        public void Report_Valid_Lowercase()
        {
            var c = new CommandParser();

            var actual = c.Parse("report");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Report);
        }

        [Fact]
        public void Report_Invalid_Reporty()
        {
            var c = new CommandParser();

            var actual = c.Parse("REPORTY");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }

        [Fact]
        public void Report_Invalid_Report_One()
        {
            var c = new CommandParser();

            var actual = c.Parse("REPORT1");

            actual.Item1.Should().BeEquivalentTo(RobotCommandType.Invalid);
        }
    }
}
