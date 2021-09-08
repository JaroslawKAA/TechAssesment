namespace AntsSimulator.Ants
{
    public class Solder : Ant
    {
        public Solder(Coordinate position, Colony colony) : base(position, colony)
        {
        }

        public override char Character { get; }
        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}