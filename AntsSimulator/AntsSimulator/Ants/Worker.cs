namespace AntsSimulator.Ants
{
    public class Worker : Ant
    {
        public Worker(Coordinate position, Colony colony) : base(position, colony)
        {
        }

        public override char Character { get; }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}