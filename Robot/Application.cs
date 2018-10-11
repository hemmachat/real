using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    public class Application : IApplication
    {
        public void Run()
        {
            Console.WriteLine("Run()");
            Console.ReadLine();
        }
    }
}
