using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeepAwake
{
    class Program
    {
        public static uint fPreviousExecutionState;
        public static IntPtr handle = Process.GetCurrentProcess().Handle; 
        static void Main(string[] args)
        {
            do
            {
                uint currentExecutionState = exeState();
                Thread.Sleep(120000);
                if (currentExecutionState == 0)
                {
                    Console.WriteLine("SetThreadExecutionState failed. Do something here...");

                }
            }
            while (1 == 1);
               
        }

   
    public static uint exeState()
    {
        // Set new state to prevent system sleep
        fPreviousExecutionState = NativeMethods.SetThreadExecutionState(
            NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
     

            return fPreviousExecutionState;

    }

    }

    internal static class NativeMethods
        {
            // Import SetThreadExecutionState Win32 API and necessary flags
            [DllImport("kernel32.dll")]
            public static extern uint SetThreadExecutionState(uint esFlags);
            public const uint ES_CONTINUOUS = 0x80000000;
            public const uint ES_SYSTEM_REQUIRED = 0x00000001;
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetConsoleWindow();
        

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr handle, int SW_HIDE);

    }
}
   

