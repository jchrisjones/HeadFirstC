using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter_06_4_BeehiveManagement_BeanCounters
{
    public partial class Form1 : Form
    {
        Queen queen;
        public Form1()
        {
            InitializeComponent();
            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(175.0,new string[] { "Nectar collector", "Honey manufacturing" });
            workers[1] = new Worker(114.0, new string[] { "Egg care", "Baby bee tutoring" });
            workers[2] = new Worker(149.0, new string[] { "Hive maintenance", "Sting patrol" });
            workers[3] = new Worker(155.0, new string[] { "Nectar collector", "Honey manufacturing",
                                                   "Egg care", "Baby bee tutoring",
                                                   "Hive maintenance", "Sting patrol" });
            queen = new Queen(275.0, workers);
        }

        private void assignJob_Click(object sender, EventArgs e)
        {
            if (!queen.AssignWork(workerBeeJob.Text, (int)shifts.Value))
                MessageBox.Show("No workers are available to do this job \""
                    + workerBeeJob.Text + "\".", "The Queen Bee says...");
            else
                MessageBox.Show("The job \"" + workerBeeJob.Text + "\" will be done in "
                    + shifts.Value + " shifts.", "The Queen Bee says...");
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}
