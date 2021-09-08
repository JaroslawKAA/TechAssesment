using System;

namespace AntsSimulator
{
    public static class Utils
    {
        public static Random Random;

        static Utils()
        {
            Random = new Random();
        }

        public static Direction GetRandomDirection()
        {
            Direction[] allDirections = (Direction[]) Enum.GetValues(typeof(Direction));
            
            return allDirections.GetRandomElement();
        }
    }
}