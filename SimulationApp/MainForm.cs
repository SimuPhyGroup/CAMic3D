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
            // Get parameter from user input
            double parameter;
            if (!double.TryParse(txtParameter.Text, out parameter))
            {
                MessageBox.Show("Invalid parameter");
                return;
            }
            
            Program.RunSimulation(parameter);
            double result = Program.GetSimulationResult();
            MessageBox.Show($"Simulation result: {result}");
        }
    }
}
