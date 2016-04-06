using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_8_10_Breakfast4Lumberjacks
{    
    public partial class Form1 : Form
    {
        private Queue<Lumberjack> breakfastLine;
        public Form1()
        {
            InitializeComponent();
            breakfastLine = new Queue<Lumberjack>();
        }

        private void buttonAddLumberjack_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textName.Text)) return;
            breakfastLine.Enqueue(new Lumberjack(textName.Text));
            textName.Text = "";
            RedrawList();
        }

        private void addFlapjacks_Click(object sender, EventArgs e)
        {
            if (breakfastLine.Count == 0) return;
            Flapjack food;
            if (crispy.Checked)
                food = Flapjack.Crispy;
            else if (soggy.Checked)
                food = Flapjack.Soggy;
            else if (browned.Checked)
                food = Flapjack.Browned;
            else
                food = Flapjack.Banana;

            Lumberjack currentLumberjack = breakfastLine.Peek();
            currentLumberjack.TakeFlapjacks(food, (int)howMany.Value);
            RedrawList();


        }

        private void buttonNextLumberjack_Click(object sender, EventArgs e)
        {
            if (breakfastLine.Count == 0) return;
            Lumberjack currentLumberjack = breakfastLine.Dequeue();
            currentLumberjack.EatFlapjacks();
            RedrawList();
        }

        private void RedrawList()
        {
             int number = 1;
             line.Items.Clear();
            foreach (Lumberjack ImOk in breakfastLine)
            {
                line.Items.Add(number + ". " + ImOk.Name);
                number++;
            }
            if(breakfastLine.Count == 0)
            {
                groupBox1.Enabled = false;
                nextInLine.Text = "";
            }
            else
            {
                groupBox1.Enabled = true;
                Lumberjack currentLumberjack = breakfastLine.Peek();
                nextInLine.Text = currentLumberjack.Name + " has " + currentLumberjack.FlapjackCount + " flapjacks";

            }

        }
        
    }
}
