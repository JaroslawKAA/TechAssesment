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

        public override void OnUpdate()
        {
            Coordinate targetPosition = Position.MoveTowards(_currentDirection);
            Position = Colony.TryMove(this, targetPosition);

            _currentDirection = _currentDirection.RotateLeft();
        }
    }
}