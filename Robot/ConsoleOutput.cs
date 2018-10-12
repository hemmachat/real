using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class ConsoleOutput : IUserOutput
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
