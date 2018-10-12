using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;
using Robot.Models;
using Robot;

namespace RobotTest
{
    public class TableTest
    {
        [Fact]
        public void Valid_Origin_Coordinate()
        {
            var co = new Coordinate(0, 0);

            Table.HasValidCoordinate(co).Should().BeTrue();
        }

        [Fact]
        public void Valid_Top_Left_Coordinate()
        {
            var co = new Coordinate(0, 4);

            Table.HasValidCoordinate(co).Should().BeTrue();
        }

        [Fact]
        public void Valid_Bottom_Right_Coordinate()
        {
            var co = new Coordinate(4, 0);

            Table.HasValidCoordinate(co).Should().BeTrue();
        }

        [Fact]
        public void Valid_Top_Right_Coordinate()
        {
            var co = new Coordinate(4, 4);

            Table.HasValidCoordinate(co).Should().BeTrue();
        }

        [Fact]
        public void Valid_Centre_Coordinate()
        {
            var co = new Coordinate(2, 2);

            Table.HasValidCoordinate(co).Should().BeTrue();
        }

        [Fact]
        public void Invalid_Minus_X_Coordinate()
        {
            var co = new Coordinate(-1, 0);

            Table.HasValidCoordinate(co).Should().BeFalse();
        }

        [Fact]
        public void Invalid_Minus_Y_Coordinate()
        {
            var co = new Coordinate(0, -1);

            Table.HasValidCoordinate(co).Should().BeFalse();
        }

        [Fact]
        public void Invalid_Minus_X_Y_Coordinate()
        {
            var co = new Coordinate(-1, -1);

            Table.HasValidCoordinate(co).Should().BeFalse();
        }

        [Fact]
        public void Invalid_Over_X_Coordinate()
        {
            var co = new Coordinate(5, 0);

            Table.HasValidCoordinate(co).Should().BeFalse();
        }

        [Fact]
        public void Invalid_Over_Y_Coordinate()
        {
            var co = new Coordinate(0, 5);

            Table.HasValidCoordinate(co).Should().BeFalse();
        }

        [Fact]
        public void Invalid_Over_X_Y_Coordinate()
        {
            var co = new Coordinate(5, 5);

            Table.HasValidCoordinate(co).Should().BeFalse();
        }

        // Origin CanMove*
        [Fact]
        public void Origin_Can_Move_North()
        {
            var co = new Coordinate(0, 0);

            Table.CanMoveNorth(co).Should().BeTrue();
        }

        [Fact]
        public void Origin_Can_Move_East()
        {
            var co = new Coordinate(0, 0);

            Table.CanMoveEast(co).Should().BeTrue();
        }

        [Fact]
        public void Origin_Cannot_Move_West()
        {
            var co = new Coordinate(0, 0);

            Table.CanMoveWest(co).Should().BeFalse();
        }

        [Fact]
        public void Origin_Cannot_Move_South()
        {
            var co = new Coordinate(0, 0);

            Table.CanMoveSouth(co).Should().BeFalse();
        }

        // Left
        [Fact]
        public void Left_Can_Move_North()
        {
            var co = new Coordinate(0, 2);

            Table.CanMoveNorth(co).Should().BeTrue();
        }

        [Fact]
        public void Left_Can_Move_East()
        {
            var co = new Coordinate(0, 2);

            Table.CanMoveEast(co).Should().BeTrue();
        }

        [Fact]
        public void Left_Cannot_Move_West()
        {
            var co = new Coordinate(0, 2);

            Table.CanMoveWest(co).Should().BeFalse();
        }

        [Fact]
        public void Left_Can_Move_South()
        {
            var co = new Coordinate(0, 2);

            Table.CanMoveSouth(co).Should().BeTrue();
        }

        // Top-left
        [Fact]
        public void Top_Left_Cannot_Move_North()
        {
            var co = new Coordinate(0, 4);

            Table.CanMoveNorth(co).Should().BeFalse();
        }

        [Fact]
        public void Top_Left_Can_Move_East()
        {
            var co = new Coordinate(0, 4);

            Table.CanMoveEast(co).Should().BeTrue();
        }

        [Fact]
        public void Top_Left_Cannot_Move_West()
        {
            var co = new Coordinate(0, 4);

            Table.CanMoveWest(co).Should().BeFalse();
        }

        [Fact]
        public void Top_Left_Can_Move_South()
        {
            var co = new Coordinate(0, 4);

            Table.CanMoveSouth(co).Should().BeTrue();
        }

