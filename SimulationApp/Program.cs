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

        [STAThread]
        static void Main()
        {
            // Set the directory where the DLL is located
            SetDllDirectory(@"C:\git\CAMic3D\SimulationEngine\x64\Debug\");

            // Load the DLL
            IntPtr pDll = LoadLibrary(@"SimulationEngine.dll");
            if (pDll == IntPtr.Zero)
            {
                Console.WriteLine("Unable to load DLL");
            }
            else
            {
                Console.WriteLine("DLL Loaded Successfully");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr LoadLibrary(string lpFileName);
    }
}
