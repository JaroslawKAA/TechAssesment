namespace AntsSimulator.Ants
{
    public class Queen : Ant
    {
        public void AskToMate(Drone drone)
        {
            throw new System.NotImplementedException();
        }

        public Queen(Coordinate position, Colony colony) : base(position, colony)
        {
        }

        public override char Character { get; }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}