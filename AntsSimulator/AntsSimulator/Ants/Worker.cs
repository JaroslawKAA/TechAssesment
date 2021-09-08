namespace AntsSimulator.Ants
{
    public class Worker : Ant
    {
        public override char Character => 'W';

        public Worker(Coordinate position, Colony colony) : base(position, colony)
        {
        }

        public override void Act()
        {
            // Randomly select one direction and try to move
            Direction randomDirection = Utils.GetRandomDirection();
            Coordinate targetPosition = Position.MoveTowards(randomDirection);

            Colony.TryMove(this, targetPosition);
        }
    }
}