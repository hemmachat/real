﻿using Robot.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Robot
{
    /// <summary>
    /// Binary number translation to use for bit shifting operation e.g. shift left when rotate left
    /// </summary>
    public enum Direction
    {
        North = 2,
        West = 4,
        South = 8,
        East = 1
    }
}
