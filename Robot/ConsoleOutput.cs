using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    /// <summary>
    /// Class to show a text message to user console
    /// </summary>
    public class ConsoleOutput : IUserOutput
    {
        public void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
