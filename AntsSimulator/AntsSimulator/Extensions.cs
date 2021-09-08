using System;
using System.Collections.Generic;
using System.Linq;

namespace AntsSimulator
{
    public static class Extensions
    {
        public static T GetRandomElement<T>(this IEnumerable<T> enumerable)
        {
            T[] array = enumerable as T[] ?? enumerable.ToArray();
            return array[Utils.Random.Next(array.Count())];
        }
        
        public static Direction RotateLeft(this Direction direction) => direction switch
        {
            Direction.North => Direction.West,
            Direction.West => Direction.South,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}