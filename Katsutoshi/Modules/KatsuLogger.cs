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
            SetConsoleColor(logCode);
            Console.Write($"{LogType(logCode)}");
            Console.ResetColor();
            Console.WriteLine($" {message}");
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
        private void SetConsoleColor(LogCode logCode)
        {
            switch (logCode)
            {
                case LogCode.Info:
                    Console.ForegroundColor = ConsoleColor.Green;
                    return;
                case LogCode.Warn:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return;
                case LogCode.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return;
                case LogCode.Fatal:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    return;
            }
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
