using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADayAtTheRaces
{
    class Greyhound
    {
        public int StartingPosition { get; set; }
        public int RacetrackLength { get; set; }
        public PictureBox myPictureBox = new PictureBox();
        int location = 0, distance = 0;
        private Random randomizer;
                
        public bool Run()
        {
            randomizer = new Random();
            if (location < RacetrackLength)
            {
                distance = randomizer.Next(1, 10);
                myPictureBox.Left += distance;
                location += distance;
                return false;
            }
            else
            {
                return true;
            }
        }
        public void TakeStartingPosition()
        {
            
            myPictureBox.Left = StartingPosition;
            location = 0;
        }
    }
}
