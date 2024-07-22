using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimulationApp
{
    static class Program
    {
        // Import the RunSimulation function from the DLL
        [DllImport("SimulationEngine.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void RunSimulation(double parameter);

        // Import the GetSimulationResult function from the DLL
        [DllImport("SimulationEngine.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetSimulationResult();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetDllDirectory(string lpPathName);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);

        [STAThread]
        static void Main()
        {
            string solutionRoot = @"C:\git\CAMic3D"; // Set this to your solution's root directory
            string dllName = "SimulationEngine.dll";
            string dllDirectory = DllFinder.FindDll(solutionRoot, dllName);

            if (!string.IsNullOrEmpty(dllDirectory))
            {
                // Add the DLL directory to the PATH environment variable
                Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);

                // Set the directory where the DLL is located
                SetDllDirectory(dllDirectory);
            }
            else
            {
                throw new Exception($"{dllName} not found in the solution directory.");
            }
            
            // Load the DLL
            IntPtr pDll = LoadLibrary(@dllName);
            if (pDll == IntPtr.Zero)
            {
                throw new Exception("Unable to load DLL");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