        // Top
        [Fact]
        public void Top_Cannot_Move_North()
        {
            var co = new Coordinate(2, 4);

            Table.CanMoveNorth(co).Should().BeFalse();
        }

        [Fact]
        public void Top_Can_Move_East()
        {
            var co = new Coordinate(2, 4);

            Table.CanMoveEast(co).Should().BeTrue();
        }

        [Fact]
        public void Top_Can_Move_West()
        {
            var co = new Coordinate(2, 4);

            Table.CanMoveWest(co).Should().BeTrue();
        }

        [Fact]
        public void Top_Can_Move_South()
        {
            var co = new Coordinate(2, 4);

            Table.CanMoveSouth(co).Should().BeTrue();
        }

        // Top-right
        [Fact]
        public void Top_Right_Cannot_Move_North()
        {
            var co = new Coordinate(4, 4);

            Table.CanMoveNorth(co).Should().BeFalse();
        }

        [Fact]
        public void Top_Right_Cannot_Move_East()
        {
            var co = new Coordinate(4, 4);

            Table.CanMoveEast(co).Should().BeFalse();
        }

        [Fact]
        public void Top_Right_Can_Move_West()
        {
            var co = new Coordinate(4, 4);

            Table.CanMoveWest(co).Should().BeTrue();
        }

        [Fact]
        public void Top_Right_Can_Move_South()
        {
            var co = new Coordinate(4, 4);

            Table.CanMoveSouth(co).Should().BeTrue();
        }

        // Right
        [Fact]
        public void Right_Can_Move_North()
        {
            var co = new Coordinate(4, 2);

            Table.CanMoveNorth(co).Should().BeTrue();
        }

        [Fact]
        public void Right_Cannot_Move_East()
        {
            var co = new Coordinate(4, 2);

            Table.CanMoveEast(co).Should().BeFalse();
        }

        [Fact]
        public void Right_Can_Move_West()
        {
            var co = new Coordinate(4, 2);

            Table.CanMoveWest(co).Should().BeTrue();
        }

        [Fact]
        public void Right_Can_Move_South()
        {
            var co = new Coordinate(4, 2);

            Table.CanMoveSouth(co).Should().BeTrue();
        }

        // Bottom-right
        [Fact]
        public void Bottom_Right_Can_Move_North()
        {
            var co = new Coordinate(4, 0);

            Table.CanMoveNorth(co).Should().BeTrue();
        }

        [Fact]
        public void Bottom_Right_Cannot_Move_East()
        {
            var co = new Coordinate(4, 0);

            Table.CanMoveEast(co).Should().BeFalse();
        }

        [Fact]
        public void Bottom_Right_Can_Move_West()
        {
            var co = new Coordinate(4, 0);

            Table.CanMoveWest(co).Should().BeTrue();
        }

        [Fact]
        public void Bottom_Right_Cannot_Move_South()
        {
            var co = new Coordinate(4, 0);

            Table.CanMoveSouth(co).Should().BeFalse();
        }

        // Bottom
        [Fact]
        public void Bottom_Can_Move_North()
        {
            var co = new Coordinate(2, 0);

            Table.CanMoveNorth(co).Should().BeTrue();
        }

        [Fact]
        public void Bottom_Can_Move_East()
        {
            var co = new Coordinate(2, 0);

            Table.CanMoveEast(co).Should().BeTrue();
        }

        [Fact]
        public void Bottom_Can_Move_West()
        {
            var co = new Coordinate(2, 0);

            Table.CanMoveWest(co).Should().BeTrue();
        }

        [Fact]
        public void Bottom_Cannot_Move_South()
        {
            var co = new Coordinate(2, 0);

            Table.CanMoveSouth(co).Should().BeFalse();
        }

        // Centre
        [Fact]
        public void Centre_Can_Move_North()
        {
            var co = new Coordinate(2, 2);

            Table.CanMoveNorth(co).Should().BeTrue();
        }

        [Fact]
        public void Centre_Can_Move_East()
        {
            var co = new Coordinate(2, 2);

            Table.CanMoveEast(co).Should().BeTrue();
        }

        [Fact]
        public void Centre_Can_Move_West()
        {
            var co = new Coordinate(2, 2);

            Table.CanMoveWest(co).Should().BeTrue();
        }

        [Fact]
        public void Centre_Can_Move_South()
        {
            var co = new Coordinate(2, 2);

            Table.CanMoveSouth(co).Should().BeTrue();
        }
    }
}
