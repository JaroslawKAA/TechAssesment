using System;

namespace AntsSimulator.Ants
{
    public class Solder : Ant
    {
        public override char Character => 'S';

        private Direction _currentDirection;
        
        public Solder(Coordinate position, Colony colony) : base(position, colony)
        {
            _currentDirection = Utils.GetRandomDirection();
        }

        public override void Act()
        {
            Coordinate targetPosition = Position.MoveTowards(_currentDirection);
            Colony.TryMove(this, targetPosition);

            _currentDirection = _currentDirection.RotateLeft();
        }
    }
}