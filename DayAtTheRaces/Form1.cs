using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayAtTheRaces
{
    public partial class Form1 : Form
    {
        // Create Greyhound and Guy array references
        Greyhound[] GreyhoundArray;
        Guy[] GuyArray;

        public Form1()
        {
            InitializeComponent();

            minimumBetLabel.Text = "Minimum bet: " + numericUpDown1.Minimum + " bucks";
            GreyhoundArray = new Greyhound[4];
            GuyArray = new Guy[3];

            GreyhoundArray[0] = new Greyhound(pictureBox1, racetrackPictureBox);
            GreyhoundArray[1] = new Greyhound(pictureBox2, racetrackPictureBox);
            GreyhoundArray[2] = new Greyhound(pictureBox3, racetrackPictureBox);
            GreyhoundArray[3] = new Greyhound(pictureBox4, racetrackPictureBox);

            GuyArray[0] = new Guy("Joe", 50, joeRadioButton, label5);
            GuyArray[1] = new Guy("Bob", 75, bobRadioButton, label6);
            GuyArray[2] = new Guy("Al", 45, radioButton3, label7);

            foreach(Guy g in GuyArray)
            {
                if(g.MyRadioButton.Checked == true)
                    name.Text = g.Name;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = GuyArray[0].Name;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = GuyArray[1].Name;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            name.Text = GuyArray[2].Name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Guy g in GuyArray)
            {
                if (g.MyRadioButton.Checked == true)
                {
                    g.PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            groupBox1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < GreyhoundArray.Length; i++)
            {
                if(GreyhoundArray[i].Run())
                {
                    timer1.Stop();
                    MessageBox.Show("Dog #" + (i + 1) + " won the race!", "We have a winner");
                    for(int j = 0; j < GuyArray.Length; j++)
                    {
                        if(GuyArray[j].MyBet != null)
                            GuyArray[j].Collect(i + 1);
                    }
                    groupBox1.Enabled = true;
                    foreach (Greyhound dog in GreyhoundArray)
                        dog.TakeStartingPosition();

                }
            }
        }
    }
}
