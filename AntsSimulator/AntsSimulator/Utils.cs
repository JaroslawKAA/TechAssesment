using System;

namespace AntsSimulator
{
    public class Utils
    {
        public static Random Random;

        public Utils()
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