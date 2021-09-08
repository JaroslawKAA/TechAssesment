﻿using System;
using System.Threading;

namespace AntsSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Colony colony = new Colony(20);
            colony.GenerateAnts(0, 0, 1);
            
            while (true)
            {
                Console.Clear();
                colony.Update();
                Console.WriteLine(colony.Display());
                Thread.Sleep(500);
            }
        }
    }
}