using System;

namespace AntsSimulator.Ants
{
    public class Queen : Ant
    {
        public override char Character => 'Q';

        private int _moodCounter;
        
        public Queen(Coordinate position, Colony colony) : base(position, colony)
        {
            ResetMoodCounter();
        }

        public override void Act()
        {
            if (_moodCounter > 0)
            {
                _moodCounter--;
            }
        }

        public void AskToMate(Drone drone)
        {
            if (_moodCounter > 0)
            {
                // Queen wouldn't like to mate 
                drone.KickAway();
                // Console.WriteLine("Drone: :(");
            }
            else
            {
                // Queen would like to mate
                drone.Mate();
                ResetMoodCounter();
                // Console.WriteLine("Drone: HALLELUJAH!");
            }
        }

        private void ResetMoodCounter()
        {
            _moodCounter = Utils.Random.Next(50, 101);
        }
    }
}