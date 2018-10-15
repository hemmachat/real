using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    /// <summary>
    /// Class to read user input from console
    /// </summary>
    public class ConsoleInput : IUserInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
