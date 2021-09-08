using System;

namespace AntsSimulator.Ants
{
    public class Drone : Ant
    {
        public override char Character => 'D';

        protected int _cooldownCounter;
        
        public Drone(Coordinate position, Colony colony) : base(position, colony)
        {
        }

        public override void Act()
        {
            if (_cooldownCounter > 0)
            {
                _cooldownCounter--;

                if (_cooldownCounter <= 0)
                {
                    KickAway();
                }
            }
            else
            {
                Coordinate queenPosition = Colony.Queen.Position;

                if (Coordinate.Distance(Position, queenPosition) == 1)
                {
                    Colony.Queen.AskToMate(this);
                }
                else
                {
                    // Move toward the queen
                    Move(queenPosition);
                }
            }
        }

        public void Mate()
        {
            _cooldownCounter = 10;
        }

        public void KickAway()
        {
            Coordinate[] edgePositions = Colony.GetAvailablePositions(true);
            Coordinate targetPosition = edgePositions[Utils.Random.Next(edgePositions.Length)];
            
            Colony.TryMove(this, targetPosition);
        }

        private void Move(Coordinate queenPosition)
        {
            Direction moveDirection;

            if (Position.X == queenPosition.X)
            {
                // Move on Y axis
                moveDirection = Position.Y > queenPosition.Y
                    ? Direction.North
                    : Direction.South;
            }
            else
            {
                // Move on X axis
                moveDirection = Position.X > queenPosition.X
                    ? Direction.West
                    : Direction.East;
            }

            Coordinate targetPosition = Position.MoveTowards(moveDirection);
            Colony.TryMove(this, targetPosition);
        }
    }
}