using System;
using AntsSimulator.Ants;

namespace AntsSimulator
{
    public class Colony
    {
        public void Place()
        {
            throw new NotImplementedException();
        }

        public Coordinate[] GetAvailablePositions(bool onlyEdge)
        {
            throw new NotImplementedException();
        }

        public void TryMove(Ant ant, Coordinate coordinate)
        {
            throw new NotImplementedException();
        }

        public Queen Queen { get; set; }
    }
}