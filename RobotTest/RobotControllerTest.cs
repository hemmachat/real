using Robot;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace RobotTest
{
    public class RobotControllerTest
    {
        [Fact]
        public void Example_A()
        {
            var input = $"PLACE 0,0,NORTH{Environment.NewLine}MOVE{Environment.NewLine}REPORT{Environment.NewLine}{Environment.NewLine}";
            var expected = $"0,1,NORTH{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example_B()
        {
            var input = $"PLACE 0,0,NORTH{Environment.NewLine}LEFT{Environment.NewLine}REPORT{Environment.NewLine}{Environment.NewLine}";
            var expected = $"0,0,WEST{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example_C()
        {
            var input = $"PLACE 1,2,EAST{Environment.NewLine}MOVE{Environment.NewLine}MOVE{Environment.NewLine}LEFT{Environment.NewLine}" +
                $"MOVE{Environment.NewLine}REPORT{Environment.NewLine}{Environment.NewLine}";
            var expected = $"3,3,NORTH{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_X_Report()
        {
            var input = $"PLACE -1,0,NORTH{Environment.NewLine}REPORT{Environment.NewLine}";
            var expected = $"{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_Y_Report()
        {
            var input = $"PLACE 0,-1,NORTH{Environment.NewLine}REPORT{Environment.NewLine}";
            var expected = $"{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_X_Move()
        {
            var input = $"PLACE -1,0,NORTH{Environment.NewLine}MOVE{Environment.NewLine}";
            var expected = $"";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_Y_Move()
        {
            var input = $"PLACE 0,-1,NORTH{Environment.NewLine}MOVE{Environment.NewLine}";
            var expected = $"";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_X_Left()
        {
            var input = $"PLACE -1,0,NORTH{Environment.NewLine}LEFT{Environment.NewLine}";
            var expected = $"";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_Y_Left()
        {
            var input = $"PLACE 0,-1,NORTH{Environment.NewLine}LEFT{Environment.NewLine}";
            var expected = $"";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_X_Right()
        {
            var input = $"PLACE -1,0,NORTH{Environment.NewLine}RIGHT{Environment.NewLine}";
            var expected = $"";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_Y_Right()
        {
            var input = $"PLACE 0,-1,NORTH{Environment.NewLine}RIGHT{Environment.NewLine}";
            var expected = $"";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Coordinate_Y_Right_Valid_Commands()
        {
            var input = $"PLACE 0,-1,NORTH{Environment.NewLine}RIGHT{Environment.NewLine}PLACE 0,0,NORTH{Environment.NewLine}MOVE{Environment.NewLine}REPORT{Environment.NewLine}{Environment.NewLine}";
            var expected = $"0,1,NORTH{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Command()
        {
            var input = $"hello{Environment.NewLine}";
            var expected = $"Bad command or filename.{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Invalid_Command_First()
        {
            var input = $"hello{Environment.NewLine}PLACE 1,2,EAST{Environment.NewLine}MOVE{Environment.NewLine}MOVE{Environment.NewLine}LEFT{Environment.NewLine}" +
                $"MOVE{Environment.NewLine}REPORT{Environment.NewLine}{Environment.NewLine}";
            var expected = $"Bad command or filename.{Environment.NewLine}3,3,NORTH{Environment.NewLine}";

            var actual = TestConsole(input);

            Assert.Equal(expected, actual);

        }

        private string TestConsole(string input)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                using (StringReader sr = new StringReader(input))
                {
                    Console.SetIn(sr);
                    Program.Main(new string[] { "" });

                    return sw.ToString();
                }
            }
        }
    }
}
