using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SimulationApp
{
    static class Program
    {
        // Import the InitializeSimulation function from the DLL
        [DllImport("SimulationEngine.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InitializeSimulation(string coordsFile, string timeFile, string tFile, string mfFile);

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
                Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);
                SetDllDirectory(dllDirectory);
            }
            else
            {
                throw new Exception($"{dllName} not found in the solution directory.");
            }

            IntPtr pDll = LoadLibrary(@dllName);
            if (pDll == IntPtr.Zero)
            {
                throw new Exception("Unable to load DLL");
            }

            // Initialize the simulation with the HDF5 files
            string coordsFile = @"path\to\coords.h5";
            string timeFile = @"path\to\time.h5";
            string tFile = @"path\to\T.h5";
            string mfFile = @"path\to\MF.h5";
            InitializeSimulation(coordsFile, timeFile, tFile, mfFile);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
