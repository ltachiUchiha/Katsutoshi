using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Katsutoshi.Modules
{
    internal class KatsuLogger
    {
        private bool _debugConsole;

        public KatsuLogger() 
        {
            _debugConsole = (bool)App.Current.Properties["debugMode"];

            if(_debugConsole)
            {
                AllocConsole();
            }
        }

        public void Log(LogCode logCode, string message)
        {
            if (_debugConsole)
                LogConsole(logCode, message);
        }

        private void LogConsole(LogCode logCode, string message)
        {
            Console.WriteLine($"{LogType(logCode)} {message}");
        }
        private string LogType(LogCode logCode)
        {
            switch (logCode)
            {
                case LogCode.Info:
                    return "Info:";
                case LogCode.Warn:
                    return "Warn:";
                case LogCode.Error:
                    return "Error:";
                case LogCode.Fatal:
                    return "Fatal:";
            }
            return "Fatal:";
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FreeConsole();
    }

    enum LogCode
    { 
        Info = 0,
        Warn = 1,
        Error = 2,
        Fatal = 3
    }
}
