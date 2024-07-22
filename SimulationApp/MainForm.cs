using System;
using System.Windows.Forms;

namespace SimulationApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRunSimulation_Click(object sender, EventArgs e)
        {
            double parameter = 42.0; // Example parameter
            Program.RunSimulation(parameter);
            double result = Program.GetSimulationResult();
            MessageBox.Show($"Simulation result: {result}");
        }
    }
}
