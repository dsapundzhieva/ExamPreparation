﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _5._3.TheRace
{
    public class Car
    {
        public Car(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

        public string Name { get; set; }

        public int Speed { get; set; }


    }
}