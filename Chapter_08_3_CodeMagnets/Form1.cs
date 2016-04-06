using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_08_3_CodeMagnets
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zilch = "zero";
            string first = "one";
            string second = "two";
            string third = "three";
            string fourth = "4.2";
            string twopointtwo = "2.2";

            string result = "";

            List<string> a = new List<string>();
            a.Add(zilch);
            a.Add(first);
            a.Add(second);
            a.Add(third);

            if (a.Contains("three"))
            {
                a.Add("four");
            }

            a.RemoveAt(2);

            if (a.IndexOf("four") != 4)
            {
                a.Add(fourth);
            }

            if (a.Contains("two"))
            {
                a.Add(twopointtwo);
            }

            foreach (string element in a)
            {
                result += "\n" + element;
            }

            MessageBox.Show(result);
        }
    }
}
