using System;
using System.Collections.Generic;
using System.Text;

namespace Robot.Interfaces
{
    public interface IRobot
    {
        void Move();
        void Place();
        void Report();
        void Left();
        void Right();

    }
}
