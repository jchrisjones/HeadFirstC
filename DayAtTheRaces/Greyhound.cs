using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public class Greyhound
    {
        public int StartingPosition; // Where my PictureBox starts
        public int RacetrackLength; // How long the racetrack is
        public PictureBox MyPictureBox = null;
        public int Location = 0;

        public static Random Randomizer = new Random(); // An instance of Random

        public Greyhound() { }
        public Greyhound(PictureBox myPicBox, PictureBox racetrackPictureBox)
        {
            MyPictureBox = myPicBox;
            StartingPosition = myPicBox.Left;
            RacetrackLength = racetrackPictureBox.Width - myPicBox.Width;            
        }

        public bool Run()
        {
            // Move forward either 1, 2, 3 or 4 spaces at random
            Location += Randomizer.Next(1,4);           
            // Update the position of my PictureBox on the form like this
            MyPictureBox.Left = StartingPosition + Location;
            // return true if I won the race;
            if (MyPictureBox.Left >= RacetrackLength)
                return true;
            else
                return false;
        }

        public void TakeStartingPosition()
        {
            this.Location = 0;
            MyPictureBox.Left = StartingPosition;
        }
    }
}
