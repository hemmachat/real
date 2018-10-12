using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class ConsoleInput : IUserInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
