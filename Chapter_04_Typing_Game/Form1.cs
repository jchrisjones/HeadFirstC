using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_04_Typing_Game
{
    public partial class typingGame : Form
    {
        Random random = new Random();
        Stats stats = new Stats();
       
        public typingGame()
        {
            InitializeComponent();            
        }

        // Add a random key to the ListBox
        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)random.Next(65, 90));
            if(listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Font = new Font("Microsoft Sans Serif", 30, FontStyle.Bold);
                listBox1.ForeColor = Color.FromName("Red");
                listBox1.Items.Add("Game over. \n Press \"Enter\" to Start again.");
                timer1.Stop();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // If the game is ended, press "Enter" to start the game again
            if(!timer1.Enabled && (e.KeyCode == Keys.Enter))
            {
                listBox1.Items.Clear();
                listBox1.Font =  new Font("Microsoft Sans Serif", 72, FontStyle.Bold);
                listBox1.ForeColor = Color.FromName("Black");
                stats = new Stats();
                timer1.Interval = 800;
                timer1.Start();
            }
            // If the user pressed a key that's in the ListBox, remove it 
            // and then make the game a little faster
            if(listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();
                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;
                difficultyProgressBar.Value = 800 - timer1.Interval;

                // The user pressed a corect key, so update the Stats object 
                // by calling its Update() method with the argument true
                stats.Update(true);                    
            }
            else 
            {
                // The user pressed an incorrect key, so update the Stats object
                // by call its Update() method with the arguement false
                stats.Update(false);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
