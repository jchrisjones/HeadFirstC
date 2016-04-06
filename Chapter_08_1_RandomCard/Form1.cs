using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_08_7_OverloadingMethods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            Card RandomCard = new Card((Suits)rand.Next(4), (Values)rand.Next(1, 14));
            MessageBox.Show(RandomCard.Name, "Is this your card?");
        }

    }
}
