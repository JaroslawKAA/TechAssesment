namespace AntsSimulator.Ants
{
    public abstract class Ant
    {
        public Coordinate Position { get; set; }
        
        protected Colony Colony { get; }

        public abstract char Character { get; }
        
        protected Ant(Coordinate position, Colony colony)
        {
            Position = position;
            Colony = colony;
        }

        public abstract void Act();
    }
}