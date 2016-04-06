using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_04_Typing_Game
{
    class Stats
    {
        public int Total = 0, Missed = 0, Correct = 0, Accuracy = 0;

        public void Update(bool correctKey)
        {
            Total++;

            if (!correctKey)
                Missed++;
            else
                Correct++;
            Accuracy = 100 * Correct / (Missed + Correct);
        }
    }
}
