using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AntsSimulator.Ants;

namespace AntsSimulator
{
    public class Colony
    {
        public int Width { get; }

        public Queen Queen { get; set; }

        private Ant[,] _ants;

        public Colony(int width)
        {
            Width = width;

            _ants = new Ant[Width, Width];

            Coordinate center = new Coordinate(Width / 2, Width / 2);

            Queen = new Queen(center, this);
            this[center] = Queen;
        }

        public void Update()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    _ants[y, x]?.Act();
                }
            }
        }

        public void GenerateAnts(int dronesCount, int workersCount, int soldiersCount)
        {
            Coordinate[] availablePositions = this.GetAvailablePositions();
            availablePositions = availablePositions.Shuffle().ToArray();

            int positionIndex = 0;

            for (int i = 0; i < dronesCount; i++)
            {
                this[availablePositions[positionIndex]] = new Drone(availablePositions[positionIndex], this);
                positionIndex++;
            }

            for (int i = 0; i < workersCount; i++)
            {
                this[availablePositions[positionIndex]] = new Worker(availablePositions[positionIndex], this);
                positionIndex++;
            }

            for (int i = 0; i < soldiersCount; i++)
            {
                this[availablePositions[positionIndex]] = new Solder(availablePositions[positionIndex], this);
                positionIndex++;
            }
        }

        private bool CanIMoveHere(Coordinate position)
        {
            // Check if given position is within borders
            if (position.X < 0 && position.X >= Width && position.Y < 0 && position.Y >= Width)
                return false;
            try
            {
                // Check if given position isn't already occupied
                return _ants[position.Y, position.X] == null;
            }
            catch (IndexOutOfRangeException e)
            {
                return false;
            }
        }

        private void Move(Ant ant, Coordinate targetPosition)
        {
            Coordinate oldPosition = ant.Position;

            this[oldPosition] = null;

            this[targetPosition] = ant;
            ant.Position = targetPosition;
        }

        public void TryMove(Ant ant, Coordinate targetPosition)
        {
            if (CanIMoveHere(targetPosition))
            {
                Move(ant, targetPosition);
            }
        }

        public Coordinate[] GetAvailablePositions(bool edgesOnly = false)
        {
            List<Coordinate> availableEdgePositions = new List<Coordinate>();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    if (_ants[y, x] == null)
                    {
                        if (edgesOnly)
                        {
                            if ((x == 0 || x == Width - 1) && (y == 0 || y == Width - 1))
                            {
                                availableEdgePositions.Add(new Coordinate(x, y));
                            }
                        }
                        else
                            availableEdgePositions.Add(new Coordinate(x, y));
                    }
                }
            }

            return availableEdgePositions.ToArray();
        }


        public string Display()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_ants[y, x] != null)
                    {
                        sb.Append(_ants[y, x].Character);
                    }
                    else
                    {
                        sb.Append('.');
                    }
                }

                sb.Append('\n');
            }

            return sb.ToString();
        }

        private Ant this[Coordinate position]
        {
            get => _ants[position.Y, position.X];
            set => _ants[position.Y, position.X] = value;
        }
    }
}