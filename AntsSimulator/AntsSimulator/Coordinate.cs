using System;

namespace AntsSimulator
{
    public class Coordinate
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinate"/> struct.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets X coordinate
        /// </summary>
        public int X { get; }

        /// <summary>
        ///     Gets Y coordinate
        /// </summary>
        public int Y { get; }

        public Coordinate MoveTowards(Direction direction, int steps = 1)
        {
            int stepX = direction switch
            {
                Direction.East => 1,
                Direction.West => -1,
                _ => 0
            };

            int stepY = direction switch
            {
                Direction.North => -1,
                Direction.South => 1,
                _ => 0
            };

            return new Coordinate(X + stepX * steps, Y + stepY * steps);
        }

        public static int Distance(Coordinate a, Coordinate b)
        {
            return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
        }
    }
}